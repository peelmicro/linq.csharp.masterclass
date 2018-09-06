<Query Kind="Statements" />

// Partitioning Operations - Taking specific parts of a collection
int[] ints = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 3, 4, 5, 5, 6, 7, 8, 8, 4, 3 };

// 01. Chaining Skip and Take
int[] ints2 = ints.Skip(10).Take(5).ToArray();
ints2.Dump();
int[] topThree = ints.OrderByDescending(i => i).Take(3).ToArray();
topThree.Dump();

// 02. SkipWhile and TakeWhile with conditions
int[] intsSkipWhile = ints.SkipWhile(i => i < 5).ToArray();
intsSkipWhile.Dump();
int[] intsTakeWhile = ints.TakeWhile(i => i < 6).ToArray();
intsTakeWhile.Dump();

// 03. Chaining SkipWhile and TakeWhile
int[] moreInts = ints.SkipWhile(i => i < 3).TakeWhile(i => i < 5).ToArray();
moreInts.Dump();