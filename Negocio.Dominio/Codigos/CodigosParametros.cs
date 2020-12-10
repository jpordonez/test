namespace Negocio.Dominio.Codigos
{
    public static class CodigosParametros
    {
        public const string PARAMETRO_NOMBRE_ORGANIZACION = "N_ORGANIZACION";
        public const string PARAMETRO_RECUPERA_CONTRA = "RECUPERA_CONTRA";
        public const string PARAMETRO_CAMBIA_CONTRA = "CAMBIA_CONTRA";

        public const string PARAMETRO_RECUP_CLASES = "RECUP_CLASES";
        

        #region <Gestion de Usuarios, Roles>

         
         public const string PARAMETRO_SEGURIDAD_UTILIZAR_ROLES_EXTERNOS = "U_ROL_EXTERNOS";
         public const string PARAMETRO_SEGURIDAD_SINCRONIZAR_USUARIOS_EXTERNOS = "U_SYNC_USER";
         public const string PARAMETRO_AYUDA_ADMINISTRADOR = "AYUDA_ADMIN";
         public const string PARAMETRO_AYUDA_DOCENTE = "AYUDA_DOCENT";
         public const string PARAMETRO_AYUDA_ESTUDIANTE = "AYUDA_ESTU";
         public const string PARAMETRO_AYUDA_SECRETARIOACADEMICO = "AYUDA_SECREACA";


        #endregion


        public const string PARAMETRO_TIEMPO_IDEAL_REGISTRO = "TIEMPO_IDEAL";
        public const string PARAMETRO_TIEMPO_MAXIMO_REGISTRO = "TIEMPO_MAXIMO";
        public const string PARAMETRO_TIEMPO_ANTES_REGISTRO = "TIEMPO_REGISTRO";

        #region <Gestion Interfaz del usuario>

        public const string PARAMETRO_PLANTILLA_SITIO = "N_THEME";

        public const string PARAMETRO_TAMAÑO_PAGINA_GRILLAS = "UI.PAGE_SIZE";

        #endregion

        #region Diario Tematico

        public const string PARAMETRO_MAX_TIME_DIARIO = "MAX_TIME_DIARIO";
        public const string PARAMETRO_MIN_WORDS_DIARIO = "MIN_CHAR_DIARIO";

        #endregion

        #region <PARAMETROS PARA FINALIZAR CLASE DOCENTE > 

        public const string PARAMETRO_TIEMPO_MINIMO_FINALIZAR_CLASE = "TIE_PRE_FIN_CLA";
        public const string PARAMETRO_TIEMPO_MAXIMO_FINALIZAR_CLASE = "TIE_POS_FIN_CLA";
      

         #endregion

        public const string PARAMETRO_PORCENTAJE_DE_FALTAS_PARA_REPROBAR = "MIN_PORC_FALTAS";
        public const string PARAMETRO_PERIODO_ACTUAL = "PERIODO_ACTUAL";



        #region Calculo de Notas (Gradebook)

        public const string PERIODO_GBOOK = "PERIODO_GBOOK";
        public const string COMP_GBOOK = "COMP_GBOOK";
        public const string NOTA_GRADBOOK = "NOTA_GRADBOOK";
        public const string MIG_GRADBOOK = "MIG_GRADBOOK";
        public const string TIP_GRADBOOK = "TIP_GRADBOOK";

        #endregion


        #region Consola Orquestacion
        public const string PARAMETRO_TIEMPO_ANTES_EJECUCION_ETL = "TIEMP_ANT_ETL";
        public const string PARAMETRO_SINCRONIZACION_MHO_ORQUESTADOR = "SINCRONIZA_MHO";

        #endregion

        #region Planes
        public const string PARAMETRO_FARMACIA_PLANES = "PARPLANES";
        
        #region Opcion Plan
        public const string OPCION_FARMACIA_PLAN1 = "PLAN1";
        public const string OPCION_FARMACIA_PLAN2 = "PLAN2";
        public const string OPCION_FARMACIA_PLAN3 = "PLAN3";
        public const string OPCION_FARMACIA_PLAN4 = "PLAN4";
        #endregion

        #endregion

        #region Periodos Academicos
        public const string PARAMETRO_PERIODOS_ACADEMICOS = "PARPERACA";
        #endregion

        #region Programas Academicos
        public const string PARAMETRO_PROGRAMAS_ACADEMICOS = "PARPROACA";
        #endregion

        #region Centros
        public const string PARAMETRO_CENTROS = "PARCENTROS";
        #endregion

        #region Modulos
        public const string PARAMETRO_MODULOS = "PARMODULOS";
        #endregion

    }
}