﻿namespace RomanNumbers.RDM.Domain
{
    public class ArabicNumber
    {
        public int Value { get; }
        public ArabicNumber(int arabicNumber)
        {
            Value = arabicNumber;
        }
        public ArabicNumber Substract(params RomanSymbol[] romanSymbolLisst)
        {
            var result = Value;
            for (int i = 0; i < romanSymbolLisst.Length; i++)
            {
                result -= romanSymbolLisst[i].ArabicValue;
            }
            return new ArabicNumber(result);
        }   

        public bool IsGreaterThan(RomanSymbol romanSymbol) =>
            Value > romanSymbol.ArabicValue;

        public bool IsGreaterOrEqualTo(RomanSymbol romanSymbol) =>
            Value == romanSymbol.ArabicValue ||
            IsGreaterThan(romanSymbol);

        public bool IsNegativeRoman(RomanSymbol romanSymbol) =>
            Value == ToNegative(romanSymbol);

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

        public override int GetHashCode()
        {
            return Value;
        }

        public int DevidedBy(RomanSymbol romanSymbol) =>
            Value / romanSymbol.ArabicValue;
    }
}
