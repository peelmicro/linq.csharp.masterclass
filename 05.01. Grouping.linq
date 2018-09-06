<Query Kind="Program" />

void Main()
{
    List<Person> people = new List<Person>()
    {
        new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
        new Person("John", "Johnson", 2, 170, 22, Gender.Male),
        new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
        new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
        new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
        new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
        new Person("John", "Jones", 7, 160, 22, Gender.Male),
        new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
        new Person("Aaron", "Myers", 9, 182, 23, Gender.Male),
        new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
        new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
        new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
    };	
	
    // 1. Group by gender
    IEnumerable<IGrouping<Gender, Person>> genderGroup = people                   // from p in people
                                                         .GroupBy(p => p.Gender); // group p by p.Gender 
														 
	genderGroup.Dump();														 
            // 02. Grouping by Property
    IEnumerable<IGrouping<int, Person>> ageGroup = people                      // from p in people
                                                   .Where(p => p.Age > 20)     // where p.Age > 20
                                                   .GroupBy(p => p.Age);       // group p by p.Age	
												   
	ageGroup.Dump();
	
    // 03. Group & order
    var alphabeticalGroup = people.OrderBy(p => p.FirstName).GroupBy(p => p.FirstName[0]);	
	alphabeticalGroup.Dump();
	
    // 04. Group by multiple keys
    var multiGroup = people.GroupBy(p => new { p.Gender, p.Age });	
	multiGroup.Dump();
	
    // 05. from 04 order by items in key
    var orderedGroupsAndCount = multiGroup.OrderBy(key => key.Count());	
	orderedGroupsAndCount.Dump();

    // 06. Order the keys in a group (into..)
    var multiGroupKeyOrderSingleLine = people.GroupBy(p => new { p.Gender, p.Age }).OrderBy(p => p.Count());
	multiGroupKeyOrderSingleLine.Dump();
	
    // 07. Even/Odd numbers group
    int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

    var numbers = arrayOfNumbers.OrderBy(n => n)
                                .GroupBy(n => (n % 2 == 0) ? "Even" : "Odd")
                                .OrderBy(key => key.Count());
	numbers.Dump();
								
    // 08. Multiple custom groups
    var peopleMultiGrouping = people.GroupBy(p => p.Age < 20
                                                        ? "Young"
                                                        : p.Age >= 20 && p.Age <= 22
                                                            ? "Adult"
                                                            : "Senior");	
	peopleMultiGrouping.Dump();
										
    // 09. How many items in each group
    var howManyOfEachGroup = people.GroupBy(p => p.Gender)
								   .OrderBy(p => p.Count())
                                   .Select(p => new
                                   {
                                       Gender = p.Key,
                                       NumOfPeople = p.Count()
                                   })
								   ;															
	howManyOfEachGroup.Dump();								   
}

// Define other methods and classes here
internal class Person
{
    private string firstName;
    private string lastName;
    private int id;
    private int height;
    private int age;

    private Gender gender;

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }

    public int ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public int Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.height = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public Gender Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            this.gender = value;
        }
    }

    public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.Height = height;
        this.Age = age;
        this.Gender = gender;
    }
}

internal enum Gender
{
    Male,
    Female
}