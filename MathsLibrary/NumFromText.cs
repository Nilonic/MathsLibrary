namespace MathsLibrary
{
    public static class NumFromText
    {
        public static long WordsToNumber(string words)
        {
            var numbers = new Dictionary<string, long>
    {
        {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5},
        {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}, {"ten", 10},
        {"eleven", 11}, {"twelve", 12}, {"thirteen", 13}, {"fourteen", 14},
        {"fifteen", 15}, {"sixteen", 16}, {"seventeen", 17}, {"eighteen", 18}, {"nineteen", 19},
        {"twenty", 20}, {"thirty", 30}, {"forty", 40}, {"fifty", 50},
        {"sixty", 60}, {"seventy", 70}, {"eighty", 80}, {"ninety", 90}
    };

            var multipliers = new Dictionary<string, long>
    {
        { "hundred", 100 },
        { "thousand", 1_000 },
        { "million", 1_000_000 },
        { "billion", 1_000_000_000 },
        { "trillion", 1_000_000_000_000 },
        { "quadrillion", 1_000_000_000_000_000 },
        { "quintillion", 1_000_000_000_000_000_000 }
    };

            long total = 0;
            long current = 0;

            foreach (var word in words.ToLower().Split([' ', '-', ','], StringSplitOptions.RemoveEmptyEntries))
            {
                if (word == "and") continue;

                if (numbers.TryGetValue(word, out long value))
                {
                    current += value;
                }
                else if (multipliers.TryGetValue(word, out long multiplier))
                {
                    current *= multiplier;
                    if (word != "hundred")
                    {
                        total += current;
                        current = 0;
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid word found: '{word}'");
                }
            }

            return total + current;
        }
        public static long TextToNumber(string text)
        {
            // just parse the string as an int
            if (long.TryParse(text, out long result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Invalid number format: '{text}'");
            }
        }
    }
}