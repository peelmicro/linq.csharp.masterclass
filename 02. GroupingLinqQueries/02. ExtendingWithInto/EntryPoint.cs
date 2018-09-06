using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendingWithInto
{
    class EntryPoint
    {
        static void Main()
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

            //----------------------------------------------
            SeparatingLine();
            // 1. Order the keys in a group
            var orderedByKey = from p in people
                               group p by p.Age into ageGroup
                               orderby ageGroup.Key
                               select ageGroup;

            foreach (var key in orderedByKey)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var item in key)
                {
                    Console.WriteLine($" {item.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Custom Group
            int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            var numbers = from n in arrayOfNumbers
                          orderby n
                          let evenOrOdd = (n % 2 == 0) ? "Even" : "Odd"
                          group n by evenOrOdd into nums
                          orderby nums.Count()
                          select nums;

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Key}");
                foreach (var i in num)
                {
                    Console.WriteLine($" {i}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 3. Custom Grouping with More than 2 Groups
            var peopleMultiGrouping = from p in people
                                      let ageSelection =
                                            p.Age < 20                              // if age < 20 
                                                ? "Young"                           // go to young
                                                : p.Age >= 20 && p.Age <= 22        // else if age is >=20 and <= 22 
                                                    ? "Adult"                       // go to adult
                                                    : "Senior"                      // else go to senior
                                      group p by ageSelection;                      

            foreach (var p in peopleMultiGrouping)
            {
                Console.WriteLine($"{p.Key}");
                foreach (var i in p)
                {
                    Console.WriteLine($" {i.Age}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 4. Getting the Keys and Amount of Items in each Key (group)
            var howManyOfEachGroup = from p in people
                                     group p by p.Gender into g
                                     orderby g.Count()
                                     select new { Gender = g.Key, NumOfPeople = g.Count() };

            foreach (var amount in howManyOfEachGroup)
            {
                Console.WriteLine($"{amount.Gender}");
                Console.WriteLine($"{amount.NumOfPeople}");
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
