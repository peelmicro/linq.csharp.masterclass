using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class EntryPoint
    {
        static void Main()
        {
            // Checking if Two Collections are Equal
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            string[] catNames2 = {"Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar"};

            Console.WriteLine(catNames == catNames2);             // False
            Console.WriteLine(Equals(catNames, catNames2));       // False
            Console.WriteLine(catNames.Equals(catNames2));        // False
            Console.WriteLine(catNames.SequenceEqual(catNames2)); // True
        }
    }
}
