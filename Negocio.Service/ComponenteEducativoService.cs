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
    public class ComponenteEducativoService : IComponenteEducativoService
    {

        private readonly IApplication _application;
        private static readonly ILogger log =
            ServiceLocator.Current.GetInstance<ILoggerFactory>().Create(typeof(ComponenteEducativoService));
        private readonly IRepository<ComponenteEducativo> _repositoryComponenteEducativo;
        private readonly DbContext _context;

        public ComponenteEducativoService(IApplication application,
            DbContext context)
        {
            _application = application;
            _context = context;
            _repositoryComponenteEducativo = new EntityFrameworkRepository<ComponenteEducativo>(context);
        }

        public ComponenteEducativo Get(int id)
        {
            return _repositoryComponenteEducativo.Get(id);
        }

        public IList<ComponenteEducativo> GetList()
        {            			
            var resultado = _repositoryComponenteEducativo.GetList();

            return resultado.ToList();			
        }

        public ComponenteEducativo Guardar(ComponenteEducativo entidad)
        {
            return _repositoryComponenteEducativo.SaveOrUpdate(entidad);
        }

        public void Eliminar(int id)
        {
            var entidad = Get(id);
            _repositoryComponenteEducativo.Delete(entidad);
        }

    }
}