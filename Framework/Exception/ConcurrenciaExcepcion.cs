namespace Framework.Exception
{
    public class ConcurrenciaExcepcion : System.Exception
    {
        public ConcurrenciaExcepcion(string mensaje)
            :base(mensaje)
        {
        }
    }
    
}