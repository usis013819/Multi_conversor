using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversor_y_mas
{
    class clasconvertir
    {

        public string [] opciones = { "Divisas", "Almacenamiento" };
        public string[][] categoria =
        {

        new string [] {"dolares", "Colones(SV)", "Yenes", "Rupia", "Peso(Chileno)", "Peso(MX)", "Peso (Argentino)", "Bitcoin" },
        new string [] { "Megabyte ", "bit", "byte", "Kilobyte", "Gigabyte", "Terabyte"}
        };

        Double[][] valores =
        {

        new double [] {1, 8.75, 111.27, 69.75, 667.08, 19.36, 39.69, 0.00026},
        new double [] {1, 8388608, 1048576, 1024, 0.0009765625, 0.00000095367431660625}
        };

        public double opconvertir(int deconver, int aconver, double cantidad, int opcion)
        {
            //formula de convercion 

            return Math.Round(valores[opcion][aconver] / valores[opcion][deconver] * cantidad, 2);
        }
    }
}
