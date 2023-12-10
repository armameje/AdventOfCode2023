namespace Day03_Part01.Model
{
    internal class LineDetails
    {
        public List<PartNumberDetails> NumbersNoSymbol { get; set; }
        public List<PartNumberDetails> NumbersWithSymbol { get; set; }
        public List<SymbolDetails> Symbols { get; set; }
    }
}
