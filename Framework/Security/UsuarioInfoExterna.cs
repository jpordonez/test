using System.Collections.Generic;

namespace Framework.Security 
{
    /// <summary>
    /// Información Externa de un usuario
    /// </summary>
    public class ExternalInfoUser
    {
        /// <summary>
        /// Listado de Roles que posee el usuario 
        /// </summary>
        public List<string> RolesAD { get; set; }

        public string AperllidoPaterno { get; set; }

        public string Nombres { get; set; }

        /// <summary>
        /// Identificacion
        /// </summary>
        public string Identificacion { get; set; }


        public string Correo { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string UserName { get; set; }

        public ExternalInfoUser() {
            RolesAD = new List<string>();
        }
        

        //public string UserPrincipalName { get; set; }

        //public int BannerId { get; set; }
        
        //public int MatriculaId { get; set; }
        

    
        
        //public string StatusEstudiante { get; set; }
        
        //public string StatusProfesor { get; set; }
    }
}
