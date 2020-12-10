namespace Framework.Exception
{
    public class ProcedimientoAlmacenadoExcepcion : System.Exception
    {
        public ProcedimientoAlmacenadoExcepcion(string mensaje,System.Exception exception)
            : base(mensaje, exception)
        {
        }
    }
}
