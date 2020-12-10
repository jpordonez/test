using System;
using System.IO;
using Framework.Logging;
using NLog;
using NLog.Config;

namespace Infrastructure.Logging.Nlog
{
    /// <summary>
    /// Implementation of <see cref="ILoggerFactory"/> for NLog.
    /// </summary>
    public class NLogFactory : AbstractLoggerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogFactory"/> class.
        /// </summary>
        //public NLogFactory()
        //    : this("NLog.config")
        //{
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="NLogFactory"/> class.
        ///// </summary>
        ///// <param name="configFile">The config file.</param>
        //public NLogFactory(string configFile)
        //{
        //    FileInfo file = GetConfigFile(configFile);
        //    LogManager.Configuration = new XmlLoggingConfiguration(file.FullName);
        //}
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogFactory"/> class.
        /// </summary>
        /// <param name="configFile">The config file.</param>
        public NLogFactory()
        {
            //PRIORIDAD DE BUSQUEDA
            //1. Archivo NLog.config
            //2. Archivo Web.config
            //3. Archivo App.config
            FileInfo file = null;
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NLog.config")))
                file = GetConfigFile("NLog.config");
            else
            {
                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config")))
                {
                    file = GetConfigFile("Web.config");
                }
                else
                {
                    if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config")))
                    {
                        file = GetConfigFile("App.config");
                    }
                }
            }

            if (file != null)
                LogManager.Configuration = new XmlLoggingConfiguration(file.FullName);
        }

        /// <summary>
        /// Creates a logger with specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override ILogger Create(String name)
        {
            Logger log = LogManager.GetLogger(name);
            return new NLogLogger(log, this);
        }

        /// <summary>
        /// Not implemented, NLog logger levels cannot be set at runtime.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException" />
        public override ILogger Create(String name, LoggerLevel level)
        {
            throw new NotImplementedException("Logger levels cannot be set at runtime. Please review your configuration file.");
        }
    }
}
