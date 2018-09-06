using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupJoin
{
    class EntryPoint
    {
        static void Main()
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District" },
                new Buyer() { Name = "Peter", District = "Scientists District" },
                new Buyer() { Name = "Paul", District = "Fantasy District" },
                new Buyer() { Name = "Maria", District = "Scientists District" },
                new Buyer() { Name = "Joshua", District = "EarthIsFlat District" },
                new Buyer() { Name = "Sylvia", District = "Developers District" },
                new Buyer() { Name = "Rebecca", District = "Scientists District" },
                new Buyer() { Name = "Jaime", District = "Developers District" },
                new Buyer() { Name = "Pierce", District = "Fantasy District" }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District" },
                new Supplier() { Name = "Charles", District = "Developers District" },
                new Supplier() { Name = "Hailee", District = "Scientists District" },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District" }
            };

            //----------------------------------------------
            SeparatingLine();
            // 1. Simple Group Join, the result of the join is in a variable (into ...) iterate on that variable to get the results
            var matchingSuppliersWithBuyers = from s in suppliers
                                              orderby s.District
                                              join b in buyers on s.District equals b.District into buyersGroup
                                              select new
                                              {
                                                  s.Name,
                                                  s.District,
                                                  Buyers = buyersGroup
                                              };

            foreach (var item in matchingSuppliersWithBuyers)
            {
                Console.WriteLine($"Supplier: {item.Name}, District: {item.District} " +
                    $"\nBuyers:");

                foreach (var buyer in item.Buyers)
                {
                    Console.WriteLine($"  {buyer.Name}");
                }
            }

            //----------------------------------------------
            SeparatingLine();
            // 2. Performing some operation on the joined collection
            var innerGroupJoin = from s in suppliers
                                 orderby s.District
                                 join b in buyers on s.District equals b.District into buyersGroup
                                 select new
                                 {
                                     s.District,
                                     s.Name,
                                     Buyers = from b in buyersGroup
                                              orderby b.Name
                                              select b
                                 };

            foreach (var supplier in innerGroupJoin)
            {
                Console.WriteLine($"Supplier: {supplier.Name}, District: {supplier.District}");

                foreach (var buyer in supplier.Buyers)
                {
                    Console.WriteLine($"  Buyer: {buyer.Name}, District: {buyer.District}");
                }
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
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string District { get; set; }
    }
}
