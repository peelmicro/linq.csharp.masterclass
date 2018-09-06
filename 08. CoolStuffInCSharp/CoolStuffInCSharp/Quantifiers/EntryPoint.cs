using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifiers
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            // Quantifying Operations
            List<int> ints = new List<int>() { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 6, 7, 8, 8, 4, 3 };
            string st1 = "I am a cat";

            // 01. Checking if all items in a collection match a given condition
            Console.WriteLine(ints.All(i => i > 0)); // True
            Console.WriteLine(st1.All(c => c < 'f')); // False

            // 02. Checking if there is at least one item in a collection matching a given condition
            Console.WriteLine(ints.Any(i => i > 5));
            Console.WriteLine(st1.Any(c => c == 'a'));
            
            // 03. Checking if a collection is empty
            string empty = string.Empty;
            Console.WriteLine(empty.Any()); // False
            Console.WriteLine(st1.Any());   // True

            Console.WriteLine(st1.Contains('f'));
        }
    }
}
