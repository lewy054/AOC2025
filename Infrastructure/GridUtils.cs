namespace Infrastructure;

public static class GridUtils
{
    static readonly (int dx, int dy)[] NeighborOffsets =
    [
        (-1, -1), (0, -1), (1, -1),
        (-1, 0), (1, 0),
        (-1, 1), (0, 1), (1, 1)
    ];

    public static int CountNeighbors(this List<string> grid, int x, int y, char target)
    {
        var count = 0;

        foreach (var (dx, dy) in NeighborOffsets)
        {
            var nx = x + dx;
            var ny = y + dy;

            if (ny < 0 || ny >= grid.Count)
            {
                continue;
            }

            if (nx < 0 || nx >= grid[ny].Length)
            {
                continue;
            }

            if (grid[ny][nx] == target)
                count++;
        }

        return count;
    }
}