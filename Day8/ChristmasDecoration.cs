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
                var distance = Distance.CalculateDistanceBetweenTwoPoints(JunctionBoxes[i].X, JunctionBoxes[i].Y, JunctionBoxes[i].Z,
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

    public static List<List<JunctionBox>> GetShortestJunctionDistances(List<JunctionDistance> distances, int howManyShortestConnections)
    {
        var circuits = new List<List<JunctionBox>>();
        var orderedJunctionDistances = distances.OrderBy(e => e.StraightLineDistance).ToList();
        for (var i = 0; i < howManyShortestConnections; i++)
        {
            var circuit1 = circuits.FirstOrDefault(l => l.Contains(orderedJunctionDistances[i].Junction1));
            var circuit2 = circuits.FirstOrDefault(l => l.Contains(orderedJunctionDistances[i].Junction2));
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
                circuit1.Add(orderedJunctionDistances[i].Junction2);
            }
            else if (circuit2 != null)
            {
                circuit2.Add(orderedJunctionDistances[i].Junction1);
            }
            else
            {
                circuits.Add([orderedJunctionDistances[i].Junction1, orderedJunctionDistances[i].Junction2]);
            }
        }

        return circuits;
    }
}