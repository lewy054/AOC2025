namespace Day1;

public class Safe(int initialDial)
{
    private const int MaxDial = 99;
    private const int MinDial = 0;
    public int Password { get; private set; }

    private int SafeDial = initialDial;

    public void TurnDial(char direction, int distance, CountingMode mode)
    {
        var step = direction == 'R' ? 1 : -1;

        for (var i = 0; i < distance; i++)
        {
            SafeDial += step;

            if (SafeDial > MaxDial)
            {
                SafeDial = MinDial;
            }

            if (SafeDial < MinDial)
            {
                SafeDial = MaxDial;
            }

            if (SafeDial == 0 && mode == CountingMode.EveryZero)
            {
                Password++;
            }
        }

        if (SafeDial == 0 && mode == CountingMode.FinalPositionOnly)
        {
            Password++;
        }
    }
}