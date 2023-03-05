using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections;
using System.Linq;


public class Kata
{
    //
    static void Main(string[] args)
    {
        string input = "Hello my darling";
        Console.WriteLine(input);

        Console.WriteLine(ReverseWords(input));

    }



    public static string ReverseWords(string str)
    {
        String[] words = str.Split(' ');
        List<string> wordsList = new List<string>();
        string reverse = "";

        foreach (string word in words)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string addStr = new string(charArray);
            reverse += addStr + " ";
        }

        reverse = reverse.Remove(reverse.Length - 1, 1);   
        return reverse;
    }


    public static int DigitalRoot(long n)
    {
        string strNum = n.ToString();
        int sum = 0;
        for(int i = 0; i < strNum.Length; i++)
        {
            sum += (int)Char.GetNumericValue(strNum[i]); 
        }
        if (sum >= 10) sum = DigitalRoot((long)sum);
        else return sum;

        return sum;
    }


    public static String Accum(string s)
    {
        string output = "";
        int i = 1;
        foreach(char ch in s)
        {
            int iter = i;
            do
            {
                if (iter < i)         
                    output += ch.ToString().ToLower();
                else
                    output += ch;
                iter--;
            } while (iter > 0);
            output += "-";
            i++;
        }
        output = output.Remove(output.Length-1, 1);
        return output;
    }


    public static string GetReadableTime(int seconds)
    {
        int finalSeconds, minutes, hours = 0;
        string fmt = "00";

        if (seconds < 60) finalSeconds = seconds;
        else finalSeconds = seconds % 60;

        if (seconds%3600 < 60) minutes = 0;
        else minutes = (seconds / 60) % 60;

        if (seconds < 3600) hours=0;
        else hours = seconds / 3600;


        //minutes = (seconds / 60) % 60;
        //hours = seconds / 3600; 
        
        return hours.ToString(fmt) + ":" + minutes.ToString(fmt) + ":" + finalSeconds.ToString(fmt);
    }



    public static string MakeComplement(string dna)
    {
        string dna2 = "";
        foreach (char ch in dna)
        {
            if(ch == 'A')
            {
                dna2 += 'T';
            }
            else if (ch == 'T')
            {
                dna2 += 'A';
            }
            else if (ch == 'C')
            {
                dna2 += 'G';
            }
            else if (ch == 'G')
            {
                dna2 += 'C';
            }

        }

        return dna2;
    }


    public static bool comp(int[] a, int[] b)
    {
        bool same = false;
        if (a.Length != b.Length)
            return false;
        else
        {
            Array.Sort(a);
            Array.Sort(b);
        }

        for(int i = 0; i < a.Length; i++)
        {
            if (b[i] != (a[i] * a[i]))
                return false;
        }
        same = true; //This line is only met if false is never returned above

        
        return same;
    }


    //In this kata you will create a function that takes a list of
    //non-negative integers and strings and returns a new list with the strings filtered out.
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
        List<int> numbers = new List<int>();
        foreach (var item in listOfItems)
        {
            if(item.GetType() == typeof(int))
                numbers.Add((int)item);
        }
        return numbers; 
    }






    public static IEnumerable<string> FriendOrFoe(string[] names)
    {
        // Good luck!
        List<string> friends = new List<string>();
        foreach(string name in names)
        {
            if (name.Length == 4)
                friends.Add(name);  
        }
        return friends;
    }

    //Finds the shortest string in a list... I think.  Failed in big random tests.  See incomplete kata
    public static int FindShort(string s)
    {

        string inputStr = trimInput(s);
        string[] wordList = inputStr.Split(" ");
        int shortestLen = wordList[0].Length;

        foreach (string word in wordList)
        {
            if (word.Length < shortestLen)
                shortestLen = word.Length;
        }
        return shortestLen;
    }


    //Used for the FindShort method. 
    public static string trimInput(string str)
    {
        string inpt = str;
        List<int> nonLetters = new List<int>();

        for (int i = 0; i < inpt.Length; i++)
        {
            if ((!Char.IsLetter((char)inpt[i])) && (inpt[i] != ' '))
            {
                nonLetters.Add(i);
            }
        }

        for (int j = nonLetters.Count-1; j >= 0 ; j--)
        {
            int a = nonLetters[j];
                inpt = inpt.Remove(a, 1);

        }

        return inpt;
    }
}