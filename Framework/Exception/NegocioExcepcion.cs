namespace Framework.Exception
{
    public class NegocioExcepcion : System.Exception, IException
    {
        public string FriendlyMessage { get; set; }
        public NegocioExcepcion(string mensajeAmigable)
            :base(mensajeAmigable)
        {
            FriendlyMessage = mensajeAmigable;
        }
    }
}
