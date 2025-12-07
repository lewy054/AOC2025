using Day6;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();
var homework = new Homework();
var problems = homework.InitializeProblems(input);

var total = homework.GetTotalOfSolutions();
Console.WriteLine($"Results of Day6, Part1 : {total}");

//Part2

var homeWorkRightToLeft = new Homework();
homeWorkRightToLeft.InitializeProblemsWrittenRightToLeft(problems);
var totalRightToLeft = homeWorkRightToLeft.GetTotalOfSolutions();

Console.WriteLine($"Results of Day6, Part2 : {totalRightToLeft}");

return;