/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     27/4/2018 9:47:53                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TADM_CATALOGO') and o.name = 'FK_TCOL_CAT_REFERENCE_TCOL_SIS')
alter table TADM_CATALOGO
   drop constraint FK_TCOL_CAT_REFERENCE_TCOL_SIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TADM_INSTITUCION') and o.name = 'FK_TADM_INS_REFERENCE_TADM_PER')
alter table TADM_INSTITUCION
   drop constraint FK_TADM_INS_REFERENCE_TADM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TADM_ITEMCATALOGO') and o.name = 'FK_TCOL_ITE_REFERENCE_TCOL_CAT')
alter table TADM_ITEMCATALOGO
   drop constraint FK_TCOL_ITE_REFERENCE_TCOL_CAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TADM_PARAMETROSISTEMA') and o.name = 'FK_TCOL_PAR_REFERENCE_TCOL_SIS')
alter table TADM_PARAMETROSISTEMA
   drop constraint FK_TCOL_PAR_REFERENCE_TCOL_SIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TADM_PARAMETRO_OPCIONES') and o.name = 'FK_TCOL_PAR_REFERENCE_TCOL_PAR')
alter table TADM_PARAMETRO_OPCIONES
   drop constraint FK_TCOL_PAR_REFERENCE_TCOL_PAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_CENTRO') and o.name = 'FK_TNEG_CEN_REFERENCE_TNEG_UNI')
alter table TNEG_CENTRO
   drop constraint FK_TNEG_CEN_REFERENCE_TNEG_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_ENCUESTA') and o.name = 'FK_TNEG_ENC_REFERENCE_TNEG_UNI')
alter table TNEG_ENCUESTA
   drop constraint FK_TNEG_ENC_REFERENCE_TNEG_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_ENCUESTA_GRUPO') and o.name = 'FK_TNEG_ENC_GRU_TNEG_ENC')
alter table TNEG_ENCUESTA_GRUPO
   drop constraint FK_TNEG_ENC_GRU_TNEG_ENC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_MODULO') and o.name = 'FK_TNEG_MOD_REFERENCE_TNEG_PRO')
alter table TNEG_MODULO
   drop constraint FK_TNEG_MOD_REFERENCE_TNEG_PRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_OFERTA_PROGRAMA') and o.name = 'FK_TNEG_OFE_REFERENCE_TNEG_PER')
alter table TNEG_OFERTA_PROGRAMA
   drop constraint FK_TNEG_OFE_REFERENCE_TNEG_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_OFERTA_PROGRAMA') and o.name = 'FK_TNEG_OFE_REFERENCE_TNEG_ENC')
alter table TNEG_OFERTA_PROGRAMA
   drop constraint FK_TNEG_OFE_REFERENCE_TNEG_ENC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_OFERTA_PROGRAMA') and o.name = 'FK_TNEG_OFE_REFERENCE_TNEG_MOD')
alter table TNEG_OFERTA_PROGRAMA
   drop constraint FK_TNEG_OFE_REFERENCE_TNEG_MOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_OFERTA_PROGRAMA') and o.name = 'FK_TNEG_OFE_REFERENCE_TNEG_CEN')
alter table TNEG_OFERTA_PROGRAMA
   drop constraint FK_TNEG_OFE_REFERENCE_TNEG_CEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_OFERTA_PROGRAMA') and o.name = 'FK_TNEG_OFE_REFERENCE_TNEG_UNI')
alter table TNEG_OFERTA_PROGRAMA
   drop constraint FK_TNEG_OFE_REFERENCE_TNEG_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_OPCION') and o.name = 'FK_TNEG_OPC_REFERENCE_TNEG_PRE')
alter table TNEG_OPCION
   drop constraint FK_TNEG_OPC_REFERENCE_TNEG_PRE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_PERIODO_ACADEMICO') and o.name = 'FK_TNEG_PER_REFERENCE_TNEG_UNI')
alter table TNEG_PERIODO_ACADEMICO
   drop constraint FK_TNEG_PER_REFERENCE_TNEG_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_PREGUNTA') and o.name = 'FK_TNEG_PRE_REFERENCE_TNEG_ENC')
alter table TNEG_PREGUNTA
   drop constraint FK_TNEG_PRE_REFERENCE_TNEG_ENC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_PROGRAMA') and o.name = 'FK_TNEG_PRO_REFERENCE_TNEG_UNI')
alter table TNEG_PROGRAMA
   drop constraint FK_TNEG_PRO_REFERENCE_TNEG_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_RESPUESTA_OPCION') and o.name = 'FK_TNEG_RES_OPC_TNEG_TIC')
alter table TNEG_RESPUESTA_OPCION
   drop constraint FK_TNEG_RES_OPC_TNEG_TIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_RESPUESTA_OPCION') and o.name = 'FK_TNEG_RES_REFERENCE_TNEG_OPC')
alter table TNEG_RESPUESTA_OPCION
   drop constraint FK_TNEG_RES_REFERENCE_TNEG_OPC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_RESPUESTA_TEXTO') and o.name = 'FK_TNEG_RES_REFERENCE_TNEG_PRE')
alter table TNEG_RESPUESTA_TEXTO
   drop constraint FK_TNEG_RES_REFERENCE_TNEG_PRE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_RESPUESTA_TEXTO') and o.name = 'FK_TNEG_RES_TEX_TNEG_TIC')
alter table TNEG_RESPUESTA_TEXTO
   drop constraint FK_TNEG_RES_TEX_TNEG_TIC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_TICKET') and o.name = 'FK_TNEG_TIC_REFERENCE_TNEG_OFE')
alter table TNEG_TICKET
   drop constraint FK_TNEG_TIC_REFERENCE_TNEG_OFE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_UNIVERSIDAD_USUARIO') and o.name = 'FK_TNEG_UNI_REFERENCE_TSEG_USU')
alter table TNEG_UNIVERSIDAD_USUARIO
   drop constraint FK_TNEG_UNI_REFERENCE_TSEG_USU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_UNIVERSIDAD_USUARIO') and o.name = 'FK_TNEG_UNI_REFERENCE_TNEG_UNI')
alter table TNEG_UNIVERSIDAD_USUARIO
   drop constraint FK_TNEG_UNI_REFERENCE_TNEG_UNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_ACCION') and o.name = 'FK_TCOL_ACC_REFERENCE_TCOL_FUN')
alter table TSEG_ACCION
   drop constraint FK_TCOL_ACC_REFERENCE_TCOL_FUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_FUNCIONALIDAD') and o.name = 'FK_TCOL_FUN_REFERENCE_TCOL_SIS')
alter table TSEG_FUNCIONALIDAD
   drop constraint FK_TCOL_FUN_REFERENCE_TCOL_SIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_MENU') and o.name = 'FK_TCOL_MEN_REFERENCE_TCOL_SIS')
alter table TSEG_MENU
   drop constraint FK_TCOL_MEN_REFERENCE_TCOL_SIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_MENUSITEM') and o.name = 'FK_TCOL_MEN_REFERENCE_TCOL_FUN')
alter table TSEG_MENUSITEM
   drop constraint FK_TCOL_MEN_REFERENCE_TCOL_FUN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_MENUSITEM') and o.name = 'FK_TCOL_MEN_REFERENCE_TCOL_MEN')
