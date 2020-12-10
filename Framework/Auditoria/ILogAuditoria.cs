namespace Framework.Auditoria
{
    public interface ILogAuditoria
    {

        void Write(string accion, string mensaje);
    }
}
