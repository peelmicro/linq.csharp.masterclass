using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            // Set Operations

            string st1 = "I am a cat";
            string st2 = "I am a dog";
            List<int> ints = new List<int>() { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 6, 7, 8, 8, 4, 3 };
            List<int> ints2 = new List<int>() { 3, 2, 3, 5, 8, 43, 5, 67, 1, 2, 3, 7, 7, 7, 6, 5, 2, 1, 1, 1, 1, 1 };

            var distinct = st1.Distinct(); // gets all unique items, disregarding their repetitions
            var distinct2 = st2.Distinct();

            var intDistinct = ints.Distinct();
            var intDistinct2 = ints2.Distinct();

            var intersect = st1.Intersect(st2); // gets all matching unique items between two collections
            var intIntersect = ints.Intersect(ints2);


            var union = st1.Union(st2); // gets all unique items from both collections that are no repeating, like two distincts
                                        // answers the questions what are the items in my collection, gets all non-repeating items
            var union2 = st2.Union(st1); // same result, just in different order
            var intUnion = ints.Union(ints2);
            
            var except = st1.Except(st2); // gets all items from st1 that are not present in st2
            var except2 = st2.Except(st1); // gets all items from st2 that are not present in st1

            var intExcept = ints.Except(ints2);
            var intExcept2 = ints2.Except(ints);
        }
    }
}
