using Infrastructure;

namespace Day8;

public class ChristmasDecoration
{
    public List<JunctionBox> JunctionBoxes { get; set; } = [];

    public void InitializeJunctionBoxes(List<string> list)
    {
        foreach (var line in list)
        {
            var numbers = line.Split(',');
            JunctionBoxes.Add(new JunctionBox()
            {
                X = int.Parse(numbers[0]),
                Y = int.Parse(numbers[1]),
                Z = int.Parse(numbers[2])
            });
        }
    }

    public List<JunctionDistance> CalculateDistanceBetweenJunctionBoxes()
    {
        List<JunctionDistance> junctionDistances = [];

        for (var i = 0; i < JunctionBoxes.Count; i++)
        {
            for (var j = i + 1; j < JunctionBoxes.Count; j++)
            {
                var distance = Distance.CalculateDistanceBetweenTwoPoints(JunctionBoxes[i].X, JunctionBoxes[i].Y,
                    JunctionBoxes[i].Z,
                    JunctionBoxes[j].X, JunctionBoxes[j].Y, JunctionBoxes[j].Z);
                junctionDistances.Add(new JunctionDistance()
                {
                    Junction1 = JunctionBoxes[i],
                    Junction2 = JunctionBoxes[j],
                    StraightLineDistance = distance
                });
            }
        }

        return junctionDistances;
    }

    public List<List<JunctionBox>> GetCircuitsAfterNConnections(List<JunctionDistance> distances, int howMany)
    {
        var circuits = new List<List<JunctionBox>>();
        var ordered = distances.OrderBy(d => d.StraightLineDistance).ToList();

        for (var i = 0; i < howMany && i < ordered.Count; i++)
        {
            circuits = GetCircuits(circuits, ordered[i]);
        }

        return circuits;
    }

    public static List<List<JunctionBox>> GetCircuits(List<List<JunctionBox>> circuits, JunctionDistance distance)
    {
        var circuit1 = circuits.FirstOrDefault(l => l.Contains(distance.Junction1));
        var circuit2 = circuits.FirstOrDefault(l => l.Contains(distance.Junction2));
        if (circuit1 != null && circuit2 != null)
        {
            if (circuit1 != circuit2)
            {
                circuit1.AddRange(circuit2);
                circuits.Remove(circuit2);
            }
        }
        else if (circuit1 != null)
        {
            circuit1.Add(distance.Junction2);
        }
        else if (circuit2 != null)
        {
            circuit2.Add(distance.Junction1);
        }
        else
        {
            circuits.Add([distance.Junction1, distance.Junction2]);
        }


        return circuits;
    }

    public (JunctionBox Junction1, JunctionBox Junction2) GetLastConnection(
        List<JunctionDistance> junctionDistances)
    {
        var orderedDistances = junctionDistances.OrderBy(d => d.StraightLineDistance).ToList();
        var circuits = new List<List<JunctionBox>>();

        foreach (var dist in orderedDistances)
        {
            var circuit1 = circuits.FirstOrDefault(c => c.Contains(dist.Junction1));
            var circuit2 = circuits.FirstOrDefault(c => c.Contains(dist.Junction2));

            if (circuit1 != null && circuit2 != null)
            {
                if (circuit1 != circuit2)
                {
                    circuit1.AddRange(circuit2);
                    circuits.Remove(circuit2);
                    var allCircuitsCount = circuits.Sum(c => c.Count);
                    if (circuits.Count == 1 && allCircuitsCount == JunctionBoxes.Count)
                    {
                        return (dist.Junction1, dist.Junction2);
                    }
                }
            }
            else if (circuit1 != null)
            {
                circuit1.Add(dist.Junction2);
            }
            else if (circuit2 != null)
            {
                circuit2.Add(dist.Junction1);
            }
            else
            {
                circuits.Add([dist.Junction1, dist.Junction2]);
            }
            var allCircuitsCountSum = circuits.Sum(c => c.Count);
            if (circuits.Count == 1 && allCircuitsCountSum == JunctionBoxes.Count)
            {
                return (dist.Junction1, dist.Junction2);
            }
        }

        throw new InvalidOperationException("Could not find the last connection; the circuits never connect.");
    }
}