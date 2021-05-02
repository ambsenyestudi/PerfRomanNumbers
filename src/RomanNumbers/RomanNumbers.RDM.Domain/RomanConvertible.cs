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
        

        protected static int ToArabicValue(RomanSymbol[] romanSymbolList)
        {
            if (romanSymbolList.First() == RomanSymbol.I)
            {
                return romanSymbolList[1].ArabicValue - romanSymbolList[0].ArabicValue;
            }
            return romanSymbolList.Sum(x => x.ArabicValue);
        }

    }
}
