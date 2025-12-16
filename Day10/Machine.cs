namespace Day10;

public class Machine
{
    public Machine(List<bool> lightIndicatorsTargetState, List<List<int>> buttonsWiring, List<int> joltage)
    {
        LightIndicatorsCurrentState = new List<bool>(
            new bool[lightIndicatorsTargetState.Count]
        );
        LightIndicatorsTargetState = lightIndicatorsTargetState;
        ButtonsWiring = buttonsWiring;
        Joltage = joltage;
    }

    private List<bool> LightIndicatorsCurrentState { get; set; }
    private List<bool> LightIndicatorsTargetState { get; set; }
    private List<List<int>> ButtonsWiring { get; set; }
    private List<int> Joltage { get; set; }

    public int GetButtonsCount()
    {
        return ButtonsWiring.Count;
    }
    

    public int GetMinimalButtonPresses()
    {
        return FindMinimalPresses(0, [..LightIndicatorsCurrentState], 0);
    }

    private bool CheckLightIndicator(List<bool> lights)
    {
        return LightIndicatorsTargetState.SequenceEqual(lights);
    }


    private int FindMinimalPresses(int buttonIndex, List<bool> currentLights, int pressesSoFar)
    {
        if (CheckLightIndicator(currentLights))
        {
            return pressesSoFar;
        }

        if (buttonIndex == GetButtonsCount())
        {
            return int.MaxValue;
        }

        var withoutPress = FindMinimalPresses(buttonIndex + 1, [..currentLights], pressesSoFar);

        var pressedLights = new List<bool>(currentLights);
        ToggleLights(pressedLights, buttonIndex);

        var withPress = FindMinimalPresses(buttonIndex + 1, pressedLights, pressesSoFar + 1);

        return Math.Min(withoutPress, withPress);
    }
    
    private void ToggleLights(List<bool> lights, int buttonIndex)
    {
        foreach (var lightId in ButtonsWiring[buttonIndex])
        {
            lights[lightId] = !lights[lightId];
        }
    }
}