using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Day04
{
    internal class Program
    {
        static int GetTotalPoints(string path)
        {
            var lines = File.ReadAllLines(path);

            Regex regex = new(@"\d+");

            List<int> pointsPerLine = new(); 

            foreach (var line in lines)
            {
                var splitLine = line.Split('|');

                var winningNumbers = regex.Matches(splitLine[0]).Where((x, i) => i > 0).Select(x => Int32.Parse(x.Value));
                var possibleWinningNumbers = regex.Matches(splitLine[1]).Select(x => Int32.Parse(x.Value));

                pointsPerLine.Add(CompareNumbers(winningNumbers, possibleWinningNumbers));
            }

            return pointsPerLine.Sum();
        }


        static int CompareNumbers(IEnumerable<int> winningNumbers, IEnumerable<int> possibleWin)
        {
            var matches = winningNumbers.Intersect(possibleWin);

            return GetTotalPointsPerLine(matches.Count());
        }

        static int GetTotalPointsPerLine(int count)
        {
            int total = 0;
            foreach (var point in Enumerable.Range(1, count))
            {
                if (point == 1)
                {
                    total++;
                }
                else
                {
                    total *= 2;
                }
            }

            return total;
        }

        [Test]
        public void GetTotalPoints_Sample1_EqualTo_13()
        {
            Assert.That(GetTotalPoints("Day04.sample1.txt"), Is.EqualTo(13));
        }

        [Test]
        public void GetTotalPoints_Actual_EqualTo_21485()
        {
            Assert.That(GetTotalPoints("Day04.input.txt"), Is.EqualTo(21485));
        }
    }
}