using System.Text.RegularExpressions;

namespace Day03_Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.input.txt");
            var lineLength = lines[0].Length;

            var symbolsRegex = new Regex(@"[^0-9.]");
            var numbersRegex = new Regex(@"\d+");
            var gearRegex = new Regex(@"[*]");

            var possibleGears = new Dictionary<string, List<int>>();
            var validPartNumbers = new List<int>();

            var numbers = lines.SelectMany(
                    (line, lineNumber) => numbersRegex.Matches(line)
                        .Select(x => new
                        {
                            Value = int.Parse(x.Value),
                            LineNumber = lineNumber,
                            StartIndex = x.Index,
                            x.Length,
                            EndIndex = x.Index + x.Length
                        }));

            foreach (var number in numbers)
            {
                var startingScan = Math.Clamp(number.StartIndex - 1, 0, lineLength);
                var endingScan = Math.Clamp(number.EndIndex + 1, 0, lineLength);
                var lengthOfScan = endingScan - startingScan;

                var lineNumbersToCheck = new List<int>(3) { number.LineNumber };
                if (number.LineNumber > 0) lineNumbersToCheck.Add(number.LineNumber - 1);
                if (number.LineNumber + 1 < lines.Length) lineNumbersToCheck.Add(number.LineNumber + 1);

                foreach (var lineNumber in lineNumbersToCheck)
                {
                    var range = lines[lineNumber].Substring(startingScan, lengthOfScan);
                    if (symbolsRegex.Match(range).Success)
                    {
                        validPartNumbers.Add(number.Value);
                    }

                    var gearMatch = gearRegex.Match(range);

                    if (gearMatch.Success)
                    {
                        var gearKey = $"{startingScan + gearMatch.Index}-{lineNumber}";

                        if (possibleGears.ContainsKey(gearKey))
                        {
                            possibleGears[gearKey].Add(number.Value);
                        }
                        else
                        {
                            possibleGears.Add(gearKey, new List<int> { number.Value });
                        }
                    }
                }
            }

            var legitGears = possibleGears.Where(x => x.Value.Count == 2).Select(x => x.Value);

            var gearRatio = legitGears.Select(x => x[0] * x[1]).Sum();

            var xxx = validPartNumbers.Sum();
        }
    }
}