﻿using System;
using System.Globalization;
using System.Web.Mvc;

namespace Negocio.Api.Helpers
{
    public class CustomDateBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext", "controllerContext is null.");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext", "bindingContext is null.");

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
                throw new ArgumentNullException(bindingContext.ModelName);

            //CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //cultureInf.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);

            try
            {
                var date = DateTime.Parse(value.RawValue.ToString(), null,
                        DateTimeStyles.RoundtripKind);
                //var date = value.ConvertTo(typeof(DateTime));

                return date;
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex);
                return null;
            }
        }
    }

}