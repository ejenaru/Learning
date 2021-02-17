using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode1
{
    class Day5
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path5 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input5.txt";
        public static string[] rawInput;

        public static void main()
        {
            rawInput = File.ReadAllLines(path5);
            List<int> IDList = new List<int>();
            int highestID = 0;
            for (int i = 0; i < rawInput.Length; i++)
            {

                IDList.Add(ReturnSeatID(rawInput[i]));

                highestID = IDList[i] > highestID ? IDList[i] : highestID;
            } 
            
            Console.WriteLine("El ID de asiento más alto es: " + highestID);
            Console.WriteLine("El ID del asiento que falta es: " + FindMissingSeat(IDList));
           


        }
        public static int ReturnSeatID(string seat)
        {
            int rowBin, columnBin, seatID;
            int rowDec = 0, columnDec = 0;

            rowBin = Int32.Parse(seat.Substring(0, 7).Replace('F','0').Replace('B','1'));
            columnBin = Int32.Parse(seat.Substring(7).Replace('L', '0').Replace('R', '1'));

            for (int position = 0; position < 7; position++)
            {
                rowDec += ((rowBin / (int)Math.Pow(10, position)) % 10) * (int)Math.Pow(2, position); //el 1 o el 0 que está en la posición position
            }
            for (int position = 0; position < 3; position++)
            {
                columnDec += ((columnBin / (int)Math.Pow(10, position)) % 10) * (int)Math.Pow(2, position); //el 1 o el 0 que está en la posición position
            }

            seatID = rowDec * 8 + columnDec;
            return seatID;
        }
        public static int FindMissingSeat(List<int> IDList_)
        {
            IDList_.Sort();
            int count = IDList_[0];

            foreach (int ID in IDList_)
            {
                if (ID != count) return count;
                count++;
            }
            return 0;
        }
    }
}
