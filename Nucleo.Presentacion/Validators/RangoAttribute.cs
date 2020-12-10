using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Presentacion.Validators
{
    public class RangoAttribute : RangeAttribute, IClientValidatable
    {
        public RangoAttribute(int minimum, int maximum)
            : base(minimum, maximum)
        {
            ErrorMessageResourceType = typeof(Mensajes);
            ErrorMessageResourceName = "RangeAttribute_ValidationError";
        }

        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string msg = FormatErrorMessage(metadata.GetDisplayName());
            yield return new ModelClientValidationRangeRule(msg, Minimum, Maximum);
        }
    }
}