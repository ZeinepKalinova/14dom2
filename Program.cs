using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Программа \"Статистика\"\n");

        string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится " +
                      "В доме, Который построил Джек. А это веселая птица-синица, Которая часто ворует " +
                      "пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

        Dictionary<string, int> wordFrequency = CountWordFrequency(text);

        Console.WriteLine("Статистика по тексту:\n");

        Console.WriteLine("| Слово      | Частота   |");
        Console.WriteLine("|------------|-----------|");

        foreach (var pair in wordFrequency)
        {
            Console.WriteLine($"| {pair.Key,-10} | {pair.Value,-9} |");
        }

        Console.ReadLine();
    }

    static Dictionary<string, int> CountWordFrequency(string text)
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            // Убираем знаки препинания из слова
            string cleanedWord = new string(word.Where(char.IsLetter).ToArray());

            if (wordFrequency.ContainsKey(cleanedWord))
            {
                wordFrequency[cleanedWord]++;
            }
            else
            {
                wordFrequency[cleanedWord] = 1;
            }
        }

        return wordFrequency;
    }
}
