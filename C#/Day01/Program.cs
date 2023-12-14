using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Day01
{
    internal class Program
    {
        static string GetTwoDigitNumber(string text)
        {
            var numbers = text.Where(x => Char.IsDigit(x));
            var firstNumber = Char.GetNumericValue(numbers.First()).ToString();
            var lastNumber = Char.GetNumericValue(numbers.Last()).ToString();

            return firstNumber + lastNumber;
        }

        static int GetEncryptedTotalValue(string path)
        {
            var totalList = new List<int>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                totalList.Add(Int32.Parse(GetTwoDigitNumber(line)));
            }

            return totalList.Sum();
        }

        static int GetEncryptedTotalValue_Part2(string path)
        {
            var totalList = new List<int>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                totalList.Add(GetTuDigitNumber(line));
            }

            return totalList.Sum();
        }

        static int GetTuDigitNumber(string text)
        {
            var regex = new Regex(@"one|two|three|four|five|six|seven|eight|nine|\d");

            var cleanText = text
                .Replace("twone", "twoone")
                .Replace("oneight", "oneeight")
                .Replace("threeight", "threeeight")
                .Replace("fiveight", "fiveeight")
                .Replace("nineight", "nineeight")
                .Replace("sevenine", "sevennine")
                .Replace("eightwo", "eighttwo");

            var numberMatches = regex.Matches(cleanText).Select(x => GetNumberFromString(x.Value));
            var number = $"{numberMatches.First()}{numberMatches.Last()}";

            return Int32.Parse(number);
        }

        static string GetNumberFromString(string input) => input switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => input
        };

        [Test]
        public void GetEncryptedTotalValue_Equal_To_142_Part1Sample()
        {
            Assert.That(GetEncryptedTotalValue("Day01.sample1.txt"), Is.EqualTo(142));
        }

        [Test]
        public void GetEncryptedTotalValue_Equal_To_56049_Part1Actual()
        {
            Assert.That(GetEncryptedTotalValue("Day01.input.txt"), Is.EqualTo(56049));
        }

        [Test]
        public void GetEncryptedTotalValue_Equal_To_281_Part2Sample()
        {
            Assert.That(GetEncryptedTotalValue_Part2("Day01.sample2.txt"), Is.EqualTo(281));
        }

        [Test]
        public void GetEncryptedTotalValue_Equal_To_281_Part2Actual()
        {
            Assert.That(GetEncryptedTotalValue_Part2("Day01.input.txt"), Is.EqualTo(54530));
        }
    }
}