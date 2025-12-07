using Infrastructure;

namespace Day6;

public class Homework
{
    private List<Problem> Problems { get; set; } = [];

    public long GetTotalOfSolutions()
    {
        return Problems.Sum(problem => problem.Calculate());
    }

    public List<Problem> InitializeProblems(List<string> list)
    {
        Problems = [];
        foreach (var line in list)
        {
            var numberMatches = Regexes.NumbersRegex().Matches(line);
            var symbolMatches = Regexes.PlusAndMultiplySymbols().Matches(line);
            Problems.EnsureIndex(numberMatches.Count - 1);
            if (numberMatches.Count == 0)
            {
                //symbol
                for (var i = 0; i < symbolMatches.Count; i++)
                {
                    var number = symbolMatches[i].Value;
                    Problems[i].Symbol = number[0];
                }
            }
            else
            {
                for (var i = 0; i < numberMatches.Count; i++)
                {
                    Problems[i].Numbers.Add(new Number()
                    {
                        Value = long.Parse(numberMatches[i].Value),
                        StartIndex = numberMatches[i].Index
                    });
                }
            }
        }

        return Problems;
    }

    public List<Problem> InitializeProblemsWrittenRightToLeft(List<Problem> problems)
    {
        foreach (var problem in problems)
        {
            var newProblem = new Problem { Symbol = problem.Symbol };

            var maxNumber = problem.Numbers.OrderByDescending(e => e.Value).First();
            var lengthOfMax = maxNumber.Value.ToString().Length;
            for (var j = lengthOfMax - 1; j >= 0; j--)
            {
                var numberCombined = "";
                foreach (var number in problem.Numbers)
                {
                    var numberStr = number.Value.ToString();
                    var offset = Math.Abs(number.StartIndex - maxNumber.StartIndex);

                    if (j - offset >= numberStr.Length || j - offset < 0)
                    {
                        continue;
                    }

                    numberCombined += numberStr[j - offset];
                }

                newProblem.Numbers.Add(new Number
                {
                    Value = int.Parse(numberCombined)
                });
            }

            Problems.Add(newProblem);
        }
        return Problems;
    }
}