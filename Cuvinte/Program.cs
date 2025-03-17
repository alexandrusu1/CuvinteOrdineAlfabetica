using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "cuvinte.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Fisierul nu exista!");
            return;
        }

        string[] cuvinte = File.ReadAllText(filePath)
                               .Split(new char[] { ' ', '\n', '\r', ',', '.', ';', '!' }, StringSplitOptions.RemoveEmptyEntries);

        List<string>[] tablou = new List<string>[26];
        for (int i = 0; i < 26; i++)
        {
            tablou[i] = new List<string>();
        }

        foreach (string cuvant in cuvinte)
        {
            char primaLitera = char.ToLower(cuvant[0]);
            if (primaLitera >= 'a' && primaLitera <= 'z')
            {
                int index = primaLitera - 'a';
                tablou[index].Add(cuvant);
            }
        }

      
        for (int i = 0; i < 26; i++)
        {
            char litera = (char)('A' + i);
            Console.WriteLine($"{litera}: {string.Join(", ", tablou[i])}");
        }
    }
}
