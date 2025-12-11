namespace Day9;

public class Rectangle(Location firstCorner, Location secondCorner)
{
    public Location FirstCorner { get; set; } = firstCorner;
    public Location SecondCorner { get; set; } = secondCorner;


    public long CalculateArea()
    {
        var width = Math.Abs(FirstCorner.X - SecondCorner.X) + 1L;
        var height = Math.Abs(FirstCorner.Y - SecondCorner.Y) + 1L;
        var area = width * height;
        return area;
    }

    public bool IsInsidePoints(List<Location> locations)
    {
        var rectangleXMin = Math.Min(FirstCorner.X, SecondCorner.X);
        var rectangleXMax = Math.Max(FirstCorner.X, SecondCorner.X);
        var rectangleYMin = Math.Min(FirstCorner.Y, SecondCorner.Y);
        var rectangleYMax = Math.Max(FirstCorner.Y, SecondCorner.Y);

        for (var i = 0; i < locations.Count; i++)
        {
            var firstBorderPoint = locations[i];
            var secondBorderPoint = locations[(i + 1) % locations.Count];

            // Vertical borderline
            if (firstBorderPoint.X == secondBorderPoint.X)
            {
                var minY = Math.Min(firstBorderPoint.Y, secondBorderPoint.Y);
                var maxY = Math.Max(firstBorderPoint.Y, secondBorderPoint.Y);

                if (firstBorderPoint.X > rectangleXMin && firstBorderPoint.X < rectangleXMax)
                {
                    if (rectangleYMax > minY && rectangleYMin < maxY)
                    {
                        return false;
                    }
                }
            }
            // Horizontal borderline
            else if (firstBorderPoint.Y == secondBorderPoint.Y)
            {
                var y = firstBorderPoint.Y;
                var minX = Math.Min(firstBorderPoint.X, secondBorderPoint.X);
                var maxX = Math.Max(firstBorderPoint.X, secondBorderPoint.X);

                if (y > rectangleYMin && y < rectangleYMax)
                {
                    if (rectangleXMax > minX && rectangleXMin < maxX)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}