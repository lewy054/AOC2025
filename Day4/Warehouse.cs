using Infrastructure;

namespace Day4;

public class Warehouse(List<string> storedPaperRolls)
{
    private const char PaperRollMark = '@';
    private const char RemovedPaperRollMark = 'x';
    private List<string> StoredPaperRolls { get; } = storedPaperRolls;

    public int GetAccessiblePaperRolls()
    {
        var accessiblePaperRolls = 0;
        foreach (var (x, y) in GetPaperRollPositions(StoredPaperRolls))
        {
            if (StoredPaperRolls.CountNeighbors(x, y, PaperRollMark) < 4)
            {
                accessiblePaperRolls++;
            }
        }

        return accessiblePaperRolls;
    }

    public int HowManyPaperRollsCanBeRemoved()
    {
        var paperRollsInWarehouse = StoredPaperRolls.ToList();
        var removedPaperRolls = 0;
        while (true)
        {
            var paperRollsToRemove = GetPaperRollPositions(paperRollsInWarehouse)
                .Where(e => paperRollsInWarehouse.CountNeighbors(e.x, e.y, PaperRollMark) < 4)
                .ToList();

            if (paperRollsToRemove.Count == 0)
            {
                break;
            }

            foreach (var (x, y) in paperRollsToRemove)
            {
                var chars = paperRollsInWarehouse[y].ToCharArray();
                chars[x] = RemovedPaperRollMark;
                paperRollsInWarehouse[y] = new string(chars);
                removedPaperRolls++;
            }
        }

        return removedPaperRolls;
    }

    private static IEnumerable<(int x, int y)> GetPaperRollPositions(List<string> grid)
    {
        for (var y = 0; y < grid.Count; y++)
        {
            for (var x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] == PaperRollMark)
                    yield return (x, y);
            }
        }
    }
}