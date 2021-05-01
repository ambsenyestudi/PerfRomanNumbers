using System;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private static readonly string[] ROMAN_SYMBOL_LIST = new string[] { "I", "V", "X" };
        private string value = "";
        public RomanNumber(int arabic)
        {
            value = FigureNumbers(arabic);
        }
        private string FigureNumbers(int arabic)
        {
            return CalculateFiftyPart(arabic);
        }

        private string CalculateFiftyPart(int arabic)
        {
            return CalculateTensPart(arabic);
        }
        private string CalculateTensPart(int arabic)
        {
            var result = "";
            
            var xTimes = arabic / RomanSymbol.X.ArabicValue; 
            if(xTimes > 0)
            {
                for (int i = 0; i < xTimes; i++)
                {
                    result += RomanSymbol.X;
                    arabic -= RomanSymbol.X.ArabicValue;
                }
            }
            if (IsOneUnitBefore(arabic, RomanSymbol.X))
            {
                result += $"{RomanSymbol.I}{RomanSymbol.X}";
                arabic -= 9;
            }
            return result + CalculateFivePart(arabic);
        }


        private string CalculateFivePart(int arabic)
        {
            if (IsOneUnitBefore(arabic, RomanSymbol.V))
            {
                return $"{RomanSymbol.I}{RomanSymbol.V}";
            }
            var result = "";
            if (arabic >= RomanSymbol.V.ArabicValue)
            {
                result += RomanSymbol.V;
                arabic -= RomanSymbol.V.ArabicValue;
            }
            return result + CalculateUnitPart(arabic);
        }
        
        private string CalculateUnitPart(int arabic)
        {
            var result = string.Empty;
            for (int i = 0; i < arabic; i++)
            {
                result += RomanSymbol.I.ToString();
            }
            return result;
        }

        public static bool IsOneUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var reminder = FigureDifference(romanSymbol, input);
            return reminder == RomanSymbol.I.ArabicValue;
        }

        public static bool IsHundredUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var reminder = FigureDifference(romanSymbol, input);
            return reminder == RomanSymbol.C.ArabicValue;
        }

        public static bool IsTenUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var reminder = FigureDifference(romanSymbol, input);
            return reminder == RomanSymbol.X.ArabicValue;
        }

        private static int FigureDifference(RomanSymbol romanSymbol, int arabicNumber)
        {
            var evaluatedValue = romanSymbol.ArabicValue;
            return evaluatedValue - arabicNumber;
        }

        public override bool Equals(object obj)
        {
            var romanValue = obj as string;
            if(string.IsNullOrWhiteSpace(romanValue))
            {
                return false;
            }
            return value == romanValue;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
