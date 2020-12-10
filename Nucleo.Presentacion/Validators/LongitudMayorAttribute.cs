using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Presentacion.Validators
{
    public class LongitudMayorAttribute : MaxLengthAttribute, IClientValidatable
    {
        public LongitudMayorAttribute(int length)
            : base(length)
        {
            ErrorMessageResourceType = typeof(Mensajes);
            ErrorMessageResourceName = "MaxLengthAttribute_ValidationError";
        }

        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string msg = FormatErrorMessage(metadata.GetDisplayName());
            yield return new ModelClientValidationMaxLengthRule(msg, Length);
        }
    }
}