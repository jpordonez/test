using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine.Text;
using CommandLine;

namespace Negocio.Proceso
{
    /// <summary>
    /// Las opciones que existen en la linea de commandos
    /// </summary>
    public sealed class OptionCommand
    {
        static readonly HeadingInfo _headingInfo =
            new HeadingInfo("Consola", "1.0");

        [Option('a', "action", Required = true, HelpText = "Accion a ejecutar")]
        public string Action { get; set; }

        [Option('u', "user", Required = true, HelpText = "Usuario para ejecutar consola")]
        public string Usuario { get; set; }

        [Option('r', "rol", Required = true, HelpText = "Codigo de Rol para ejecutar consola, el rol debe estar asociado al usuario")]
        public string Rol { get; set; }
      

     
        [HelpOption(HelpText = "Visualizar ayuda")]
        public string GetUsage()
        {
            var help = new HelpText(_headingInfo)
            {
                AdditionalNewLineAfterOption = true,
                Copyright = new CopyrightInfo("UDLA", DateTime.Now.Year)
            };


            help.AddPreOptionsLine("Consola");
            help.AddPreOptionsLine("Uso: Udla.CarpetaLinea.Consola -a <accion> ");
            help.AddPreOptionsLine("\tAcciones:");
            help.AddPreOptionsLine("\t\tINSTALL Instalación del Sistema");
            help.AddPreOptionsLine("\t\tCLEAR_CACHE Limpiar cache  del Sistema");
            help.AddPreOptionsLine("\t\tREGAESTSESNOINI Registrar asistencia estudiantes para la sesiones en las que el docente no inicio la clase");
            help.AddPreOptionsLine("\t\tORQUESTADORETLS Orquestador ETLS");
    
            help.AddOptions(this);
            return help;
        }
    }
}
