using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode1
{
    class Day6
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path6 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input6.txt";
        public static string[] eachGroupRawInput; // answer of each group, separated by "\n"
        public static void main()
        {
            eachGroupRawInput = File.ReadAllText(path6).Split("\n\n");

            List<string> groups = new List<string>(); //answer of each group. NOT separated
            int countSumAnyone = 0;
            int countSumEveryone = 0;

            for (int i = 0; i < eachGroupRawInput.Length; i++)
            {
                groups.Add(eachGroupRawInput[i].Replace("\n", ""));
                countSumAnyone += groups[i].Distinct().ToArray().Length;
            }
            Console.WriteLine("----------INICIO--------------");
            Console.WriteLine("Número de caracteres diferentes:  " + countSumAnyone);
            Console.WriteLine("-----------FIN-------------");
            
            for (int i = 0; i < groups.Count; i++)
            {
                

                string oneGroupDistinct = new string(groups[i].Distinct().ToArray()); //answer of ONE group, Without repetitions
                Console.WriteLine("--GRUPO:  " + i + "   --INPUT::" + groups[i] + "   --DISTINTAS: " + oneGroupDistinct);
                
                int groupLength = eachGroupRawInput[i].Split("\n").Length;
                Console.WriteLine("******Nº PERSONAS*****:   " + groupLength);

                int groupCoincidence = 0;
                
                //miro si cada letra está exactamente group.Length o más

                for (int j = 0; j < oneGroupDistinct.Length; j++)
                {

                    int repetitionsOfLetter = (int)eachGroupRawInput[i].LongCount(character => character == oneGroupDistinct[j]);

                    if (repetitionsOfLetter == groupLength) 
                    {
                        groupCoincidence++;
                        countSumEveryone++;
                    }
                    Console.WriteLine("Letra  " + oneGroupDistinct[j] + "  " + "Repeticiones  " + repetitionsOfLetter + "  ");
                }
                Console.WriteLine("COINCIDENCIAS:  " + groupCoincidence);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine(" LA CUENTA TOTAL ES::: " + countSumEveryone);
            Console.WriteLine("--------------------");
        }

    }
}
