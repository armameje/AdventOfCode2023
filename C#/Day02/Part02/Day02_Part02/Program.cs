using Day02.Model;
using System.Text.RegularExpressions;

namespace Day02_Part02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

            ParseGameMaxValue(t);
        }

        static GameSetInfo ParseGameMaxValue(string gameString)
        {
            List<GameSetInfo> gameSetInfos = new();
            string generalPatternToCapture = @"Game\s\d+:\s(.+)";

            var matches = GetMatchingRegex(generalPatternToCapture, gameString);

            var gameSets = matches.Groups[1].Value.Split(';');

            foreach (var gameSet in gameSets ) 
            {
                gameSetInfos.Add(ParseGameSet(gameSet.Trim()));
            }

            return GetGamePower(gameSetInfos);
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

        static (string color, int count) GetColorWithValues(string colorCount)
        {
            string cubeNumberValuepattern = @"(\d+)\s(\w+)";

            var matches = GetMatchingRegex(cubeNumberValuepattern, colorCount);

            var count = Int32.Parse(matches.Groups[1].Value);
            var color = matches.Groups[2].Value;

            return (color, count);
        }

        static GameSetInfo GetGamePower(List<GameSetInfo> gameSets)
        {
            GameSetInfo maxGameSetValues = new();
            (List<int> red, List<int> green, List<int> blue) coloredValues = (new(), new(), new());

            foreach (var gameSet in gameSets)
            {
                coloredValues.red.Add(gameSet.RedCube);
                coloredValues.green.Add(gameSet.GreenCube);
                coloredValues.blue.Add(gameSet.BlueCube);
            }

            maxGameSetValues.RedCube = coloredValues.red.Max();
            maxGameSetValues.GreenCube = coloredValues.green.Max();
            maxGameSetValues.BlueCube = coloredValues.blue.Max();

            return maxGameSetValues;
        }

        static Match GetMatchingRegex(string pattern, string input)
        {
            Regex regex = new(pattern);

            return regex.Match(input);
        }
    }
}