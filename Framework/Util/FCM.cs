using Framework.Constantes;
using RestSharp;
using System.Configuration;

namespace Framework.Util
{
    public class FCM
    {
        public static void enviarMensaje(object data)
        {
            var urlEnvioMensajesFCM = AppSettings.Get<string>(ConstantesWebConfig.FCM_ENVIO_URL);
            var clavePrivadaFCM = AppSettings.Get<string>(ConstantesWebConfig.FCM_CLAVE_SECRETA);

            var client = new RestClient("https://fcm.googleapis.com");

            var request = new RestRequest(urlEnvioMensajesFCM, Method.POST);

            request.AddHeader("Authorization", "key="+ clavePrivadaFCM);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(data);

            var respuesta = client.Execute(request);
        }

    }
}
