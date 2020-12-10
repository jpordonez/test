using System.Web;
using Framework.Auditoria;
using Framework.MVC;
using NLog;
using Nucleo.Dominio;
using Nucleo.Service;
using Microsoft.Practices.ServiceLocation;

namespace Infrastructure.Logging.Nlog
{
    public class LogAuditoria : ILogAuditoria
    {
        private readonly LogAuditoriaFactory _laf;
        private Logger _logger;
        private readonly IApplication _application;
        private readonly IPersonaService _iPersonaService;
        public LogAuditoria(LogAuditoriaFactory laf,
            Logger logger,
            IApplication application)
        {
            //_lei.Properties.Add("funcionalidad", logger.Name);

            _logger = logger;
            //_lei = lei;

            _laf = laf;
            //_logger = LogManager.GetLogger("auditoria");
            _application = application;
            _iPersonaService = ServiceLocator.Current.GetInstance<IPersonaService>();
        }

        public void Write(string accion, string mensaje)
        {

            var _lei = new LogEventInfo(LogLevel.Info, _logger.Name, _logger.Name);

            _lei.Properties.Add("accion", accion);

            if (_application.IsAuthenticated())
            {
                var personaId = _application.GetCurrentUser().PersonaId;
                if (personaId.HasValue)
                {
                    var persona = _iPersonaService.Get((int)personaId);
                    _lei.Properties.Add("indentificacion", persona.Identificacion);
                }
                else
                {
                    _lei.Properties.Add("indentificacion", "AN");
                }

            }
            else
            {
                _lei.Properties.Add("indentificacion", "AN");
            }


            //Almacenar IP
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                string ipAddress = RequestHelpers.GetClientIpAddress(new HttpRequestWrapper(HttpContext.Current.Request));

                _lei.Properties.Add("ip", ipAddress);
            }
            else
            {
                _lei.Properties.Add("ip", string.Empty);
            }

            _lei.Message = mensaje;

            _logger.Log(_lei);

        }
    }
}
