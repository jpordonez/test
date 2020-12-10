using Framework;
using Framework.Repository;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Dominio
{

    public interface ISesionRepository<TEntity> : IRepository<TEntity>
        where TEntity : Sesion
    {

        /// <summary>
        /// Busca sesiones. El resultado es paginado segun los parametros
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="Skip"></param>
        /// <param name="Take"></param>
        /// <returns></returns>
        IPagedListMetaData<Sesion> Buscar(SesionCriteria criteria, int Skip, int Take);
    }
}
