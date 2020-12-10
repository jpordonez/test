using Framework;
using Nucleo.Dominio;
using Nucleo.Dominio.DTO;

namespace Nucleo.Service
{
    public interface ISesionService
    {
        /// <summary>
        /// Obtener listado de Sesiones
        /// </summary>
        /// <returns></returns>
        IPagedListMetaData<SesionDTO> GetList(SesionCriteria criteria);
        
    }
}
