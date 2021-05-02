using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public abstract class RomanConvertible
    {
        public int ArabicValue { get; }
        public string RomanValue { get; }
        protected RomanConvertible(string romanValue, int arabicValue) => (ArabicValue, RomanValue) = (arabicValue, romanValue);

        protected RomanConvertible(RomanSymbol[] romanSymbolList)
        {
            ArabicValue = ToArabicValue(romanSymbolList);
            RomanValue = string.Join("", romanSymbolList.ToList());
        }
        

        public static int ToArabicValue(IEnumerable<RomanSymbol> romanSymbolList)
        {
            if(romanSymbolList == null || !romanSymbolList.Any())
            {
                return 0;
            }
            if (romanSymbolList.First() == RomanSymbol.I)
            {
                return romanSymbolList.Last().ArabicValue - romanSymbolList.First().ArabicValue;
            }
            return romanSymbolList.Sum(x => x.ArabicValue);
        }

    }
}
