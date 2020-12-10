using System;

namespace Nucleo.Presentacion.Helpers
{
    public class AgendaHelper
    {
        public Boolean validaUltimoIntervalo(TimeSpan horaInicio, TimeSpan horaFin, TimeSpan horaActual, int tiempoMax)
        {
            var horaHolguraMax = horaFin.TotalMinutes + tiempoMax;
            if (horaActual.TotalMinutes >= horaInicio.TotalMinutes && horaActual.TotalMinutes <= horaHolguraMax)
            {
                return true;
            }
            return false;
        }



        public Boolean validaIdealIntervalo(TimeSpan horaFin, TimeSpan horaActual, int tiempoMax, int tiempoMin)
        {
            var horaAct = horaActual.TotalMinutes;
            var horaHolguraMin = horaFin.TotalMinutes - tiempoMin;
            var horaHolguraMax = horaFin.TotalMinutes + tiempoMax;


            if (horaAct >= horaHolguraMin && horaAct <= horaHolguraMax)
            {
                return true;
            }
            return false;
        }


        public Boolean validaAntesDespuesIntervalo(TimeSpan horaFin, TimeSpan horaActual, int tiempoMax, int tiempoMin)
        {
            var horaAct = horaActual.TotalMinutes;
            var horaHolguraMin = horaFin.TotalMinutes - tiempoMin;
            var horaHolguraMax = horaFin.TotalMinutes - tiempoMax;

            if (horaAct < horaHolguraMin || horaAct > horaHolguraMax)
            {
                return true;
            }
            return false;
        }


    }
}
