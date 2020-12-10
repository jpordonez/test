using System.Collections.Generic;

namespace Nucleo.Presentacion.Constantes
{
    //public class ConstantesFuncionalidadesAuditoria
    //{
    //    //Las constantes para registro de auditoria debe tener Modulo\Funcionalidad
    //    //Esto permite configurar auditoria por modulo o funcionalidades especificas. 

    //    public const string FUNCIONALIDAD_GESTION_USUARIOS = @"Seguridad\Gestion Usuarios";
    //    public const string FUNCIONALIDAD_AGENDA_DOCENTE = @"Agenda\Agenda Docente";
    //    public const string FUNCIONALIDAD_DIARIO_TEMATICO = @"Agenda\Diario Tematico";
    //}

    public static class FUNCIONALIDADES_AUDITORIA {

        public static List<IFUNCIONALIDAD_GESTION_USUARIOS> Funcionalidades = new List<IFUNCIONALIDAD_GESTION_USUARIOS>();

        static FUNCIONALIDADES_AUDITORIA() {
            Funcionalidades.Add(new FUNCIONALIDAD_GESTION_USUARIOS());
            Funcionalidades.Add(new FUNCIONALIDAD_DIARIO_TEMATICO());
            Funcionalidades.Add(new FUNCIONALIDAD_AGENDA_DOCENTE());
        
        }
    }

    public  class FUNCIONALIDAD_GESTION_USUARIOS : IFUNCIONALIDAD_GESTION_USUARIOS
    {

         public const string Nombre =  @"Seguridad\Gestion Usuarios";

         private List<string> _Acciones = new List<string>();
         public List<string> Acciones
         {
             get { return _Acciones; }
             set { _Acciones = value;  } 
         }


         public const string ACCION_LOGIN = "Login";
         public const string ACCION_LOGOUT = "Logout";


         public  FUNCIONALIDAD_GESTION_USUARIOS()
         {
             Acciones.Add(ACCION_LOGIN);
             Acciones.Add(ACCION_LOGOUT);
        }

         public override string ToString()
         {
             return Nombre;
         }

    }

    public  class FUNCIONALIDAD_DIARIO_TEMATICO : IFUNCIONALIDAD_GESTION_USUARIOS
    {
        public const string Nombre = @"Agenda\Diario Tematico";

        private List<string> _Acciones = new List<string>();
        public List<string> Acciones
        {
            get { return _Acciones; }
            set { _Acciones = value; }
        }


       
        public const string ACCION_REGISTRAR_DIARIO_TEMATICO = "Registro Diario Tematico";
        public const string ACCION_EDITAR_DIARIO_TEMATICO = "Editar Diario Tematico";


        public  FUNCIONALIDAD_DIARIO_TEMATICO() {
          
            Acciones.Add(ACCION_REGISTRAR_DIARIO_TEMATICO);
            Acciones.Add(ACCION_EDITAR_DIARIO_TEMATICO);
        }

        public override string ToString()
        {
            return Nombre;
        }

    }

    public  class FUNCIONALIDAD_AGENDA_DOCENTE : IFUNCIONALIDAD_GESTION_USUARIOS
    {

        public const string Nombre = @"Agenda\Agenda Docente";

        private List<string> _Acciones = new List<string>();
        public List<string> Acciones
        {
            get { return _Acciones; }
            set { _Acciones = value; }
        }


        public const string ACCION_INICIAR_SESION = "Inicio Sesion";
        public const string ACCION_VISUALIZAR_AGENDA_DECENTE = "Visualizar Agenda Docente";
        public const string ACCION_REGISTRAR_ASISTENCIA_DOCENTES = "Registro Asistencia Docente";
        public const string ACCION_REGISTRAR_ASISTENCIA_ESTUDIANTES = "Registro Asistencia Estudiantes";
        public const string ACCION_FINALIZAR_SESION = "Finalizar Sesion";
        public const string ACCION_APERTURA_DIARIO_TEMATICO = "Apertura Diario Tematico";

 
        public  FUNCIONALIDAD_AGENDA_DOCENTE()
        {

            Acciones.Add(ACCION_INICIAR_SESION);
            Acciones.Add(ACCION_VISUALIZAR_AGENDA_DECENTE);
            Acciones.Add(ACCION_REGISTRAR_ASISTENCIA_DOCENTES);
            Acciones.Add(ACCION_REGISTRAR_ASISTENCIA_ESTUDIANTES);
            Acciones.Add(ACCION_FINALIZAR_SESION);

            Acciones.Add(ACCION_APERTURA_DIARIO_TEMATICO);


        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}