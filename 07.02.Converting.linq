<Query Kind="Program" />

void Main()
{
    List<Person> people = new List<Person>()
    {
        new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
        new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
        new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
        new Supplier() { Age = 22 },
        new Supplier() { Age = 20 }
    };	
	
    // 01. Converting IEnumerable to Array or List
    var toCollection = (from p in people
                            // some complicated query
                        select p);//.ToArray(); // .ToList()	
	toCollection.Dump();						
	toCollection.ToArray().Dump();
	toCollection.ToList().Dump();
	
    // 02. Converting one type to another, Buyer -> Supplier
    var buyersToSuppliers = people.OfType<Buyer>()
                                  .ToList()
                                  .ConvertAll(b => new Supplier() { Age = b.Age });	
	buyersToSuppliers.Dump();			
	
    // 03. Converting one type to another with Query Syntax, Buyer -> Supplier
    var buyersToSuppliers2 = (from p in people
                              where p is Buyer
                              let b = p as Buyer
                              // some complicated query
                              select new Supplier()
                              {
                                  Age = b.Age
                              });
	buyersToSuppliers2.Dump();							  
	buyersToSuppliers2.ToList().Dump();							  
	buyersToSuppliers2.ToArray().Dump();		
	
	
    // 04. Converting integers to strings
    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    var stringNumbers = numbers.ConvertAll(n => n.ToString());	
	stringNumbers.Dump();
}

// Define other methods and classes here
internal class Person
{

}

internal class Buyer : Person
{
    public int Age { get; set; }
    public int ID { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
}

internal class Supplier : Person
{
    public int Age { get; set; }
}