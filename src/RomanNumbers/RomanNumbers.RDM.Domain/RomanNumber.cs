using System;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private const int EMPTY_UNIT = 0;
        private const int MAX_ALLOWED_UNITS = 3;
        private readonly string[] UNIT_LIST = new string[] { "I", "II", "III" };
        private readonly string[] ROMAN_SYMBOL_LIST = new string[] { "I", "V", "X" };
        private const int HALF_TEN_ARABIC = 5;
        private const int TEN_ARABIC = 10;
        private string value = "";
        public RomanNumber(int arabic)
        {
            value = FigureNumbers(arabic);
        }
        private string FigureNumbers(int arabic)
        {
            var result = "";

            if(arabic == 4)
            {
                return "IV";
            }
            if(arabic == 9)
            {
                return "IX";
            }
            if (arabic >= TEN_ARABIC)
            {
                result += ROMAN_SYMBOL_LIST[2];
                arabic -= HALF_TEN_ARABIC * 2;
            }
            if (arabic >= HALF_TEN_ARABIC)
            {
                result += ROMAN_SYMBOL_LIST[1];
                arabic -= HALF_TEN_ARABIC;
            }

            if(HasUnitPart(arabic))
            {
                var unitIndex = arabic - 1;
                result += UNIT_LIST[unitIndex];
            }

            return result;
        }
        private bool HasUnitPart(int arabic) =>
            arabic > EMPTY_UNIT &&
            arabic <= MAX_ALLOWED_UNITS;


        public override bool Equals(object obj)
        {
            var romanValue = obj as string;
            if(string.IsNullOrWhiteSpace(romanValue))
            {
                return false;
            }
            return value == romanValue;
        }
    }
}
