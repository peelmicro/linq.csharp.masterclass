<Query Kind="Statements" />

            // Checking if Two Collections are Equal
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            string[] catNames2 = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };

            Console.WriteLine(catNames == catNames2);             // False
            Console.WriteLine(Equals(catNames, catNames2));       // False
            Console.WriteLine(catNames.Equals(catNames2));        // False
            Console.WriteLine(catNames.SequenceEqual(catNames2)); // True