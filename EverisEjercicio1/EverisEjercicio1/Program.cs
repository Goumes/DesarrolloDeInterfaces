using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisEjercicio1
{
    class Program
    {

      

        static void Main(string[] args)
        {

            int resultado2 = 0;
            int contadorGlobal = 0;
            int x = 1;

            int calcularSiguienteEntero(int entero)
            {
                int resultado = 0;

                string enteroString = entero.ToString();
                int numeroDigitos = enteroString.Length;
                List<int> arrayint = new List<int>();

                for (int i = 0; i < numeroDigitos; i++)
                {
                    arrayint.Add(entero % 10);
                    entero = entero / 10;
                    arrayint [i] = (arrayint[i]) * (arrayint[i]);
                }

                for (int i = 0; i < arrayint.Count; i++)
                {
                    resultado+= arrayint[i];
                }

                return resultado;
            }


            while (x <= 85)
            {
                resultado2 = x;
                while (resultado2 != 89 && resultado2!=1)
                {
                    resultado2 = calcularSiguienteEntero(resultado2);

                    if (resultado2 == 89)
                    {
                        contadorGlobal++;
                    }

                }

                x++;
            }
            Console.WriteLine(contadorGlobal);
            
            System.Console.ReadLine();
        }
    }
}
