using System;
using System.Web.Mvc;
using Negocio.Api.Helpers;

namespace Negocio.Api
{
    public static class CustomModelBindersConfig
    {
        public static void RegisterCustomModelBinders()
        {
            //JSA. Aplicar Binder personalizado de fechas a todo el proyecto
            ModelBinders.Binders.Add(typeof(DateTime), new CustomDateBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableCustomDateBinder());
        
            //ModelBinders.Binders.Add(typeof(AuditoriaCriteria), new AuditoriaCriteriaBinder());
 
        
        }
    }
}