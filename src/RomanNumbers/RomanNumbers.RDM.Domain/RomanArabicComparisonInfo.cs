namespace RomanNumbers.RDM.Domain
{
    public record RomanArabicComparisonInfo
    {
        public int ArabicValue { get; }
        public string RomanValue { get; }
        public RomanArabicComparisonInfo(int arabicValue, string romanValue) => 
            (ArabicValue, RomanValue) = (arabicValue, romanValue);
    }
}
