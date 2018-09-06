<Query Kind="Program" />

void Main()
{
	    List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };
	// 01. Grouping Persons by Gender
	IEnumerable<IGrouping<Gender, Person>> genderGroup = from p in people
                                                        group p by p.Gender;
	genderGroup.Dump();	

    // 02. Grouping an Object by Property, Persons by Age with condition
    IEnumerable<IGrouping<int, Person>> ageGroup = from p in people
                                                   where p.Age > 20
                                                   group p by p.Age;	
	ageGroup.Dump();
	
	// 03. Grouping an Object by Property, Alphabetical Grouping
    IEnumerable<IGrouping<char, Person>> alphabeticalGroup = from p in people
                                                             orderby p.FirstName
                                                             group p by p.FirstName[0];	
	alphabeticalGroup.Dump();
	
	// 04. Grouping by Multikey
    var multiGroup = from p in people
                     group p by new { p.Gender, p.Age };	
	multiGroup.Dump();
	
    // 5. Ordering by amount of numbers in each key (group)
    var orderedGroupsAndCount = from g in multiGroup
                                orderby g.Count()
                                select g;	
	orderedGroupsAndCount.Dump();
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