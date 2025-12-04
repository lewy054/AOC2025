using Day4;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();

var part1 = new Part1(input);
var accessiblePaperRolls = part1.Resolve();
Console.WriteLine($"Results of Day1, Part1 : {accessiblePaperRolls}");
