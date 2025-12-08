using Infrastructure;

namespace Day7;

public class BeamSimulator
{
    private const char StartLocationMark = 'S';
    private const char SplitterMark = '^';
    private readonly IList<string> input;
    private readonly List<Location> beamsLocations = [];
    private int splitCounter;

    public BeamSimulator(IList<string> input)
    {
        this.input = input;
    }

    public int Run()
    {
        InitializeStartBeam();

        for (var i = 2; i < input.Count; i++)
        {
            var splitters = FindSplitters(i);
            var beamsInPreviousLine = FindBeamLocations(i - 1);

            foreach (var beamLocation in beamsInPreviousLine)
            {
                if (CanGoDown(splitters, beamLocation))
                {
                    beamsLocations.Add(new Location()
                    {
                        X = beamLocation.X,
                        Y = i
                    });
                    continue;
                }

                var added = HandleSplit(beamLocation, i, splitters);
                if (added)
                {
                    splitCounter++;
                }
            }
        }

        return splitCounter;
    }

    private bool HandleSplit(Location beamLocation, int i, List<int> splitters)
    {
        var addedNewBeam = false;
        if (beamLocation.X > 0)
        {
            var newBeam = new Location()
            {
                X = beamLocation.X - 1,
                Y = i
            };
            if (!beamsLocations.Any(e => e.X == newBeam.X && e.Y == newBeam.Y) && !splitters.Contains(newBeam.X))
            {
                beamsLocations.Add(newBeam);
                addedNewBeam = true;
            }
        }

        if (beamLocation.X <= input[i].Length)
        {
            var newBeam = new Location()
            {
                X = beamLocation.X + 1,
                Y = i
            };
            if (!beamsLocations.Any(e => e.X == newBeam.X && e.Y == newBeam.Y) && !splitters.Contains(newBeam.X))
            {
                beamsLocations.Add(newBeam);
                addedNewBeam = true;
            }
        }

        return addedNewBeam;
    }

    private static bool CanGoDown(List<int> splitters, Location beamLocation)
    {
        return splitters.Count == 0 || splitters.All(e => e != beamLocation.X);
    }

    private void InitializeStartBeam()
    {
        var startX = input.First().IndexOf(StartLocationMark);
        beamsLocations.Add(new Location()
        {
            X = startX,
            Y = 1
        });
    }

    private List<int> FindSplitters(int y)
    {
        return input[y]
            .AllIndexesOf(SplitterMark.ToString())
            .ToList();
    }

    private List<Location> FindBeamLocations(int y)
    {
        return beamsLocations.Where(e => e.Y == y).ToList();
    }
}