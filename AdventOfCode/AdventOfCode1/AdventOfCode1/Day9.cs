using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode1
{
    class Day9
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path8 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input9.txt";
        public static string[] rawInput;
        public static int[] numbers;
        public static void main()
        {

            rawInput = File.ReadAllLines(prueba);
            numbers = new int[rawInput.Length];
            
            for (int i = 0; i < rawInput.Length; i++)
            {
                numbers[i] = int.Parse(rawInput[i]);
                Console.WriteLine(numbers[i]);
            }

            for (int i = 0; i < numbers.Length-5; i++)
            {
                int number = numbers[i + 5];
                for (int j = i; j < i+5; j++)
                {
                    for (int k = j+1; k < 5; k++)
                    {
                        if (!(numbers[j] + numbers[k] == numbers[i + 5]))
                        {
                            Console.WriteLine("I: " + i);
                            Console.WriteLine("J: " + j);
                            Console.WriteLine("K: " + k);
                            Console.WriteLine(" Number = " + numbers[i+5]);
                        }
                    }
                }
            }


        }

    }
}
