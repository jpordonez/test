using System;

namespace Negocio.Proceso
{
    /// <summary>
    /// Procesar Acciones
    /// </summary>
    public static class ProcesarAcciones
    {

        public static int Run(OptionCommand options)
        {

            switch (options.Action)
            {
                case Constantes.Instalar:

                    InstallProces.Procesar();

                    return Constantes.PROCESO_EXITO;


                case Constantes.LimpiarCacheSistema:

                    SystemProcess.Procesar();

                    return Constantes.PROCESO_EXITO;

                case Constantes.PromocionesEstados:

                    //PromocionesEstados.Procesar();

                    return Constantes.PROCESO_EXITO;                

                default:
                    Console.Error.WriteLine("Acción desconocida: {0}", options.Action);
                    return Constantes.PROCESO_ERROR;
            }
        }
    }
}
