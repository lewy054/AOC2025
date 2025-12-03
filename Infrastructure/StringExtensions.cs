namespace Infrastructure;

public static class StringExtensions
{
    extension(string text)
    {
        public List<string> SplitIntoParts(int parts)
        {
            var partLength = text.Length / parts;
            var result = new List<string>();

            for (var i = 0; i < parts; i++)
            {
                result.Add(text.Substring(i * partLength, partLength));
            }

            return result;
        }

        public bool AllCharactersSame()
        {
            return text.All(ch => ch == text.First());
        }

        public bool HasRepeatedParts()
        {
            var length = text.Length;
            for (var partCount = 2; partCount <= length / 2; partCount++)
            {
                if (length % partCount != 0)
                    continue;

                var parts = text.SplitIntoParts(partCount);
                if (parts.All(p => p == parts.First()))
                    return true;
            }

            return false;
        }

        public List<int> SortNumericString()
        {
            return text
                .Select(c => int.Parse(c.ToString()))
                .OrderBy(x => x)
                .ToList();
        }
        
        public UInt128 GetHighestNumber(int howManyDigits)
        {
            var final = "";
            var remaining = text;
            while (final.Length < howManyDigits)
            {
                var remainingLengthNeeded = howManyDigits - final.Length;
                var maxIndex = 0;
                
                // stop before the end to ensure enough digits remain for the final number
                for (var i = 0; i <= remaining.Length - remainingLengthNeeded; i++)
                {
                    if (remaining[i] > remaining[maxIndex])
                        maxIndex = i;
                }
                final += remaining[maxIndex];

                remaining = remaining[(maxIndex + 1)..];
            }
            return UInt128.Parse(final);
        }
    }
}