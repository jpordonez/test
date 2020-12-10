using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Proceso
{
    public class Constantes
    {

        public const int PROCESO_EXITO = 0;
        public const int PROCESO_ERROR = 1;


        /// <summary>
        /// Instalar el sistema
        /// </summary>
        public const string Instalar = "INSTALL";

        /// <summary>
        /// Limpiar Cache del Sistema
        /// </summary>
        public const string LimpiarCacheSistema = "CLEAR_CACHE";

        /// <summary>
        /// Actualiza el estado de las promociones en el tiempo
        /// </summary>
        public const string PromocionesEstados = "PROPROMOEST";
               
        
    }
}