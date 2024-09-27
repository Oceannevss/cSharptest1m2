using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("opandore@d-edge.com", "Ocededgegg")
        };
        using (var message = new MailMessage("opandore@d-edge.com", "belle971vitry@hotmail.com")
        {
            Subject = "subject test",
            Body = "body test"
        })

        {
            //ms.Position = 0;
            //message.Attachments.Add(attach);
            smtp.Send(message);
        }

        //Exercice 2
        string text;
        Console.WriteLine("input :");
        text = Console.ReadLine();
        Console.WriteLine(ConvertToUpper(text));

        //Exercice 3
        Console.Write("Entrez un nombre: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number % 2 == 0)
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

        //Algo
        List<int> ints = new List<int> { 1, 2, 3, 5, 2, 2, 1, 5 };
        Console.WriteLine(MostAppear(ints));

    }

    public static int ComputeClosestToZero(int[] ts)
    {
        // Write your code here
        // To debug: Console.Error.WriteLine("Debug messages...");
        int[] tabPos = new int[] {};
        int[] tabneg = new int[] {};

        foreach ( int temps in ts )
        {
            if ( temps >= 0)
            {
                tabPos.Append(temps);
            }else
            {
                tabneg.Append(temps);
            }
        }

        var t1 = tabPos.Min();
        var t2 = tabneg.Max();

        if (t1 > t2 )
        {
            return t1;

        }else
        {
            return t2;
        }

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
            char lettre = name.ElementAt(i);
            foreach (char c in alphabet)
            {
                if (lettre.Equals(c))
                {
                    num += alphabet.IndexOf(c);
                    Console.WriteLine(num);
                }
            }
        }

        return num;
    }

    public static void AlgoTest(Func<string, string> func)
    {
        if (func("ab") == "01")
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
        int result = 0;
        Dictionary<int, int> occurences = new Dictionary<int, int>();
        foreach (int i in ints)
        {
            if (occurences.ContainsKey(i))
            {
                occurences[i] = occurences.GetValueOrDefault(i) + 1;
            }
            else
            {
                occurences.Add(i, 1);
            }

        }
        foreach (KeyValuePair<int, int> occ in occurences)
        {
            Console.WriteLine("Clé: {0}, Valeur: {1}",
                occ.Key, occ.Value);
        }

        foreach (var occ in occurences)
        {
            if (occ.Value >= max)
            {
                max = occ.Value;
                result = occ.Key;
            }
        }
        return result;

    }
}