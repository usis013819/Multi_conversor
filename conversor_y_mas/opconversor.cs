using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversor_y_mas
{
    class opconversor
    {

        public string[] opcion = { "Divisas", "Longitud", "Peso", "Volumen", "Almacenamiento" };

        public string[][] definicion =

        {
            new string [] {"Dolar($)", "Colones ¢ (SV)", "Yenes(¥)", "Rupias(₹)", "Lempiras(L)", "Peso (MXN)", "Bitcoin(฿)", "Quetzal(Q)", "Euro(€)", "Cordoba(C$)","Balboa(B/)","Peso Argentino($)", "Peso Chileno($)", "Peso Colombiano($)", "Soles (S/)", "Dolar Canadiense($)", "Dolar Beliceño($)", "Afgani(؋)", "Boliviano($b)", "Yuan(¥)"},
            new string [] {"Metro", "Cm", "Pulgada", "pie", "Varas","Yardas","Km","Millas", "Milímetro","MicróMetro", "Nanómetro", "Decímetro", "Hectómetro", "Picómetro", "Terámetro", "Gigámetro", "Megámetro", "Decámetro", "Petámetro", "Femtómetro"},
            new string [] {"Kilogramo","Gramo","Miligramo","MicroGramo","Libra","Onza", "Tonelada", "Stone", "Gigagramo", "Hectogramo", "Decagramo", "Decigramo", "Centigramo", "Nanogramo", "Picogramo", "Quintal", "Megagramo", "Teragramo", "Exagramo", "Zettagramo"},
            new string [] {"Litros", "Mililitros", "Gigalitros", "Megalitro", "Kilolitros", "Hectolitros", "Decalitros", "Decilitros", "Centilitros", "Microlitros", "Nanolitro", "Pie cubico", "Pulgada cubica", "Galon imperial", "Cuarto imperial", "Pinta imperial", "Taza imperial", "Onza liquida imperial", "Cucharada imperial", "Cucharadita imperial"},
            new string [] {"Megabytes(MB)", "Kilobytes(kB)", "Bytes(B)", "Gigabytes", "TeraBytes", "PetaBytes", "ExaBytes", "Bit", "Nibble", "Kilobit", "Megabit", "Gigabits", "Terabits", "Petabits", "Exabits"}
        };

        double[][] valores =
       {
            new double[] { 1, 8.75, 111.26, 69.75, 24.36, 19.36, 0.00026, 7.69, 0.88,32.95,1.00,39.95, 667.65, 3126.73,3.30, 1.33, 2.02, 77.00, 6.92, 7.00},
            new double[] { 1, 100, 39.3701, 3.28084, 1.1963081929167, 1.09361, 0.001, 0.000621371, 1000, 1e+6, 1e+9, 10, 0.01, 1e+12, 1e-12, 1e-9, 1e-6, 0.1, 1e-15, 1e+15},
            new double[] {1, 1000, 1000000 , 1000000000, 2.20462, 35.274, 0.001, 0.157473, 1e-6, 10, 100, 10000, 100000, 1e+12, 1e+15, 0.01, 0.001, 1e-9, 1e-15, 1e-18},
            new double[] {1, 1000, 1e-9, 1e-6, 0.001, 0.01, 0.1, 10, 100, 1000000, 1000000000, 0.0353147, 61.0237, 0.219969, 0.879877, 1.75975, 3.51951, 35.1951, 56.3121, 168.936 },
            new double[] {1, 1024, 1048576, 9.77e-4, 9.54e-7, 9.3e-10, 9.09e-13, 8388608, 2097152, 8192, 8, 7.8e-3, 7.6e-6, 7.5e-9, 8.88e-16 }
        };

        public double convertir(int deconver, int aconver, double cantidad, int opcion)
        {
            //formula de convercion 

            return Math.Round(valores[opcion][aconver] / valores[opcion][deconver] * cantidad, 2);
        }
    }
}

