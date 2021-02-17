using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode1
{
    class Day12
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path12 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input12.txt";
        public static string[] rawInput;
        public static int facingDirection;
        public static void main()
        {

            rawInput = File.ReadAllLines(path12);
            int xAxis = 0;
            int yAxis = 0;
            facingDirection = 0;
            Console.WriteLine(facingDirection % 360);
            for (int i = 0; i < rawInput.Length; i++)
            {
                Console.WriteLine("FACING: " + facingDirection);
                var instruction = ReturnTuple(rawInput[i]);
                MoveBoat(instruction.action, instruction.number, ref xAxis, ref yAxis);
                Console.WriteLine("X: " + xAxis + " Y: " + yAxis);
            }
            Console.WriteLine("RESULTADO:  " + (Math.Abs(xAxis) + Math.Abs(yAxis)));
        }


        public static void MoveBoat(string action, int distance, ref int xAxis, ref int yAxis)
        {

            switch (action)
            {
                case "N":
                    yAxis += distance;

                    break;
                case "S":
                    yAxis -= distance;

                    break;
                case "E":
                    xAxis += distance;

                    break;
                case "W":
                    xAxis -= distance;

                    break;

                case "L":
                    ModifyDirection(action, distance);
                    break;
                case "R":
                    ModifyDirection(action, distance);
                    break;
                case "F":
                    MoveForward(ref xAxis, ref yAxis, facingDirection, distance);
                    break;

            }
            Console.WriteLine("FACING: " + facingDirection);


        }

        public static void MoveForward(ref int x, ref int y, int facing, int distance)
        {

            switch (facing)
            {
                case 270:
                    y += distance;

                    break;
                case 90:
                    y -= distance;

                    break;
                case 0:
                    x += distance;

                    break;
                case 180:
                    x -= distance;

                    break;
            }
        }
        public static (string action, int number) ReturnTuple(string input)
        {
            string instruction = input.Substring(0, 1);
            int number = int.Parse(input.Substring(1));
            return (instruction, number);
        }
        public static void ModifyDirection(string dir, int degrees)
        {
            if (dir == "R")
                facingDirection = (facingDirection + degrees) % 360;
            else if (dir == "L")
                facingDirection = (facingDirection - degrees) >= 0 ? (facingDirection - degrees) % 360 : (facingDirection - degrees) % 360 + 360;
        }
    }
}
