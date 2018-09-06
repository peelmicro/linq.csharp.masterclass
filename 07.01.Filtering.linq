<Query Kind="Program" />

void Main()
{
    List<Person> people = new List<Person>()
    {
        new Buyer() { Age = 20 },
        new Buyer() { Age = 25 },
        new Buyer() { Age = 20 },
        new Supplier() { Age = 22 },
        new Supplier() { Age = 20 }
    };	
	
    // 01. Filtering a collection by the type of its items
    var suppliers = from p in people
                    where p is Supplier
                    select p;
	suppliers.Dump();
	
    var buyers = from p in people
                 where p is Buyer
                 select p;	
	buyers.Dump();			
	
    // 02. Filtering a collection by type and by additional filter (age) with query syntax
    var suppliersWithAgeFilter = from p in people
                                 let s = p as Supplier
                                 where s?.Age == 20  // (p as Supplier).Age == 20
                                 select s;
	suppliersWithAgeFilter.Dump();
	
    // 03. Filtering a collection by type and by additional filter with method syntax
    var buyersWithAgeFilter = people.OfType<Buyer>().Where(b => b.Age == 20);
	buyersWithAgeFilter.Dump();
}

// Define other methods and classes here
internal class Person
{
    public int Age { get; set; }
}

internal class Buyer : Person
{
}

internal class Supplier : Person
{
}