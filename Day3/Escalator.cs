using Infrastructure;

namespace Day3;

public class Escalator(List<string> banks)
{
    private List<string> Batteries { get; } = banks;

    public UInt128 GetMaxJoltageBatteries(int digits)
    {
        UInt128 totalJoltage = 0;
        foreach (var battery in Batteries)
        {
            var maxJoltage = battery.GetHighestNumber(digits);
            totalJoltage += maxJoltage;
        }

        return totalJoltage;
    }
}