alter table TSEG_MENUSITEM
   drop constraint FK_TCOL_MEN_REFERENCE_TCOL_MEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_PERMISOS') and o.name = 'FK_TCOL_PER_REFERENCE_TCOL_ACC')
alter table TSEG_PERMISOS
   drop constraint FK_TCOL_PER_REFERENCE_TCOL_ACC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_PERMISOS') and o.name = 'FK_TCOL_PER_REFERENCE_TCOL_ROL')
alter table TSEG_PERMISOS
   drop constraint FK_TCOL_PER_REFERENCE_TCOL_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_USUARIO') and o.name = 'FK_TSEG_USU_REFERENCE_TADM_PER')
alter table TSEG_USUARIO
   drop constraint FK_TSEG_USU_REFERENCE_TADM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_USUARIO_ROL') and o.name = 'FK_TCOL_USU_REFERENCE_TCOL_ROL')
alter table TSEG_USUARIO_ROL
   drop constraint FK_TCOL_USU_REFERENCE_TCOL_ROL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TSEG_USUARIO_ROL') and o.name = 'FK_TCOL_USU_REFERENCE_TCOL_USU')
alter table TSEG_USUARIO_ROL
   drop constraint FK_TCOL_USU_REFERENCE_TCOL_USU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TADM_CATALOGO')
            and   name  = 'U_CATALOGO'
            and   indid > 0
            and   indid < 255)
   drop index TADM_CATALOGO.U_CATALOGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TADM_CATALOGO')
            and   type = 'U')
   drop table TADM_CATALOGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TADM_INSTITUCION')
            and   type = 'U')
   drop table TADM_INSTITUCION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TADM_ITEMCATALOGO')
            and   name  = 'U_ITM_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TADM_ITEMCATALOGO.U_ITM_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TADM_ITEMCATALOGO')
            and   type = 'U')
   drop table TADM_ITEMCATALOGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TADM_PARAMETROSISTEMA')
            and   type = 'U')
   drop table TADM_PARAMETROSISTEMA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TADM_PARAMETRO_OPCIONES')
            and   type = 'U')
   drop table TADM_PARAMETRO_OPCIONES
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TADM_PERSONA')
            and   name  = 'U_CORREO'
            and   indid > 0
            and   indid < 255)
   drop index TADM_PERSONA.U_CORREO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TADM_PERSONA')
            and   name  = 'U_IDENTIFICACION'
            and   indid > 0
            and   indid < 255)
   drop index TADM_PERSONA.U_IDENTIFICACION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TADM_PERSONA')
            and   type = 'U')
   drop table TADM_PERSONA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAUD_AUDITORIA')
            and   type = 'U')
   drop table TAUD_AUDITORIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBAT_EJECUCION_PROCESO')
            and   type = 'U')
   drop table TBAT_EJECUCION_PROCESO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_CENTRO')
            and   name  = 'UX_CENTRO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_CENTRO.UX_CENTRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_CENTRO')
            and   type = 'U')
   drop table TNEG_CENTRO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_ENCUESTA')
            and   name  = 'UX_ENCUESTA'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_ENCUESTA.UX_ENCUESTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_ENCUESTA')
            and   type = 'U')
   drop table TNEG_ENCUESTA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_ENCUESTA_GRUPO')
            and   name  = 'UX_ENCUESTA_GRUPO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_ENCUESTA_GRUPO.UX_ENCUESTA_GRUPO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_ENCUESTA_GRUPO')
            and   type = 'U')
   drop table TNEG_ENCUESTA_GRUPO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_MODULO')
            and   name  = 'UX_MODULO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_MODULO.UX_MODULO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_MODULO')
            and   type = 'U')
   drop table TNEG_MODULO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_OFERTA_PROGRAMA')
            and   name  = 'UX_OFERTA_PROGRAMA'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_OFERTA_PROGRAMA.UX_OFERTA_PROGRAMA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_OFERTA_PROGRAMA')
            and   type = 'U')
   drop table TNEG_OFERTA_PROGRAMA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_OPCION')
            and   name  = 'UX_OPCION'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_OPCION.UX_OPCION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_OPCION')
            and   type = 'U')
   drop table TNEG_OPCION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_PERIODO_ACADEMICO')
            and   name  = 'UX_PERIODO_ACADEMICO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_PERIODO_ACADEMICO.UX_PERIODO_ACADEMICO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_PERIODO_ACADEMICO')
            and   type = 'U')
   drop table TNEG_PERIODO_ACADEMICO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_PREGUNTA')
            and   name  = 'UX_PREGUNTA'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_PREGUNTA.UX_PREGUNTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_PREGUNTA')
            and   type = 'U')
   drop table TNEG_PREGUNTA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_PROGRAMA')
            and   name  = 'UX_PROGRAMA'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_PROGRAMA.UX_PROGRAMA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_PROGRAMA')
            and   type = 'U')
   drop table TNEG_PROGRAMA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_RESPUESTA_OPCION')
            and   name  = 'UX_RESPUESTA'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_RESPUESTA_OPCION.UX_RESPUESTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_RESPUESTA_OPCION')
            and   type = 'U')
   drop table TNEG_RESPUESTA_OPCION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_RESPUESTA_TEXTO')
            and   name  = 'UX_RESPUESTA_TEXTO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_RESPUESTA_TEXTO.UX_RESPUESTA_TEXTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_RESPUESTA_TEXTO')
            and   type = 'U')
   drop table TNEG_RESPUESTA_TEXTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_TICKET')
            and   name  = 'UX_TICKET'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_TICKET.UX_TICKET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_TICKET')
            and   type = 'U')
   drop table TNEG_TICKET
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_UNIVERSIDAD')
            and   name  = 'UX_UNIVERSIDAD'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_UNIVERSIDAD.UX_UNIVERSIDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_UNIVERSIDAD')
            and   type = 'U')
   drop table TNEG_UNIVERSIDAD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_UNIVERSIDAD_USUARIO')
            and   name  = 'UX_UNIVERSIDAD_USUARIO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_UNIVERSIDAD_USUARIO.UX_UNIVERSIDAD_USUARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_UNIVERSIDAD_USUARIO')
            and   type = 'U')
   drop table TNEG_UNIVERSIDAD_USUARIO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_ACCION')
            and   name  = 'UX_ACC_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_ACCION.UX_ACC_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_ACCION')
            and   type = 'U')
   drop table TSEG_ACCION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_FUNCIONALIDAD')
            and   name  = 'UX_FUN_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_FUNCIONALIDAD.UX_FUN_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_FUNCIONALIDAD')
            and   type = 'U')
   drop table TSEG_FUNCIONALIDAD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_MENU')
            and   name  = 'UX_MEN_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_MENU.UX_MEN_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_MENU')
            and   type = 'U')
   drop table TSEG_MENU
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_MENUSITEM')
            and   name  = 'UX_MIT_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_MENUSITEM.UX_MIT_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_MENUSITEM')
            and   type = 'U')
   drop table TSEG_MENUSITEM
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_PERMISOS')
            and   name  = 'UX_PERMISOS'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_PERMISOS.UX_PERMISOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_PERMISOS')
            and   type = 'U')
   drop table TSEG_PERMISOS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_ROL')
            and   name  = 'UX_ROL_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_ROL.UX_ROL_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_ROL')
            and   type = 'U')
   drop table TSEG_ROL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_SESION')
            and   type = 'U')
   drop table TSEG_SESION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_SISTEMA')
            and   name  = 'UX_SIS_CODIGO'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_SISTEMA.UX_SIS_CODIGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_SISTEMA')
            and   type = 'U')
   drop table TSEG_SISTEMA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TSEG_USUARIO')
            and   name  = 'UX_USR_CUENTA'
            and   indid > 0
            and   indid < 255)
   drop index TSEG_USUARIO.UX_USR_CUENTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_USUARIO')
            and   type = 'U')
   drop table TSEG_USUARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TSEG_USUARIO_ROL')
            and   type = 'U')
   drop table TSEG_USUARIO_ROL
