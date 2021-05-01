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
        
    }
}
