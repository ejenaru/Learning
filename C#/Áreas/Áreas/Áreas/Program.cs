using System;

namespace Áreas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Area();
            Numbers();
        }
        public static void Area()
        {
            //Secuencial and structured programming
            // Ejercicio1: Calcula el área de un triángulo pidiendo los datos por consola.
            //Muestra el área en formato double, int y float.
            double triangBase = 1, triangHeight = 1, area;
            bool aux = true;

            while (aux)
            {
                Console.WriteLine("Introduce el valor de la BASE del triángunlo");
                if (!double.TryParse(Console.ReadLine(), out triangBase))
                    Console.WriteLine("Por favor, escribe un valor correcto");
                else if (triangBase <= 0)
                    Console.WriteLine("Por favor, escribe un valor por encima de 0");
                else
                {
                    aux = false;
                    Console.WriteLine("Correcto, la Base del triángulo introducida es: {0}", triangBase);
                }
            }
            aux = true;
            while (aux)
            {
                Console.WriteLine("Introduce el valor de la ALTURA del triángunlo");
                if (!double.TryParse(Console.ReadLine(), out triangHeight))
                    Console.WriteLine("Por favor, escribe un valor correcto");
                else if (triangHeight <= 0)
                    Console.WriteLine("Por favor, escribe un valor por encima de 0");
                else
                {
                    aux = false;
                    Console.WriteLine("Correcto, la Altura del triángulo introducida es: {0}", triangHeight);
                }
            }
            area = (triangBase * triangHeight) / 2;
            Console.WriteLine("El área de tu triángulo en DOUBLE es: {0}", area);
            Console.WriteLine("El área de tu triángulo en INT es: {0}", Convert.ToInt32(area));
            Console.WriteLine("El área de tu triángulo en FLOAT es: {0}", Convert.ToSingle(area));
        }
        public static void Numbers()
        {
            //Secuencial and structured programming
            // Ejercicio 2: Diseña un programa que pida 10 números a continuación, los muestre
            //por pantalla y en el orden en que han sido introducidos Y en orden inverso.
            int length = 0;
            double[] numbers;

            Console.WriteLine("Este programa le pide una cantidad de números y se los muestra: \n" +
                "* Por orden de introducción\n" +
                "* Por orden inverso de introducción\n" +
                "* Ordenados de menor a mayor\n" +
                "* Ordenados de mayor a menor\n");
            
            bool aux = true;

            while (aux)
            {
                Console.WriteLine("Introduzca la cantidad de números que desea introducir");
                if (!int.TryParse(Console.ReadLine(), out length))
                    Console.WriteLine("Por favor, escribe un valor correcto");
                else if (length <= 0)
                    Console.WriteLine("Por favor, escribe un valor por encima de 0");
                else
                {
                    aux = false;
                    Console.WriteLine("Correcto, longitud introducida es: {0}", length);
                }
            }

            numbers = new double[length];
            //recoger números
            for (int i = 0; i < length; i++)
            {
                aux = true;
                while (aux)
                {
                    Console.WriteLine("Introduzca el número en la posición {0}", i+1);
                    if (!double.TryParse(Console.ReadLine(), out numbers[i]))
                        Console.WriteLine("Por favor, escribe un valor correcto");
                    else aux = false;
                }
            }
            //mostrar números
            Console.WriteLine("Números * Por orden de introducción *" );
            for (int i = 0; i < length; i++)
            {
                Console.Write( numbers[i]);
                if (i < length-1) Console.Write(", ");
            }

            Console.WriteLine("\nNúmeros * Por orden inverso de introducción *");

            for (int i = length-1; i >= 0; i--)
            {
                Console.Write(numbers[i]);
                if (i !=0) Console.Write(", ");
            }

            //ordenar números
            double[] sortedList = new double[length];
            double valor;
            
            for (int vuelta = 0; vuelta < length; vuelta++)
            {
                valor = numbers[vuelta];
                for (int i = 0; i < length; i++)
                {
                    if (valor > numbers[i])
                    {
                        valor = numbers[vuelta];
                        
                    } 
                }
                sortedList[vuelta] = valor;
                
                Console.Write("\nNúmero " + vuelta + ". " + valor + "---");

               
            }
        }
    }
}
