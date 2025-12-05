namespace Day5;

public class Refrigerator
{
    private List<(ulong from, ulong to)> FreshIngredientsIdsRange { get; } = [];
    private List<ulong> IngredientIds { get; } = [];

    public void PutFreshIngredientIdRange(ulong from, ulong to)
    {
        FreshIngredientsIdsRange.Add((from, to));
    }

    public void AddIngredientId(ulong id)
    {
        IngredientIds.Add(id);
    }

    public int GetFreshIngredientsCount()
    {
        return GetFreshIngredients().Count;
    }

    public List<ulong> GetFreshIngredients()
    {
        var freshIngredientsIds = new List<ulong>();
        foreach (var productId in IngredientIds)
        {
            foreach (var (from, to) in FreshIngredientsIdsRange)
            {
                if (productId < from || productId > to)
                {
                    continue;
                }
                freshIngredientsIds.Add(productId);
                break;
            }
        }
        return freshIngredientsIds;
    }

    public ulong GetFreshIngredientsBasedOnRangesCount()
    {
        var ranges = FreshIngredientsIdsRange
            .OrderBy(r => r.from)
            .ToList();
        ulong totalFreshIngredientsCount = 0;
        var rangeStart = ranges.First().from;
        var rangeEnd = ranges.First().to;

        for (var i = 1; i < ranges.Count; i++)
        {
            var (from, to) = ranges[i];
            if (from <= rangeEnd + 1)
            {
                //ranges can be merged
                rangeEnd = Math.Max(rangeEnd, to);
            }
            else
            {
                totalFreshIngredientsCount += rangeEnd - rangeStart + 1;
                rangeStart = from;
                rangeEnd = to;
            }
        }
        totalFreshIngredientsCount += rangeEnd - rangeStart + 1;
        return totalFreshIngredientsCount;
    }

}