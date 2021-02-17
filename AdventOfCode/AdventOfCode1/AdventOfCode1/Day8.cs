using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode1
{
    class Day8
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path8 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input8.txt";
        public static string[] rawInput;
        public static List<(string inst, int value)> instructions;
        public static void main()
        {
            rawInput = File.ReadAllLines(path8);
            instructions = new List<(string, int)>();
            foreach (var item in rawInput)
            {
                instructions.Add((item.Substring(0, 3), int.Parse(item.Substring(4))));
            }

            FindTheBug();

            //if (Probar()) Console.WriteLine("HA FUNCIONADO");
            //else Console.WriteLine("NO HA FUNCIONADO");


        }

        public static void FindTheBug()
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                switch (instructions[i].inst)
                {
                    case "nop":
                        instructions[i] = ("jmp", instructions[i].value);
                        if (TryIfEnds())
                        {
                            Console.WriteLine("ESTE HA FUNCIONADO");
                            Console.WriteLine("NOP en posición: " + i);
                            return;
                        }
                       
                        instructions[i] = ("nop", instructions[i].value);
                        break;

                    case "jmp":
                        instructions[i] = ("nop", instructions[i].value);
                        if (TryIfEnds())
                        {
                            Console.WriteLine("ESTE HA FUNCIONADO");
                            Console.WriteLine("JMP en posición: " + i);
                            return;
                        }
                       
                        instructions[i] = ("jmp", instructions[i].value);
                        break;
                }
            }
        }
        public static bool TryIfEnds()
        {
            List<int> indexAccumulator = new List<int>();
            int accumulator = 0;
            int i = 0;
            while (!indexAccumulator.Contains(i)) //salgo cuando el índice de la instrucción en la que estoy, ya ya aparecido antes
            {
                if (i == instructions.Count)
                    break;
                indexAccumulator.Add(i);

                switch (instructions[i].inst)
                {
                    case "nop":
                        //Console.WriteLine("NOP");
                        i++;
                        break;
                    case "acc":
                        //Console.WriteLine("ACC");
                        accumulator += instructions[i].value;
                        i++;
                        break;
                    case "jmp":
                        i += instructions[i].value;
                        //Console.WriteLine("JMP");
                        break;
                }
            }
            Console.WriteLine(" ACUMULATOR " + accumulator);
            return !indexAccumulator.Contains(i);

        }



    }
}
