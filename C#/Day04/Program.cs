using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Day04
{
    internal class Program
    {
        static (int totalPoints, int copiesTotal) GetTotalPoints(string path)
        {
            var lines = File.ReadAllLines(path);

            Regex regex = new(@"\d+");

            List<int> pointsPerLine = new();
            Dictionary<int, List<int>> og = new();
            Dictionary<int, List<int>> cop = new();
            Dictionary<int, int> cardWithWins = new();

            foreach (var line in lines)
            {
                var splitLine = line.Split('|');

                var currentLine = Int32.Parse(regex.Match(line).Value);

                var winningNumbers = regex.Matches(splitLine[0]).Where((x, i) => i > 0).Select(x => Int32.Parse(x.Value));
                var possibleWinningNumbers = regex.Matches(splitLine[1]).Select(x => Int32.Parse(x.Value));
                var matchesPerLine = winningNumbers.Intersect(possibleWinningNumbers).Count();

                cardWithWins.Add(currentLine, matchesPerLine);

                pointsPerLine.Add(GetTotalPointsPerLine(matchesPerLine));

                og.Add(currentLine, new List<int> { currentLine });
            }

            var result = new List<KeyValuePair<int, int>>(cardWithWins);

            foreach (var item in cardWithWins)
            {
                result.AddRange(awerg(cardWithWins, item));
            }

            return (pointsPerLine.Sum(), result.Count());
        }

        static List<KeyValuePair<int, int>> awerg(Dictionary<int, int> gameLogs, KeyValuePair<int, int> cardWithWins)
        {
            var start = Math.Clamp(cardWithWins.Key, 0, gameLogs.Count());
            var end = Math.Clamp(cardWithWins.Key + cardWithWins.Value, 0, gameLogs.Count());
            var count = end - start;

            var copies = gameLogs.ToList().GetRange(start, count).ToList();

            var result = new List<KeyValuePair<int, int>>(copies);

            foreach (var item in copies) 
            {
                result.AddRange(awerg(gameLogs, item));
            }

            return result;
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
            Assert.That(GetTotalPoints("Day04.sample1.txt").totalPoints, Is.EqualTo(13));
        }

        [Test]
        public void GetTotalPoints_Actual_EqualTo_21485()
        {
            Assert.That(GetTotalPoints("Day04.input.txt").totalPoints, Is.EqualTo(21485));
        }

        [Test]
        public void ScratchCardWorth_Sample1_EqualTo_30()
        {
            Assert.That(GetTotalPoints("Day04.sample1.txt").copiesTotal, Is.EqualTo(30));
        }

        [Test]
        public void ScratchCardWorth_Sample1_EqualTo_11024379()
        {
            Assert.That(GetTotalPoints("Day04.input.txt").copiesTotal, Is.EqualTo(11024379));
        }
    }
}