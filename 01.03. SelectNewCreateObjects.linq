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
        new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
        new Person("John", "Jones", 7, 160, 37, Gender.Female),
        new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
        new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
        new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
        new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
        new Person("Lara", "Croft", 12, 162, 18, Gender.Female)
    };	
    // 1. Creating new anonymous objects for Young People
    var youngPeople = from p in people
                      where p.Age < 25
                      select new
                      {
                          FirstName = p.FirstName,
                          Age = p.Age
                      };	
	youngPeople.Dump();
	
    // 2. Reusing the Properties Names
    var youngPeopleSameProp = from p in people
                              where p.Age < 25
                              select new
                              {
                                  p.FirstName,
                                  p.Age
                              };	
	youngPeopleSameProp.Dump();		
	
    // 3. Reusing the Properties Names, Mix
    var youngPeopleMixProp = from p in people
                             where p.Age < 25
                             select new
                             {
                                 N = p.FirstName,
                                 p.Age
                             };	
	youngPeopleMixProp.Dump();							 
	
    // 4. Creating new YoungPerson Objects from Person
    var youngPersonObj = from p in people
                         where p.Age < 25
                         select new YoungPerson
                         {
                             FullName = p.FirstName,
                             Age = p.Age
                         };
	youngPersonObj.Dump();
	
    // 5. Creating new YoungPerson Objects from Person
    var youngPersonFullName = from p in people
                              where p.Age < 25
                              select new YoungPerson
                              {
                                  FullName = string.Format($"{p.FirstName} {p.LastName}"),
                                  Age = p.Age
                              };
	youngPersonFullName.Dump();							  
}

// Define other methods and classes here
   internal class YoungPerson
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }

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