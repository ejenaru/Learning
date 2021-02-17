using System;
using System.Collections.Generic;
using System.IO;
public class Day1
{
    public static string path1 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input1.txt";

    public static void main()
    {
        int[] numArray = Day1.ReturnArrayIntFromFile(path1);
        Console.WriteLine(Day1.Find2Sum2020(numArray));
        Console.WriteLine(Day1.Find3Sum2020(numArray));
    }
    public static int[] ReturnArrayIntFromFile(string path)
    {
        string[] input = File.ReadAllLines(@path);
        int[] output = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = Int32.Parse(input[i]);
        }
        return output;
    }
    public static int Find2Sum2020(int[] numList)
    {
        for (int i = 0; i < numList.Length; i++)
        {
            for (int j = i; j < numList.Length; j++)
            {
                if (numList[i] + numList[j] == 2020)
                {
                    return numList[i] * numList[j];
                }
            }
        }

        return -1;
    }

    public static int Find3Sum2020(int[] numList)
    {
        for (int i = 0; i < numList.Length; i++)
        {
            for (int j = i; j < numList.Length; j++)
            {
                for (int k = j; k < numList.Length; k++)
                {
                    if ((numList[i] + numList[j] + numList[k]) == 2020)
                    {
                        return numList[i] * numList[j] * numList[k];
                    }
                }

            }
        }

        return -1;
    }
}
