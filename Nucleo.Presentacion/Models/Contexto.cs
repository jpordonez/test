using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Reflection;
using Nucleo.Data.EF.Mapping;
using Nucleo.Dominio.Entidades;
using Nucleo.Dominio.Menus;
using Nucleo.Dominio.Seguridad;
using Nucleo.Dominio.Models;
using Negocio.Dominio.Models;

namespace Nucleo.Presentacion.Models
{

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
            //Disable initializer
            // Database.SetInitializer<UdlaContext>(new DropCreateDatabaseIfModelChanges<UdlaContext>());
            Database.SetInitializer<Contexto>(null);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UdlaContext, Migrations.Configuration>("CarpetaLineaContext"));


            //Aplicar logs
            //var logs = ConfigurationManager.AppSettings["Udla.BaseDatos.Logs"];

            //var aplicarLogs = false;
            //bool.TryParse(logs, out aplicarLogs);

            //if (aplicarLogs)
            //{
            //    //Database.Log = l => log.Info(l); 
            //}
        }

        public virtual DbSet<Institucion> TADM_INSTITUCION { get; set; }
        public virtual DbSet<Persona> TADM_PERSONA { get; set; }
        public virtual DbSet<Accion> TSEG_ACCION { get; set; }
        public virtual DbSet<Auditoria> TAUD_AUDITORIA { get; set; }
        public virtual DbSet<Catalogo> TADM_CATALOGO { get; set; }
        public virtual DbSet<EjecucionProceso> TBAT_EJECUCION_PROCESO { get; set; }
        public virtual DbSet<Funcionalidad> TSEG_FUNCIONALIDAD { get; set; }
        public virtual DbSet<ItemCatalogo> TADM_ITEMCATALOGO { get; set; }
        public virtual DbSet<Menu> TSEG_MENU { get; set; }
        public virtual DbSet<MenuItem> TSEG_MENUSITEM { get; set; }
        public virtual DbSet<ParametroOpcion> TADM_PARAMETRO_OPCIONES { get; set; }
        public virtual DbSet<ParametroSistema> TADM_PARAMETROSISTEMA { get; set; }
        public virtual DbSet<Permiso> TSEG_PERMISOS { get; set; }
        public virtual DbSet<Rol> TSEG_ROL { get; set; }
        public virtual DbSet<Sesion> TSEG_SESION { get; set; }
        public virtual DbSet<Sistema> TSEG_SISTEMA { get; set; }
        public virtual DbSet<Usuario> TSEG_USUARIO { get; set; }        
        public virtual DbSet<SitioContacto> TNEG_SITIO_CONTACTO { get; set; }
        public virtual DbSet<SitioSuscriptor> TNEG_SITIO_SUSCRIPTOR { get; set; }

        //TODO: Revisar si se puede separar los contextos nucleo y negocio
        //Negocio
        public virtual DbSet<AsignacionDocente> AsignacionDocente { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Resultado> Resultado { get; set; }
        public virtual DbSet<ComponenteEducativo> ComponenteEducativo { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //Agregar las dll donde se encuentra las configuraciones de los mappers
            Assembly assemblyNucleo = typeof(SistemaMap).Assembly;
            modelBuilder.Configurations.AddFromAssembly(assemblyNucleo);

            ////modelBuilder.Configurations.Add(new SistemaMap());

            //modelBuilder.Configurations.Add(new AgendaClaseExtraMap());
            //modelBuilder.Configurations.Add(new AgendaSalaDocenteMap());
            //modelBuilder.Configurations.Add(new AsistenciaDocenteMap());
            //modelBuilder.Configurations.Add(new AsistenciaEstudianteMap());
            //modelBuilder.Configurations.Add(new NumeroSesionesPeriodoAcademicoMap());
            //modelBuilder.Configurations.Add(new DiarioTematicoMap());
            //modelBuilder.Configurations.Add(new JustificacionEstudianteMap());
            //modelBuilder.Configurations.Add(new JustificacionDocenteMap());
            //modelBuilder.Configurations.Add(new ProgramacionAcademicaMap());
            //modelBuilder.Configurations.Add(new ModuloHorarioMap());
            //modelBuilder.Configurations.Add(new ModuloHorarioDiaMap());
            //modelBuilder.Configurations.Add(new EstudiantesCursoMap());
            //modelBuilder.Configurations.Add(new TipoMotivoMap());
            //modelBuilder.Configurations.Add(new PeriodoAcademicoMap());
            //modelBuilder.Configurations.Add(new ResultadoAsistenciaMap());
            //modelBuilder.Configurations.Add(new AgendasConsecutivasMap());
            //modelBuilder.Configurations.Add(new ParametroMap());
            //base.OnModelCreating(modelBuilder);
            //var config = new Configuration();

            //var migrator = new DbMigrator(config);

            //migrator.Update();

            modelBuilder.Entity<Institucion>()
                .ToTable("TADM_INSTITUCION")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.Id)
                .HasColumnName("INS_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.PersonaId)
                .HasColumnName("PER_ID");

            modelBuilder.Entity<Institucion>()
                .Property(e => e.RazonSocial)
                .HasColumnName("INS_RAZON_SOCIAL")
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.Ruc)
                .HasColumnName("INS_RUC")
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.InscritoId)
                .HasColumnName("ITM_INSCRITO");

            modelBuilder.Entity<Institucion>()
                .Property(e => e.LugarInscripcion)
                .HasColumnName("INS_LUGAR_INSCRIPCION")
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.NumeroAcuerdoRegistro)
                .HasColumnName("INS_NUMERO_ACUERDO_REGISTRO")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .ToTable("TADM_PERSONA")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Id)
                .HasColumnName("PER_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Persona>()
                .Property(e => e.PrimerNombre)
                .HasColumnName("PER_NOMBRE1")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.SegundoNombre)
                .HasColumnName("PER_NOMBRE2")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.PrimerApellido)
                .HasColumnName("PER_APELLIDO1")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.SegundoApellido)
                .HasColumnName("PER_APELLIDO2")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.TipoDocumento)
                .HasColumnName("ITM_TIPO_DOCUMENTO");

            modelBuilder.Entity<Persona>()
                .Property(e => e.Identificacion)
                .HasColumnName("PER_IDENTIFICACION")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Telefono)
                .HasColumnName("PER_TELEFONO")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Movil)
                .HasColumnName("PER_MOVIL")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Correo)
                .HasColumnName("PER_CORREO")
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.EstadoCivil)
                .HasColumnName("ITM_ESTADO_CIVIL");

            modelBuilder.Entity<AsignacionDocente>()
                .ToTable("TNEG_ASIGNACION_DOCENTE")
                .HasKey(e => e.Id);

            modelBuilder.Entity<AsignacionDocente>()
                .Property(e => e.Id)
                .HasColumnName("ASD_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AsignacionDocente>()
                .Property(e => e.ComponenteEducativoId)
                .HasColumnName("COE_ID");

            modelBuilder.Entity<AsignacionDocente>()
                .Property(e => e.DocenteId)
                .HasColumnName("PER_ID");

            modelBuilder.Entity<AsignacionDocente>()
                .Property(e => e.Fecha)
                .HasColumnName("ASD_FECHA");            

            modelBuilder.Entity<Matricula>()
                .ToTable("TNEG_MATRICULA")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Matricula>()
                .Property(e => e.Id)
                .HasColumnName("MAT_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            

            modelBuilder.Entity<Matricula>()
                .Property(e => e.EstudianteId)
                .HasColumnName("PER_ID");

            modelBuilder.Entity<Matricula>()
                .Property(e => e.ComponenteEducativoId)
                .HasColumnName("COE_ID");

            modelBuilder.Entity<Matricula>()
                .Property(e => e.Fecha)
                .HasColumnName("MAT_FECHA");              

            modelBuilder.Entity<ComponenteEducativo>()
                .ToTable("TNEG_COMPONENTE_EDUCATIVO")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ComponenteEducativo>()
                .Property(e => e.Id)
                .HasColumnName("COE_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ComponenteEducativo>()
                .Property(e => e.Codigo)
                .HasColumnName("COE_CODIGO")
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteEducativo>()
                .Property(e => e.Nombre)
                .HasColumnName("COE_NOMBRE")
                .IsUnicode(false);           

            modelBuilder.Entity<Resultado>()
                .ToTable("TNEG_RESULTADOS")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resultado>()
                .Property(e => e.Id)
                .HasColumnName("RES_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Resultado>()
                .Property(e => e.AsignacionDocenteId)
                .HasColumnName("ASD_ID");

            modelBuilder.Entity<Resultado>()
                .Property(e => e.MatriculaId)
                .HasColumnName("MAT_ID");

            modelBuilder.Entity<Resultado>()
                .Property(e => e.Deberes)
                .HasColumnName("RES_DEBERES");

            modelBuilder.Entity<Resultado>()
                .Property(e => e.Examen)
                .HasColumnName("RES_EXAMEN");

            modelBuilder.Entity<Resultado>()
                .Property(d => d.Fecha)
                .HasColumnName("RES_FECHA");

            /*
            modelBuilder.Entity<Encuesta>()
                .HasMany(e => e.EncuestaGrupos)
                .WithRequired(e => e.Encuesta)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Encuesta>()
                .HasMany(e => e.OfertaProgramas)
                .WithRequired(e => e.Encuesta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EncuestaGrupo>()
                .HasMany(e => e.Preguntas)
                .WithRequired(e => e.EncuestaGrupo)
                .WillCascadeOnDelete(true);            

            modelBuilder.Entity<Pregunta>()
                .HasMany(e => e.Opciones)
                .WithRequired(e => e.Pregunta)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Pregunta>()
                .HasMany(e => e.RespuestaTextos)
                .WithRequired(e => e.Pregunta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Opcion>()
                .HasMany(e => e.RespuestaOpciones)
                .WithRequired(e => e.Opcion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.RespuestaOpciones)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.RespuestaTextos)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Centro>()
                .HasMany(e => e.OfertaProgramas)
                .WithRequired(e => e.Centro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modulo>()
                .HasMany(e => e.OfertaProgramas)
                .WithRequired(e => e.Modulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PeriodoAcademico>()
                .HasMany(e => e.OfertaProgramas)
                .WithRequired(e => e.PeriodoAcademico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Programa>()
                .HasMany(e => e.Modulos)
                .WithRequired(e => e.Programa)
                .WillCascadeOnDelete(false);            

            modelBuilder.Entity<Universidad>()
                .HasMany(e => e.Centros)
                .WithRequired(e => e.Universidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Universidad>()
                .HasMany(e => e.Encuestas)
                .WithRequired(e => e.Universidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Universidad>()
                .HasMany(e => e.PeriodoAcademicos)
                .WithRequired(e => e.Universidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Universidad>()
                .HasMany(e => e.Programas)
                .WithRequired(e => e.Universidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Universidad>()
                .HasMany(e => e.UniversidadUsuarios)
                .WithRequired(e => e.Universidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UniversidadUsuario>()
                .HasMany(e => e.OfertaProgramas)
                .WithRequired(e => e.UniversidadUsuario)
                .WillCascadeOnDelete(false);*/

        }
    }
}
