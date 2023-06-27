using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio56.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double celsius;
            double fah, reaumur;
            int cantidadIngresada = 0, cantidadSuperior15 = 0;
            double promedioTemperaturas = 0;
            bool Seguir = true;
            do {

                celsius = PedirDoubleEntreMinYMax("Ingrese el valor de la temperatura en grados Celsius (0 para terminar):",-80,80);
                if (celsius != 0)
                {
                    fah = ConvertirCelsiusFah(celsius);
                    reaumur = ConvertirCelsiusReamur(celsius);
                    cantidadIngresada++;
                    promedioTemperaturas += celsius;
                    if (celsius > 15)
                    {
                        cantidadSuperior15++;
                    }
                    Console.WriteLine($"{celsius} - {fah} - {reaumur}");
                }
                else
                {
                    Seguir = false;
                }
            } while( Seguir);
            promedioTemperaturas = promedioTemperaturas / cantidadIngresada;
            Console.WriteLine($"Promedio de temperaturas ingresadas={promedioTemperaturas}");
            Console.WriteLine($"Se ingresaron {cantidadIngresada} temperaturas");
            Console.WriteLine($"Se ingresaron {cantidadSuperior15} temperaturas superiores a 15 grados");
            Console.ReadLine();
        }

        private static double ConvertirCelsiusFah(double celsius)
        {
            return 1.8 * celsius + 32;
        }

        private static double ConvertirCelsiusReamur(double celsius)
        {
            return 0.8 * celsius;
        }

        private static double PedirDouble(string Mensaje)
        {
            double nro = 0;
            do
            {
                Console.Write(Mensaje);
                string strConsola = Console.ReadLine();
                if (!double.TryParse(strConsola, out nro))
                {
                    Console.WriteLine("Número mal ingresado");

                }
                else 
                {
                    break;
                }

            } while (true);
            return nro;
        }
        private static double PedirDoubleEntreMinYMax(string Mensaje,double min, double max)
        {
            double nro = 0;
            do
            {
                Console.Write(Mensaje);
                string strConsola = Console.ReadLine();
                strConsola=strConsola.Replace('.', ',');
                if (!double.TryParse(strConsola, out nro))
                {
                    Console.WriteLine("Número mal ingresado");

                }
                else if(nro>=min && nro<=max)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"El número debe estar entre {min} y {max}");
                }

            } while (true);
            return nro;
        }

    }
}
