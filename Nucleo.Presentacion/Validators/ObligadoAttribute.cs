using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nucleo.Dominio.Recursos;

namespace Nucleo.Presentacion.Validators
{
    public class ObligadoAttribute : RequiredAttribute, IClientValidatable
    {
        public ObligadoAttribute()
        {
            ErrorMessageResourceType = typeof (Mensajes);
            ErrorMessageResourceName = "RequiredAttribute_ValidationError";
        }

        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string msg = FormatErrorMessage(metadata.GetDisplayName());
            yield return new ModelClientValidationRequiredRule(msg);
        }
    }
}