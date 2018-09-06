using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenation
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            // Concatenating Collections
            int[] ints = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 5, 6, 7, 8, 8, 4, 3 };
            int[] ints2 = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5 };
            int[] ints3 = new int[] { 1, 2, 2, 2, 2, 2, 2 };

            // 01. Concatenating three collections
            int[] concatenated = ints2.Concat(ints3).ToArray();

            // 02. Mixing Concatenation with Other methods, squaring the second half of the ints array
            ints = ints.Take(ints.Length / 2)
                       .Concat(ints.Skip(ints.Length / 2)       
                                   .Select(i => i * i))
                       .ToArray();
        }
    }
}
