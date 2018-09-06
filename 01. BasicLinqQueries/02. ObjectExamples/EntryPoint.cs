using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectExamples
{
    public class EntryPoint
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", 180, 70, Gender.Male),
                new Person("John", 170, 88, Gender.Male),
                new Person("Anna", 150, 48, Gender.Female),
                new Person("Kyle", 164, 77, Gender.Male),
                new Person("Anna", 164, 77, Gender.Male),
                new Person("Maria", 160, 55, Gender.Female),
                new Person("John", 160, 55, Gender.Female)
            };

            //----------------------------------------------
            SeparatingLine();
            // 1. Linq Example with Objects
            var fourCharPeople = from p in people
                                 where (p.Name.Length == 4)
                                 select p;

            foreach (var p in fourCharPeople)
            {
                Console.WriteLine(p.Name);
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Linq Example with Objects Condition and Ordering
            var fourCharPeopleOrdered = from p in people
                                        where (p.Name.Length == 4)
                                        orderby p.Weight
                                        select p;

            foreach (var p in fourCharPeopleOrdered)
            {
                Console.WriteLine(p.Name);
            }

            //----------------------------------------------
            SeparatingLine();
            // 3. Linq Example Extracting Properties from Objects in a new collection
            var extractedNames = from p in people
                                 where (p.Name.Length == 4)
                                 select p.Name;

            foreach (var p in extractedNames)
            {
                Console.WriteLine(p);
            }

            //----------------------------------------------
            SeparatingLine();
            // 4. Linq Example with Objects Condition and Special Ordering
            var peopleSpecialOrder = from p in people
                                     where (p.Name.Length == 4)
                                     orderby p.Name, p.Height
                                     select p;

            foreach (var p in peopleSpecialOrder)
            {
                Console.WriteLine($"Name: {p.Name}, Height: {p.Height}");
            }
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }

    internal class Person
    {
        private string name;
        private int height;
        private int weight;

        private Gender gender;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
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

        public Person(string name, int height, int weight, Gender gender)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }
}
