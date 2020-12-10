using Framework.EntityFramewok;
using Framework.Logging;
using Framework.Repository;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using System.Data.Entity;
using Negocio.Dominio.Models;
using System;
using Nucleo.Dominio.DTO;
using Negocio.Dominio.Criteria;
using System.Linq;
using Framework;
using Negocio.Dominio.Codigos;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Negocio.Service
{
    public class AsignacionDocenteService : IAsignacionDocenteService
    {

        private readonly IApplication _application;
        private static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(AsignacionDocenteService));
        private readonly IRepository<AsignacionDocente> _repositoryAsignacionDocente;
        private readonly DbContext _context;

        public AsignacionDocenteService(IApplication application,
            DbContext context)
        {
            _application = application;
            _context = context;
            _repositoryAsignacionDocente = new EntityFrameworkRepository<AsignacionDocente>(context);
        }

        public AsignacionDocente Get(int id)
        {
            return _repositoryAsignacionDocente.Get(id);
        }

        public IList<AsignacionDocente> GetList(AsignacionDocenteCriteria criteria)
        {
            //Criteria
            Expression<Func<AsignacionDocente, bool>> condiciones =
                p => (criteria.DocenteId == null || criteria.DocenteId == p.DocenteId);

            var resultado = _repositoryAsignacionDocente.GetList(condiciones);

            return resultado.ToList();			
        }

        public AsignacionDocente Guardar(AsignacionDocente entidad)
        {
            return _repositoryAsignacionDocente.SaveOrUpdate(entidad);
        }

        public void Eliminar(int id)
        {
            var entidad = Get(id);
            _repositoryAsignacionDocente.Delete(entidad);
        }

    }
}