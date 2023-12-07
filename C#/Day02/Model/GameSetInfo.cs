namespace Day02.Model
{
    internal class GameSetInfo
    {
        public GameSetInfo()
        {

        }

        public GameSetInfo(int red, int green, int blue)
        {
            RedCube = red;
            GreenCube = green;
            BlueCube = blue;
        }

        public int RedCube { get; set; }
        public int GreenCube { get; set; }
        public int BlueCube { get; set; }
    }
}
