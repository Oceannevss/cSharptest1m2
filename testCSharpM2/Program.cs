using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Exercice 2
        string text;
        Console.WriteLine("input :");
        text = Console.ReadLine();
        Console.WriteLine(ConvertToUpper(text));

        //Exercice 3
        Console.Write("Entrez un nombre: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if(number%2 == 0)
            {
                Console.WriteLine(number + " est un nombre pair");
            }
            else
            {
                Console.WriteLine(number + "est un nombre impair");
            }
        }
        else
        {
            Console.WriteLine("Veuillez entrer un nombre entier valide.");
        }

        //Exercice 4 
        string mot;
        Console.WriteLine("entrez un nom");
        mot = Console.ReadLine();
        Console.WriteLine(MyNameIs(mot));
        AlgoTest(MyNameIs);
        Console.ReadLine();

    }

    public static string ConvertToUpper(string text)
    {
        return text.ToUpper();
    }
    static List<char> alphabet = new List<char>
    {
        'a','b','c','d','e','f','g','h','i','j','k','l','m',
        'n','o','p','q','r','s','t','u','v','w','x','y','z' };
    public static string MyNameIs(string name)
    {
        string num = "";
        for (int i = 0; i < name.Length; i++)
        {
            char index = name.ElementAt(i);
            System.Console.Write(alphabet[index]);  
            //foreach(char c in alphabet)
            //{
            //    if (index == c)
            //    {
            //        num += alphabet.IndexOf(c);
            //    }
            //}
        }

        return num;
    }

    public static void AlgoTest(Func<string, string> func)
    {
        if (func("AB") == "01")
        {
            Console.WriteLine("Success");
        }
        else
        {
            Console.WriteLine("Fail");
        }
    }

    public static int MostAppear(List<int> ints)
    {
        int max = 0;
        Dictionary<int, int> occurences = new Dictionary<int, int>();
        foreach (int i in ints)
        {
            occurences.Add(i, occurences[i]+1);
        }
        foreach(int i in occurences.Keys)
        {
            foreach(int j in occurences.Values)
            {
                if (j >= max)
                {
                    max = j;
                }
            }
        }
        return max;
    }
}