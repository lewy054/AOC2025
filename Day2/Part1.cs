namespace Day2;

using System.Numerics;

public class Part1(string input)
{
    public UInt128 Resolve()
    {
        var shop = new Shop();
        shop.LoadIdRanges(input);
        var invalidIds = shop.FindInvalidIds();
        var sum = invalidIds.Aggregate(UInt128.Zero, (acc, x) => acc + x);
        return sum;
    }
}