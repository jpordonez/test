Ejecutar sps 
pro_obt_horarios_atencion
pro_obt_horarios_turno

/*==============================================================*/
/* Index: U_CORREO                                              */
/*==============================================================*/
create unique index U_CORREO on TADM_PERSONA (
PER_CORREO ASC
)
go

Deploy 23 de agosto 2017

pro_obt_suscripciones.sql

Deploy 24 de agosto 2017

pro_obt_horarios_turno.sql
pro_obt_horarios_atencion.sql
pro_obt_farmacias_usuarios.sql
pro_obt_farmacia_productos.sql

Agregar columna PFR_EN_STOCK en TNEG_PRODUCTO_FARMACIA
Agregar columnas en TBAT_EJECUCION_PROCESO

/*==============================================================*/
/* Index: UX_FARMACIA                                           */
/*==============================================================*/
create unique index UX_FARMACIA on dbo.TNEG_FARMACIA (
FAR_NOMBRE ASC,
FAR_DIRECCION ASC
)
go

Deploy 1 de septiembre 2017

Actualizar tabla productos

pro_obt_productos.sql
pro_obt_farmacia_productos.sql

Deploy 7 de septiembre 2017

ALTER TABLE [dbo].[TNEG_FARMACIA] ADD FAR_LOGO_THUMBAIL IMAGE NULL
ALTER TABLE [dbo].[TNEG_PROMOCION_VISUAL] ADD PMV_IMAGEN_THUMBAIL IMAGE NOT NULL

pro_obt_promociones_textos.sql
pro_obt_promociones_textos_movil.sql
pro_obt_promociones_visuales.sql
pro_obt_promociones_visuales_movil.sql
pro_obt_farmacias_movil.sql

/*==============================================================*/
/* Table: TNEG_PRO_FAR_PRO_TEXTO                                */
/*==============================================================*/
create table dbo.TNEG_PRO_FAR_PRO_TEXTO (
   PPT_ID               int                  identity,
   PFR_ID               int                  not null,
   PMT_ID               int                  not null,
   constraint PK_TNEG_PRO_FAR_PRO_TEXTO primary key (PPT_ID)
)
go

/*==============================================================*/
/* Table: TNEG_PROMOCION_TEXTO                                  */
/*==============================================================*/
create table dbo.TNEG_PROMOCION_TEXTO (
   PMT_ID               int                  identity,
   PMT_DESCRIPCION      varchar(100)         not null,
   PMT_FECHA_DESDE      smalldatetime        not null,
   PMT_FECHA_HASTA      smalldatetime        not null,
   PMT_ESTADO           int                  not null,
   VERSION              int                  not null,
   constraint PK_TNEG_PROMOCION_TEXTO primary key (PMT_ID)
)
go

alter table dbo.TNEG_PRO_FAR_PRO_TEXTO
   add constraint FK_TNEG_PRO_FAR_REFERENCE_TNEG_PRO_TEX foreign key (PFR_ID)
      references dbo.TNEG_PRODUCTO_FARMACIA (PFR_ID)
go

alter table dbo.TNEG_PRO_FAR_PRO_TEXTO
   add constraint FK_TNEG_PPT_REFERENCE_TNEG_PMT foreign key (PMT_ID)
      references dbo.TNEG_PROMOCION_TEXTO (PMT_ID)
go

