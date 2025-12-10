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
}