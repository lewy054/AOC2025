using Day5;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();

var separatorIndex = input.FindIndex(string.IsNullOrWhiteSpace);
var freshIngredientsRanges = input.Take(separatorIndex).ToList();
var availableIngredientIds = input.Skip(separatorIndex + 1).ToList();
var refrigerator = new Refrigerator();

foreach (var freshIngredientsRange in freshIngredientsRanges)
{
    var ranges = freshIngredientsRange.Split("-");
    var from = ulong.Parse(ranges[0]);
    var to = ulong.Parse(ranges[1]);
    refrigerator.PutFreshIngredientIdRange(from, to);
}

foreach (var availableIngredientId in availableIngredientIds)
{
    refrigerator.AddIngredientId(ulong.Parse(availableIngredientId));
}

var freshIngredientsCount = refrigerator.GetFreshIngredientsCount();
Console.WriteLine($"Results of Day5, Part1 : {freshIngredientsCount}");

var freshIngredientsBasedOnRangesCount = refrigerator.GetFreshIngredientsBasedOnRangesCount();
Console.WriteLine($"Results of Day5, Part2 : {freshIngredientsBasedOnRangesCount}");