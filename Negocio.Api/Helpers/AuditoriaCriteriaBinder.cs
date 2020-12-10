using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using Nucleo.Dominio;
using Nucleo.Dominio.Criterias;

namespace Negocio.Api.Helpers
{
    public class AuditoriaCriteriaBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            //TODO: JSA, ESTA QUEMADO EL VALOR DE LAS VARIABLES Criteria., CON LO QUE SE ENCUENTRA EN LA VISTA 
            //model.Criteria.Identificador

            string Funcionalidad = request.Params.Get("Criteria.Funcionalidad")??request.Params.Get("Funcionalidad");
            string Accion = request.Params.Get("Criteria.Accion") ?? request.Params.Get("Accion");
            string Identificador = request.Params.Get("Criteria.Identificador") ?? request.Params.Get("Identificador");
            string Usuario = request.Params.Get("Criteria.Usuario") ?? request.Params.Get("Usuario");
            string FechaInicioString = request.Params.Get("Criteria.FechaInicio") ?? request.Params.Get("FechaInicio");
            string FechaFinalString = request.Params.Get("Criteria.FechaFinal") ?? request.Params.Get("FechaFinal");

            DateTime? FechaInicio = null;
            DateTime? FechaFinal = null;
            try
            {
                CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();

                FechaInicio = DateTime.Parse(FechaInicioString);
             }
            catch (Exception ex)
            {
                
            }

            try
            {
                CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();

                FechaFinal = DateTime.Parse(FechaFinalString);
            }
            catch (Exception ex)
            {

            }

            return new AuditoriaCriteria() 

            {
                Funcionalidad = Funcionalidad,
                Accion = Accion,
                Identificador = Identificador,
                Usuario = Usuario,
                FechaInicio = FechaInicio,
                FechaFinal = FechaFinal
                //Date = day + "/" + month + "/" + year
            };
        }
    } 
}