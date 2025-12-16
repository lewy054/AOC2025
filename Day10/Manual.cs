using System.Collections.Concurrent;

namespace Day10;

public class Manual
{
    public Manual(List<Machine> machines)
    {
        Machines = machines;
    }

    public List<Machine> Machines { get; set; }


    public int TurnOnMachines()
    {
        var total = 0;

        Parallel.ForEach(Machines, machine =>
        {
            var presses = machine.GetMinimalButtonPresses();
            Interlocked.Add(ref total, presses);
        });

        return total;
    }
}