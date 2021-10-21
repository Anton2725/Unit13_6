using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static string path = "h:\\projects\\CDEV-9\\temp\\Text1.txt";
        static void Main(string[] args)
        {
            // Задание 1
            // Наша задача — сравнить производительность вставки в List<T> и LinkedList<T>.Для этого используйте уже знакомый вам StopWatch.
            // На примере этого текста, выясните, какие будут различия между этими коллекциями.


            string text = File.ReadAllText(path);
            string noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] separators = { ' ', '\n' };
            string[] words = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var listWords = new List<string>();
            var linkedListWords = new LinkedList<string>();

            var stopWatch = Stopwatch.StartNew();
            foreach (var word in words)
            {
                //Console.Write($"{word} || ");
                listWords.Add(word);
            }
            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            // Примерно 2 мс.

            stopWatch = Stopwatch.StartNew();
            foreach (var word in words)
            {
                //linkedListWords.AddLast(word);
                linkedListWords.AddFirst(word);
            }
            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            // Примерно 14 мс.

            // Вывод - вставка в List быстрее чем в LinkedList.

            Console.ReadLine();
        }
    }
}
