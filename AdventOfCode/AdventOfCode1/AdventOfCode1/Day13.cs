using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode1
{
    class Day13
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path13 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input13.txt";
        public static string[] rawInput;
        public static long initialTimeStamp;
        public static void main()
        {
            //==========================INPUT READ=================================
            initialTimeStamp = long.Parse(File.ReadAllLines(path13)[0]);
            rawInput = File.ReadAllLines(path13)[1].Split(",");

            //===========================PROGRAM===================================
            Console.WriteLine("---------------------PART 1-----------------------");
            Console.WriteLine("Tiempo de llegada:  " + initialTimeStamp);
            int lowerminutes = 0, bus = 0;

            foreach (var busNumber in rawInput)
            {
                Console.WriteLine("BUS Number::  " + busNumber);
                if (busNumber != "x")
                {
                    int thisBusMinutes = NextDepartureMinutes(int.Parse(busNumber));
                    Console.WriteLine("MINUTOS::  " + thisBusMinutes);

                    if (lowerminutes == 0)
                    {
                        lowerminutes = thisBusMinutes;
                        bus = int.Parse(busNumber);
                    }
                    else if (thisBusMinutes < lowerminutes)
                    {
                        lowerminutes =  thisBusMinutes;
                        bus = int.Parse(busNumber);
                    }
                }
            }

            Console.WriteLine("BUS QUE MENOS TARDA:: " + lowerminutes*bus);

            Console.WriteLine("---------------------PART 2-----------------------");
        }


        public static int NextDepartureMinutes(int bus)
        {
            int remaining = bus - (int)(initialTimeStamp % bus);


            return remaining;
        }

        //public static void BestBus(out int bus, out int minutes)
        //{
        //    if ()
        //}
    }
}
