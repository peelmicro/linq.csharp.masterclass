<Query Kind="Program" />

void Main()
{
    List<Person> people = new List<Person>()
    {
        new Person() { Age = 20 , ID = 1, Height = 125, Weight = 77},
        new Person() { Age = 25 , ID = 2, Height = 150, Weight = 88},
        new Person() { Age = 21 , ID = 5, Height = 100, Weight = 58},
        new Person() { Age = 25 , ID = 3, Height = 150, Weight = 98},
        new Person() { Age = 20 , ID = 5, Height = 120, Weight = 48},
    };	
	
	var orderedPeople = people.OrderBy(p => p.ID).ThenBy(p => p.Age);
	orderedPeople.Dump();
}

// Define other methods and classes here
internal class Person 
{
    public int Age { get; set; }
    public int ID { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }	
}