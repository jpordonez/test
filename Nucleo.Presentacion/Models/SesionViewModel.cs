using System.Collections.Generic;
using Framework.MVC;
using Framework.Security;
using Nucleo.Dominio;

namespace Nucleo.Presentacion.Models
{
    public class SesionViewModel : IViewModel
    {

         /// <summary>
        /// Metatados para la paginacion
        /// </summary>
        public PagedListMetaDataModel Metadatos { get; set; }

        /// <summary>
        /// Listado 
        /// </summary>
        public IList<Dominio.Seguridad.Sesion> Sesiones { get; set; }

        public EstadoSesion Estados { get; set; }


        /// <summary>
        /// Criteria para buscar
        /// </summary>
        public SesionCriteria Criteria { get; set; }

        public SesionViewModel()
        {
            Metadatos = new PagedListMetaDataModel();
            Sesiones = new List<Dominio.Seguridad.Sesion>();
            Criteria = new SesionCriteria();
        }

    }
}