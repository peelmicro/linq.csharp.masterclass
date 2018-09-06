<Query Kind="Program" />

void Main()
{
        string sentence = "I love cats";
        string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
        int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };	
        // 1. Simple Linq Example
        var simpleLinq = from s in sentence
                         select s;		
		simpleLinq.Dump();
        // 2. Linq Example with Condition
        var lessThanFive = from num in numbers
                           where num < 5
                           select num;		
		lessThanFive.Dump();
        // 3. Linq Example with Multiple Conditions
        var lessThanFiveAndGreaterThanTen = from num in numbers
                                            where (num > 5) && (num < 10)
                                            select num;		
		lessThanFiveAndGreaterThanTen.Dump();
		
        // 4. Linq Example with Contains
        var catsWithA = from cat in catNames
                        where cat.Contains("a")
                        select cat;	
		catsWithA.Dump();
		// 5. Linq Example with Multiple Where
        var moreSpecificCats = from cat in catNames
                               where cat.Contains("a")
                               where cat.Length > 4
                               select cat;		
		moreSpecificCats.Dump();
		
        // 6. Linq Example with Ordering
         var orderedNumbers = from num in numbers
                             where (num > 5) && (num < 10)
                             orderby num // optional argument ascending or descending, ascending by default
                             select num;		
		orderedNumbers.Dump();							 
}

// Define other methods and classes here
