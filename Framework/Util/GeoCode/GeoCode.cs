using RestSharp;
using System.Collections.Generic;

namespace Framework.Util.GeoCode
{
    public class GeoCode
    {
        public static string getLocationName(double latitud, double longitud)
        {
            var client = new RestClient("http://maps.googleapis.com/maps/api/");

            var request = new RestRequest("geocode/json", Method.GET);

            string latlng = latitud.ToString().Replace(",", ".") + "," + longitud.ToString().Replace(",", ".");

            request.AddQueryParameter("latlng", latlng);

            var resultado = client.Execute<GeoCodeResult>(request).Data;

            if (resultado.status == "OK")
            {
                if (resultado.results.Count > 1)
                {
                    //Se considera la ciudad en la que encontramos la farmacia
                    var penultimo = resultado.results.Count - 2;
                    var tema = resultado.results[penultimo].formatted_address;
                    tema = tema.Replace(",", "");
                    tema = tema.Replace(" ", "_");
                    return tema;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    class GeoCodeResult
    {
        public List<Result> results { get; set; }
        public string status { get; set; }

    }

    class Result
    {
        public string formatted_address { get; set; }

    }

}
