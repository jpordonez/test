using Framework.Service;
using Negocio.Dominio.Codigos;

namespace Nucleo.Service
{
    public class MetaDataPaginacionServicio : IMetaDataPaginacionServicio
    {


        private readonly IParametroService _parametroService;

        public MetaDataPaginacionServicio(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }

        public int getPageSize() {
            var pageSize = _parametroService.GetValor<int>(CodigosParametros.PARAMETRO_TAMAÑO_PAGINA_GRILLAS);
            return pageSize;
        }

    }
}
