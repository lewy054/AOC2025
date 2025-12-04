using Infrastructure;

namespace Day4;

public class Part1(List<string> input)
{
    public List<string> Input { get; set; } = input;
    private const char CharToFind = '@';

    public int Resolve()
    {
        var accessiblePaperRolls = 0;
        for (var y = 0; y < input.Count; y++)
        {
            for (var x = 0; x < input[y].Length; x++)
            {
                if (input[y][x] != CharToFind)
                {
                    continue;
                }
                var howManyNeighbours = input.CountNeighbors(x, y, CharToFind);
                if (howManyNeighbours < 4)
                {
                    accessiblePaperRolls++;
                }
            }
        }

        return accessiblePaperRolls;
    }
}