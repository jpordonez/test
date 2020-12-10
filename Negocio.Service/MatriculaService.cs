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
    public class MatriculaService : IMatriculaService
    {

        private readonly IApplication _application;
        private static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(MatriculaService));
        private readonly IRepository<Matricula> _repositoryMatricula;
        private readonly DbContext _context;

        public MatriculaService(IApplication application,
            DbContext context)
        {
            _application = application;
            _context = context;
            _repositoryMatricula = new EntityFrameworkRepository<Matricula>(context);
        }

        public Matricula Get(int id)
        {
            return _repositoryMatricula.Get(id);
        }

        public IList<Matricula> GetList(MatriculaCriteria criteria)
        {
            //Criteria
            Expression<Func<Matricula, bool>> condiciones =
                p => (criteria.EstudianteId == null || criteria.EstudianteId == p.EstudianteId);

            var resultado = _repositoryMatricula.GetList(condiciones);

            return resultado.ToList();			
        }

        public Matricula Guardar(Matricula entidad)
        {
            return _repositoryMatricula.SaveOrUpdate(entidad);
        }

        public void Eliminar(int id)
        {
            var entidad = Get(id);
            _repositoryMatricula.Delete(entidad);
        }

    }
}