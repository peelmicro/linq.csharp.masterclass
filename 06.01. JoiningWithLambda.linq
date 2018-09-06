<Query Kind="Program" />

void Main()
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
	
    // 01. Simple Inner Join, just seleecting properties
    var innerJoin = suppliers.Join(buyers,
                              s => s.District, b => b.District,
                              (s, b) => new
                              {
                                  SupplierName = s.Name,
                                  BuyerName = b.Name,
                                  District = b.District
                              });	
	innerJoin.Dump();
    // 02. Joining by more than one key
    var compositeJoin = suppliers.Join(buyers,
                                       s => new { s.District, s.Age },
                                       b => new { b.District, b.Age },
                                       (s, b) => new
                                       {
                                           Supplier = s,
                                           BuyerName = b.Name
                                       });
	compositeJoin.Dump();
    // 03. Simple Group Join, the result of the join is in a variable (into ...) iterate on that variable to get the results
    var groupJoin = suppliers.GroupJoin(buyers, 
        s => s.District, b => b.District, 
        (s, buyersGroup) => new
            {
                s.Name,
                s.District,
                Buyers = buyersGroup.OrderBy(b => b.Name)
            });	
	groupJoin.Dump();
    // 04. Left Outer Join Buyer Object Returned
    var leftOuterJoinBuyer = suppliers.GroupJoin(
        buyers,
        s => s.District,
        b => b.District,
        (s, buyersGroup) => new
        {
            s.Name,
            s.District,
            Buyers = buyersGroup.DefaultIfEmpty(new Buyer() { Name = "No name", District = "No place", })
        })
        .SelectMany(s => s.Buyers,
                    (s, b) => new
                    {
                        SupplierName = s.Name,
                        Buyers = s.Buyers,
                        s.District
                    }
        );
	leftOuterJoinBuyer.Dump();
    // 05. Left Outer Join Anonymous object returned
    var leftOuterJoinAnon = suppliers.GroupJoin(buyers, 
        s => s.District, b => b.District,
        (s, buyersGroup) => new
        {
            s.Name,
            s.District,
            Buyers = buyersGroup.OrderBy(b => b.Name)
        })
        .SelectMany(s => s.Buyers.DefaultIfEmpty(),
        (s, b) => new
        {
            s.Name,
            s.District,
            BuyersName = b?.Name ?? "No name",
            BuyersDistrict = b?.District ?? "No place"
        });	
	leftOuterJoinAnon.Dump();		
}

// Define other methods and classes here
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