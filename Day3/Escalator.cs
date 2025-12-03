using Infrastructure;

namespace Day3;

public class Escalator(List<string> banks)
{
    private List<string> Batteries { get; set; } = banks;

    public int GetMaxJoltageFromTwoBatteries()
    {
        var totalJoltage = 0;
        foreach (var battery in Batteries)
        {
            var maxJoltage = battery.GetHighestNumber(2);
            totalJoltage += maxJoltage;
        }

        return totalJoltage;
    }
}