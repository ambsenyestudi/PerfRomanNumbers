using System;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private const string UNIT = "I";
        private const int HALF_TEN_ARABIC = 5;
        private const string HALF_TEN = "V";
        private string value = "";
        public RomanNumber(int arabic)
        {
            value = FigureUnits(arabic);
        }
        private string FigureUnits(int arabic)
        {
            if(arabic > 4)
            {
                return HALF_TEN;
            }
            var result = "";
            for (int i = 0; i < arabic; i++)
            {
                result += UNIT;
            }
            return result;
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
    }
}
