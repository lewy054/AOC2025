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
    }
}