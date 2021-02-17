using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AdventOfCode1
{
    class Day7
    {
        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path7 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input7.txt";
        public static string[] rawInput;
        public static Dictionary<string, Dictionary<string, string>> BIGDict;
        public static void main()
        {
            rawInput = File.ReadAllLines(path7);

            BIGDict = ReturnDictionary(rawInput);

            List<string> Bags = FindAllThatContains("shiny gold bag", BIGDict);

            int count;
            List<string> aux;
            do
            {
                count = Bags.Distinct().Count();
                aux = new List<string>();
                foreach (var b in Bags)
                {
                    // Union removes duplicates, instead of AddRange.
                    aux.AddRange(FindAllThatContains(b, BIGDict));
                }
                foreach (var b in Bags)
                    aux.Remove(b);

                Bags.AddRange(aux);
                
            } while (Bags.Distinct().Count() > count);

            Console.WriteLine(Bags.Distinct().Count());

            /*
            foreach (var item in Bags)
            {
                Console.WriteLine("Shiny gold bag está dentro de: --> " + item);
                foreach (var item2 in FindAllThatContains(item, BIGDict))
                {
                    count++;
                    Console.WriteLine( item + "Está dentro de --> " + item2);
                }
                Console.WriteLine("COUNT : " + count);
            }
            */
        }

        public static Dictionary<string, Dictionary<string, string>> ReturnDictionary(string[] _rawInput)
        {
            var BIGDict = new Dictionary<string, Dictionary<string, string>>(); //gran diccionario
            List<string> _LITTLEDict = new List<string>(); //clave para encontrar el pequeño diccionario
            string[] subkeyList;
            string subkey;
            //1er for, crea diccionario GRANDE de KEY + diccionario pequeño
            for (int i = 0; i < _rawInput.Length; i++)
            {
                _LITTLEDict.Add(_rawInput[i].Split(" contain ")[0].Replace("bags", "bag"));
                subkeyList = _rawInput[i].Split(" contain ")[1].Split(", ");
                //añade 1 valor y un PEQUEÑO diccionario
                BIGDict.Add(_LITTLEDict[i], new Dictionary<string, string>());
                // crea diccionario PEQUEÑO con SUBKEY + valor
                for (int j = 0; j < subkeyList.Length; j++)
                {
                    //Esto es necesario porque no sé cuantas bags pueden ir dentro de cada 
                    subkey = subkeyList[j].Replace("bags", "bag").Replace(".", "");

                    //añade clave: tipo de bolsa, valor: "0"
                    BIGDict[_LITTLEDict[i]].Add(subkey.Remove(0, 2), subkey.Remove(2));
                    //subvalue can be "no"

                    //Console.WriteLine("\tKey = " + subkey.Remove(0, 2) +
                    //    " \t\t|| Value = " + subkey.Remove(2));
                    ////Console.WriteLine(keyValues[key].Keys);
                }
            }
            return BIGDict;
        }

        public static List<string> FindAllThatContains(string WantedBag, Dictionary<string, Dictionary<string, string>> DICT)
        {
            List<string> bagThatContains = new List<string>();
            foreach (var miniDIC in DICT)
            {
                //si ese minidic.key, contiene el wantedbag
                foreach (var keyval in DICT[miniDIC.Key])
                {
                    if (keyval.Key == WantedBag) bagThatContains.Add(miniDIC.Key);
                    //añadelo a la lista
                }

            }
            return bagThatContains;
        }
    }
}
