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
            value = FigureNumbers(arabic);
        }
        private string FigureNumbers(int arabic)
        {
            var result = "";
            if(arabic >= HALF_TEN_ARABIC)
            {
                result = HALF_TEN;
                arabic -= HALF_TEN_ARABIC;
            }

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
