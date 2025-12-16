using System.Text.RegularExpressions;
using Day10;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();
var machines = new List<Machine>();
foreach (var line in input)
{
    var lightIndicatorsTargetState = GetLightIndicatorsTargetState(line);
    var buttonsWiring = GetButtonsWiring(line);

    var joltage = GetJoltage(line);
    var machine = new Machine(lightIndicatorsTargetState, buttonsWiring, joltage);
    machines.Add(machine);
}
var manual = new Manual(machines);
var result = manual.TurnOnMachines();
Console.WriteLine($"Results of Day10, Part1 : {result}");

return;

List<List<int>> GetButtonsWiring(string line)
{
    var list = new List<List<int>>();
    var matches = Regex.Matches(line, @"\(([^)]*)\)");
    foreach (Match match in matches)
    {
        var numbers = match.Groups[1].Value
            .Split(',', StringSplitOptions.RemoveEmptyEntries);

        var innerList = numbers.Select(n => int.Parse(n.Trim())).ToList();

        list.Add(innerList);
    }

    return list;
}


List<bool> GetLightIndicatorsTargetState(string line)
{
    var chars = Regexes.CharsBetweenSquareBracket().Match(line).Groups[1].Value;
    var state = chars.Select(c => c != '.').ToList();
    return state;
}

List<int> GetJoltage(string line)
{
    var match = Regexes.NumbersBetweenCurlyBrace().Match(line);
    return Regexes.NumbersRegex().Matches(match.Groups[1].Value)
        .Select(m => int.Parse(m.Value))
        .ToList();
}
