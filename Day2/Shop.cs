using Infrastructure;

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

    public List<UInt128> FindDoubleRepeatIds()
    {
        var invalidIds = new List<UInt128>();
        foreach (var idRange in IdRanges)
        {
            for (var id = idRange.From; id <= idRange.To; id++)
            {
                if (!IsInvalidByDuplicatedHalves(id))
                {
                    continue;
                }

                invalidIds.Add(id);
            }
        }

        return invalidIds;
    }

    public List<UInt128> FindRepeatedPatternIds()
    {
        var invalidIds = new List<UInt128>();
        foreach (var idRange in IdRanges)
        {
            for (var id = idRange.From; id <= idRange.To; id++)
            {
                var idString = id.ToString();

                var idLength = idString.Length;
                if (idLength < 2)
                {
                    continue;
                }

                if (IsInvalidByDuplicatedHalves(id))
                {
                    invalidIds.Add(id);
                    continue;
                }

                if (idString.HasRepeatedParts())
                {
                    invalidIds.Add(id);
                }

                if (idString.AllCharactersSame())
                {
                    invalidIds.Add(id);
                }
            }
        }

        return invalidIds;
    }


    private static bool IsInvalidByDuplicatedHalves(UInt128 id)
    {
        var length = id.ToString().Length;
        if (length % 2 != 0)
        {
            return false;
        }

        var firstHalf = id.ToString()[..(id.ToString().Length / 2)];
        var secondHalf = id.ToString()[(id.ToString().Length / 2)..];
        if (secondHalf[0] == '0')
        {
            return false;
        }

        if (firstHalf != secondHalf)
        {
            return false;
        }

        return true;
    }
}