namespace Day02.Model
{
    internal class GameInfo
    {
        public GameInfo()
        {
            
        }
        public GameInfo(int gameNumber, List<GameSetInfo> gameSets)
        {
            GameNumber = gameNumber;
            GameSets = gameSets;
        }

        public int GameNumber { get; init; }
        public List<GameSetInfo> GameSets { get; init; }
    }
}
