namespace Framework.Security
{

    /// <summary>
    /// gestion de identidades de usuarios
    /// </summary>
    public interface IIdentityUser
    {
        /// <summary>
        /// Obtener el identificador de la identidad del usuario
        /// </summary>
        /// <returns></returns>
        int GetCurrentIdentity();
    }
}
