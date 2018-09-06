using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoiningIntro
{
    class EntryPoint
    {
        static void Main()
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };

            //----------------------------------------------
            SeparatingLine();
            // 1. Simple Inner Join, just selecting properties
            var innerJoin = from b in buyers
                            orderby b.District
                            join s in suppliers on b.District equals s.District
                            select new
                            {
                                Supplier = s.Name,
                                Buyer = b.Name,
                                District = b.District
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine($"District: {item.District}, Supplier: {item.Supplier}, Buyer: {item.Buyer}");
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Joining by more than one key
            var compositeJoin = from b in buyers
                                join s in suppliers on new { b.District, b.Age } equals new { s.District, s.Age }
                                select new
                                {
                                    Supplier = s,
                                    BuyerName = b.Name
                                };

            foreach (var item in compositeJoin)
            {
                Console.WriteLine($"District: {item.Supplier.District}, Age: {item.Supplier.Age}");
                Console.WriteLine($"  Supplier: {item.Supplier.Name}");
                Console.WriteLine($"  Supplier: {item.BuyerName}");
                Console.WriteLine();
            }
        }

        private static void SeparatingLine()
        {
            Console.WriteLine(new string('-', 40));
        }
    }

    internal class Supplier
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }
    
}
