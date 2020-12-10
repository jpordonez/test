using System;

namespace Framework.Util
{
    public class Identificacion
    {
        /// <summary>
        /// Algoritmo de Validacion de Cedula Ecuatoriana
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public static bool CedulaEsValida(string cedula)
        {
            if (cedula == null)
                return false;
            try
            {
                string[] array = new string[10];

                int num = cedula.Length;
                if (num == 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        array[i] = cedula.Substring(i, 1);
                    }

                    int total = 0;
                    int digito = (Convert.ToInt32(array[9]) * 1);
                    for (int i = 0; i < (num - 1); i++)
                    {
                        int mult = 0;
                        if ((i % 2) != 0)
                        {
                            total = total + (Convert.ToInt32(array[i]) * 1);
                        }
                        else
                        {
                            mult = Convert.ToInt32(array[i]) * 2;
                            if (mult > 9)
                                total = total + (mult - 9);
                            else
                                total = total + mult;
                        }
                    }
                    double decena = total / 10;
                    decena = Math.Floor(decena);
                    decena = (decena + 1) * 10;
                    double final = (decena - total);

                    return (final == 10 && digito == 0) || (final == digito);
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Algoritmo de Validacion de Ruc Ecuatoriano
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        public static bool RucEsValido(string ruc)
        {
            const int tamanoLongitudRuc = 13;
            long isNumeric;
            if (ruc == null || !ruc.Length.Equals(tamanoLongitudRuc) || !long.TryParse(ruc, out isNumeric))
            {
                return false;
            }
            var cedula = ruc.Substring(0, 10);
            var sufijo = ruc.Substring(10);

            return CedulaEsValida(cedula) && sufijo.Equals("001");
        }

        /// <summary>
        /// Algoritmo de Validacion de Pasaporte
        /// </summary>
        /// <param name="pasaporte"></param>
        /// <returns></returns>
        public static bool PasaporteEsValido(string pasaporte)
        {
            return true;
        }

    }
}
