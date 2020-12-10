using Negocio.Dominio.Constantes;
using System;

namespace Negocio.Dominio.DTO
{
    public class ResultadoDTO
    {

        public int Id { get; set; }
        public int DocenteId { get; set; }
        public string DocentePrimerApellido { get; set; }
        public string DocenteSegundoApellido { get; set; }
        public string DocentePrimerNombre { get; set; }
        public string DocenteSegundoNombre { get; set; }
        public string DocenteIdentificacion { get; set; }
        public int EstudianteId { get; set; }
        public string EstudiantePrimerApellido { get; set; }
        public string EstudianteSegundoApellido { get; set; }
        public string EstudiantePrimerNombre { get; set; }
        public string EstudianteSegundoNombre { get; set; }
        public string EstudianteIdentificacion { get; set; }
        public int CoeId { get; set; }
        public string CoeCodigo { get; set; }
        public string CoeNombre { get; set; }
        public decimal Deberes { get; set; }
        public decimal Examen { get; set; }
        public int AsignacionDocenteId { get; set; }
        public int MatriculaId { get; set; }
        public DateTime Fecha { get; set; }

        public string EstudianteNombre()
        {
            return EstudiantePrimerNombre + " " + EstudianteSegundoNombre + " " + EstudiantePrimerApellido + " " + EstudianteSegundoApellido;
        }

        public string DocenteNombre()
        {
            return DocentePrimerNombre + " " + DocenteSegundoNombre + " " + DocentePrimerApellido + " " + DocenteSegundoApellido;
        }

        public decimal Promedio { get { return (Deberes + Examen) / 2; } }
        public string Estado { get { return Promedio < 7 ? ConstantesCatalogos.ITM_ESTADO_COE_REPROBADO : ConstantesCatalogos.ITM_ESTADO_COE_APROBARDO; } }

    }
}