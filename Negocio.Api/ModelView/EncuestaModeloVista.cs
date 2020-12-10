using System.Collections.Generic;

namespace Negocio.Api.Models
{

    public class OpcionModeloVista
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Orden { get; set; }
        public string Texto { get; set; }        
        public string FechaCreacion { get; set; }
    }

    public class PreguntaModeloVista
    {
        public PreguntaModeloVista()
        {
            Opciones = new List<OpcionModeloVista>();
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Orden { get; set; }
        public string Texto { get; set; }
        public int TipoId { get; set; }
        public List<int> Respuestas { get; set; }
        public string Respuesta { get; set; }
        public string FechaCreacion { get; set; }
        public List<OpcionModeloVista> Opciones { get; set; }
    }

    public class GruposModeloVista
    {
        public GruposModeloVista()
        {
            Preguntas = new List<PreguntaModeloVista>();
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Orden { get; set; }
        public string Texto { get; set; }
        public bool TieneGrupo { get; set; }
        public string FechaCreacion { get; set; }
        public List<PreguntaModeloVista> Preguntas { get; set; }
    }

    public class EncuestaModeloVista
    {
        public EncuestaModeloVista()
        {
            Grupos = new List<GruposModeloVista>();
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int PeriodoAcademicoId { get; set; }
        public int ProgramaAcademicoId { get; set; }
        public int CentroId { get; set; }
        public int ModuloId { get; set; }
        public string Instructor { get; set; }
        public string Descripcion { get; set; }
        public string Funcion { get; set; }
        public string FechaCreacion { get; set; }
        public string param { get; set; }
        public List<GruposModeloVista> Grupos { get; set; }
    }

}