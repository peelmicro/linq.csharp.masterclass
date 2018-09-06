<Query Kind="Statements" />

var repeated = Enumerable.Repeat(5,10);
repeated.Dump();

var oddNumbers = Enumerable.Range(1, 10).Where(n => n % 2 == 0);
oddNumbers.Dump();

var evenNumbers = from n in Enumerable.Range(1, 10)
                  where n % 2 != 0
                  select n;
evenNumbers.Dump();

var squared = Enumerable.Range(1, 10).Select(n => n * n);
squared.Dump();

var squared2 = from n in Enumerable.Range(1, 10)
               select n * n;
squared2.Dump();

Random rng = new Random();
var randoms = Enumerable.Range(1, 10).Select(_ => rng.Next(1, 100));
randoms.Dump();

var alphabet = Enumerable.Range(0, 26).Select(c => ((char)(c + 'a')).ToString());
alphabet.Dump();

var fontSizes = Enumerable.Range(1, 10).Select(i => (i * 10) + " pt");
fontSizes.Dump();