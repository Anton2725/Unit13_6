using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    class Program
    {
        static string path = "h:\\projects\\CDEV-9\\temp\\Text1.txt";
        static void Main(string[] args)
        {
            // Задание 2
            // Ваша задача — написать программу, которая позволит понять, какие 10 слов чаще всего встречаются в тексте.


            string text = File.ReadAllText(path);
            string noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] separators = { ' ', '\n' };
            string[] words = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var counter = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (counter.ContainsKey(word))
                {
                    counter[word]++;
                }
                else
                {
                    counter.Add(word, 1);
                }
            }

            var listTop = counter.Values.ToList<int>();
            listTop.Sort();
            listTop.Reverse();
            var hsTop = listTop.ToHashSet();

            int countTop = 1;
            foreach (var el in hsTop)
            {
                Console.WriteLine($"Место-{countTop} - употребляется в тексте {el} раз:");

                foreach (var word in counter)
                {
                    if (word.Value == el)
                    {
                        Console.WriteLine($"    {word.Key}");
                    }
                }

                countTop++;

                if (countTop > 10) break;
            }

            Console.ReadLine();
        }

    }
}
