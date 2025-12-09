namespace Infrastructure;

public static class Distance
{
    public static double CalculateDistanceBetweenTwoPoints(int x1, int y1, int z1, int x2, int y2, int z2)
    {
        var distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
        return distance;
    }
}