using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExamples
{
    public class EntryPoint
    {
        static void Main()
        {
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
            object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4, };

            SeparatingLine();
            // 1. Extract odd numbers with Lambda
            List<int> oddNumbers = numbers.Where(n => (n % 2) == 1).ToList();

            Console.WriteLine("The odd numbers are: " + string.Join(", ", oddNumbers));

            SeparatingLine();
            // 2. Select vs Where
            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };

            List<int> heights = warriors.Where(wh => wh.Height == 100)
                                        .Select(wh => wh.Height)
                                        .ToList();

            Console.WriteLine("Heights: " + string.Join(", ", heights));

            SeparatingLine();
            // 3. Short ForEach
            Console.WriteLine("Short ForEach heights");
            heights.ForEach(h => Console.WriteLine(h));

            Console.WriteLine("Short ForEach heights from Warriors");
            warriors.ForEach(wh => Console.WriteLine(wh.Height)); // can't do it with string.Join
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }

    internal class Warrior
    {
        public int Height { get; set; }
    }
}
