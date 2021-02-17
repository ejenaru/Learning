using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode1
{
    class Day3
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path3 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input3.txt";
        public static int vertical = 1;
        public static int horizontal = 3;
        public static char character = '#';
        public static int[,] slopes = new int[,] {{1,1},{3,1},{5,1},{7,1},{1,2}};

        public static void main()
        {
            Console.WriteLine(BetterSlopes(slopes, ReturnArrayStrFromFile(path3)));
            //Console.WriteLine(CountTrees(ReturnArrayStrFromFile(path3),vertical,horizontal,character));
        }
        public static string[] ReturnArrayStrFromFile(string path)
        {
            string[] output = File.ReadAllLines(path);
            return output;
        }

        public static int CountTrees(string[] treePatern, int vertical,int horizontal, char tree)
        {
            int horizPosition = 0;
            int numberOfTrees = 0;
            for (int i = 0; i < treePatern.Length; i+=vertical)
            {
                //Console.WriteLine("LINEA (i)::{0}, HORIZONTAL :: {2} numberoftrees ::{1}, ", i,numberOfTrees,horizPosition);
                if (treePatern[i][horizPosition] == tree) 
                    numberOfTrees++;

                //horizPosition += horizontal;
                //if (horizPosition >= treePatern[i].Length) horizPosition = horizPosition % treePatern[i].Length;

                horizPosition = (horizPosition + horizontal) % treePatern[i].Length;
            }
            return numberOfTrees;
        }

        public static long BetterSlopes(int[,] rightDownSlopes, string[] treePatern)
        {
            long result = 1;
            for (int line = 0; line < rightDownSlopes.GetLength(0); line++)
            {
                Console.WriteLine(result);
                result *= CountTrees(treePatern, rightDownSlopes[line, 1], rightDownSlopes[line, 0], character);
            }
            return result;
        }
    }
}
