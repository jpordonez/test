using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework.Logging;
using Framework.Repository;
using Nucleo.Dominio;
using Nucleo.Dominio.DTO;
using Microsoft.Practices.ServiceLocation;
using Framework.Util;
using System.Linq;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Criteria;
using Framework;
using Negocio.Dominio.Constantes;

namespace Nucleo.Service
{
    public class PersonaService : IPersonaService
    {

        public IApplication _application;
        private static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(PersonaService));
        private readonly IRepository<Persona> _repositoryPersona;
        private readonly ICatalogoService _iCatalogoService;

        public PersonaService(IApplication application,
                              IRepository<Persona> repositoryPersona,
                              ICatalogoService iCatalogoService)
        {
            _application = application;
            _repositoryPersona = repositoryPersona;
            _iCatalogoService = iCatalogoService;
        }

        public Persona Get(int id)
        {
            return _repositoryPersona.Get(id);
        }

        public Persona Get(string identificacion)
        {
            return _repositoryPersona.GetQuery(p => p.Identificacion.Equals(identificacion)).FirstOrDefault();
        }

        public IPagedListMetaData<PersonaDTO> GetList(PersonaCriteria personaCriteria)
        {
            var _manejadorSP = ServiceLocator.Current.GetInstance<IStoreProcedureRepository<PersonaDTO>>();

            var parametros = new List<Object>();

            var nombres = new SqlParameter("@nombre", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(personaCriteria.Nombre) ? null : personaCriteria.Nombre
            };

            var apellidos = new SqlParameter("@apellido", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(personaCriteria.Apellido) ? null : personaCriteria.Apellido
            };

            var identificacion = new SqlParameter("@identificacion", SqlDbType.NVarChar)
            {
                Value = string.IsNullOrWhiteSpace(personaCriteria.Identificacion) ? null : personaCriteria.Identificacion
            };

            parametros.Add(nombres);
            parametros.Add(apellidos);
            parametros.Add(identificacion);

            var resultadoPaginado = _manejadorSP.SpConResultadosPaginado("pro_obt_personas", parametros, personaCriteria.NumeroPagina);

            return resultadoPaginado;
        }

        public Persona Guardar(Persona persona)
        {
            return _repositoryPersona.SaveOrUpdate(persona);
        }

        public void Eliminar(int id)
        {
            Persona entidad = Get(id);
            _repositoryPersona.Delete(entidad);
        }

        public bool ValidarIdentificacion(int? personaId, int tipoIdentificacion, string identificacion, out string mensaje)
        {
            //Creacion de Persona
            var existeIdentificacion = _repositoryPersona.GetQuery(p => p.Identificacion.Equals(identificacion)
                                                                    && (!personaId.HasValue || personaId != p.Id)).Any();
            if (existeIdentificacion)
            {
                mensaje = "Ya existe una persona registrada con la identificación: " + identificacion;
                return false;
            }
            var tipoDocumento = _iCatalogoService.GetItem(tipoIdentificacion);
            switch (tipoDocumento.Codigo)
            {
                case ConstantesCatalogos.ITM_TIPO_DOC_CED:
                    var esValida = Identificacion.CedulaEsValida(identificacion);
                    if (!esValida)
                    {
                        mensaje = "La identificación " + identificacion + " de tipo Cédula no es Valida.";
                        return false;
                    }
                    break;
                case ConstantesCatalogos.ITM_TIPO_DOC_RUC:
                    esValida = Identificacion.RucEsValido(identificacion);
                    if (!esValida)
                    {
                        mensaje = "La identificación " + identificacion + " de tipo Ruc no es Valida.";
                        return false;
                    }
                    break;
                case ConstantesCatalogos.ITM_TIPO_DOC_PAS:
                    esValida = Identificacion.PasaporteEsValido(identificacion);
                    if (!esValida)
                    {
                        mensaje = "La identificación " + identificacion + " de tipo Pasaporte no es Valida.";
                        return false;
                    }
                    break;
            }
            mensaje = null;
            return true;
        }

        public bool ValidarExistenciaCorreo(int? personaId, string correo)
        {
            var existeRegistroCorreo = _repositoryPersona.GetQuery(p => p.Correo != null
                                        && p.Correo.Equals(correo)
                                        && (!personaId.HasValue || personaId != p.Id)).Any();
            return !existeRegistroCorreo;
        }

    }
}
