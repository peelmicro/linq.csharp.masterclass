using System;
using System.Linq;

namespace Enumerabl
{
    class EntryPoint
    {
        static void Main()
        {
            var oddNumbers = Enumerable.Range(1, 10).Where(n => n % 2 == 0);

            var evenNumbers = from n in Enumerable.Range(1, 10)
                              where n % 2 != 0
                              select n;

            var squared = Enumerable.Range(1, 10).Select(n => n * n);

            var squared2 = from n in Enumerable.Range(1, 10)
                           select n * n;

            Random rng = new Random();
            var randoms = Enumerable.Range(1, 10).Select(_ => rng.Next(1, 100));

            var alphabet = Enumerable.Range(0, 26).Select(c => ((char)(c + 'a')).ToString());

            var fontSizes = Enumerable.Range(1, 10).Select(i => (i * 10) + " pt");
        }
    }
}
