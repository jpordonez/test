using System;

namespace Negocio.Dominio.DTO
{
    public class OfertaProgramaDTO
    {

        public int Id { get; set; }

        public int PeriodoAcademicoId { get; set; }

        public string PeriodoAcademicoNombre { get; set; }

        public int EncuestaId { get; set; }

        public string EncuestaDescripcion { get; set; }

        public int CentroId { get; set; }

        public string CentroNombre { get; set; }

        public int UniversidadUsuarioId { get; set; }

        public string DocenteNombre => Nombres + " " + Apellidos;

        public string Apellidos => PrimerApellido + " " + SegundoApellido;

        public string Nombres => PrimerNombre + " " + SegundoNombre;

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public int ProgramaId { get; set; }

        public string ProgramaNombre { get; set; }

        public int ModuloId { get; set; }

        public string ModuloNombre { get; set; }

        public DateTime FechaCreacion { get; set; }

    }

}