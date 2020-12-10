/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     10/12/2020 11:31:04 a. m.                    */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TADM_CATALOGO') and o.name = 'FK_TCOL_CAT_REFERENCE_TCOL_SIS')
alter table TADM_CATALOGO
   drop constraint FK_TCOL_CAT_REFERENCE_TCOL_SIS
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
   where r.fkeyid = object_id('TNEG_ASIGNACION_DOCENTE') and o.name = 'FK_TNEG_ASI_REFERENCE_TNEG_COM')
alter table TNEG_ASIGNACION_DOCENTE
   drop constraint FK_TNEG_ASI_REFERENCE_TNEG_COM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_ASIGNACION_DOCENTE') and o.name = 'FK_TNEG_ASI_REFERENCE_TADM_PER')
alter table TNEG_ASIGNACION_DOCENTE
   drop constraint FK_TNEG_ASI_REFERENCE_TADM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_MATRICULA') and o.name = 'FK_TNEG_MAT_REFERENCE_TNEG_COM')
alter table TNEG_MATRICULA
   drop constraint FK_TNEG_MAT_REFERENCE_TNEG_COM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_MATRICULA') and o.name = 'FK_TNEG_MAT_REFERENCE_TADM_PER')
alter table TNEG_MATRICULA
   drop constraint FK_TNEG_MAT_REFERENCE_TADM_PER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_RESULTADOS') and o.name = 'FK_TNEG_RES_REFERENCE_TNEG_MAT')
alter table TNEG_RESULTADOS
   drop constraint FK_TNEG_RES_REFERENCE_TNEG_MAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TNEG_RESULTADOS') and o.name = 'FK_TNEG_RES_REFERENCE_TNEG_ASI')
alter table TNEG_RESULTADOS
   drop constraint FK_TNEG_RES_REFERENCE_TNEG_ASI
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
           where  id    = object_id('TNEG_ASIGNACION_DOCENTE')
            and   name  = 'U_ASIG_DOC'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_ASIGNACION_DOCENTE.U_ASIG_DOC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_ASIGNACION_DOCENTE')
            and   type = 'U')
   drop table TNEG_ASIGNACION_DOCENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_COMPONENTE_EDUCATIVO')
            and   name  = 'U_COM_EDU'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_COMPONENTE_EDUCATIVO.U_COM_EDU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_COMPONENTE_EDUCATIVO')
            and   type = 'U')
   drop table TNEG_COMPONENTE_EDUCATIVO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_MATRICULA')
            and   name  = 'U_MATRICULA'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_MATRICULA.U_MATRICULA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_MATRICULA')
            and   type = 'U')
   drop table TNEG_MATRICULA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TNEG_RESULTADOS')
            and   name  = 'U_RESULTADO'
            and   indid > 0
            and   indid < 255)
   drop index TNEG_RESULTADOS.U_RESULTADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TNEG_RESULTADOS')
            and   type = 'U')
   drop table TNEG_RESULTADOS
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
/* Table: TNEG_ASIGNACION_DOCENTE                               */
/*==============================================================*/
create table TNEG_ASIGNACION_DOCENTE (
   ASD_ID               int                  identity,
   COE_ID               int                  not null,
   PER_ID               int                  not null,
   ASD_FECHA            datetime             not null,
   constraint PK_TNEG_ASIGNACION_DOCENTE primary key (ASD_ID)
)
go

/*==============================================================*/
/* Index: U_ASIG_DOC                                            */
/*==============================================================*/
create unique index U_ASIG_DOC on TNEG_ASIGNACION_DOCENTE (
COE_ID ASC,
PER_ID ASC
)
go

/*==============================================================*/
/* Table: TNEG_COMPONENTE_EDUCATIVO                             */
/*==============================================================*/
create table TNEG_COMPONENTE_EDUCATIVO (
   COE_ID               int                  identity,
   COE_CODIGO           varchar(15)          not null,
   COE_NOMBRE           varchar(80)          not null,
   constraint PK_TNEG_COMPONENTE_EDUCATIVO primary key (COE_ID)
)
go

/*==============================================================*/
/* Index: U_COM_EDU                                             */
/*==============================================================*/
create unique index U_COM_EDU on TNEG_COMPONENTE_EDUCATIVO (
COE_CODIGO ASC
)
go

/*==============================================================*/
/* Table: TNEG_MATRICULA                                        */
/*==============================================================*/
create table TNEG_MATRICULA (
   MAT_ID               int                  identity,
   COE_ID               int                  not null,
   PER_ID               int                  not null,
   MAT_FECHA            datetime             not null,
   constraint PK_TNEG_MATRICULA primary key (MAT_ID)
)
go

/*==============================================================*/
/* Index: U_MATRICULA                                           */
/*==============================================================*/
create unique index U_MATRICULA on TNEG_MATRICULA (
COE_ID ASC,
PER_ID ASC
)
go

/*==============================================================*/
/* Table: TNEG_RESULTADOS                                       */
/*==============================================================*/
create table TNEG_RESULTADOS (
   RES_ID               int                  identity,
   MAT_ID               int                  not null,
   ASD_ID               int                  not null,
   RES_DEBERES          float                not null,
   RES_EXAMEN           float                not null,
   RES_FECHA            datetime             not null,
   constraint PK_TNEG_RESULTADOS primary key (RES_ID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TNEG_RESULTADOS')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RES_DEBERES')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TNEG_RESULTADOS', 'column', 'RES_DEBERES'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador del Rol Usuario',
   'user', @CurrentUser, 'table', 'TNEG_RESULTADOS', 'column', 'RES_DEBERES'
go

/*==============================================================*/
/* Index: U_RESULTADO                                           */
/*==============================================================*/
create unique index U_RESULTADO on TNEG_RESULTADOS (
MAT_ID ASC,
ASD_ID ASC
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

alter table TNEG_ASIGNACION_DOCENTE
   add constraint FK_TNEG_ASI_REFERENCE_TNEG_COM foreign key (COE_ID)
      references TNEG_COMPONENTE_EDUCATIVO (COE_ID)
go

alter table TNEG_ASIGNACION_DOCENTE
   add constraint FK_TNEG_ASI_REFERENCE_TADM_PER foreign key (PER_ID)
      references TADM_PERSONA (PER_ID)
go

alter table TNEG_MATRICULA
   add constraint FK_TNEG_MAT_REFERENCE_TNEG_COM foreign key (COE_ID)
      references TNEG_COMPONENTE_EDUCATIVO (COE_ID)
go

alter table TNEG_MATRICULA
   add constraint FK_TNEG_MAT_REFERENCE_TADM_PER foreign key (PER_ID)
      references TADM_PERSONA (PER_ID)
go

alter table TNEG_RESULTADOS
   add constraint FK_TNEG_RES_REFERENCE_TNEG_MAT foreign key (MAT_ID)
      references TNEG_MATRICULA (MAT_ID)
go

alter table TNEG_RESULTADOS
   add constraint FK_TNEG_RES_REFERENCE_TNEG_ASI foreign key (ASD_ID)
      references TNEG_ASIGNACION_DOCENTE (ASD_ID)
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

