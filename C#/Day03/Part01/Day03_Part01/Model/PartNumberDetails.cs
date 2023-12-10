namespace Day03_Part01.Model
{
    internal class PartNumberDetails
    {
        private string _partNumber;
        private int _length;
        public string PartNumber { get => _partNumber; set => _partNumber = value; }
        public int Index { get; set; }
        public int Length { get => _length; set => _length = _partNumber.Length; }
    }
}
