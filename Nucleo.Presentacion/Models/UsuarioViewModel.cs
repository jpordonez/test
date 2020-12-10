using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.MVC;
using Framework.Security;
using Negocio.Dominio.Criteria;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Seguridad;
using Nucleo.Presentacion.Helpers;
using Nucleo.Presentacion.Validators;

namespace Nucleo.Presentacion.Models
{
    public class UsuarioViewModel
    {
        /// <summary>
        /// Metadados para la paginacion
        /// </summary>
        public PagedListMetaDataModel Metadatos { get; set; }

        /// <summary>
        /// Listado 
        /// </summary>
        public IList<IUsuario> Usuarios { get; set; }
        
        /// <summary>
        /// Criteria para buscar
        /// </summary>
        public UsuarioCriteria Criteria { get; set; }
        

        public MensajeHelper Mensaje { get; set; }
    }

    public class EnrolamientoUsuarioViewModel
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Listado 
        /// </summary>
        [Obligado]
        [Display(Name = "Roles")]
        public int[] Roles { get; set; }

        public string RolesNombre { get; set; }

        /// <summary>
        /// Mensaje
        /// </summary>
        public MensajeHelper Mensaje { get; set; }

        public UsuarioCriteria Criteria { get; set; }

    }

}
