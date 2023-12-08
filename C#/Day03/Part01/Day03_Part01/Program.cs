using System.Text.RegularExpressions;

namespace Day03_Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = "467..114@..";

            var c = t.Split('.');

            foreach (var item in c)
            {
                string.IsNullOrEmpty(item);
            }

            var x = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..\r\n";

            var s = x.Split("\r\n").Where(x => !string.IsNullOrEmpty(x));

            Regex regex = new(@"[^a-zA-Z0-9]");

            foreach (var item in c)
            {
                regex.IsMatch(item);
            }

            //foreach (var item in z)
            //{
            //    IsSymbol(item);
            //}

            //AnySymbolBeside(z, x);
        }

        static bool IsSymbol(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            string symbolPattern = @"[^a-zA-Z0-9]";
            Regex regex = new(symbolPattern);

            return regex.IsMatch(input);
        }

        static bool AnyNumbersBeside(string input)
        {
            string lookAheadPattern = @"(\d+)(?=[^a-zA-Z0-9\.])";
            string lookBehindPattern = @"(?<=[^a-zA-Z0-9\.])(\d+)";

            Regex lookAheadRegex = new(lookAheadPattern);
            Regex lookBehindRegex = new(lookBehindPattern);

            return lookAheadRegex.IsMatch(input) || lookBehindRegex.IsMatch(input);
        }

        // Checks if any number has a symbol beside then in a line
        static void AnySymbolBeside(string[] values, string og)
        {
            Dictionary<string, int> partNumbers = new();
            foreach (var str in values.Select((x, i) => new { i = i, value = x }))
            {
                if (IsSymbol(str.value) && str.value.Length > 1) partNumbers.Add(str.value, str.i);
            }

            foreach (var item in partNumbers.Keys)
            {
                partNumbers[item] = og.IndexOf(item);
            }
        }
    }
}