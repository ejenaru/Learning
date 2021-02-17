using System;
using System.Collections.Generic;
using System.IO;

public class Day2
{
    public static string path2 = @"C:\Users\Trabajo\Desktop\Repositorios\Learning\AdventOfCode\AdventOfCode1\AdventOfCode1\input2.txt";

    public static void main()
    {
        Console.WriteLine(HowManyValidPsw(ReturnArrayStrFromFile(path2)));
    }
    public static string[] ReturnArrayStrFromFile(string path)
    {
        string[] output = File.ReadAllLines(path);
        return output;
    }

    public static int HowManyValidPsw(string[] rows)
    {
        int validPswNumber = 0;
        int minValue, maxValue;
        for (int i = 0; i < rows.Length; i++)
        {
            string[] rowFields = rows[i].Split(" "); //rowField = {policy, character, password}
            string[] policy = rowFields[0].Split("-"); //policy = {minValue, maxValue]
            minValue = Int32.Parse(policy[0]);
            maxValue = Int32.Parse(policy[1]);

            char character = Convert.ToChar(rowFields[1].Remove(rowFields[1].Length -1)); //character = "a:" remove ":"

            string password = rowFields[2]; //password = "password"

            if(IsThisPassSecure2(minValue,maxValue,character,password)) 
                validPswNumber++;

        }

        return validPswNumber;
    }
    public static bool IsThisPassSecure1(int _minValue, int _maxValue, char _character, string _password)
    {
        int count = 0;
        foreach (char item in _password)
        {
            if (_character == item) 
                count++;
        }

        return (count >= _minValue && count <= _maxValue);
    }

    public static bool IsThisPassSecure2(int _minValue, int _maxValue, char _character, string _password)
    {
        //no concept of "index zero"
        _minValue--;
        _maxValue--;
        return (_password[_minValue] == _character ^ _password[_maxValue] == _character);
    }
}
