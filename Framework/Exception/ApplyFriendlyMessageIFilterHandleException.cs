
using Nucleo.Dominio.Recursos;
using System.Data.Entity.Validation;
using System.Linq;

namespace Framework.Exception
{

    /// <summary>
    /// Aplicar un mensaje amigable para visualizar al usaurio, basado en varios criterios
    /// </summary>

    public class ApplyFriendlyMessageIFilterHandleException : IFilterHandleException
    {
        public HandleExceptionResult HandleException(System.Exception originalException, HandleExceptionResult result)
        {
            //TODO: JSA, APLICAR CADENA DE RESPONSABILIDAD
            System.Exception _innerException = originalException;


            if (_innerException.GetType() == typeof(GenericException))
            {
                var genericException = _innerException as GenericException;
                result.TypeResult = TypeResult.Information;
                result.Message = genericException.FriendlyMessage;
            }
            else
            {
                if (_innerException.GetType() == typeof(ConcurrenciaExcepcion))
                {
                    result.TypeResult = TypeResult.Error;
                    result.Message = Mensajes.ErrorConcurrencia;
                }
                else
                {
                    if (_innerException.GetType() == typeof(NegocioExcepcion))
                    {
                        var negocioException = _innerException as NegocioExcepcion;
                        result.TypeResult = TypeResult.Error;
                        result.Message = negocioException.FriendlyMessage;
                    }
                    else
                    {
                        if (_innerException.GetType() == typeof(DbEntityValidationException))
                        {
                            var dbEntityValidationException = _innerException as DbEntityValidationException;
                            result.TypeResult = TypeResult.Error;
                            var errorMessages = dbEntityValidationException.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);
                            var fullErrorMessage = string.Join("; ", errorMessages);
                            result.Message = fullErrorMessage;
                        }
                        else
                        {
                            //Default 
                            result.TypeResult = TypeResult.Error;
                            result.Message = Mensajes.ErrorGenerico;
                        }
                    }
                }
            }

            return result;
        }

    }
}
