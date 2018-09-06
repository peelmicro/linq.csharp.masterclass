<Query Kind="Program" />

void Main()
{
    string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
    List<int> numbers = new List<int>() { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
    object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4, };

    // 1. Extract odd numbers with Lambda
    var oddNumbers = numbers.Where(n => (n % 2) == 1);	
	
	oddNumbers.Dump();
	
    // 2. Select vs Where
    List<Warrior> warriors = new List<Warrior>()
    {
        new Warrior() { Height = 100 },
        new Warrior() { Height = 80 },
        new Warrior() { Height = 100 },
        new Warrior() { Height = 70 },
    };

    var heights = warriors.Where(wh => wh.Height == 100)
                                .Select(wh => wh.Height);
	heights.Dump();
	
	
}

// Define other methods and classes here
internal class Warrior
{
    public int Height { get; set; }
}