using Day9;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();

var redTilesLocations = LoadRedTilesLocations(input);
var rectangleAreas = CreateRectangles(redTilesLocations);
var largestRectangleByArea = rectangleAreas.MaxBy(e => e.CalculateArea());
Console.WriteLine($"Results of Day8, Part1 : {largestRectangleByArea?.CalculateArea()}");

var filledRectangle = GetRectanglesInsideBox(rectangleAreas, redTilesLocations);
var largestFilledRectangle = filledRectangle.MaxBy(e => e.CalculateArea());
Console.WriteLine($"Results of Day8, Part2 : {largestFilledRectangle?.CalculateArea()}");

return;

List<Rectangle> GetRectanglesInsideBox(List<Rectangle> rectanglesWithArea, List<Location> redTileLocations)
{
    var orderedRectangle = rectanglesWithArea
        .OrderByDescending(r => r.CalculateArea());
    var rectanglesInside = new List<Rectangle>();
    foreach (var rectangle in orderedRectangle)
    {
        var isInsideRectangle = rectangle.IsInsidePoints(redTileLocations);
        if (isInsideRectangle)
        {
            rectanglesInside.Add(rectangle);
        }
    }

    return rectanglesInside;
}


List<Rectangle> CreateRectangles(List<Location> locations)
{
    var rectangles = new List<Rectangle>();
    for (var i = 0; i < locations.Count; i++)
    {
        for (var j = i + 1; j < locations.Count; j++)
        {
            var rectangle = new Rectangle(locations[i], locations[j]);
            rectangles.Add(rectangle);
        }
    }

    return rectangles;
}

List<Location> LoadRedTilesLocations(List<string> list)
{
    var redTiles = new List<Location>();
    foreach (var line in list)
    {
        var redTileLocation = line.Split(',');
        redTiles.Add(new Location()
        {
            X = int.Parse(redTileLocation[0]),
            Y = int.Parse(redTileLocation[1]),
        });
    }

    return redTiles;
}