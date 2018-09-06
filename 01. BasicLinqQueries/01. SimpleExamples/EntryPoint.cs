using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExamples
{
    public class EntryPoint
    {
        static void Main()
        {
            string sentence = "I love cats";
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            //----------------------------------------------
            SeparatingLine();
            // 1. Simple Linq Example
            var simpleLinq = from s in sentence
                             select s;

            Console.WriteLine(string.Join("", simpleLinq));

            //----------------------------------------------
            SeparatingLine();
            // 2. Linq Example with Condition
            var lessThanFive = from num in numbers
                               where num < 5
                               select num;

            Console.WriteLine(string.Join(", ", lessThanFive));

            //----------------------------------------------
            SeparatingLine();
            // 3. Linq Example with Multiple Conditions
            var lessThanFiveAndGreaterThanTen = from num in numbers
                                                where (num > 5) && (num < 10)
                                                select num;

            Console.WriteLine(string.Join(", ", lessThanFiveAndGreaterThanTen));

            //----------------------------------------------
            SeparatingLine();
            // 4. Linq Example with Contains
            var catsWithA = from cat in catNames
                            where cat.Contains("a")
                            select cat;

            Console.WriteLine(string.Join(", ", catsWithA));

            //----------------------------------------------
            SeparatingLine();
            // 5. Linq Example with Multiple Where
            var moreSpecificCats = from cat in catNames
                                   where cat.Contains("a")
                                   where cat.Length > 4
                                   select cat;

            Console.WriteLine(string.Join(", ", moreSpecificCats));

            //----------------------------------------------
            SeparatingLine();
            // 6. Linq Example with Ordering
             var orderedNumbers = from num in numbers
                                 where (num > 5) && (num < 10)
                                 orderby num // optional argument ascending or descending, ascending by default
                                 select num;

            Console.WriteLine(string.Join(", ", orderedNumbers));
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }
}



//List<int> lessThanFiveAndGreaterThanTenList = new List<int>();
//
//for (int i = 0; i<numbers.Length; i++)
//{
//    if ((i > 5) && (i< 10))
//    {
//        lessThanFiveAndGreaterThanTenList.Add(i);
//    }
//}
