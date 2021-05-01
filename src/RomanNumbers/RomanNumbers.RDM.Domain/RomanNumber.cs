using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private string value = "";
        private RomanNumber()
        {
        }
        private RomanNumber(RomanNumber roman, RomanNumber part)
        {
            value = $"{roman}{part}";
        }
        public RomanNumber(RomanSymbol romanSymbol, int times = 1)
        {
            var result = string.Empty;
            for (int i = 0; i < times; i++)
            {
                result += romanSymbol.RomanValue;
            }
            value = result;
        }
        public RomanNumber(int num)
        {
            var arabic = new ArabicNumber(num);
            value = FigureNumbers(arabic);
        }
        private string FigureNumbers(ArabicNumber arabic)
        {
            var romanNumber = CalculateFiftyPart(arabic);
            return romanNumber.value;
        }

        private RomanNumber CalculateFiftyPart(ArabicNumber arabic)
        {
            var lOccurrances = RomanSymbol.L.GetOccurances(arabic.Value);
            if (lOccurrances.Any())
            {
                var result = RomanNumber.FromRomanSymbols(lOccurrances);
                arabic = arabic.Substract(lOccurrances);
                return new RomanNumber(result, CalculateTensPart(arabic));
            }
            return CalculateTensPart(arabic);
        }
        private RomanNumber CalculateTensPart(ArabicNumber arabic)
        {

            if (IsOneUnitBefore(arabic, RomanSymbol.X))
            {
                return FromRomanSymbols(RomanSymbol.I, RomanSymbol.X);
            }

            var xTimes = RomanSymbol.X.CalculateNumberOfOcurrances(arabic.Value);
            if (xTimes > 0)
            {
                var result = new RomanNumber(RomanSymbol.X, xTimes);
                var ocurrances = Enumerable
                    .Repeat(RomanSymbol.X, xTimes)
                    .ToArray();
                arabic = arabic.Substract(ocurrances);
                return new RomanNumber(result, CalculateTensPart(arabic));
            }

            return CalculateFivePart(arabic);
        }

        private RomanNumber CalculateFivePart(ArabicNumber arabic)
        {
            var fiveList = CalculateFromOcurrances(arabic, RomanSymbol.V)
                .ToArray();
            if(fiveList.Any())
            {
                arabic = arabic.Substract(fiveList);
            }
            var resultList = arabic.Value > 0
                ? fiveList.Concat(CalculateFromOcurrances(arabic, RomanSymbol.I)).ToArray()
                : fiveList;

            return FromRomanSymbols(resultList);
        }


        private IEnumerable<RomanSymbol> CalculateFromOcurrances(ArabicNumber arabic, RomanSymbol romanSymbol)
        {

            var result = romanSymbol.GetOccurances(arabic.Value);
            if(!result.Any() && IsOneUnitBefore(arabic, romanSymbol))
            {
                return new List<RomanSymbol> { RomanSymbol.I, RomanSymbol.V };
            }
            return result;
        }

        public static bool IsOneUnitBefore(ArabicNumber arabicNumber, RomanSymbol romanSymbol)
        {
            var arabicReminder = arabicNumber.Substract(romanSymbol);
            return arabicReminder.IsNegativeRoman(RomanSymbol.I);           
        }
        public static bool IsTenUnitBefore(ArabicNumber arabicNumber, RomanSymbol romanSymbol)
        {
            var arabicReminder = arabicNumber.Substract(romanSymbol);
            return arabicReminder.IsNegativeRoman(RomanSymbol.X);
        }

        public static bool IsHundredUnitBefore(ArabicNumber arabicNumber, RomanSymbol romanSymbol)
        {
            var arabicReminder = arabicNumber.Substract(romanSymbol);
            return arabicReminder.IsNegativeRoman(RomanSymbol.C);
        }
        public static RomanNumber FromRomanSymbols(params RomanSymbol[] romanSymbolsList)
        {
            var result = "";
            for (int i = 0; i < romanSymbolsList.Length; i++)
            {
                result += romanSymbolsList[i].RomanValue;
            }
            var romanResult = new RomanNumber();
            romanResult.value = result;
            return romanResult;
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
        public override string ToString() =>
            value;
    }
}
