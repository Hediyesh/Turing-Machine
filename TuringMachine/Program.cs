using System;
using System.Collections.Generic;

namespace TuringMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string yn = "y";
            do
            {
                Console.WriteLine("Please enter the string by the alphabet 0 and 1:");
                string s = Console.ReadLine();
                var len = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '0' || s[i] == '1')
                    {
                        len++;
                    }
                }
                if (s.Length == 0 || len != s.Length)
                {
                    Console.WriteLine("Please enter the string in the right format!");
                }
                else
                {
                    Machine m = new Machine(s);
                    m.MohasebeReshte();
                }
                Console.WriteLine("Please enter y if you want to continue and n if you want to exit:");
                yn = Console.ReadLine();
                if (yn == "y")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Exited.");
                }
            } while (yn == "y");
        }
    }
}
class Machine
{
    public string str;
    public List<string> li = new List<string>();
    public int FindLastIndex()
    {
        int index = -1;
        foreach (var item in li)
        {
            if (item == "0" || item == "1")
            {
                index++;
            }
            if (item == "x")
            {
                break;
            }
        }
        Console.WriteLine("State q1 : " + "B|" + string.Join("|", li) + "|B");
        return index;
    }
    public void MohasebeReshte()
    {
        Console.WriteLine("string : " + string.Join("", li));
        Console.WriteLine("Start reversing");
        Console.WriteLine("_____________________________________________");
        Console.WriteLine("State q0 : " + "B|" + string.Join("|", li) + "|B");
        for (int i = 0; i < str.Length; i++)
        {
            int index = FindLastIndex();
            if (index == -1)
            {
                break;
            }
            if (li[index] == "0")
            {
                li[index] = "x";
                Console.WriteLine("State q2 : " + "B|" + string.Join("|", li) + "|B");
                li.Add("0");
                Console.WriteLine("State q4 : " + "B|" + string.Join("|", li) + "|B");
            }
            else if (li[index] == "1")
            {
                li[index] = "x";
                Console.WriteLine("State q3 : " + "B|" + string.Join("|", li) + "|B");
                li.Add("1");
                Console.WriteLine("State q4 : " + "B|" + string.Join("|", li) + "|B");
            }
        }
        int find = FindLastIndex();
        while (li[find + 1] == "x"){
            li.RemoveAt(find + 1);
            Console.WriteLine("State q5 : " + "B|" + string.Join("|", li) + "|B");

        }
        Console.WriteLine("State qf : " + "B|" + string.Join("|", li) + "|B");
        Console.WriteLine("_____________________________________________");
        Console.WriteLine("Reversed string : " + string.Join("", li));
    }
    public Machine(string s)
    {
        str = s;
        for (int i = 0; i < s.Length; i++)
        {
            li.Add(s[i].ToString());
        }
    }
}