using System;
using Framework.Auditoria;
using Framework.Logging;
using NLog;
using Nucleo.Dominio;

namespace Infrastructure.Logging.Nlog
{
    public class LogAuditoriaFactory : AbstractLogAuditoriaFactory
    {
        private IApplication _application;

        public LogAuditoriaFactory(IApplication application) {
            _application = application;
        }
        public override ILogAuditoria Create(string name)
        {
           
            Logger logger = LogManager.GetLogger(name);

            return new LogAuditoria(this,logger, _application);
        }

        public override ILogAuditoria Create(string name, LoggerLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
