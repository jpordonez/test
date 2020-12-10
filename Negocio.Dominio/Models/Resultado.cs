namespace Negocio.Dominio.Models
{
    using Framework;
    using Negocio.Dominio.Constantes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Resultado : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int MatriculaId { get; set; }
        public int AsignacionDocenteId { get; set; }
        [Range(0, 10)]
        public decimal Deberes { get; set; }
        [Range(0, 10)]
        public decimal Examen { get; set; }
        public System.DateTime Fecha { get; set; }
        public virtual AsignacionDocente AsignacionDocente { get; set; }
        public virtual Matricula Matricula { get; set; }
        public decimal Promedio { get { return (Deberes + Examen) / 2; } }
        public string Estado { get { return Promedio < 7 ? ConstantesCatalogos.ITM_ESTADO_COE_REPROBADO : ConstantesCatalogos.ITM_ESTADO_COE_APROBARDO; } }

    }
}
