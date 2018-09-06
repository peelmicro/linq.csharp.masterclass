using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftOuterJoin
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
                new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40 },
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
            // 01. Left Outer Join producing Type Specific Object for default (no match) scenarios
            var leftOuterJoinType = from s in suppliers
                                    join b in buyers on s.District equals b.District into buyersGroup
                                    select new
                                    {
                                        s.Name,
                                        s.District,
                                        Buyers = buyersGroup.DefaultIfEmpty(
                                            new Buyer()
                                            {
                                                Name = "No one here",
                                                District = "Nowhere"
                                            })
                                    };

            foreach (var item in leftOuterJoinType)
            {
                Console.WriteLine($"{item.District}, {item.Name}");
                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"  {buyer.District} {buyer.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 02. Left Outer Join producing Anonymous Object for default (no match) scenarios
            var leftOuterJoinAnon = from s in suppliers
                                    join b in buyers on s.District equals b.District into buyersGroup
                                    from b in buyersGroup.DefaultIfEmpty()
                                    select new
                                    {
                                        s.Name,
                                        s.District,
                                        BuyersName = b?.Name ?? "No one here",
                                        BuyersDistrict = b?.District ?? "Nowhere"
                                    };

            foreach (var item in leftOuterJoinAnon)
            {
                Console.WriteLine($"{item.District}");
                Console.WriteLine($"  {item.Name}, {item.BuyersName}");
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