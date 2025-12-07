using Infrastructure;

namespace Day6;

public class Problem
{
    public List<Number> Numbers { get; set; } = [];
    public char Symbol { get; set; }

    public long Calculate()
    {
        return Symbol switch
        {
            '*' => Numbers.Select(e => e.Value).Aggregate((a, b) => a * b),
            '+' => Numbers.Select(e => e.Value).Aggregate((a, b) => a + b),
            _ => -1
        };
    }

    
}