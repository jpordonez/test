using System.Collections.Generic;
using Framework.MVC;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Presentacion.Models
{

    public class AuditoriaViewModel : IViewModel
    {

        /// <summary>
        /// Metatados para la paginacion
        /// </summary>
        public PagedListMetaDataModel Metadatos { get; set; }

        /// <summary>
        /// Listado 
        /// </summary>
        public IList<Auditoria> Auditorias { get; set; }
 

        /// <summary>
        /// Criteria para buscar
        /// </summary>
        public AuditoriaCriteria Criteria { get; set; }


        

    }
}
