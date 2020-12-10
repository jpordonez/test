using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace Framework.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public static class ModelStateExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static IDictionary ToSerializedDictionary(this ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
                k => k.Key,
                v => v.Value.Errors.Select(x => x.ErrorMessage).ToArray()
            );
        }

        //public static IEnumerable<Error> AllErrors(this ModelStateDictionary modelState)
        //{
        //    var result = new List<ModelError>();
        //    var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
        //                                    .Select(x => new { x.Key, x.Value.Errors });

        //    foreach (var erroneousField in erroneousFields)
        //    {
        //        var fieldKey = erroneousField.Key;
        //        var fieldErrors = erroneousField.Errors
        //                           .Select(error => new ModelError(fieldKey, error.ErrorMessage));
        //        result.AddRange(fieldErrors);
        //    }

        //    return result;
        //}

    }

    public class Error
    {
        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
