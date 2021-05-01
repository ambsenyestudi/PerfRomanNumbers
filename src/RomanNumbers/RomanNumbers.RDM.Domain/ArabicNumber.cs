namespace RomanNumbers.RDM.Domain
{
    public class ArabicNumber
    {
        public int Value { get; }
        public ArabicNumber(int arabicNumber)
        {
            Value = arabicNumber;
        }
        public ArabicNumber Substract(RomanSymbol romanSymbol) =>
            new ArabicNumber(Value - romanSymbol.ArabicValue);

        public bool IsGreaterThan(RomanSymbol romanSymbol) =>
            Value > romanSymbol.ArabicValue;
        public bool IsGreatherOrEqualTo(RomanSymbol romanSymbol) =>
            Value == romanSymbol.ArabicValue ||
            IsGreaterThan(romanSymbol);

        public override int GetHashCode()
        {
            return Value;
        }

    }
}
