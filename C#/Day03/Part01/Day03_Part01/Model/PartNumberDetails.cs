namespace Day03_Part01.Model
{
    internal class PartNumberDetails
    {
        private string _number;
        public string Number { get => _number; set => _number = value; }
        public int Index { get; set; }
        public int Length { get => _number.Length; }
    }
}
