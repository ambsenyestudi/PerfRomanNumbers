using RomanNumbers.RDM.Domain.Symbols;

namespace RomanNumbers.RDM.Domain
{
    public class ArabicNumber
    {
        public static ArabicNumber Zero { get; } = new ArabicNumber(0);
        public int Value { get; }
        public ArabicNumber(int arabicNumber)
        {
            Value = arabicNumber;
        }
        public ArabicNumber Substract(RomanSymbol[] romanSymbolList)
        {
            var result = Value - RomanConvertible.ToArabicValue(romanSymbolList);
            return result == 0
                ? Zero
                :new ArabicNumber(result);
        }   

        public bool IsGreaterThan(RomanSymbol romanSymbol) =>
            Value > romanSymbol.ArabicValue;

        public bool IsGreaterOrEqualTo(RomanSymbol romanSymbol) =>
            Value == romanSymbol.ArabicValue ||
            IsGreaterThan(romanSymbol);

        public bool IsNegativeRoman(RomanSymbol romanSymbol) =>
            Value == ToNegative(romanSymbol);

        internal bool IsGreaterThan(ArabicNumber other) =>
            this.Value > other.Value;

        private int ToNegative(RomanSymbol romanSymbol) =>
            romanSymbol.ArabicValue * -1;

        public override bool Equals(object obj)
        {
            var arabic = obj as ArabicNumber;
            if(arabic != null)
            {
                return Value == arabic.Value;
            }
            var romanSymbo = obj as RomanSymbol;
            if(romanSymbo != null)
            {
                return Value == romanSymbo.ArabicValue;
            }
            var num = obj as int?;
            if (!num.HasValue)
            {
                return false;
            }
            return num.Value == Value;
        }

        public override int GetHashCode() => Value;

        public int DevidedBy(RomanSymbol romanSymbol) =>
            Value / romanSymbol.ArabicValue;
    }
}
