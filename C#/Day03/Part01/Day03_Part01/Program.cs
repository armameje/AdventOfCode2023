using Day03_Part01.Model;
using Day03_Part01.Model.Enum;
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

            var sd = "............*....-..811..........846..855......*.............*..$........230.92@............................=....................@65.......";
            var ds = ".*155....822*609....&..84.........155#..............#.....481...968.64................+..337.....152...254..";
            // 1, 8, 33
            bool isFirstLine = true;


            //foreach (var item in z)
            //{
            //    IsSymbol(item);
            //}

            AnySymbolBeside(ds.Split('.'), ds);

            //KekW(sd);
        }

        static bool HasSymbol(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            string symbolPattern = @"[^a-zA-Z0-9]";
            Regex regex = new(symbolPattern);

            return regex.IsMatch(input);
        }

        static bool IsSymbol(string input)
        {
            Regex regex = new(Extension.onlySymbolPattern);

            return regex.IsMatch(input);
        }

        static SymbolDetails GetSymbol(string input, int index, string og)
        {
            Regex regex = new(Extension.onlySymbolPattern);
            var symbol = regex.Match(input).Groups;

            string temp = og.Substring(index);


            return new SymbolDetails();
        }

        static SymbolPosition WhereSymbolAt(string input)
        {
            string symbolPattern = @"[^a-zA-Z0-9]";
            Regex regex = new(symbolPattern);

            var symbol = regex.Match(input).Groups[0];

            if (symbol.Index == 0 || symbol.Index == input.Length - 1)
            {
                return SymbolPosition.Ends;
            }

            return SymbolPosition.Between;
        }

        static void ParseNumbersBetweenSymbol(string input, int startIndex)
        {
            Dictionary<string, int> kek = new();
            string symbolPattern = @"[^a-zA-Z0-9]";
            Regex regex = new(symbolPattern);

            var symbol = regex.Match(input).Groups[0];

            var splitNumbers = input.Split(symbol.Value).Select((x, i) => new { index = i, value = x });

            foreach (var number in splitNumbers)
            {
                //number
            }
        }

        static int ParseNumberFromStringWithSymbol(string input)
        {
            string lookAheadPattern = @"(\d+)(?=[^a-zA-Z0-9\.])";
            string lookBehindPattern = @"(?<=[^a-zA-Z0-9\.])(\d+)";

            Regex lookAheadRegex = new(lookAheadPattern);
            Regex lookBehindRegex = new(lookBehindPattern);

            var x = lookAheadRegex.IsMatch(input);
            var z = lookAheadRegex.Match(input).Groups[0];

            // Hve this in a separate function to handle this scenario
            if (lookAheadRegex.IsMatch(input) && lookBehindRegex.IsMatch(input))
            {
                return Int32.Parse(lookAheadRegex.Match(input).Groups[0].Value) + Int32.Parse(lookBehindRegex.Match(input).Groups[0].Value);
            }
            else if (lookAheadRegex.IsMatch(input))
            {
                return Int32.Parse(lookAheadRegex.Match(input).Groups[0].Value);
            }
            else
            {
                return Int32.Parse(lookBehindRegex.Match(input).Groups[0].Value);
            }
        }

        #region Handling all needed for current line
        static void GetNumbersNoSymbol()
        { 
            
        }

        static void GetLineDetails(string[] input, string og)
        {
            List<SymbolDetails> symbols = new();
            List<PartNumberDetails> numbers = new();
            List<PartNumberDetails> numbersWithSymbol = new();

            var inputWithIndexes = input.Select((x, i) => new { index = i, value = x });

            foreach (var item in inputWithIndexes)
            {
                if (string.IsNullOrEmpty(item.value)) continue;

                

                if (IsSymbol(item.value)) 
                {
                
                }
            }
        }

        #endregion
        // Checks if any number has a symbol beside then in a line
        static List<int> AnySymbolBeside(string[] values, string og)
        {
            Dictionary<string, int> partNumbers = new();
            List<string> vals = new();
            List<int> parsedPartNumbers = new();
            foreach (var str in values.Select((x, i) => new { i = i, value = x }))
            {
                // If given with a string like 234@213, handle it alone, only add to dictionary
                // when properly parsed and separated
                // Make new function for dictionary as well
                if (HasSymbol(str.value) && str.value.Length > 1) partNumbers.Add(str.value, str.i);

                //if (HasSymbol(str.value) && str.value.Length > 1)
                //{
                //    switch (WhereSymbolAt(str.value))
                //    {
                //        case SymbolPosition.Between:
                //            break;
                //        case SymbolPosition.Ends:
                //            partNumbers.Add(str.value, str.i);
                //    }
                //}
            }

            List<string> allNonPeriod = values.Where(x => !string.IsNullOrEmpty(x)).ToList();
            var ogLength = og.Length;

            foreach (var item in partNumbers.Keys)
            {
                var s = allNonPeriod.IndexOf(item);
                var t = allNonPeriod.Where((x, i) => i < s).ToList();
                int previouslength = PrevLen(t);
                string temp = og.Substring(partNumbers[item] + previouslength);
                int redactedOgLength = og.Substring(0, partNumbers[item] + previouslength).Length;

                var ss = og[redactedOgLength];
                partNumbers[item] = redactedOgLength;
            }

            foreach (var validNumber in partNumbers.Keys)
            {
                parsedPartNumbers.Add(ParseNumberFromStringWithSymbol(validNumber));
            }

            return parsedPartNumbers;
        }

        static int PrevLen(List<string> k)
        {
            int total = 0;

            foreach (var item in k)
            {
                total += item.Length;
            }

            return total;
        }

        static List<int> SymbolsInPriorLine(string input)
        {
            string symbolPattern = @"[^a-zA-Z0-9\.]";
            List<int> symbolPosition = new();

            Regex regex = new(symbolPattern);

            var symbolMatches = regex.Matches(input);

            foreach (Match item in symbolMatches)
            {
                symbolPosition.Add(item.Index);
            }

            return symbolPosition;
        }

        static void KekW(string main)
        {
            List<int> partNumbers = new();
            var stringLines = main.Split("\r\n").Where(x => !string.IsNullOrEmpty(x)).ToArray();

            bool isFirstLine = true;

            if (isFirstLine)
            {
                partNumbers.AddRange(AnySymbolBeside(main.Split('.'), main));
            }
        }
    }
}