using Day2;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();
var line = input.First();

var shop = new Shop();
shop.LoadIdRanges(line);
var doubleRepeatIds = shop.FindDoubleRepeatIds();
var doubleRepeatIdsSum = doubleRepeatIds.Aggregate(UInt128.Zero, (acc, x) => acc + x);
Console.WriteLine($"Results of Day1, Part1 : {doubleRepeatIdsSum}");

var repeatedPatternIds = shop.FindRepeatedPatternIds();
var repeatedPatternIdsSum = repeatedPatternIds.Aggregate(UInt128.Zero, (acc, x) => acc + x);
Console.WriteLine($"Results of Day1, Part1 : {repeatedPatternIdsSum}");