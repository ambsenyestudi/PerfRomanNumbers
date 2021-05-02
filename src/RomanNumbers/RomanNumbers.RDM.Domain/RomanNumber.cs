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
            var tenList = RomanConvertibleCollection.FromRepetition(RomanSymbol.X, arabic.DevidedBy(RomanSymbol.X))
                .ToArray();
            if (tenList.Any())
            {
                arabic = arabic.Substract(tenList);
            }

            if(SpecialRomanSymbol.ContainsEquivalent(arabic.Value))
            {
                var specialResult = tenList.Concat(SpecialRomanSymbol.GetItemsFromEquivalent(arabic.Value))
                    .ToArray();
                return FromRomanSymbols(specialResult);
            }
            var collection = RomanConvertibleCollection.FromArabic(arabic);
            var resultList = tenList.Concat(collection.Items)
                .ToArray();

            return FromRomanSymbols(resultList);
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
        public static RomanNumber FromRomanSymbols(params RomanConvertible[] romanConvertiblesList)
        {
            var romanResult = new RomanNumber();
            romanResult.value = string.Join("", romanConvertiblesList.AsEnumerable());
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
