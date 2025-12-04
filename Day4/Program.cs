using Day4;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();

var warehouse = new Warehouse(input);
var accessiblePaperRolls = warehouse.GetAccessiblePaperRolls();
Console.WriteLine($"Results of Day1, Part1 : {accessiblePaperRolls}");

var howManyPaperRollsCanBeRemoved = warehouse.HowManyPaperRollsCanBeRemoved();
Console.WriteLine($"Results of Day1, Part2 : {howManyPaperRollsCanBeRemoved}");
