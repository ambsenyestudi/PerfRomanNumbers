using System;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private readonly string[] UNIT_LIST = new string[] { "I", "II", "III" };
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
            if(arabic == 4)
            {
                return "IV";
            }
            if(arabic >= HALF_TEN_ARABIC)
            {
                result = HALF_TEN;
                arabic -= HALF_TEN_ARABIC;
            }
            var unitIndex = arabic - 1;
            return result + UNIT_LIST[unitIndex];
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
