namespace Day03_Part01
{
    internal static class Extension
    {
        public static readonly string hasSymbolPattern = @"[^a-zA-Z0-9]";
        public static readonly string onlySymbolPattern = @"^[^a-zA-Z0-9]$";
        public static readonly string numWithSymbolLookAheadPattern = @"(\d+)(?=[^a-zA-Z0-9\.])";
        public static readonly string numWithSymbolLookBehindPattern = @"(?<=[^a-zA-Z0-9\.])(\d+)";

    }
}
