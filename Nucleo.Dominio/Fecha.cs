using System.ComponentModel.DataAnnotations;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Dominio
{
    public class Fecha : DataTypeAttribute
    {
        public Fecha()
            : base(DataType.Date)
        {
            ErrorMessageResourceType = typeof(Mensajes);
            ErrorMessageResourceName = "DataTypeAttribute_DateValidationError";
        }
    }
}
