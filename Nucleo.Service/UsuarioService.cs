using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework.Repository;
using Framework.Security;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.DTO;
using Nucleo.Dominio.Seguridad;
using Nucleo.Dominio.Entidades;
using Framework;

namespace Nucleo.Service
{
    /// <summary>
    /// Servicio para la gestion de Usuarios 
    /// </summary>
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository<Usuario> _repositoryUsuario;
        private IRepository<Permiso> _repositoryPermiso;
        private IRepository<Rol> _repositoryRol;
        private IRepository<Persona> _repositoryPersona;
        private IApplication _application;

        public UsuarioService(IApplication application,
            IUsuarioRepository<Usuario> repositoryUsuario,
            IRepository<Permiso> repositoryPermiso,
            IRepository<Rol> repositoryRol,
            IRepository<Persona> repositoryPersona)
        {
            _application = application;
            _repositoryUsuario = repositoryUsuario;
            _repositoryPermiso = repositoryPermiso;
            _repositoryRol = repositoryRol;
            _repositoryPersona = repositoryPersona;
        }


        public Usuario Get(int id)
        {
            var usuario = _repositoryUsuario.Get(id);
            if (usuario.PersonaId.HasValue)
            {
                var persona = _repositoryPersona.Get((int)usuario.PersonaId);
                usuario.Nombres = persona.PrimerNombre + " " + persona.SegundoNombre;
                usuario.Apellidos = persona.PrimerApellido + " " + persona.SegundoApellido;
                usuario.Identificacion = persona.Identificacion;
                usuario.Correo = persona.Correo;
            }
            return usuario;
        }

        public Permiso GetPermiso(int id)
        {
            return _repositoryPermiso.Get(id);
        }

        public IPagedListMetaData<UsuarioDTO> GetList(UsuarioCriteria criteria)
        {
            var _manejadorSP = ServiceLocator.Current.GetInstance<IStoreProcedureRepository<UsuarioDTO>>();

            var parametros = new List<Object>();

            var identificacion = new SqlParameter("@identificacion", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(criteria.Identificacion) ? null : criteria.Identificacion
            };

            var apellidos = new SqlParameter("@cuenta", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(criteria.Cuenta) ? null : criteria.Cuenta
            };

            var rol = new SqlParameter("@en_rol_id", SqlDbType.Int)
            {
                Value = criteria.RolId
            };

            parametros.Add(apellidos);
            parametros.Add(identificacion);
            parametros.Add(rol);

            var resultadoPaginado = _manejadorSP.SpConResultadosPaginado("pro_obt_usuarios", parametros, criteria.NumeroPagina);

            return resultadoPaginado;
        }

        public Usuario Guardar(Usuario persona)
        {
            return _repositoryUsuario.SaveOrUpdate(persona);
        }

        public void Eliminar(int id)
        {
            Usuario entidad = Get(id);
            _repositoryUsuario.Delete(entidad);
        }

        public void EliminarPermiso(int id)
        {
            Permiso entidad = _repositoryPermiso.Get(id);
            _repositoryPermiso.Delete(entidad);
        }

        public IList GetEstadosUsuario()
        {
            var estadoActivo = new { value = Estado.Activo, label = "Activo" };
            var estadoInactivo = new { value = Estado.Inactivo, label = "Inactivo" };

            var estados = new[] { estadoActivo, estadoInactivo };
            return estados;
        }

        public IEnumerable<Rol> GetRolesSistema()
        {
            return _repositoryRol.GetList();
        }

        public bool ExisteUsuario(string cuenta)
        {
            return _repositoryUsuario.ExisteUsuario(cuenta);
        }
    }
}
