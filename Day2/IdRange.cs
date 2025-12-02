namespace Day2;

public class IdRange
{
    public UInt128 From { get; set; }
    public UInt128 To { get; set; }

    public IdRange(UInt128 from, UInt128 to)
    {
        From = from;
        To = to;
    }
}