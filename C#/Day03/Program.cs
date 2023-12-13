using System.Text.RegularExpressions;

namespace Day03_Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.input.txt");
            var lineLength = lines[0].Length;

            var symbolsRegex = new Regex("[^0-9.]");
            var numbersRegex = new Regex(@"\d+");

            var potentialGears = new Dictionary<string, List<int>>();
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

                }
            }

            var xxx = validPartNumbers.Sum();
        }
    }
}