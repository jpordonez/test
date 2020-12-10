using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Nucleo.Dominio.Recursos;
using Nucleo.Presentacion.Validators;

namespace Nucleo.Presentacion.Models
{
    public class ConsultaAsistenciaEstudianteViewModel
    {
        public string EstudianteId { get; set; }

        [Obligado]
        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Cedula_DisplayName")]
        public string Cedula { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Nombre_DisplayName")]
        public string Nombre { get; set; }

        [DisplayName("Período:")]
        public string Periodo { get; set; }
        public ConsultaAsistenciaEstudianteItem[] Elementos { get; set; }

        public string[] PeriodosEstudiante{ get; set; } 

    }

    public class ConsultaAsistenciaEstudianteItem
    {
        public string CodigoAsignatura { get; set; }
        
        public string Asignatura { get; set; }

        public string Periodo { get; set; }

        public int Nrc { get; set; }

        public string Identificador_Curso { get; set; }
        
        public int Total { get; set; }
        
        public int Asistencias { get; set; }

        public int Inasistencias { get; set; }

        public int InasistenciasJustificadas { get; set; }

        public int Faltas { get; set; }
        
        public decimal Porciento { get; set; }
        
        public bool Highlight { get; set; }
    }

    public class DetallesAsistenciasEstudianteViewModel
    {
        public string EstudianteId { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Cedula_DisplayName")]
        public string Cedula { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Nombre_DisplayName")]
        public string Nombre { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_CodigoAsignatura_DisplayName")]
        public string CodigoAsignatura { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Asignatura_DisplayName")]
        public string Asignatura { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Periodo_DisplayName")]
        public string Periodo { get; set; }

         [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Nrc_DisplayName")]
        public int Nrc { get; set; }

         [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Identificador_Curso_DisplayName")]
        public string Identificador_Curso { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Total_DisplayName")]
        public int Total { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Asistencias_DisplayName")]
        public int Asistencias { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Inasistencias_DisplayName")]
        public int Inasistencias { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_InasistenciasJustificadas_DisplayName")]
        public int InasistenciasJustificadas { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Faltas_DisplayName")]
        public int Faltas { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Porciento_DisplayName")]
        [DisplayFormat(DataFormatString = "{0}%")]
        public decimal Porciento { get; set; }
        
        public bool Highlight { get; set; }
        
        public DetallesAsistenciasEstudianteItem[] Elementos { get; set; }
    }

    public class DetallesAsistenciasEstudianteItem
    {
        [Display(ResourceType = typeof (Titulos), Name = "Consultas_AsistenciaEstudiante_Fecha_DisplayName")]
        public DateTime Fecha { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Horario_DisplayName")]
        public string Horario { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Docente_DisplayName")]
        public string Docente { get; set; }

        [Display(ResourceType = typeof(Titulos), Name = "Consultas_AsistenciaEstudiante_Inasistencia_DisplayName")]
        public bool Inasistencia { get; set; }

        [Display(ResourceType = typeof (Titulos), Name = "Consultas_AsistenciaEstudiante_InasistenciaJustificada_DisplayName")]
        public bool InasistenciaJustificada { get; set; }
    }

}