using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace letKeyword
{
    public class EntryPoint
    {
        static void Main()
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

            //----------------------------------------------
            SeparatingLine();
            // 1. Extracting People with names that start with 'a'
            var peopleWithA = from p in people
                              let pNameFirstLetter = p.FirstName.ToLower()[0]
                              where pNameFirstLetter == 'a'
                              select p;
            
            foreach (var p in peopleWithA)
            {
                Console.WriteLine($"My name is {p.FirstName} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Extracting New Objects from people names that start with 'a'
            var peopleWithAObj = from p in people
                                 let pNameFirstLetter = p.FirstName.ToLower()[0]
                                 where pNameFirstLetter == 'a'
                                 select new { Name = string.Format($"{p.FirstName} {p.LastName}"), p.Age };

            foreach (var p in peopleWithAObj)
            {
                Console.WriteLine($"My name is {p.Name} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            SeparatingLine();
            // 3. Collection of Collections into a single Collection
            var youngPersonFullName = from p in people
                                      where p.Age < 25
                                      let fN = string.Format($"{p.FirstName} {p.LastName}")
                                      select new YoungPerson { FullName = fN, Age = p.Age };

            foreach (var p in youngPersonFullName)
            {
                Console.WriteLine($"My name is {p.FullName} and I am {p.Age} years old.");
            }

            //----------------------------------------------
            SeparatingLine();
            // 4. Collection of Collections into a single Collection
            List<List<int>> list = new List<List<int>>
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 }
            };

            var allNumbers = from l in list
                             let numbers = l
                             from n in numbers
                             select n;

            foreach (var n in allNumbers)
            {
                Console.WriteLine($"{n}");
            }

            //----------------------------------------------
            SeparatingLine();
            // 5. Collection of Collections into a single Collection of Squared Numbers that are less than 50
            var allNumbersSquared = from l in list
                                    from n in l
                                    let squared = n * n
                                    where squared < 50
                                    select squared;

            foreach (var n in allNumbersSquared)
            {
                Console.WriteLine($"{n}");
            }

            //----------------------------------------------
            SeparatingLine();
            // (A bit more advanced example) 6. Extract persons whos age is less than the average age of all persons
            var lessThanAverageAge = from p in people
                                    let averageAge = people.Sum(person => person.Age) / people.Count
                                    where p.Age < averageAge
                                    select p;

            foreach (var p in lessThanAverageAge)
            {
                Console.WriteLine($"Name: {p.FirstName}, Age: {p.Age}");
            }
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('=', 40));
        }
    }
    
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
}
