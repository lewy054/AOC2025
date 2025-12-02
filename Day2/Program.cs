using Day2;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();
var line = input.First();
var part1 = new Part1(line);
var part1Result = part1.Resolve();
Console.WriteLine($"Results of Day1, Part1 : {part1Result}");
//
// var part2 = new Part2(line);
// var part2Result = part2.Resolve();
// Console.WriteLine($"Results of Day1, Part2 : {part2Result}");