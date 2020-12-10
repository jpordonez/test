using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Nucleo.Dominio;
using Framework.Logging;
using Framework.Repository;
using Nucleo.Dominio.Entidades;
using Negocio.Proceso.DTO;
using Negocio.Service;
using Framework.Exception;
using Framework.Util;

namespace Negocio.Proceso
{
    public class PromocionesEstados
    {
        /*private static readonly IApplication _application = ServiceLocator.Current.GetInstance<IApplication>();
        private static readonly IPromocionTextoService _promocionPorProductoService = ServiceLocator.Current.GetInstance<IPromocionTextoService>();
        private static readonly IPromocionVisualService _promocionPorImagenService = ServiceLocator.Current.GetInstance<IPromocionVisualService>();
        private static readonly IRepository<EjecucionProceso> _repositorioEjecucionProceso = ServiceLocator.Current.GetInstance<IRepository<EjecucionProceso>>();
        public static void Procesar()
        {
            Console.WriteLine("Iniciado PromocionesEstados.Procesar");
            var ultimaEjecucionProceso = _repositorioEjecucionProceso.GetList(ep => ep.UltimaEjecucion == 1 && ep.CodigoProceso == Constantes.PromocionesEstados).FirstOrDefault();
            DateTime fechaUltimaEjecucionProceso;
            DateTime fechaActual = _application.getDateTime();
            if (ultimaEjecucionProceso != null)
            {
                fechaUltimaEjecucionProceso = ultimaEjecucionProceso.FechaEjecucion;
            }
            else
            {
                //Fecha por defecto de ultima actualizacion
                fechaUltimaEjecucionProceso = new DateTime(2017, 1, 1);
            }

            actualizarEstadosYNotificar();

            var ejecucionProcesos = new List<EjecucionProceso>();

            if (ultimaEjecucionProceso != null)
            {
                ultimaEjecucionProceso.UltimaEjecucion = 0;
                ejecucionProcesos.Add(ultimaEjecucionProceso);
            }

            var ejecucionProceso = new EjecucionProceso();
            ejecucionProceso.FechaEjecucion = fechaActual;
            ejecucionProceso.CodigoProceso = Constantes.PromocionesEstados;
            ejecucionProceso.UltimaEjecucion = 1;
            ejecucionProcesos.Add(ejecucionProceso);

            _repositorioEjecucionProceso.SaveOrUpdate(ejecucionProcesos);

            Console.WriteLine("Ejecutado satisfactoriamente PromocionesEstados.Procesar");

        }

        private static void actualizarEstadosYNotificar()
        {
            var promociones = actualizarEstados();
            notificar(promociones);
        }

        private static IList<PromocionDTO> actualizarEstados()
        {
            var _manejadorSP = ServiceLocator.Current.GetInstance<IStoreProcedureRepository<PromocionDTO>>();

            var parametros = new List<Object>();

            var resultado = _manejadorSP.SpConResultados("pro_act_promociones", parametros, true);

            Console.WriteLine("Ejecutado satisfactoriamente pro_act_promociones");

            return resultado;
        }

        private static void notificar(IList<PromocionDTO> promociones)
        {
            Console.WriteLine("Total resultados: " + promociones.Count());
            foreach (var pn in promociones)
            {
                Console.WriteLine("id:" + pn.id + ", tipo:" + pn.tipo);
                switch (pn.tipo)
                {
                    case 1:
                        notificacionPorProducto(pn.id);
                        break;
                    case 2:
                        notificacionPorImagen(pn.id);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Ejecutado satisfactoriamente notificaciones");
        }

        private static void notificacionPorProducto(int id)
        {
            var pmt = _promocionPorProductoService.Get(id);
            var localidades = pmt.ProductosFarmacias.Select(f => f.Farmacia.Localidad).Where(l => !string.IsNullOrEmpty(l)).Distinct();
            foreach (var localidad in localidades)
            {
                try
                {
                    var data = new
                    {
                        to = "/topics/" + localidad,
                        data = new
                        {
                            Id = pmt.Id,
                            mensaje = pmt.Descripcion,
                            FarmaciaNombre = pmt.ProductosFarmacias.Select(f => f.Farmacia).FirstOrDefault(f => localidad.Equals(f.Localidad))?.Nombre,
                            FechaDesde = pmt.FechaDesde.ToString("o"),
                            FechaHasta = pmt.FechaHasta.ToString("o"),
                            Productos = pmt.ProductosFarmacias.Select(p => new { p.Producto.Id, p.Producto.Nombre }),
                            Tipo = "Producto"
                        },
                        notification = new
                        {
                            body = pmt.Descripcion,
                            title = "Promoción",
                            sound = "default",
                            click_action = "FCM_PLUGIN_ACTIVITY"
                        }
                    };
                    FCM.enviarMensaje(data);
                    Console.WriteLine("Notificacion Por Producto Correcta, id: " + id);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Notificacion Por Producto Falla, id: " + id);
                }
            }
        }

        private static void notificacionPorImagen(int id)
        {
            var pv = _promocionPorImagenService.Get(id);
            var localidades = pv.Farmacias.Select(f => f.Localidad).Where(l => !string.IsNullOrEmpty(l)).Distinct();
            foreach (var localidad in localidades)
            {
                try
                {
                    var data = new
                    {
                        to = "/topics/" + localidad,
                        data = new
                        {
                            Id = pv.Id,
                            mensaje = "Nueva Promoción",
                            FarmaciaNombre = pv.Farmacias.FirstOrDefault(f => localidad.Equals(f.Localidad))?.Nombre,
                            FechaDesde = pv.FechaDesde.ToString("o"),
                            FechaHasta = pv.FechaHasta.ToString("o"),
                            Tipo = "Imagen"
                        },
                        notification = new
                        {
                            body = "Nueva Promoción",
                            title = "Promoción",
                            sound = "default",
                            click_action = "FCM_PLUGIN_ACTIVITY"
                        }
                    };
                    FCM.enviarMensaje(data);
                    Console.WriteLine("Notificacion Por Imagen Correcta, id: " + id);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Notificacion Por Imagen Falla, id: " + id);
                }
            }
        }*/

    }
}
