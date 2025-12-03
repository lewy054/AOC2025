using Day3;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();
var escalator = new Escalator(input);
var maxJoltageFromTwoBatteries = escalator.GetMaxJoltageBatteries(2);
Console.WriteLine($"Results of Day1, Part1 : {maxJoltageFromTwoBatteries}");

var maxJoltageFromTwelveBatteries = escalator.GetMaxJoltageBatteries(12);
Console.WriteLine($"Results of Day1, Part1 : {maxJoltageFromTwelveBatteries}");
