using System.Collections.Generic;
using Framework.Security;
using System;

namespace Negocio.Api.Models
{
    public class UsuarioMovilModeloVista
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string DispositivoUUID { get; set; }        
        public string TokenFCM { get; set; }
        public string Tema { get; set; }
        public string Plataforma { get; set; }
        public string Modelo { get; set; }
        public string VersionSO { get; set; }

    }
}