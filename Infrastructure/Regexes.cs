using System.Text.RegularExpressions;

namespace Infrastructure;

public static partial class Regexes
{
    [GeneratedRegex("\\d+")]
    public static partial Regex NumbersRegex();
}