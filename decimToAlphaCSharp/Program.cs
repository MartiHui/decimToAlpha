using System;

namespace decimToAlphaCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDecimal = 0;
            Boolean valido = true;

            //Comprobamos que se han introducido argumentos por consola, y que son enteros
            if (args.Length == 0)
            {
                Console.WriteLine("Tienes que introducir un argumento por consola para " +
                    "que el programa funcione correctamente");
                valido = false;
            }
            else
            {
                if (args.Length > 1)
                {
                    Console.WriteLine("Has introducido más de un argumento por consola." +
                        " Se utilizará para el programa el primer número entero, si es que hay");
                    valido = false;
                    foreach (string arg in args)
                    {
                        if (int.TryParse(arg, out numDecimal))
                        {
                            valido = true;
                            break;
                        }
                    }
                    if (valido)
                    {
                        Console.WriteLine("Se ha encontrado un entero entre los argumentos" +
                            " proporcionados.");
                    }
                    else
                    {
                        Console.WriteLine("No se ha encontrado ningún entero");
                    }
                }
                else
                {
                    if (!int.TryParse(args[0], out numDecimal))
                    {
                        valido = false;
                        Console.WriteLine("No has introducido un entero por consola");
                    }
                }
            }

            //Una vez obtenido el entero, se mira que no sea negativo
            if (valido && numDecimal < 0)
            {
                valido = false;
                Console.WriteLine("No se permiten números negativos");
            }

            //Procedemos a convertir de decimal a alfanúmerico
            if (valido)
            {
                int div = numDecimal, resto;
                String numAlfa = "";

                do
                {
                    resto = div % 36;
                    div = div / 36;
                    if (resto < 10)
                    {
                        numAlfa = resto.ToString() + numAlfa;
                    }
                    else
                    {
                        numAlfa = Convert.ToChar(resto + 55).ToString() + numAlfa;
                    }
                } while (div != 0);

                Console.WriteLine("Has introducido el número decimal " + numDecimal
                    + ". Su equivalente alfanúmerico es " + numAlfa + ".");
            }
            else
            {
                Console.WriteLine("No se ha podido ejecutar la conversión");
            }

            Console.ReadKey();
        }
    }
}
