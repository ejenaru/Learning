using System;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            int matriz1Fila, matriz1Col, matriz2Fila, matriz2Col;
            int[,] matriz1, matriz2;

            //Se pide el número de filas y columnas de la MATRIZ 1.
            Console.WriteLine("Introduzca la cantidad de FILAS de MATRIZ 1: ");
            matriz1Fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca la cantidad de COLUMNAS de MATRIZ 1: ");
            matriz1Col = int.Parse(Console.ReadLine());

            //Se pide el número de filas y columnas de la MATRIZ 2.
            Console.WriteLine("Introduzca la cantidad de FILAS de MATRIZ 2: ");
            matriz2Fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca la cantidad de COLUMNAS de MATRIZ 2: ");
            matriz2Col = int.Parse(Console.ReadLine());

            //Se crean las matrices con el tamaño elegido.
            matriz1 = new int[matriz1Fila,matriz1Col];
            matriz2 = new int[matriz2Fila, matriz2Col];

            //Se introducen los elementos de la MATRIZ 1.
            for (int i = 0; i < matriz1Fila; i++)
            {
                for (int j = 0; j < matriz1Col; j++)
                {
                    Console.WriteLine("Introduzca el elemento en la FILA {0}, COLUMNA {1} de la MATRIZ 1",i,j);
                    matriz1[i,j] = int.Parse(Console.ReadLine());
                }
            }

            //Se introducen los elementos de la MATRIZ 2.
            for (int i = 0; i < matriz2Fila; i++)
            {
                for (int j = 0; j < matriz2Col; j++)
                {
                    Console.WriteLine("Introduzca el elemento en la FILA {0}, COLUMNA {1} de la MATRIZ 2", i, j);
                    matriz2[i, j] = int.Parse(Console.ReadLine());
                }
            }

            //Se muestra por pantalla el contenido de la MATRIZ 1.
            Console.WriteLine("El resultado de la MATRIZ 1 es: ");
           
            for (int i = 0; i < matriz1Fila; i++)
            {
                
                for (int j = 0; j < matriz1Col; j++)
                {
                    Console.Write(Convert.ToString(matriz1[i, j]) + " ", i, j);
                }
                Console.WriteLine("");
            }
            
            //Se muestra por pantalla el contenido de la MATRIZ 2.
            Console.WriteLine("El resultado de la MATRIZ 2 es: ");
            for (int i = 0; i < matriz2Fila; i++)
            {
                for (int j = 0; j < matriz2Col; j++)
                {
                    Console.Write(Convert.ToString(matriz2[i, j]) + " ", i,j);
                }
                Console.WriteLine("");
            }

            //Se comprueba si las matrices se pueden comparar o no.
            bool esIgual = true;

            if ((matriz1Fila == matriz2Fila) && (matriz1Col == matriz2Col))
            {
                Console.WriteLine("Las matrices pueden ser comparadas");
                for (int i = 0; i < matriz1Fila; i++)
                {
                    for (int j = 0; j < matriz1Col; j++)
                    {
                        if (matriz1[i, j] != matriz2[i, j]) esIgual = false;
                    }
                   
                }
                if (esIgual)
                {
                    Console.WriteLine("Las matrices son iguales");
                }
                else
                {
                    Console.WriteLine("Las matrices no son iguales");
                }
            }
            else
            {
                Console.WriteLine("Las matrices no pueden ser comparadas");
            }
        }
    }
}
