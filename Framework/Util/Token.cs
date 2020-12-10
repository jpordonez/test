using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace Framework.Util
{
    public class Token
    {

        private static IManagerDateTime _managerDateTime = ServiceLocator.Current.GetInstance<IManagerDateTime>();

        public static string GenerateToken(string secretKeyBase64, long userId, long rolId, long sesionId, int minutosExpiracionToken)
        {            
            var payload = new Dictionary<string, object>()
            {
                { "fechaCaducidad", _managerDateTime.Get().AddMinutes(minutosExpiracionToken) },
                { "key", Guid.NewGuid().ToString() },
                { "userId", userId },
                { "rolId", rolId },
                { "sesionId", sesionId }
            };
            
            string token = JWT.JsonWebToken.Encode(payload, secretKeyBase64, JWT.JwtHashAlgorithm.HS256);

            return token;
        }

        public static TokenResult DecodeToken(string secretKeyBase64, string token)
        {
            var result = new TokenResult();
            IDictionary<string, object> payload;
            try
            {
                payload = JWT.JsonWebToken.DecodeToObject(token, secretKeyBase64) as IDictionary<string, object>;
            }
            catch (JWT.SignatureVerificationException)
            {
                result.Errors.Add(TokenValidationStatus.WrongToken);
                return result;
            }

            result.UserId = Convert.ToInt32(payload["userId"]);
            result.RolId = Convert.ToInt32(payload["rolId"]);
            result.SesionId = Convert.ToInt32(payload["sesionId"]);
            result.FechaCaducidad = Convert.ToDateTime(payload["fechaCaducidad"]);

            var fechaActual = _managerDateTime.Get();

            if (result.FechaCaducidad < fechaActual)
            {
                result.Errors.Add(TokenValidationStatus.Expired);
            }

            return result;
        }

    }

    public class TokenResult
    {
        public bool Validated { get { return Errors.Count == 0; } }
        public readonly List<TokenValidationStatus> Errors = new List<TokenValidationStatus>();
        public int UserId;
        public int RolId;
        public int SesionId;
        public DateTime FechaCaducidad;
    }

    public enum TokenValidationStatus
    {
        Expired,
        WrongToken
    }

}
