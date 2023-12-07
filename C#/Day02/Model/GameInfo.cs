namespace Day02.Model
{
    internal class GameInfo
    {
        public GameInfo()
        {
            
        }
        public GameInfo(int gameNumber, List<GameSetInfo> gameSets, bool gameEligible)
        {
            GameNumber = gameNumber;
            GameSets = gameSets;
            IsGameEligible = gameEligible;
        }

        public int GameNumber { get; init; }
        public List<GameSetInfo> GameSets { get; init; }
        public bool IsGameEligible { get; init; }
    }
}
