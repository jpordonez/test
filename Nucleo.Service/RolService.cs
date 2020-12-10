using System.Collections.Generic;
using System.Linq;
using Framework.Cache;
using Framework.Exception;
using Framework.Repository;
using Nucleo.Dominio;
using Nucleo.Dominio.Seguridad;
using System;
using Negocio.Dominio.Constantes;

namespace Nucleo.Service
{
    public class RolService : IRolService
    {
        IRepository<Rol> _repository;
        ICacheManager _cacheManager;
        IApplication _application;
        IRepository<Permiso> _repositoryPermiso;

        public RolService(IApplication application, IRepository<Rol> repository, IRepository<Permiso> repositoryPermiso, ICacheManager cacheManager)
        {
            _application = application;
            _repository = repository;
            _repositoryPermiso = repositoryPermiso;
            _cacheManager = cacheManager;
        }


        public IEnumerable<Rol> GetList()
        {
            var lista = GetListRoles();

            return lista;
        }

        public Rol Get(int id)
        {
            //TODO: No utilizar cache, ya que si este rol se utiliza para modificar, se cambia el objeto del cache tambien
            return _repository.Get(id);
        }

        /// <summary>
        /// Obtener Rol
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Rol Get(string codigo)
        {
            var rol = _repository.GetQuery(r => r.Codigo.Equals(codigo)).FirstOrDefault();
            if (rol == null)
            {
                throw new Exception("No existe un rol con codigo: " + codigo);
            }
            return rol;
        }


        public Rol SaveOrUpdate(Rol rol)
        {

            var rolActualizado = _repository.SaveOrUpdate(rol);

            //En el caso que se cambien alguna propiedad  del rol : "Es Administrador" que afecte a la seguridad. Y se trate del mismo rol actualmente 
            //autentificado, volver a establecer 
            if (_application.GetCurrentRol().Equals(rol))
            {
                _application.SetCurrentRol(rolActualizado);
            }


            //Reset cache
            ResetCache(rol.Codigo);

            return rolActualizado;

        }

        public void Eliminar(int id)
        {

            Rol entidad = Get(id);

            if (entidad == null)
            {
                string error = string.Format("No existe el rol con el identificador {0}", id);
                throw new GenericException(error, error);
            }

            _repository.Delete(entidad);

            //Reset cache
            ResetCache(entidad.Codigo);
        }

        public void EliminarPermisos(IList<Permiso> listEntity)
        {
            _repositoryPermiso.Delete(listEntity);

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_ROLES_SISTEMA);

        }


        /// <summary>
        /// Actualiza los permisos de un rol. Crear Permisos, o eliminar permisos, segun el listado de identificadores de acciones enviados
        /// </summary>
        /// <param name="rol">Rol</param>
        /// <param name="listAccionId">Lista de acciones de funcionalidades que debe posee</param>
        /// <returns></returns>
        public Rol UpdatePermissions(Rol rol, int[] listAccionId)
        {

            Rol rolUpdate = null;

            if (listAccionId != null) //&& idRol != 0)
            {
                //Delete
                List<int> permisosIdRol = (from i in rol.Permisos
                                           select i.AccionId).ToList();

                var eliminar = permisosIdRol.Except(listAccionId);

                //TODO: JSA, mejorar ahora se esta eliminando uno por uno las entidades.
                //Delete
                List<Permiso> permisosEliminar = new List<Permiso>();
                foreach (var item in eliminar)
                {
                    var permisoEliminar = rol.Permisos.Where(p => p.AccionId == item).FirstOrDefault();
                    //rol.Permisos.Remove(permisoEliminar);
                    //_repositoryPermiso.Delete(permisoEliminar);
                    permisosEliminar.Add(permisoEliminar);
                }


                if (permisosEliminar.Count() > 0)
                {

                    _repositoryPermiso.Delete(permisosEliminar);
                }


                foreach (var accion in listAccionId)
                {
                    var permiso = new Permiso();
                    permiso.RolId = rol.Id;
                    permiso.AccionId = accion;


                    //Add
                    if (!rol.Permisos.Where(c => c.AccionId == permiso.AccionId).Any())
                    {
                        rol.Permisos.Add(permiso);
                    }

                }

                rolUpdate = _repository.SaveOrUpdate(rol);

            }
            else
            {
                //TODO: JSA, mejorar ahora se esta eliminando uno por uno las entidades.
                //Eliminar todos los permisos del Rol

                _repositoryPermiso.Delete(rol.Permisos.ToList());

                rolUpdate = _repository.Get(rol.Id);
            }


            //Reset cache
            ResetCache(rol.Codigo);

            return rolUpdate;

        }

        private IEnumerable<Rol> GetListRoles()
        {
            //Cache
            var roles = _cacheManager.GetData(ConstantesCache.CACHE_ROLES_SISTEMA) as IEnumerable<Rol>;
            if (roles == null)
            {
                //1. Recuperar todos los parametros
                var sistema = _application.GetCurrentSistema();
                roles = _repository.GetListIncluding(include => include.Permisos);

                _cacheManager.Add(ConstantesCache.CACHE_ROLES_SISTEMA, roles);
            }

            return roles;
        }

        private void ResetCache(string codigoRol)
        {

            //Reset cache
            _cacheManager.Remove(ConstantesCache.CACHE_ROLES_SISTEMA);

            //TODO: JSA. MEJORAR RESET Cache del Menu. ??, YA QUE TIENE UNA CLAVE POR MENU Y ROL
            var codigoCacheMenu = "Web.Cache.Menu." + ConstantesMenus.MENU_PRINCIPAL + "." + codigoRol;
            _cacheManager.Remove(codigoCacheMenu);

            //TODO: JSA, que pasa si existen varios menus (Sitio docente, sitio del estudiante)

        }
    }
}
