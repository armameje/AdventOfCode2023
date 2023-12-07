using Day02.Model;
using System.Text.RegularExpressions;

namespace Day02_Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = "Game 1: 4 blue; 1 green, 2 red; 4 blue, 1 green, 6 red\r\nGame 2: 7 red, 1 green, 4 blue; 13 red, 11 blue; 6 red, 2 blue; 9 blue, 9 red; 4 blue, 11 red; 15 red, 1 green, 3 blue\r\nGame 3: 1 blue, 10 green; 4 green, 8 blue; 3 blue, 14 green, 1 red\r\nGame 4: 1 green, 2 blue; 1 blue, 4 green; 8 red, 3 blue, 3 green; 8 red, 2 green, 1 blue; 7 green, 3 blue, 2 red; 1 red, 1 green, 3 blue\r\nGame 5: 3 red, 7 blue, 4 green; 12 blue, 16 red, 4 green; 9 red, 2 green; 1 blue, 1 green, 1 red\r\nGame 6: 15 blue; 15 red, 14 blue, 2 green; 8 red, 2 blue, 2 green; 2 green, 11 blue, 1 red\r\nGame 7: 6 green, 6 red, 2 blue; 1 blue, 2 red, 7 green; 12 red; 5 green, 3 red, 1 blue; 16 red, 10 green\r\nGame 8: 2 green, 10 red, 3 blue; 1 blue, 5 green, 11 red; 6 red, 1 blue, 2 green; 11 red; 4 red, 1 blue, 5 green; 5 green, 3 blue\r\nGame 9: 5 blue, 11 red; 2 blue, 2 green; 11 red, 2 green\r\nGame 10: 3 red, 5 green; 3 blue, 5 green; 3 red, 2 blue, 14 green\r\nGame 11: 1 green, 1 blue, 6 red; 2 blue, 7 red, 2 green; 2 green, 2 red, 3 blue; 10 red; 2 red, 2 blue; 11 red, 3 blue\r\nGame 12: 6 blue, 8 red, 6 green; 15 green, 4 red; 1 red, 10 green, 1 blue; 1 red, 3 blue, 11 green\r\nGame 13: 2 blue, 6 red; 15 red, 6 blue; 20 blue, 10 red, 3 green; 17 blue, 1 red, 4 green\r\nGame 14: 3 green, 7 blue, 7 red; 2 blue; 7 blue, 10 red\r\nGame 15: 3 green, 7 blue; 9 green, 8 blue, 5 red; 6 green, 13 red; 14 red, 2 green, 15 blue; 15 red, 7 green\r\nGame 16: 13 blue; 6 green, 4 blue, 11 red; 15 red, 2 green, 6 blue; 1 green, 13 red, 8 blue; 8 green, 7 blue, 14 red\r\nGame 17: 3 red; 17 red, 4 green; 1 blue, 11 red; 3 blue, 20 red, 3 green\r\nGame 18: 4 red, 2 blue, 3 green; 9 red, 6 green; 11 red, 1 blue\r\nGame 19: 1 green, 4 blue; 1 green, 2 red; 2 blue, 1 green; 4 red, 2 blue\r\nGame 20: 15 blue, 6 green, 6 red; 13 green, 1 blue, 1 red; 13 green, 13 blue, 5 red; 7 red, 16 green, 4 blue\r\nGame 21: 10 blue, 5 green, 8 red; 6 blue, 12 red, 4 green; 2 green, 16 blue, 3 red; 6 red, 12 blue, 3 green; 1 red, 3 green; 7 blue, 6 green, 7 red\r\nGame 22: 3 blue, 3 green, 17 red; 1 green, 18 red; 3 green, 10 red, 5 blue; 2 green, 2 red, 4 blue; 2 blue, 13 red; 1 green, 3 blue, 9 red\r\nGame 23: 4 green, 16 red, 2 blue; 10 red, 10 green, 7 blue; 2 green, 6 red, 13 blue; 1 green, 13 blue, 16 red; 7 green, 16 blue, 9 red\r\nGame 24: 6 blue, 7 red, 4 green; 6 blue, 2 green; 2 green, 6 blue, 2 red; 5 red, 3 green, 11 blue\r\nGame 25: 4 red, 2 green; 1 green; 4 green, 4 blue, 8 red; 5 red, 1 blue\r\nGame 26: 9 red, 4 blue, 13 green; 3 blue, 10 red, 7 green; 13 blue, 5 green, 9 red\r\nGame 27: 1 green, 12 red, 2 blue; 2 blue, 13 red, 2 green; 2 blue, 7 red; 4 green, 9 red, 2 blue; 1 blue, 2 green, 15 red; 3 red, 4 green, 1 blue\r\nGame 28: 1 red, 9 blue, 17 green; 14 green, 15 blue, 2 red; 4 red, 18 green, 13 blue\r\nGame 29: 16 green, 5 blue, 1 red; 6 green, 6 red, 16 blue; 4 red, 9 green, 12 blue; 5 green, 14 blue, 1 red\r\nGame 30: 3 red, 2 blue, 12 green; 13 green, 4 red; 13 green, 2 red, 1 blue; 2 blue, 6 red, 4 green; 3 blue, 13 green, 5 red\r\nGame 31: 3 red; 6 red, 2 green; 5 red; 3 green, 2 red; 1 green, 2 red, 1 blue; 1 blue, 6 red\r\nGame 32: 1 red, 7 green; 9 green, 5 blue; 1 green, 2 red; 4 blue, 2 red, 1 green; 4 blue, 1 green, 3 red\r\nGame 33: 11 green; 12 blue, 2 green; 5 green, 1 blue; 10 green, 3 blue; 4 blue, 1 red, 4 green; 4 green, 5 blue\r\nGame 34: 4 red, 8 blue, 2 green; 8 green, 4 red, 14 blue; 11 green, 6 red, 8 blue; 16 green, 3 blue, 5 red; 3 blue, 3 red, 13 green\r\nGame 35: 7 green, 12 red, 1 blue; 1 red; 13 red; 14 red, 2 blue, 9 green\r\nGame 36: 3 red, 4 green, 1 blue; 3 red, 4 blue; 6 red, 4 blue, 3 green; 3 green, 4 blue, 3 red; 2 blue, 4 green, 7 red\r\nGame 37: 2 green, 1 blue, 5 red; 1 green; 3 blue; 3 blue, 1 green\r\nGame 38: 1 red, 12 blue, 17 green; 4 blue, 2 red, 8 green; 7 blue, 20 green; 6 red, 3 blue; 6 green, 7 red, 6 blue; 10 green, 3 red\r\nGame 39: 3 green, 3 blue, 2 red; 4 blue, 4 red, 4 green; 4 blue, 4 red; 1 blue, 5 green, 2 red; 5 green, 3 blue, 4 red; 4 green, 2 blue\r\nGame 40: 18 green, 1 red; 17 green, 1 blue; 2 green, 1 blue, 1 red; 9 green, 1 blue; 3 green, 1 red; 1 red, 10 green\r\nGame 41: 2 red, 4 blue, 3 green; 8 blue, 2 red; 5 blue; 2 green, 2 red, 3 blue; 1 green, 7 blue\r\nGame 42: 1 green, 2 blue; 9 green, 2 blue, 15 red; 1 green, 4 blue, 9 red\r\nGame 43: 5 blue, 3 red; 2 blue, 8 red, 7 green; 17 red, 4 blue, 7 green\r\nGame 44: 13 red, 3 green, 12 blue; 15 green, 10 blue; 8 green, 11 red, 2 blue; 10 blue, 16 red, 2 green; 12 blue, 5 green, 5 red; 14 green, 8 red, 13 blue\r\nGame 45: 1 red, 3 green; 4 green, 5 blue, 2 red; 6 red, 2 blue, 6 green; 3 blue, 2 green; 5 blue, 3 green, 4 red; 5 red, 5 blue, 6 green\r\nGame 46: 12 red, 2 blue, 3 green; 15 red, 14 blue, 11 green; 6 red, 11 blue, 6 green; 4 red, 1 green; 7 blue, 14 red; 14 red, 18 blue, 6 green\r\nGame 47: 3 blue, 5 red, 4 green; 1 blue, 10 red; 6 blue, 5 green, 7 red; 3 red, 4 green; 2 blue, 2 green, 13 red; 4 blue, 13 red, 2 green\r\nGame 48: 2 green, 3 blue, 7 red; 12 red, 1 green, 2 blue; 5 red, 2 blue; 4 blue, 3 green, 10 red\r\nGame 49: 8 green, 13 blue, 3 red; 14 blue, 1 green; 14 blue, 2 green\r\nGame 50: 1 red, 2 green, 3 blue; 2 green, 2 red; 1 green, 5 blue; 4 green\r\nGame 51: 10 green, 5 red; 10 green, 2 blue, 2 red; 2 blue, 13 red, 1 green; 6 blue, 10 green, 3 red\r\nGame 52: 8 green, 1 blue, 6 red; 4 green, 5 blue; 4 green, 7 red; 3 blue, 6 green, 3 red; 7 red, 6 blue, 7 green; 4 red, 8 green, 4 blue\r\nGame 53: 11 blue, 10 green, 1 red; 6 blue, 1 green, 12 red; 6 green, 12 blue, 13 red; 1 blue, 10 green, 10 red; 11 green, 2 blue; 7 green, 7 red, 5 blue\r\nGame 54: 3 blue, 1 green, 7 red; 18 blue, 3 red, 1 green; 11 blue, 6 red\r\nGame 55: 9 blue, 1 red; 3 blue, 1 green, 2 red; 1 green, 6 blue, 5 red; 1 green, 5 red, 12 blue; 5 red, 3 green, 12 blue; 12 blue\r\nGame 56: 3 red, 1 green, 11 blue; 2 red, 20 blue; 12 blue, 4 red; 3 red, 2 blue, 6 green\r\nGame 57: 1 green, 13 red, 1 blue; 7 green, 2 red, 2 blue; 6 red, 3 blue; 6 blue, 4 red, 3 green; 1 green, 11 red\r\nGame 58: 3 red, 13 blue, 2 green; 6 green, 6 red, 19 blue; 4 blue, 9 green, 1 red; 1 blue, 6 red\r\nGame 59: 11 red, 2 blue, 2 green; 1 blue, 13 red; 12 red, 6 blue\r\nGame 60: 8 blue, 4 red, 11 green; 10 green; 5 blue, 3 red, 8 green; 6 blue, 6 red, 12 green\r\nGame 61: 1 green, 1 blue, 3 red; 1 blue, 2 green, 5 red; 4 red, 1 green, 1 blue; 5 red, 2 green\r\nGame 62: 14 blue, 2 green, 11 red; 11 red, 2 green, 8 blue; 5 blue, 14 red, 5 green; 17 red, 2 blue, 3 green; 2 red, 3 green, 5 blue; 11 blue, 10 red, 3 green\r\nGame 63: 2 blue, 2 green; 9 blue, 3 red; 1 green, 2 red, 12 blue\r\nGame 64: 14 green, 1 blue, 5 red; 4 red, 14 green, 12 blue; 10 blue, 3 red, 10 green\r\nGame 65: 1 green, 6 red, 6 blue; 7 red, 7 blue, 3 green; 14 blue, 5 red\r\nGame 66: 10 blue, 2 red, 7 green; 3 red, 16 blue; 10 green, 7 red, 17 blue; 10 red, 5 green, 5 blue; 13 blue, 10 green, 6 red\r\nGame 67: 9 blue, 6 green; 1 red, 8 blue, 9 green; 3 blue, 1 green, 1 red; 2 blue, 6 green, 1 red\r\nGame 68: 4 green, 9 red, 3 blue; 6 blue, 5 green, 2 red; 6 blue, 9 red, 3 green; 4 red, 2 green; 4 red, 9 green\r\nGame 69: 1 green, 1 blue, 2 red; 2 red, 7 green; 3 red, 1 blue, 5 green; 8 red, 7 green; 2 green, 1 blue; 6 red, 1 blue, 7 green\r\nGame 70: 13 blue, 3 green, 5 red; 1 red, 1 green, 6 blue; 4 red, 11 blue; 14 blue, 5 red, 1 green; 8 red, 16 blue, 1 green\r\nGame 71: 1 blue, 1 green; 6 blue, 2 red; 5 green, 1 red, 4 blue; 4 green, 3 red\r\nGame 72: 4 green, 2 blue, 11 red; 4 red, 7 green, 4 blue; 3 red, 6 green, 14 blue; 4 green, 12 red, 15 blue; 4 blue, 14 red; 6 blue, 13 red, 6 green\r\nGame 73: 4 green, 6 red, 7 blue; 11 red, 4 blue, 6 green; 8 red, 2 blue, 5 green; 3 red, 1 green, 7 blue\r\nGame 74: 5 blue, 10 green; 6 green, 5 blue, 10 red; 4 green, 2 red, 1 blue; 3 blue, 11 green\r\nGame 75: 3 red, 3 green, 15 blue; 6 blue, 3 green, 5 red; 11 blue, 1 red, 3 green; 7 blue, 3 green, 4 red; 9 blue, 1 red, 3 green\r\nGame 76: 11 red; 7 green, 12 red; 2 red, 1 blue, 2 green; 2 red, 1 blue, 6 green; 5 red, 7 green; 1 blue, 8 green\r\nGame 77: 2 blue, 15 green, 1 red; 6 blue, 1 red; 1 green, 5 blue, 1 red; 2 blue, 1 red, 1 green; 15 green, 8 blue, 1 red; 19 green, 5 blue\r\nGame 78: 14 red, 2 green, 7 blue; 2 green, 14 red, 3 blue; 1 blue, 7 red\r\nGame 79: 15 red, 2 green, 1 blue; 3 red, 1 green; 12 red, 2 blue; 12 red, 1 green; 1 blue, 2 red, 1 green\r\nGame 80: 2 red, 1 green, 7 blue; 7 red, 6 blue, 5 green; 6 blue, 6 red; 6 green, 2 blue, 3 red; 5 red, 5 blue, 1 green\r\nGame 81: 10 red, 1 green, 3 blue; 6 green, 13 blue, 3 red; 1 green, 2 red, 10 blue\r\nGame 82: 4 blue, 1 red, 7 green; 4 red, 14 blue, 8 green; 1 red, 11 blue, 6 green\r\nGame 83: 10 red, 3 blue, 9 green; 3 green, 3 red, 1 blue; 4 blue, 11 green, 8 red; 2 blue, 8 green, 2 red; 2 green, 2 red\r\nGame 84: 2 green, 2 blue, 14 red; 7 red, 5 blue, 11 green; 4 red, 6 blue, 5 green; 3 blue, 13 green, 14 red; 6 red, 7 blue, 8 green; 2 blue, 3 red, 18 green\r\nGame 85: 8 green, 14 blue; 6 green, 9 red, 15 blue; 9 red, 12 green, 15 blue; 12 green, 6 red; 9 green, 10 red, 15 blue; 12 blue, 6 green\r\nGame 86: 1 blue, 1 green, 4 red; 6 green, 4 red, 6 blue; 1 red, 4 blue, 4 green; 6 green, 2 blue, 1 red\r\nGame 87: 17 blue, 13 green; 8 blue, 3 red; 16 green, 4 red, 6 blue\r\nGame 88: 11 red, 16 blue, 6 green; 10 red, 2 blue, 1 green; 5 blue, 2 green, 14 red\r\nGame 89: 3 blue, 2 green; 2 red; 9 blue, 8 green, 1 red; 2 green, 2 blue, 3 red; 4 red, 3 green\r\nGame 90: 2 blue, 14 red, 2 green; 6 blue, 2 red, 2 green; 17 red, 1 blue, 6 green; 1 blue, 8 green, 1 red\r\nGame 91: 6 green, 1 blue, 13 red; 10 red, 4 green, 12 blue; 9 green, 17 red, 3 blue; 12 blue, 5 red, 2 green; 2 green, 9 red, 14 blue\r\nGame 92: 2 red, 4 green, 6 blue; 9 blue, 3 green, 6 red; 5 blue, 4 green; 3 blue, 2 green, 7 red; 4 red, 4 green, 11 blue\r\nGame 93: 4 red, 11 blue, 9 green; 10 blue, 3 green, 9 red; 3 green, 11 red, 1 blue\r\nGame 94: 11 green, 3 red, 1 blue; 3 green, 2 red, 6 blue; 2 red, 6 blue, 5 green; 4 blue, 5 green, 5 red; 17 green, 6 red, 6 blue; 5 green, 6 red, 7 blue\r\nGame 95: 1 red, 3 blue, 15 green; 5 green, 6 blue; 11 green, 2 red, 11 blue; 15 green, 5 red, 7 blue\r\nGame 96: 13 red, 3 blue; 3 red, 13 blue; 5 blue, 1 red, 2 green; 7 red, 7 blue; 12 red, 9 blue, 3 green; 8 red, 15 blue, 2 green\r\nGame 97: 4 blue, 9 green, 2 red; 2 red, 5 green, 13 blue; 9 blue, 2 red, 16 green\r\nGame 98: 3 red; 1 green, 10 red; 2 blue, 8 red; 1 green, 11 red, 2 blue\r\nGame 99: 6 red, 14 green; 8 green, 15 red; 1 red, 4 green; 2 blue, 7 green, 13 red; 14 green, 5 red, 1 blue; 1 blue, 5 red, 8 green\r\nGame 100: 9 blue, 18 green, 4 red; 5 green, 10 blue, 11 red; 1 green, 1 red; 16 green, 5 red, 1 blue";

            var x = GetEligibleGames(input);
            Console.WriteLine(x);
        }

        static void GetShit(string gameString, string pattern)
        {
            Regex regex = new(pattern);

            var matches = regex.Match(gameString);

            foreach (var item in matches.Groups)
            {
                Console.WriteLine(item);
            }
        }


        static GameInfo ParseGames(string gameString) 
        {
            List<GameSetInfo> gameSetInfo = new();
            string generalPatternToCapture = @"Game\s(\d+):\s(.+)";

            var matches = GetMatchingRegex(generalPatternToCapture, gameString);

            var gameNumber = Int32.Parse(matches.Groups[1].Value);

            var gameSets = matches.Groups[2].Value.Split(';');

            foreach (var gameSet in gameSets)
            {
                gameSetInfo.Add(ParseGameSet(gameSet.Trim()));
            }

            return new GameInfo(gameNumber, gameSetInfo, IsEligibleCount(gameSetInfo));
        }

        static GameSetInfo ParseGameSet(string gameSetString)
        {
            GameSetInfo gameSetInfo = new();

            var sets = gameSetString.Split(',');

            List<(string color, int count)> colorCounts = new();

            foreach (var set in sets)
            {
                colorCounts.Add(GetColorWithValues(set.Trim()));
            }

            foreach (var c in colorCounts)
            {
                switch (c.color)
                {
                    case "red":
                        gameSetInfo.RedCube = c.count;
                        break;
                    case "green":
                        gameSetInfo.GreenCube = c.count;
                        break;
                    case "blue":
                        gameSetInfo.BlueCube = c.count;
                        break;
                }
            }

            return gameSetInfo;
        }

        static bool IsEligibleCount(List<GameSetInfo> gameSets)
        {
            (int red, int green, int blue) = (12, 13, 14);
            (bool red, bool green, bool blue) isEligible = (false, false, false);

            List<bool> setBools = new();

            foreach (var gameSet in gameSets)
            {
                isEligible.red = gameSet.RedCube <= red ? true : false;
                isEligible.green = gameSet.GreenCube <= green ? true : false;
                isEligible.blue = gameSet.BlueCube <= blue ? true : false;

                setBools.Add(isEligible.red && isEligible.green && isEligible.blue);
            }

            return !setBools.Contains(false);
        }

        static (string color, int count) GetColorWithValues(string colorCount)
        { 
            string cubeNumberValuepattern = @"(\d+)\s(\w+)";

            var matches = GetMatchingRegex(cubeNumberValuepattern, colorCount);

            var count = Int32.Parse(matches.Groups[1].Value);
            var color = matches.Groups[2].Value;

            return (color, count);
        }

        static Match GetMatchingRegex(string pattern, string input)
        {
            Regex regex = new(pattern);

            return regex.Match(input);
        }

        static int GetEligibleGames(string values)
        {
            var eligibleGames = new List<int>();
            int total = 0;

            using (StringReader reader = new StringReader(values))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var game = ParseGames(line.Trim());

                    if (game.IsGameEligible)
                    {
                        eligibleGames.Add(game.GameNumber);
                    }
                }
            }

            foreach (var item in eligibleGames)
            {
                total += item;
            }

            return total;
        }
    }
}