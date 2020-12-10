using System.ComponentModel.DataAnnotations;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Presentacion.Validators
{
    public class FechaAttribute: DataTypeAttribute
    {
        public FechaAttribute() : base(DataType.Date)
        {
            ErrorMessageResourceType = typeof (Mensajes);
            ErrorMessageResourceName = "DataTypeAttribute_DateValidationError";
        }
    }
}