using Infrastructure;

namespace Day1;

public class Part2(IEnumerable<string> input)
{

    private const int RotationIndicatorIndex = 0;
    public int Resolve()
    {
        const int dial = 50;
        var safe = new Safe(dial);
        foreach (var line in input)
        {
            var distance = int.Parse(Regexes.NumbersRegex().Match(line).Value);
            var direction = line[RotationIndicatorIndex];
            safe.TurnDial(direction, distance, CountingMode.EveryZero);
        }

        return safe.Password;
    }
   
}