go

drop schema dbo
go

drop user dbo
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
execute sp_grantdbaccess dbo
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
create schema dbo authorization dbo
go

/*==============================================================*/
/* Table: TADM_CATALOGO                                         */
/*==============================================================*/
create table TADM_CATALOGO (
   CAT_ID               int                  identity(1, 1),
   SIS_ID               int                  null,
   CAT_CODIGO           varchar(15)          collate Modern_Spanish_CI_AI not null,
   CAT_NOMBRE           varchar(80)          collate Modern_Spanish_CI_AI not null,
   CAT_DESCRIPCION      varchar(255)         collate Modern_Spanish_CI_AI null,
   VERSION              int                  null constraint DF__TCOL_CATA__VERSI__68D28DBC default (1),
   CAT_FECHA_CREACION   datetime             not null constraint DF__TCOL_CATA__CAT_F__69C6B1F5 default getdate(),
   CAT_FECHA_ACTUALIZACION datetime             null,
   CAT_USUARIO_CREACION_ID int                  not null constraint DF__TCOL_CATA__CAT_U__6ABAD62E default (1),
   CAT_USUARIO_ACTUALIZACION_ID int                  null,
   constraint PK_TCOL_CATALOGO primary key nonclustered (CAT_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TADM_CATALOGO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TADM_CATALOGO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Tabla de catalogos del sistema', 
   'user', @CurrentUser, 'table', 'TADM_CATALOGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_CATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CAT_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'CAT_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de catalogo',
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'CAT_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_CATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CAT_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'CAT_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo de catalogo',
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'CAT_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_CATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CAT_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'CAT_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre de catalogo',
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'CAT_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_CATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version de registro',
   'user', @CurrentUser, 'table', 'TADM_CATALOGO', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: U_CATALOGO                                            */
/*==============================================================*/
create unique index U_CATALOGO on TADM_CATALOGO (
SIS_ID ASC,
CAT_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TADM_INSTITUCION                                      */
/*==============================================================*/
create table TADM_INSTITUCION (
   INS_ID               int                  identity,
   PER_ID               int                  null,
   INS_RAZON_SOCIAL     varchar(80)          not null,
   INS_RUC              varchar(13)          not null,
   ITM_INSCRITO         int                  not null,
   INS_LUGAR_INSCRIPCION varchar(80)          null,
   INS_NUMERO_ACUERDO_REGISTRO varchar(10)          null,
   constraint PK_TADM_INSTITUCION primary key (INS_ID)
)
go

/*==============================================================*/
/* Table: TADM_ITEMCATALOGO                                     */
/*==============================================================*/
create table TADM_ITEMCATALOGO (
   ITM_ID               int                  identity(1, 1),
   ITM_CODIGO           varchar(15)          collate Modern_Spanish_CI_AI not null,
   CAT_CODIGO           varchar(15)          collate Modern_Spanish_CI_AI not null,
   CAT_ID               int                  null,
   ITM_NOMBRE           varchar(80)          collate Modern_Spanish_CI_AI not null,
   ITM_DESCRIPCION      varchar(250)         collate Modern_Spanish_CI_AI null,
   VERSION              int                  null constraint DF__TCOL_ITEM__VERSI__6BAEFA67 default (1),
   itm_FECHA_CREACION   datetime             not null constraint DF__TCOL_ITEM__itm_F__6CA31EA0 default getdate(),
   itm_FECHA_ACTUALIZACION datetime             null,
   itm_USUARIO_CREACION_ID int                  not null constraint DF__TCOL_ITEM__itm_U__6D9742D9 default (1),
   itm_USUARIO_ACTUALIZACION_ID int                  null,
   ITM_ESTADO           bit                  not null,
   constraint PK_TCOL_ITEMCATALOGO primary key nonclustered (ITM_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TADM_ITEMCATALOGO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Items de Catalogos. 
      Ej. Catalogo: Genero => Items: Masculino, Femenino', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_ITEMCATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ITM_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de Item',
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_ITEMCATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ITM_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo del Item',
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_ITEMCATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CAT_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'CAT_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de catalogo',
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'CAT_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_ITEMCATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ITM_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre de Item',
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_ITEMCATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ITM_DESCRIPCION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_DESCRIPCION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Descripcion del Item',
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'ITM_DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_ITEMCATALOGO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TADM_ITEMCATALOGO', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: U_ITM_CODIGO                                          */
/*==============================================================*/
create unique index U_ITM_CODIGO on TADM_ITEMCATALOGO (
ITM_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TADM_PARAMETROSISTEMA                                 */
/*==============================================================*/
create table TADM_PARAMETROSISTEMA (
   PAR_ID               int                  identity(1, 1),
   SIS_ID               int                  null,
   PAR_CODIGO           varchar(15)          collate Modern_Spanish_CI_AI not null,
   PAR_NOMBRE           varchar(80)          collate Modern_Spanish_CI_AI not null,
   PAR_DESCRIPCION      varchar(255)         collate Modern_Spanish_CI_AI null,
   PAR_CATEGORIAID      int                  not null,
   PAR_TIPOID           int                  not null,
   PAR_VALOR            varchar(255)         collate Modern_Spanish_CI_AI null,
   PAR_ESEDITABLE       bit                  not null,
   PAR_FECHA_CREACION   datetime             not null,
   PAR_FECHA_ACTUALIZACION datetime             null,
   PAR_USUARIO_CREACION_ID int                  not null,
   PAR_USUARIO_ACTUALIZACION_ID int                  null,
   VERSION              int                  not null,
   PAR_OPCIONES         bit                  not null constraint DF__TCOL_PARA__PAR_O__73501C2F default (0),
   constraint PK_TCOL_PARAMETROSISTEMA primary key nonclustered (PAR_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TADM_PARAMETROSISTEMA') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Parámetros de configuración del sistema', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de parametro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo del parametro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre de parametro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_DESCRIPCION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_DESCRIPCION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Descripcion del parametro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_CATEGORIAID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_CATEGORIAID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Categoria del parametro (Item de catalogo. Ejemplo Parametros de interfaz del usuario, parametros de seguridad, etc.)',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_CATEGORIAID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_TIPOID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_TIPOID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Tipo del parametro (Item de Catalogo). (Numero, Cadena, Boleano, Listado de valores, etc.)',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_TIPOID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_VALOR')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_VALOR'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Valor del parametro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_VALOR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_ESEDITABLE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_ESEDITABLE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Si el parametro es editable desde el sistema.',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_ESEDITABLE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_FECHA_CREACION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_FECHA_CREACION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Fecha de creacion del registro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_FECHA_CREACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_FECHA_ACTUALIZACION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_FECHA_ACTUALIZACION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Fecha de actualizacion del registro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_FECHA_ACTUALIZACION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_USUARIO_CREACION_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_USUARIO_CREACION_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre / Identificador del Usuario que creo el registro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_USUARIO_CREACION_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_USUARIO_ACTUALIZACION_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_USUARIO_ACTUALIZACION_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre / Identificador del Usuario que realizado la ultima actualizacion del regsitro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'PAR_USUARIO_ACTUALIZACION_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETROSISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETROSISTEMA', 'column', 'VERSION'
go

/*==============================================================*/
/* Table: TADM_PARAMETRO_OPCIONES                               */
/*==============================================================*/
create table TADM_PARAMETRO_OPCIONES (
   POP_ID               int                  identity(1, 1),
   PAR_ID               int                  not null,
   POP_VALOR            varchar(30)          collate Modern_Spanish_CI_AI not null,
   POP_TEXTO            varchar(255)         collate Modern_Spanish_CI_AI not null,
   VERSION              int                  not null,
   constraint PK_TCOL_PARAMETRO_OPCIONES primary key (POP_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TADM_PARAMETRO_OPCIONES') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Listado de ocpciones que puede tener un parámetro.', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETRO_OPCIONES')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'POP_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'POP_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de la opcion',
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'POP_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETRO_OPCIONES')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAR_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'PAR_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de parametro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'PAR_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETRO_OPCIONES')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'POP_VALOR')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'POP_VALOR'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Valor de la Opcion',
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'POP_VALOR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETRO_OPCIONES')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'POP_TEXTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'POP_TEXTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Texto de usuario asociado al valor de la opcion de paraemtro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'POP_TEXTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TADM_PARAMETRO_OPCIONES')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TADM_PARAMETRO_OPCIONES', 'column', 'VERSION'
go

/*==============================================================*/
/* Table: TADM_PERSONA                                          */
/*==============================================================*/
create table TADM_PERSONA (
   PER_ID               int                  identity,
   PER_APELLIDO1        varchar(80)          not null,
   PER_APELLIDO2        varchar(80)          null,
   PER_NOMBRE1          varchar(80)          not null,
   PER_NOMBRE2          varchar(80)          null,
   ITM_TIPO_DOCUMENTO   int                  not null,
   PER_IDENTIFICACION   varchar(20)          not null,
   PER_TELEFONO         varchar(10)          null,
   PER_MOVIL            varchar(10)          not null,
   PER_CORREO           varchar(50)          null,
   ITM_ESTADO_CIVIL     int                  not null,
   constraint PK_TADM_PERSONA primary key nonclustered (PER_ID)
)
go

/*==============================================================*/
/* Index: U_IDENTIFICACION                                      */
/*==============================================================*/
create unique index U_IDENTIFICACION on TADM_PERSONA (
PER_IDENTIFICACION ASC
)
go

/*==============================================================*/
/* Index: U_CORREO                                              */
/*==============================================================*/
create unique index U_CORREO on TADM_PERSONA (
PER_CORREO ASC
)
go

/*==============================================================*/
/* Table: TAUD_AUDITORIA                                        */
/*==============================================================*/
create table TAUD_AUDITORIA (
   AUD_ID               int                  identity(1, 1),
   AUD_MENSAJE          text                 collate Modern_Spanish_CI_AI not null,
   AUD_NIVEL            nvarchar(10)         collate Modern_Spanish_CI_AI not null,
   AUD_FECHA            datetime             not null,
   AUD_USUARIO          nvarchar(60)         collate Modern_Spanish_CI_AI not null,
   AUD_FUNCIONALIDAD    nvarchar(30)         collate Modern_Spanish_CI_AI not null,
   AUD_ACCION           nvarchar(40)         collate Modern_Spanish_CI_AI not null,
   AUD_IDENTIFICACION   nvarchar(20)         collate Modern_Spanish_CI_AI not null,
   AUD_DIRECCION_IP     nvarchar(30)         collate Modern_Spanish_CI_AI not null,
   constraint PK_Table_1 primary key (AUD_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TBAT_EJECUCION_PROCESO                                */
/*==============================================================*/
create table TBAT_EJECUCION_PROCESO (
   EPR_ID               int                  identity(1, 1),
   EPR_FECHA_EJECUCION  datetime             not null,
   EPR_CODIGO           nvarchar(30)         collate Modern_Spanish_CI_AI not null,
   EPR_ULTIMA_EJECUCION int                  not null,
   EPR_FECHA_ULTIMO_VALOR datetime             not null constraint DF_TCOL_EJECUCION_PROCESO_EPR_FECHA_ULTIMO_VALOR default getdate(),
   EPR_ESTADO           int                  not null constraint DF_TCOL_EJECUCION_PROCESO_EPR_ESTADO default (0),
   EPR_USUARIO_CREACION int                  null,
   EPR_PARAMETROS       nvarchar(250)        null,
   EPR_OBSERVACION      nvarchar(250)        null,
   constraint "PK_dbo.TCOL_EJECUCION_PROCESO" primary key (EPR_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TNEG_CENTRO                                           */
/*==============================================================*/
create table TNEG_CENTRO (
   CEN_ID               int                  identity,
   UNI_ID               int                  not null,
   CEN_CODIGO           varchar(15)          not null,
   CEN_NOMBRE           varchar(80)          not null,
   ESTADO               int                  not null,
   constraint PK_TNEG_CENTRO primary key (CEN_ID)
)
go

/*==============================================================*/
/* Index: UX_CENTRO                                             */
/*==============================================================*/
create unique index UX_CENTRO on TNEG_CENTRO (
CEN_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_ENCUESTA                                         */
/*==============================================================*/
create table TNEG_ENCUESTA (
   ENC_ID               int                  identity,
   UNI_ID               int                  not null,
   ENC_CODIGO           varchar(15)          not null,
   ENC_TEXTO            text                 not null,
   FECHA_CREACION       datetime             not null,
   FECHA_ACTUALIZACION  datetime             null,
   USR_CREACION_ID      int                  not null,
   USR_ACTUALIZACION_ID int                  null,
   constraint PK_TNEG_ENCUESTA primary key (ENC_ID)
)
go

/*==============================================================*/
/* Index: UX_ENCUESTA                                           */
/*==============================================================*/
create unique index UX_ENCUESTA on TNEG_ENCUESTA (
ENC_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_ENCUESTA_GRUPO                                   */
/*==============================================================*/
create table TNEG_ENCUESTA_GRUPO (
   ENG_ID               int                  identity,
   ENG_CODIGO           varchar(15)          not null,
   ENG_ORDEN            int                  not null,
   ENC_ID               int                  not null,
   ENG_TEXTO            text                 null,
   ENG_TIENE            bit                  not null,
   FECHA_CREACION       datetime             not null,
   FECHA_ACTUALIZACION  datetime             null,
   USR_CREACION_ID      int                  not null,
   USR_ACTUALIZACION_ID int                  null,
   constraint PK_TNEG_ENCUESTA_GRUPO primary key (ENG_ID)
)
go

/*==============================================================*/
/* Index: UX_ENCUESTA_GRUPO                                     */
/*==============================================================*/
create unique index UX_ENCUESTA_GRUPO on TNEG_ENCUESTA_GRUPO (
ENG_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_MODULO                                           */
/*==============================================================*/
create table TNEG_MODULO (
   MOD_ID               int                  identity,
   PGA_ID               int                  not null,
   MOD_CODIGO           varchar(15)          not null,
   MOD_NOMBRE           varchar(80)          not null,
   ESTADO               int                  not null,
   constraint PK_TNEG_MODULO primary key (MOD_ID)
)
go

/*==============================================================*/
/* Index: UX_MODULO                                             */
/*==============================================================*/
create unique index UX_MODULO on TNEG_MODULO (
MOD_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_OFERTA_PROGRAMA                                  */
/*==============================================================*/
create table TNEG_OFERTA_PROGRAMA (
   OPR_ID               int                  identity,
   PAC_ID               int                  not null,
   ENC_ID               int                  not null,
   MOD_ID               int                  not null,
   CEN_ID               int                  not null,
   UNU_ID               int                  not null,
   constraint PK_TNEG_OFERTA_PROGRAMA primary key (OPR_ID)
)
go

/*==============================================================*/
/* Index: UX_OFERTA_PROGRAMA                                    */
/*==============================================================*/
create unique index UX_OFERTA_PROGRAMA on TNEG_OFERTA_PROGRAMA (
PAC_ID ASC,
ENC_ID ASC,
MOD_ID ASC,
CEN_ID ASC,
UNU_ID ASC
)
go

/*==============================================================*/
/* Table: TNEG_OPCION                                           */
/*==============================================================*/
create table TNEG_OPCION (
   OPC_ID               int                  identity,
   PRG_ID               int                  not null,
   OPC_CODIGO           varchar(15)          not null,
   OPC_ORDEN            int                  not null,
   OPC_TEXTO            text                 not null,
   FECHA_CREACION       datetime             not null,
   FECHA_ACTUALIZACION  datetime             null,
   USR_CREACION_ID      int                  not null,
   USR_ACTUALIZACION_ID int                  null,
   constraint PK_TNEG_OPCION primary key (OPC_ID)
)
go

/*==============================================================*/
/* Index: UX_OPCION                                             */
/*==============================================================*/
create unique index UX_OPCION on TNEG_OPCION (
OPC_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_PERIODO_ACADEMICO                                */
/*==============================================================*/
create table TNEG_PERIODO_ACADEMICO (
   PAC_ID               int                  identity,
   UNI_ID               int                  not null,
   PAC_CODIGO           varchar(15)          not null,
   PAC_NOMBRE           varchar(80)          not null,
   PAC_FECHA_DESDE      datetime             not null,
   PAC_FECHA_HASTA      datetime             not null,
   ESTADO               int                  not null,
   constraint PK_TNEG_PERIODO_ACADEMICO primary key (PAC_ID)
)
go

/*==============================================================*/
/* Index: UX_PERIODO_ACADEMICO                                  */
/*==============================================================*/
create unique index UX_PERIODO_ACADEMICO on TNEG_PERIODO_ACADEMICO (
PAC_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_PREGUNTA                                         */
/*==============================================================*/
create table TNEG_PREGUNTA (
   PRG_ID               int                  identity,
   ENG_ID               int                  not null,
   PRG_CODIGO           varchar(15)          not null,
   PRG_ORDEN            int                  not null,
   PRG_TEXTO            text                 not null,
   PRG_TIPO             int                  not null,
   FECHA_CREACION       datetime             not null,
   FECHA_ACTUALIZACION  datetime             null,
   USR_CREACION_ID      int                  not null,
   USR_ACTUALIZACION_ID int                  null,
   constraint PK_TNEG_PREGUNTA primary key (PRG_ID)
)
go

/*==============================================================*/
/* Index: UX_PREGUNTA                                           */
/*==============================================================*/
create unique index UX_PREGUNTA on TNEG_PREGUNTA (
PRG_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_PROGRAMA                                         */
/*==============================================================*/
create table TNEG_PROGRAMA (
   PGA_ID               int                  identity,
   UNI_ID               int                  not null,
   PGA_CODIGO           varchar(15)          not null,
   PGA_NOMBRE           varchar(80)          not null,
   ESTADO               int                  not null,
   constraint PK_TNEG_PROGRAMA primary key (PGA_ID)
)
go

/*==============================================================*/
/* Index: UX_PROGRAMA                                           */
/*==============================================================*/
create unique index UX_PROGRAMA on TNEG_PROGRAMA (
PGA_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_RESPUESTA_OPCION                                 */
/*==============================================================*/
create table TNEG_RESPUESTA_OPCION (
   RPO_ID               int                  identity,
   TIC_ID               int                  not null,
   OPC_ID               int                  not null,
   RPO_VALOR            bit                  not null,
   RPO_FECHA_CREACION   datetime             not null,
   constraint PK_TNEG_RESPUESTA_OPCION primary key (RPO_ID)
)
go

/*==============================================================*/
/* Index: UX_RESPUESTA                                          */
/*==============================================================*/
create unique index UX_RESPUESTA on TNEG_RESPUESTA_OPCION (
TIC_ID ASC,
OPC_ID ASC
)
go

/*==============================================================*/
/* Table: TNEG_RESPUESTA_TEXTO                                  */
/*==============================================================*/
create table TNEG_RESPUESTA_TEXTO (
   RPT_ID               int                  identity,
   TIC_ID               int                  not null,
   PRG_ID               int                  not null,
   RPT_VALOR            text                 not null,
   RPT_FECHA_CREACION   datetime             not null,
   constraint PK_TNEG_RESPUESTA_TEXTO primary key (RPT_ID)
)
go

/*==============================================================*/
/* Index: UX_RESPUESTA_TEXTO                                    */
/*==============================================================*/
create unique index UX_RESPUESTA_TEXTO on TNEG_RESPUESTA_TEXTO (
TIC_ID ASC,
PRG_ID ASC
)
go

/*==============================================================*/
/* Table: TNEG_TICKET                                           */
/*==============================================================*/
create table TNEG_TICKET (
   TIC_ID               int                  identity,
   OPR_ID               int                  not null,
   TIC_IDENTIFICACION   varchar(20)          not null,
   TIC_CORREO           varchar(50)          not null,
   TIC_RESUELTO         bit                  not null,
   FECHA_CREACION       datetime             not null,
   FECHA_ACTUALIZACION  datetime             null,
   USR_CREACION_ID      int                  not null,
   USR_ACTUALIZACION_ID int                  null,
   constraint PK_TNEG_TICKET primary key (TIC_ID)
)
go

/*==============================================================*/
/* Index: UX_TICKET                                             */
/*==============================================================*/
create unique index UX_TICKET on TNEG_TICKET (
OPR_ID ASC,
TIC_CORREO ASC
)
go

/*==============================================================*/
/* Table: TNEG_UNIVERSIDAD                                      */
/*==============================================================*/
create table TNEG_UNIVERSIDAD (
   UNI_ID               int                  identity,
   UNI_CODIGO           varchar(15)          not null,
   UNI_NOMBRE           varchar(80)          not null,
   ESTADO               int                  not null,
   constraint PK_TNEG_UNIVERSIDAD primary key (UNI_ID)
)
go

/*==============================================================*/
/* Index: UX_UNIVERSIDAD                                        */
/*==============================================================*/
create unique index UX_UNIVERSIDAD on TNEG_UNIVERSIDAD (
UNI_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_UNIVERSIDAD_USUARIO                              */
/*==============================================================*/
create table TNEG_UNIVERSIDAD_USUARIO (
   UNU_ID               int                  identity,
   USR_ID               int                  not null,
   UNI_ID               int                  not null,
   constraint PK_TNEG_UNIVERSIDAD_USUARIO primary key (UNU_ID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TNEG_UNIVERSIDAD_USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USR_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TNEG_UNIVERSIDAD_USUARIO', 'column', 'USR_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador Usuario',
   'user', @CurrentUser, 'table', 'TNEG_UNIVERSIDAD_USUARIO', 'column', 'USR_ID'
go

/*==============================================================*/
/* Index: UX_UNIVERSIDAD_USUARIO                                */
/*==============================================================*/
create unique index UX_UNIVERSIDAD_USUARIO on TNEG_UNIVERSIDAD_USUARIO (
USR_ID ASC,
UNI_ID ASC
)
go

/*==============================================================*/
/* Table: TSEG_ACCION                                           */
/*==============================================================*/
create table TSEG_ACCION (
   ACC_ID               int                  identity(1, 1),
   ACC_CODIGO           varchar(30)          collate Modern_Spanish_CI_AI not null,
   ACC_NOMBRE           nvarchar(80)         collate Modern_Spanish_CI_AI not null,
   FUN_ID               int                  not null,
   VERSION              int                  not null,
   constraint PK_TCOL_ACCION primary key (ACC_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_ACCION') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_ACCION' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Acciones que se puede ejecutar en una funcionalidad (Crear, eliminar, visualizar, editar, imprimir, etc.)', 
   'user', @CurrentUser, 'table', 'TSEG_ACCION'
go

/*==============================================================*/
/* Index: UX_ACC_CODIGO                                         */
/*==============================================================*/
create unique index UX_ACC_CODIGO on TSEG_ACCION (
ACC_CODIGO ASC,
FUN_ID ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_FUNCIONALIDAD                                    */
/*==============================================================*/
create table TSEG_FUNCIONALIDAD (
   FUN_ID               int                  identity(1, 1),
   SIS_ID               int                  not null,
   FUN_CODIGO           nvarchar(15)         collate Modern_Spanish_CI_AI not null,
   FUN_NOMBRE           nvarchar(80)         collate Modern_Spanish_CI_AI not null,
   FUN_DESCRIPCION      nvarchar(250)        collate Modern_Spanish_CI_AI null,
   FUN_CONTROLADOR      nvarchar(80)         collate Modern_Spanish_CI_AI not null,
   FUN_ESTADOID         int                  not null,
   VERSION              int                  null,
   constraint PK_TCOL_FUNCIONALIDAD primary key (FUN_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_FUNCIONALIDAD') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_FUNCIONALIDAD' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Funcionalidades del sistema', 
   'user', @CurrentUser, 'table', 'TSEG_FUNCIONALIDAD'
go

/*==============================================================*/
/* Index: UX_FUN_CODIGO                                         */
/*==============================================================*/
create unique index UX_FUN_CODIGO on TSEG_FUNCIONALIDAD (
SIS_ID ASC,
FUN_CODIGO ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_MENU                                             */
/*==============================================================*/
create table TSEG_MENU (
   MEN_ID               int                  identity(1, 1),
   SIS_ID               int                  not null,
   MEN_CODIGO           nvarchar(15)         collate Modern_Spanish_CI_AI not null,
   MEN_NOMBRE           nvarchar(80)         collate Modern_Spanish_CI_AI not null,
   MEN_DESCRIPCION      nvarchar(250)        collate Modern_Spanish_CI_AI null,
   VERSION              int                  null,
   constraint PK_TCOL_MENU primary key (MEN_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_MENU') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_MENU' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Menus del sistema. Un menu esta formado por items de menus', 
   'user', @CurrentUser, 'table', 'TSEG_MENU'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENU')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MEN_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'MEN_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo del menu',
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'MEN_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENU')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MEN_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'MEN_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre del menu',
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'MEN_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENU')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MEN_DESCRIPCION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'MEN_DESCRIPCION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Descripcion del menu',
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'MEN_DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENU')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_MENU', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: UX_MEN_CODIGO                                         */
/*==============================================================*/
create unique index UX_MEN_CODIGO on TSEG_MENU (
SIS_ID ASC,
MEN_CODIGO ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_MENUSITEM                                        */
/*==============================================================*/
create table TSEG_MENUSITEM (
   MIT_ID               int                  identity(1, 1),
   MIT_CODIGO           nvarchar(15)         collate Modern_Spanish_CI_AI not null,
   MIT_NOMBRE           nvarchar(80)         collate Modern_Spanish_CI_AI not null,
   MIT_DESCRIPCION      nvarchar(250)        collate Modern_Spanish_CI_AI null,
   MIT_URL              nvarchar(250)        collate Modern_Spanish_CI_AI null,
   MIT_ESTADOID         int                  not null,
   MIT_TIPOID           int                  not null,
   MEN_ID               int                  not null,
   PADRE_CODIGO         varchar(15)          null,
   FUN_ID               int                  null,
   VERSION              int                  null,
   MIT_ORDEN            int                  null,
   MIT_ICONO            varchar(30)          collate Modern_Spanish_CI_AI null,
   constraint PK_TCOL_MENUSITEM primary key (MIT_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_MENUSITEM') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Items de Menus', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MIT_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo del Item de Menu',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MIT_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre del item de Menu',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MIT_DESCRIPCION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_DESCRIPCION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Descripcion del Item de menu',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MIT_URL')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_URL'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Url del Item de Menu',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_URL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MIT_ESTADOID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_ESTADOID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Estado del item del Menu (Activo / Desactivo)',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_ESTADOID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MIT_TIPOID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_TIPOID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Tipo de Menu (Contenedor de Items de Menus o Item de Menu)',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MIT_TIPOID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MEN_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MEN_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador del menu a cual pertenece el item de menu',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'MEN_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PADRE_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'PADRE_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Padre del item de menu. Para crear menus jerarquicos',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'PADRE_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_MENUSITEM')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FUN_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'FUN_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de la funcionalidad asociada al item de menu. Un item de menu puede estar asociada a una funcionalidad del sistema, esto permite visualizar el item de menu si existe permisos a la funcionalidad de lectura',
   'user', @CurrentUser, 'table', 'TSEG_MENUSITEM', 'column', 'FUN_ID'
go

/*==============================================================*/
/* Index: UX_MIT_CODIGO                                         */
/*==============================================================*/
create unique index UX_MIT_CODIGO on TSEG_MENUSITEM (
MIT_CODIGO ASC,
MEN_ID ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_PERMISOS                                         */
/*==============================================================*/
create table TSEG_PERMISOS (
   PMI_ID               int                  identity(1, 1),
   ROL_ID               int                  not null,
   ACC_ID               int                  not null,
   PMI_NO_VISUALIZAR_MENU bit                  not null,
   VERSION              int                  not null constraint DF__TCOL_PERM__VERSI__74444068 default (1),
   constraint PK_TCOL_PERMISOS primary key nonclustered (PMI_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_PERMISOS') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Permisos que posee un rol sobre las acciones de una funcionalidad', 
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_PERMISOS')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PMI_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS', 'column', 'PMI_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador rol',
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS', 'column', 'PMI_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_PERMISOS')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS', 'column', 'ROL_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador rol',
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS', 'column', 'ROL_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_PERMISOS')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_PERMISOS', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: UX_PERMISOS                                           */
/*==============================================================*/
create unique index UX_PERMISOS on TSEG_PERMISOS (
ROL_ID ASC,
ACC_ID ASC
)
go

/*==============================================================*/
/* Table: TSEG_ROL                                              */
/*==============================================================*/
create table TSEG_ROL (
   ROL_ID               int                  identity(1, 1),
   ROL_CODIGO           varchar(30)          collate Modern_Spanish_CI_AI not null,
   ROL_NOMBRE           varchar(60)          collate Modern_Spanish_CI_AI not null,
   ROL_ESADMINISTRADOR  bit                  null,
   VERSION              int                  null constraint DF__TCOL_ROL__VERSIO__1FC39B4A default (1),
   ROL_ESEXTERNO        bit                  null,
   ROL_FECHA_CREACION   datetime             not null constraint DF__TCOL_ROL__ROL_FE__7720AD13 default getdate(),
   ROL_FECHA_ACTUALIZACION datetime             null,
   ROL_USUARIO_CREACION_ID int                  not null constraint DF__TCOL_ROL__ROL_US__7814D14C default (1),
   ROL_USUARIO_ACTUALIZACION_ID int                  null,
   ROL_URL              varchar(255)         collate Modern_Spanish_CI_AI null,
   ROL_PARAMETROS       varchar(Max)         null,
   constraint PK_TCOL_ROL primary key nonclustered (ROL_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_ROL') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_ROL' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Tabla de roles para asignar a los usuairos', 
   'user', @CurrentUser, 'table', 'TSEG_ROL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador rol',
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo del rol',
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre de rol',
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_ESADMINISTRADOR')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_ESADMINISTRADOR'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Estado del rol',
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'ROL_ESADMINISTRADOR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_ROL', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: UX_ROL_CODIGO                                         */
/*==============================================================*/
create unique index UX_ROL_CODIGO on TSEG_ROL (
ROL_CODIGO ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_SESION                                           */
/*==============================================================*/
create table TSEG_SESION (
   SES_ID               int                  identity(1, 1),
   SES_CUENTA           nvarchar(60)         collate Modern_Spanish_CI_AI not null,
   SES_INICIO           datetime             not null,
   SES_FIN              datetime             null,
   SES_ESTADOID         int                  not null,
   SES_IP               varchar(25)          collate Modern_Spanish_CI_AI null,
   ROL_ID               int                  null,
   VERSION              int                  not null constraint DF__TCOL_SESI__VERSI__7908F585 default (1),
   constraint PK_TCOL_SESION primary key nonclustered (SES_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_SESION') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_SESION' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Guarda informacion de sesion de un usuario en el sistema', 
   'user', @CurrentUser, 'table', 'TSEG_SESION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SES_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de la sesion',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SES_CUENTA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_CUENTA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'cuenta del usuario',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_CUENTA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SES_INICIO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_INICIO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'fecha de inicio de la sesion',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_INICIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SES_FIN')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_FIN'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'fecha de finalizacion de la sesion',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_FIN'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SES_ESTADOID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_ESTADOID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'estado de la sesion (iniciada, finalizada)',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_ESTADOID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SES_IP')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_IP'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'guardar la Ip del usuario que inicio la sesion.',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'SES_IP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'ROL_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador del rol con el cual inicio la sesion',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'ROL_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SESION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_SESION', 'column', 'VERSION'
go

/*==============================================================*/
/* Table: TSEG_SISTEMA                                          */
/*==============================================================*/
create table TSEG_SISTEMA (
   SIS_ID               int                  identity(1, 1),
   SIS_CODIGO           nvarchar(15)         collate Modern_Spanish_CI_AI not null,
   SIS_NOMBRE           nvarchar(80)         collate Modern_Spanish_CI_AI not null,
   SIS_DESCRIPCION      nvarchar(250)        collate Modern_Spanish_CI_AI null,
   VERSION              int                  null,
   constraint PK_TCOL_SISTEMA primary key (SIS_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_SISTEMA') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Información del sistema', 
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SIS_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador del Sistema',
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SIS_CODIGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_CODIGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Codigo del sistema',
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_CODIGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SIS_NOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_NOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nombre del sistema',
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_NOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SIS_DESCRIPCION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_DESCRIPCION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Descripcion del sistema',
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'SIS_DESCRIPCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_SISTEMA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_SISTEMA', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: UX_SIS_CODIGO                                         */
/*==============================================================*/
create unique index UX_SIS_CODIGO on TSEG_SISTEMA (
SIS_CODIGO ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_USUARIO                                          */
/*==============================================================*/
create table TSEG_USUARIO (
   USR_ID               int                  identity(1, 1),
   PER_ID               int                  null,
   USR_CUENTA           varchar(15)          collate Modern_Spanish_CI_AI not null,
   VERSION              int                  null constraint DF__TCOL_USUA__VERSI__79FD19BE default (1),
   USR_FECHA_CREACION   datetime             not null constraint DF__TCOL_USUA__USR_F__7AF13DF7 default getdate(),
   USR_FECHA_ACTUALIZACION datetime             null,
   USR_USUARIO_CREACION_ID int                  not null constraint DF__TCOL_USUA__USR_U__7BE56230 default (1),
   USR_USUARIO_ACTUALIZACION_ID int                  null,
   USR_ESTADO           int                  null constraint DF_TCOL_USUARIO_USR_ESTADO default (1),
   USR_CLAVE            varchar(80)          not null,
   constraint PK_TCOL_USUARIO primary key nonclustered (USR_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_USUARIO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_USUARIO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Tabla de usuarios de carpeta en Línea', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USR_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO', 'column', 'USR_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador Usuario',
   'user', @CurrentUser, 'table', 'TSEG_USUARIO', 'column', 'USR_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_USUARIO', 'column', 'VERSION'
go

/*==============================================================*/
/* Index: UX_USR_CUENTA                                         */
/*==============================================================*/
create unique index UX_USR_CUENTA on TSEG_USUARIO (
USR_CUENTA ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TSEG_USUARIO_ROL                                      */
/*==============================================================*/
create table TSEG_USUARIO_ROL (
   USR_ROL_ID           int                  identity(1, 1),
   ROL_ID               int                  not null,
   USR_ID               int                  not null,
   VERSION              int                  not null constraint DF__TCOL_USUA__VERSI__7CD98669 default (1),
   constraint PK_TCOL_USUARIO_ROL primary key nonclustered (USR_ROL_ID)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TSEG_USUARIO_ROL') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Tabla de usuarios - roles', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_USUARIO_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USR_ROL_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'USR_ROL_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador del Rol Usuario',
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'USR_ROL_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_USUARIO_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ROL_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'ROL_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador rol id',
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'ROL_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_USUARIO_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USR_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'USR_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador de usuario',
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'USR_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TSEG_USUARIO_ROL')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VERSION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'VERSION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Version del registro',
   'user', @CurrentUser, 'table', 'TSEG_USUARIO_ROL', 'column', 'VERSION'
go

alter table TADM_CATALOGO
   add constraint FK_TCOL_CAT_REFERENCE_TCOL_SIS foreign key (SIS_ID)
      references TSEG_SISTEMA (SIS_ID)
         on update cascade
go

alter table TADM_INSTITUCION
   add constraint FK_TADM_INS_REFERENCE_TADM_PER foreign key (PER_ID)
      references TADM_PERSONA (PER_ID)
go

alter table TADM_ITEMCATALOGO
   add constraint FK_TCOL_ITE_REFERENCE_TCOL_CAT foreign key (CAT_ID)
      references TADM_CATALOGO (CAT_ID)
         on update cascade
go

alter table TADM_PARAMETROSISTEMA
   add constraint FK_TCOL_PAR_REFERENCE_TCOL_SIS foreign key (SIS_ID)
      references TSEG_SISTEMA (SIS_ID)
         on update cascade
go

alter table TADM_PARAMETRO_OPCIONES
   add constraint FK_TCOL_PAR_REFERENCE_TCOL_PAR foreign key (PAR_ID)
      references TADM_PARAMETROSISTEMA (PAR_ID)
go

alter table TNEG_CENTRO
   add constraint FK_TNEG_CEN_REFERENCE_TNEG_UNI foreign key (UNI_ID)
      references TNEG_UNIVERSIDAD (UNI_ID)
go

alter table TNEG_ENCUESTA
   add constraint FK_TNEG_ENC_REFERENCE_TNEG_UNI foreign key (UNI_ID)
      references TNEG_UNIVERSIDAD (UNI_ID)
go

alter table TNEG_ENCUESTA_GRUPO
   add constraint FK_TNEG_ENC_GRU_TNEG_ENC foreign key (ENC_ID)
      references TNEG_ENCUESTA (ENC_ID)
         on delete cascade
go

alter table TNEG_MODULO
   add constraint FK_TNEG_MOD_REFERENCE_TNEG_PRO foreign key (PGA_ID)
      references TNEG_PROGRAMA (PGA_ID)
go

alter table TNEG_OFERTA_PROGRAMA
   add constraint FK_TNEG_OFE_REFERENCE_TNEG_PER foreign key (PAC_ID)
      references TNEG_PERIODO_ACADEMICO (PAC_ID)
go

alter table TNEG_OFERTA_PROGRAMA
   add constraint FK_TNEG_OFE_REFERENCE_TNEG_ENC foreign key (ENC_ID)
      references TNEG_ENCUESTA (ENC_ID)
go

alter table TNEG_OFERTA_PROGRAMA
   add constraint FK_TNEG_OFE_REFERENCE_TNEG_MOD foreign key (MOD_ID)
      references TNEG_MODULO (MOD_ID)
go

alter table TNEG_OFERTA_PROGRAMA
   add constraint FK_TNEG_OFE_REFERENCE_TNEG_CEN foreign key (CEN_ID)
      references TNEG_CENTRO (CEN_ID)
go

alter table TNEG_OFERTA_PROGRAMA
   add constraint FK_TNEG_OFE_REFERENCE_TNEG_UNI foreign key (UNU_ID)
      references TNEG_UNIVERSIDAD_USUARIO (UNU_ID)
go

alter table TNEG_OPCION
   add constraint FK_TNEG_OPC_REFERENCE_TNEG_PRE foreign key (PRG_ID)
      references TNEG_PREGUNTA (PRG_ID)
         on delete cascade
go

alter table TNEG_PERIODO_ACADEMICO
   add constraint FK_TNEG_PER_REFERENCE_TNEG_UNI foreign key (UNI_ID)
      references TNEG_UNIVERSIDAD (UNI_ID)
go

alter table TNEG_PREGUNTA
   add constraint FK_TNEG_PRE_REFERENCE_TNEG_ENC foreign key (ENG_ID)
      references TNEG_ENCUESTA_GRUPO (ENG_ID)
         on delete cascade
go

alter table TNEG_PROGRAMA
   add constraint FK_TNEG_PRO_REFERENCE_TNEG_UNI foreign key (UNI_ID)
      references TNEG_UNIVERSIDAD (UNI_ID)
go

alter table TNEG_RESPUESTA_OPCION
   add constraint FK_TNEG_RES_OPC_TNEG_TIC foreign key (TIC_ID)
      references TNEG_TICKET (TIC_ID)
go

alter table TNEG_RESPUESTA_OPCION
   add constraint FK_TNEG_RES_REFERENCE_TNEG_OPC foreign key (OPC_ID)
      references TNEG_OPCION (OPC_ID)
go

alter table TNEG_RESPUESTA_TEXTO
   add constraint FK_TNEG_RES_REFERENCE_TNEG_PRE foreign key (PRG_ID)
      references TNEG_PREGUNTA (PRG_ID)
go

alter table TNEG_RESPUESTA_TEXTO
   add constraint FK_TNEG_RES_TEX_TNEG_TIC foreign key (TIC_ID)
      references TNEG_TICKET (TIC_ID)
go

alter table TNEG_TICKET
   add constraint FK_TNEG_TIC_REFERENCE_TNEG_OFE foreign key (OPR_ID)
      references TNEG_OFERTA_PROGRAMA (OPR_ID)
go

alter table TNEG_UNIVERSIDAD_USUARIO
   add constraint FK_TNEG_UNI_REFERENCE_TSEG_USU foreign key (USR_ID)
      references TSEG_USUARIO (USR_ID)
go

alter table TNEG_UNIVERSIDAD_USUARIO
   add constraint FK_TNEG_UNI_REFERENCE_TNEG_UNI foreign key (UNI_ID)
      references TNEG_UNIVERSIDAD (UNI_ID)
go

alter table TSEG_ACCION
   add constraint FK_TCOL_ACC_REFERENCE_TCOL_FUN foreign key (FUN_ID)
      references TSEG_FUNCIONALIDAD (FUN_ID)
         on update cascade on delete cascade
go

alter table TSEG_FUNCIONALIDAD
   add constraint FK_TCOL_FUN_REFERENCE_TCOL_SIS foreign key (SIS_ID)
      references TSEG_SISTEMA (SIS_ID)
         on update cascade
go

alter table TSEG_MENU
   add constraint FK_TCOL_MEN_REFERENCE_TCOL_SIS foreign key (SIS_ID)
      references TSEG_SISTEMA (SIS_ID)
         on update cascade
go

alter table TSEG_MENUSITEM
   add constraint FK_TCOL_MEN_REFERENCE_TCOL_FUN foreign key (FUN_ID)
      references TSEG_FUNCIONALIDAD (FUN_ID)
go

alter table TSEG_MENUSITEM
   add constraint FK_TCOL_MEN_REFERENCE_TCOL_MEN foreign key (MEN_ID)
      references TSEG_MENU (MEN_ID)
         on update cascade on delete cascade
go

alter table TSEG_PERMISOS
   add constraint FK_TCOL_PER_REFERENCE_TCOL_ACC foreign key (ACC_ID)
      references TSEG_ACCION (ACC_ID)
         on update cascade
go

alter table TSEG_PERMISOS
   add constraint FK_TCOL_PER_REFERENCE_TCOL_ROL foreign key (ROL_ID)
      references TSEG_ROL (ROL_ID)
         on update cascade
go

alter table TSEG_USUARIO
   add constraint FK_TSEG_USU_REFERENCE_TADM_PER foreign key (PER_ID)
      references TADM_PERSONA (PER_ID)
go

alter table TSEG_USUARIO_ROL
   add constraint FK_TCOL_USU_REFERENCE_TCOL_ROL foreign key (ROL_ID)
      references TSEG_ROL (ROL_ID)
go

alter table TSEG_USUARIO_ROL
   add constraint FK_TCOL_USU_REFERENCE_TCOL_USU foreign key (USR_ID)
      references TSEG_USUARIO (USR_ID)
go

