using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqGroupingIntro
{
    class EntryPoint
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
                new Person("Maria", "Ann", 6, 160, 19, Gender.Female),
                new Person("John", "Jones", 7, 160, 22, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 23, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 23, Gender.Female)
            };

            //----------------------------------------------
            SeparatingLine();
            // 01. Grouping Persons by Gender
            IEnumerable<IGrouping<Gender, Person>> genderGroup = from p in people
                                                                 group p by p.Gender;

            foreach (IGrouping<Gender, Person> item in genderGroup)
            {
                Console.WriteLine("People with Gender: " + item.Key);

                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}, Gender: {p.Gender}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 02. Grouping an Object by Property, Persons by Age with condition
            IEnumerable<IGrouping<int, Person>> ageGroup = from p in people
                                                           where p.Age > 20
                                                           group p by p.Age;

            foreach (IGrouping<int, Person> item in ageGroup)
            {
                Console.WriteLine("People with Age: " + item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}, Age: {p.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 03. Grouping an Object by Property, Alphabetical Grouping
            IEnumerable<IGrouping<char, Person>> alphabeticalGroup = from p in people
                                                                     orderby p.FirstName
                                                                     group p by p.FirstName[0];

            foreach (IGrouping<char, Person> item in alphabeticalGroup)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var p in item)
                {
                    Console.WriteLine($" {p.FirstName}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 4. Grouping by Multikey
            var multiGroup = from p in people
                             group p by new { p.Gender, p.Age };

            foreach (var item in multiGroup)
            {
                Console.WriteLine($"{item.Key}");

                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.FirstName}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 5. Ordering by amount of numbers in each key (group)
            var orderedGroupsAndCount = from g in multiGroup
                                        orderby g.Count()
                                        select g;

            foreach (var item in orderedGroupsAndCount)
            {
                Console.WriteLine($"Gender: {item.Key.Gender}, Age: {item.Key.Age}");
                foreach (Person i in item)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }

        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
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
