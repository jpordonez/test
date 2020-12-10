using Framework;
using Framework.Security;
using Nucleo.Dominio.Criterias;
using Nucleo.Dominio.Seguridad;

namespace Nucleo.Dominio
{
    /// <summary>
    /// Repositorio para el usuario
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUsuarioRepository<TEntity>  
        where TEntity : class , IUsuario
    {

        /// <summary>
        /// Obtener el usuario por su identificador
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        Usuario Get(int id);

        /// <summary>
        /// Obtener el usuario por su cuenta
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Usuario Get(string cuenta);

        /// <summary>
        /// Obtener el usuario por su correo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetByPersona(int id);

        /// <summary>
        /// Guardar o Actualiza un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Usuario SaveOrUpdate(Usuario usuario);

        /// <summary>
        /// Busca registro de usuario. El resultado es paginado segun los parametros
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="Skip"></param>
        /// <param name="Take"></param>
        /// <returns></returns>
        IPagedListMetaData<IUsuario> Buscar(UsuarioCriteria criteria, int Skip, int Take);

        /// <summary>
        /// I'll let you guess what this does.
        /// </summary>
        void Delete(Usuario entity);

        bool ExisteUsuario(string cuenta);

    }
}
