using Framework;
using Framework.Repository;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Entidades;

namespace Nucleo.Dominio
{

    public interface IAuditoriaRepository<TEntity> : IRepository<TEntity>
        where TEntity : Auditoria
    {

        /// <summary>
        /// Busca registro de auditoria. El resultado es paginado segun los parametros
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="Skip"></param>
        /// <param name="Take"></param>
        /// <returns></returns>
        IPagedListMetaData<Auditoria> Buscar(AuditoriaCriteria criteria, int Skip, int Take);
    }
}
