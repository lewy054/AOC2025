using Day3;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();
var escalator = new Escalator(input);
var maxJoltage = escalator.GetMaxJoltageFromTwoBatteries();
Console.WriteLine($"Results of Day1, Part1 : {maxJoltage}");

// var part2 = new Part2(input);
// var part2Result = part2.Resolve();
// Console.WriteLine($"Results of Day1, Part2 : {part2Result}");