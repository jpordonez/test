using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StackExchange.Profiling;
using ServiceStack.MiniProfiler.EF6;
using System;
using System.Text;
using Recursos.Web;

namespace Negocio.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Para incrementar la longitud permitida de json
            ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().FirstOrDefault());
            ValueProviderFactories.Factories.Add(new MyJsonValueProviderFactory());

            IoCConfig.Register();

            if (IsDebug)
            {
                //MiniProfiler.Start();
                MiniProfilerEF6.Initialize();
            }

            //Binder Personalizados
            CustomModelBindersConfig.RegisterCustomModelBinders();

        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal && IsDebug)
            {
                MiniProfiler.Start();
            }
        }


        protected void Application_EndRequest()
        {
            if (Request.IsLocal && IsDebug)
            {
                MiniProfiler.Stop();
            }
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                //Solo se requiere autenticacion para elmah.
                if (Request.Url.AbsolutePath.ToLowerInvariant().Contains("elmah.axd"))
                {
                    if (Request.UrlReferrer == null || !Request.UrlReferrer.AbsolutePath.ToLowerInvariant().Contains("Cuenta/LogOn"))
                    {
                        // Possible that a partially rendered page has already been written to response 
                        // buffer before encountering error, so clear it.
                        Response.Clear();
                        Response.Redirect("~/Cuenta/LogOn");
                    }
                    else
                    {
                        //Para evitar la redireccion a Login.aspx
                        Response.SuppressFormsAuthenticationRedirect = true;
                    }
                }
                else
                {
                    //Para evitar la redireccion a Login.aspx
                    Response.SuppressFormsAuthenticationRedirect = true;
                }
            }
            else
            {
                //Para evitar la redireccion a Login.aspx
                Response.SuppressFormsAuthenticationRedirect = true;
            }
        }

        public static bool IsDebug
        {
            get
            {
                bool debug = false;
#if DEBUG
                debug = true;
#endif
                return debug;
            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            var ex = Server.GetLastError();

            Response.StatusCode = 409;
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.UTF8;

            Response.Write("{\"mensaje\":\"" + Mensajes.ErrorGenerico + "\",");
            Response.Write("\"presentar\":true}");

            Response.End();

            // Clear the error from the server
            Server.ClearError();
        }

    }
}
