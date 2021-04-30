using System;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private const string UNIT = "I";
        private string value = "";
        public RomanNumber(int arabic)
        {
            value = FigureUnits(arabic);
        }
        private string FigureUnits(int arabic)
        {
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
