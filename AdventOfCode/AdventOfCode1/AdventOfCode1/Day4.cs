using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode1
{
    class Day4
    {
        //here is a perfect moment to use "enum" but i didn't know  how to do it :< 
        //I need to try this: https://stackoverflow.com/questions/31254387/how-do-i-use-an-array-in-a-switch-statement-in-c?rq=1

        public static string prueba = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\pruebas.txt";
        public static string path4 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input4.txt";
        public static string[] requiredFields = new string[]{ "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

        public static void main()
        {
            int validPassports = 0;
            string[] passportS = ReturnEachPassport(path4);

            foreach (string passport in passportS)
            {
                Console.WriteLine("PASAPORTE" + passport + "  FIN"); //Here is only 1 passport
                if (IsPassportValid(passport, requiredFields))
                    validPassports++;
                Console.WriteLine(validPassports);
            }

        }
        public static string[] ReturnEachPassport(string path)
        {
            string[] passport = File.ReadAllText(path).Split("\n\n");

            for (int i = 0; i < passport.Length; i++)
            {
                passport[i] = passport[i].Replace("\n", " ");  
            }
            return passport;
        }

        public static bool IsPassportValid(string passport1, string[] requireFields)
        {
            Dictionary<string, string> keys = new Dictionary<string, string>(); //stores key + value of 1 passport
            int numberOfCoincidences = 0; //stores the number of coincidences in requiredField
            int IsValueOk = 0;
            

            string[] passport = passport1.Split(" "); //cada string es "clave:valor"
            for (int i = 0; i < passport.Length; i++)
            {
                string[] keyValue = passport[i].Split(":"); //keyvalue[0] ="clave" KeyValue[1]="valor"
                keys.Add(keyValue[0], keyValue[1]); //añado la clave y el valor al diccionario


                if (Array.Exists(requireFields, element => element == keyValue[0]))//Busco en requireFields si existe la clave de esta iteración
                {
                    numberOfCoincidences++;

              
                }//Aqui dentro debería comprobar tambien si justo ese tiene los datos 
                
                switch (keyValue[0])
                {
                    case "byr":
                        int a = int.Parse(keyValue[1]);
                        Console.WriteLine("byr:: "+a);
                        if (1920 <= a && a <= 2002) 
                            IsValueOk++; 
                        break;

                    case "iyr":
                        int b = int.Parse(keyValue[1]);
                        Console.WriteLine("iyr:: "+b);
                        if (2010 <= b && b <= 2020) IsValueOk++;
                        break;

                    case "eyr":
                        int c = int.Parse(keyValue[1]);
                        Console.WriteLine("eyr:: "+c);
                        if (2020 <= c && c <= 2030) IsValueOk++;
                        break;

                    case "hgt":
                        int num;
                        if (int.TryParse(keyValue[1].Substring(0, keyValue[1].Length - 2), out num))
                        {
                            string measure = keyValue[1].Substring(keyValue[1].Length - 2);
                            if (measure == "cm" && 150 <= num && num <= 193)
                                IsValueOk++;
                            else if (measure == "in" && 59 <= num && num <= 76)
                                IsValueOk++;
                            Console.WriteLine("HGT ::  " + "num: " + num + "measure: " + measure);
                        }
                        break;

                    case "hcl":
                        string hairColor = keyValue[1];
                        Console.WriteLine("hcl:: " + hairColor);
                        char[] validChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                        if (hairColor[0] == '#')
                        {
                            bool isValid = true;
                            foreach (char item in hairColor.Substring(1))
                            {
                                if (!Array.Exists(validChars, element => element == item))
                                    isValid = false;
                            }
                            if (isValid)
                                IsValueOk++;
                        }
                        break;

                    case "ecl":
                        string[] validEcl = { "amb","blu","brn","gry","grn","hzl","oth" };
                        string ecl = keyValue[1];
                        Console.WriteLine("ecl:: " + ecl);
                        if (Array.Exists(validEcl, element => element == ecl))
                            IsValueOk++;
                        break;

                    case "pid":
                        string pid = keyValue[1];
                        int aux;
                        Console.WriteLine("pid::: "+ pid);
                        if (pid.Length == 9 && int.TryParse(pid, out aux))
                            IsValueOk++;
                        break;
                    case "cid":
                        Console.WriteLine("TIENE CID");
                        IsValueOk++;
                        break;
                    
                }
            }

            if (!keys.ContainsKey("cid"))
            {
                IsValueOk++;
                numberOfCoincidences++;
            }
                
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("NumberOfCoincidences::  "+ numberOfCoincidences + "Is Value OK?:: " + IsValueOk);
            Console.WriteLine("-----------------------------------");
            
            return (numberOfCoincidences>=requireFields.Length) && (IsValueOk >=requireFields.Length);
        }


    }
}
