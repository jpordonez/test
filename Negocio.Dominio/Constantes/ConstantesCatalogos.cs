namespace Negocio.Dominio.Constantes
{
    /// <summary>
    /// Constantes de Catalogos del Sistema
    /// </summary>
    public static class ConstantesCatalogos
    {
        public const string CATALOGO_FOO = "FOO";
        public const string CAT_ALERT_ADOC = "CAT_ALERT_ADOC";
        public const string CAT_AGENDA_VIGENCIA = "CAT_AGEN_ESTADO";
        public const string CAT_RANGOS_PALABRAS = "CATRANGOSPAL";
        public const string CAT_TIPO_ACTIVIDAD = "CAT_TIP_ACTIVID";

        public const string CAT_DIAS_SEMANA = "DIASSEMANA";



        #region Codigos Items de Catalogo
        public const string ALERT_TIEMPO = "ALERT_TIEMPO";
        public const string ALERT_ID_MAX = "ALERT_ID_MAX";
        public const string ITM_AGENDA_VIGENCIA_ACTIVA = "ACTIVO";
        public const string ITM_NO_REGISTRA_CARACTERES = "INOREGISTRACAR";
        public const string ITM_REGISTRA_CARACTERES = "IREGISTRACAR";

        #region Codigos Items Formas de Pago
        public const string FORMA_PAGO_TARJETA = "TARJETA";
        public const string FORMA_PAGO_DEPOSITO_TRANSFERENCIA = "DEPOSTRANSF";
        #endregion

        #endregion


        #region Codigos  Estados Ejecucion Procesos
        //Catalogo
        public const string CAT_EST_PROCESO = "CAT_EST_PROCESO";
        // Items
        public const string FINALIZADO = "FINALIZADO";
        public const string ACTIVO = "ACTIVO";
        public const string PENDIENTE = "PENDIENTE";
        #endregion

        #region Codigos Items TipoDocumento

        public const string ITM_TIPO_DOC_CED = "TIPOCEDULA";
        public const string ITM_TIPO_DOC_RUC = "TIPORUC";
        public const string ITM_TIPO_DOC_PAS = "TIPOPASAPORT";

        #endregion

        #region Codigos  Tipo de Calculo
        //Catalogo
        public const string CAT_TIP_CALCULO = "CAT_TPO_CALCULO";
        // Items
        public const string NORMAL = "GNORMAL";
        public const string REPROCESO = "GREPROCESO";

        #endregion

        #region Predio

        #region Ubicacion Predial

        public const string DIVICION_POLITICA = "DIVPOLITICA";

        #endregion

        #region Datos Propietario

        public const string CAT_DAT_PRO_REG_TEN = "DATPROREGTEN";

        #endregion

        #region Identificacion Predial

        public const string CAT_IDE_PRE_ORIENT = "IDEPREORIENT";
        public const string ITM_IDE_PRE_ORIENT_NOR = "IDEPREORIENT1";
        public const string ITM_IDE_PRE_ORIENT_SUR = "IDEPREORIENT2";
        public const string ITM_IDE_PRE_ORIENT_EST = "IDEPREORIENT3";
        public const string ITM_IDE_PRE_ORIENT_OES = "IDEPREORIENT4";

        #endregion

        #region Tenencia

        public const string CAT_TENENCIA_DOMINIO = "TENENCIADOM";
        public const string CAT_TENENCIA_FORMAS_PROPIEDAD = "TENENFORPRO";
        public const string CAT_TENENCIA_FORMAS_ADQUISICION = "TENENFORADQ";
        public const string CAT_TENENCIA_TRASLACION_DOMINIO = "TENENTRADOM";

        #endregion

        #region Descripcion del Terreno

        public const string CAT_DES_TER_CAR_SUE = "DESTERCARSUE";
        public const string CAT_DES_TER_TIP_SUE = "DESTERTIPSUE";
        public const string CAT_DES_TER_OCUPAC = "DESTEROCUPAC";
        public const string CAT_DES_TER_UBI_LOT = "DESTERUBILOT";
        public const string CAT_DES_TER_FORMA = "DESTERFORMA";
        public const string CAT_DES_TER_ZON_RIE = "DESTERZONRIE";
        public const string CAT_DES_TER_TOPOGR = "DESTERTOPOGR";

        //Version 2
        public const string CAT_DES_TER_CAR_SUE_V2 = "DESTERCASUV2";
        public const string CAT_DES_TER_ZON_RIE_V2 = "DESTERZORIV2";
        public const string CAT_DES_TER_TOPOGR_V2 = "DESTERTOPV2";
        public const string ITM_DES_TER_TOPOGR_BAJO_NIVEL_VIA = "DESTERTOPV21";
        public const string ITM_DES_TER_TOPOGR_SOBRE_NIVEL_VIA = "DESTERTOPV22";

        #endregion

        #region Infraestructura y Terrenos

        public const string CAT_INF_SER_USO_VIA = "INFSERUSOVIA";
        public const string CAT_INF_SER_CLA_VIA = "INFSERCLAVIA";
        public const string CAT_INF_SER_MATERI = "INFSERMATERI";
        public const string CAT_INF_SER_ENE_ELE = "INFSERENEELE";
        public const string CAT_INF_SER_ABA_AGU = "INFSERABAAGU";
        public const string CAT_INF_SER_ZON_RIE = "INFSERALCANT";
        public const string CAT_INF_SER_COMPLE = "INFSERCOMPLE";
        public const string CAT_INF_SER_SER_MUN = "INFSERSERMUN";

        //Version 2
        public const string CAT_INF_SER_USO_VIA_V2 = "INFSERUSVIV2";
        public const string CAT_INF_SER_ENE_ELE_V2 = "INFSERENELV2";
        public const string CAT_INF_SER_ABA_AGU_V2 = "INFSERABAGV2";
        public const string CAT_INF_SER_ZON_RIE_V2 = "INFSERALANV2";
        public const string CAT_INF_SER_COMPLE_V2 = "INFSERCOPLV2";

        #endregion

        #region Uso del Suelo y Uso Constructivo

        public const string CAT_USU_UCON_USO_CON = "USUUCONUSOCON";
        public const string CAT_USU_UCON_USO_SUE = "USUUCONUSOSUE";
        public const string CAT_USU_UCON_CON_OCU = "USUUCONCONOCU";

        //Versión 2
        public const string CAT_USU_UCON_USO_CON_V2 = "USUUCONUSCOV2";

        #endregion

        #region Caracteristicas Edificación

        public const string CAT_CAR_EDI_ETA_CON = "CAREDIETACON";
        public const string CAT_CAR_EDI_CMB_EST = "CAREDICMBEST";
        public const string CAT_CAR_EDI_CMB_PAR = "CAREDICMBPAR";
        public const string CAT_CAR_EDI_CMB_CUE = "CAREDICMBCUE";
        public const string CAT_CAR_EDI_CMA_RPE = "CAREDICMARPE";
        public const string CAT_CAR_EDI_CMA_RPI = "CAREDICMARPI";
        public const string CAT_CAR_EDI_CMA_VEN = "CAREDICMAVEN";
        public const string CAT_CAR_EDI_CMA_PUE = "CAREDICMAPUE";
        public const string CAT_CAR_EDI_CMA_PIS = "CAREDICMAPIS";
        public const string CAT_CAR_EDI_CMA_TUM = "CAREDICMATUM";
        public const string CAT_CAR_EDI_COM_EQI = "CAREDICOMEQI";
        public const string CAT_CAR_EDI_COM_GES = "CAREDICOMGES";

        public const string ITM_CAR_EDI_ETA_CON_SOL_EST = "CAREDIETACON1";
        public const string ITM_CAR_EDI_ETA_CON_MANPOS = "CAREDIETACON2";
        public const string ITM_CAR_EDI_ETA_CON_TERMIN = "CAREDIETACON3";

        public const string ITM_CAR_EDI_CMB_EST_MAL = "CAREDICMBEST1";
        public const string ITM_CAR_EDI_CMB_EST_REG = "CAREDICMBEST2";
        public const string ITM_CAR_EDI_CMB_EST_BUE = "CAREDICMBEST3";
        public const string ITM_CAR_EDI_CMB_EST_MBU = "CAREDICMBEST4";

        //Version 2
        public const string CAT_CAR_EDI_TIP_EST = "CAREDITIPEST";
        public const string CAT_CAR_EDI_MAT_EST = "CAREDIMATEST";
        public const string CAT_CAR_EDI_ETA_CON_V2 = "CAREDIETCOV2";
        public const string CAT_CAR_EDI_EST_CON = "CAREDIESTCON";
        public const string CAT_CAR_EDI_MAMPOS = "CAREDIMAMPOS";
        public const string CAT_CAR_EDI_CUB_ENT = "CAREDICUBENT";
        public const string CAT_CAR_EDI_REV_PAR = "CAREDIREVPAR";
        public const string CAT_CAR_EDI_VENTANAS = "CAREDIVENTAN";
        public const string CAT_CAR_EDI_PUERTAS = "CAREDIPUERTA";
        public const string CAT_CAR_EDI_PISOS = "CAREDIPISOS";
        public const string CAT_CAR_EDI_TUMBADOS = "CAREDITUMBAD";
        public const string CAT_CAR_EDI_CLOSETS = "CAREDICLOSET";
        public const string CAT_CAR_EDI_INS_ELE = "CAREDIINSELE";
        public const string CAT_CAR_EDI_INS_SAN = "CAREDIINSSAN";

        #endregion

        #region Complementos Adicionales

        public const string CAT_COM_ADI_CER = "COMADICER";
        public const string CAT_COM_ADI_INF_ESP = "COMADIINFESP";
        public const string CAT_COM_ADI_EST = "COMADIEST";
        public const string CAT_COM_ADI_POS_CER = "COMADIPOSCER";

        public const string ITM_COM_ADI_INF_ESP_PLANTA_ELECTRICA = "COMADIINFESP4";
        public const string ITM_COM_ADI_INF_ESP_TORRE_TELECOMUNICACION = "COMADIINFESP6";

        #endregion

        #endregion

        #region Persona

        public const string CAT_TIPO_IDENTIFICACION = "TIPOIDENTIFICA";
        public const string CAT_ESTADO_CIVIL = "ESTADOCIVIL";
        public const string CAT_TIPO_PERSONA = "TIPOPERSONA";

        #region Codigos Items TipoPersona

        public const string ITM_TIPO_PER_REP_LEG = "TIPPERREPLEG";
        public const string ITM_TIPO_PER_PROPIETARIO = "TIPPERPRO";
        public const string ITM_TIPO_PER_CONYUGE = "TIPPERCOY";
        public const string ITM_TIPO_PER_JEFE_HOGAR = "TIPPERJHO";

        #endregion

        #endregion

        #region Institucion

        public const string INSCRITOS_EN = "INSINSCRIEN";

        #endregion

        //JOR: Se utiliza para manejar el estado de registros en todas las tablas
        //estos pueden ser Activos o Inactivos
        #region Estados Entidad

        public const string CAT_ESTADO_ENTIDAD = "ESTENTIDAD";

        #region Codigos Items Estado Entidad

        public const string ITM_ESTADO_ENTIDAD_ACTIVO = "ESTENTACTI";
        public const string ITM_ESTADO_ENTIDAD_INACTIVO = "ESTENTINAC";

        #endregion

        #endregion

        #region Estados Componente Educativo

        public const string CAT_ESTADO_COE = "ESTENTIDAD";

        #region Codigos Items Estado Componente Educativo

        public const string ITM_ESTADO_COE_APROBARDO = "ESTCOEAPR";
        public const string ITM_ESTADO_COE_REPROBADO = "ESTCOEREP";

        #endregion

        #endregion  

    }
}
