using System.Text.RegularExpressions;

namespace Infrastructure;

public static partial class Regexes
{
    [GeneratedRegex("\\d+")]
    public static partial Regex NumbersRegex();
    
    [GeneratedRegex(@"[+*]")]
    public static partial Regex PlusAndMultiplySymbols();
    
    [GeneratedRegex(@"\{([^}]*)\}")]
    public static partial Regex NumbersBetweenCurlyBrace();
    
    [GeneratedRegex(@"\[(.*?)\]")]
    public static partial Regex CharsBetweenSquareBracket();
}