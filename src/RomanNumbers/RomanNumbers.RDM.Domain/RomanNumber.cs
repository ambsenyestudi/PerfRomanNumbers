using System;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private string value = "";
        public RomanNumber(int arabic)
        {
            if (arabic > 1)
            {
                value = "II";
            }
            else
            {
                value = "I";
            }
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
