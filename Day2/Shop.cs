namespace Day2;

public class Shop
{
    public List<IdRange> IdRanges { get; set; } = [];

    public void LoadIdRanges(string input)
    {
        input.Split(',').ToList().ForEach(idRange =>
            {
                var ranges = idRange.Split('-');
                var from = UInt128.Parse(ranges[0]);
                var to = UInt128.Parse(ranges[1]);
                IdRanges.Add(new IdRange(from, to));
            }
        );
    }

    public List<UInt128> FindInvalidIds()
    {
        var invalidIds = new List<UInt128>();
        foreach (var idRange in IdRanges)
        {
            for (var id = idRange.From; id <= idRange.To; id++)
            {
                var length = id.ToString().Length;
                if (length % 2 != 0)
                {
                    continue;
                }
                var firstHalf = id.ToString()[..(id.ToString().Length / 2)];
                var secondHalf = id.ToString()[(id.ToString().Length / 2)..];
                if (firstHalf != secondHalf)
                {
                    continue;
                }
                invalidIds.Add(id);
            }
        }

        return invalidIds;
    }
}