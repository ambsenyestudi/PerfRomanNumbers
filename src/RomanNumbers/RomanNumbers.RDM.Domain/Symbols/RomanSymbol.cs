using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain.Symbols
{
    
    public class RomanSymbol : RomanConvertible
    {
        
        public bool IsRepitable { get; }

        internal RomanSymbol(int arabicValue, string romanValue, bool isRepetible= true):base(romanValue, arabicValue)
        {
            IsRepitable = isRepetible;
        }

        

        public bool IsSmallerThan(int num) =>
            ArabicValue < num;

        public bool IsSmallerOrEqualTo(int num) =>
            ArabicValue == num || IsSmallerThan(num);

        

        public int CalculateNumberOfOcurrances(int num)
        {
            if(num == 0)
            {
                return 0;
            }
            var result = num / ArabicValue;
            return result;
        }

        public RomanSymbol[] GetOccurances(int num) =>
            Enumerable.Repeat(this, CalculateNumberOfOcurrances(num))
            .ToArray();

        


        public override bool Equals(object obj)
        {
            var otherRoman = obj as RomanSymbol;
            if(otherRoman != null)
            {
                return ArabicValue == otherRoman.ArabicValue &&
                    RomanValue == otherRoman.RomanValue;
            }
            var romanRaw = obj as string;
            if(string.IsNullOrWhiteSpace(romanRaw))
            {
                return false;
            }
            return RomanValue == romanRaw;

        }
        public override int GetHashCode() =>
            ArabicValue.GetHashCode() + RomanValue.GetHashCode();

        public override string ToString() =>
            RomanValue;

    }
}
