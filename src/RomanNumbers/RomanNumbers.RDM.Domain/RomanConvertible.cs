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
        

        public static int ToArabicValue(IEnumerable<RomanSymbol> romanSymbolCollection)
        {
            if(romanSymbolCollection == null || !romanSymbolCollection.Any())
            {
                return 0;
            }
            var result = 0;
            var romanSymbolList = romanSymbolCollection.ToArray();
            for (int i = 0; i < romanSymbolList.Length; i++)
            {
                var currentSymbol = romanSymbolList[i];
                var currResult = currentSymbol.ArabicValue;
                
                if (CanPullNext(i, romanSymbolList.Length))
                {
                    var nextIndex = i + 1;
                    var next = romanSymbolList[nextIndex];
                    if(next.ArabicValue > currentSymbol.ArabicValue)
                    {
                        currResult = next.ArabicValue - currResult;
                        i++;
                    }
                }
                
                result += currResult;

            }
            return result;
        }
        private static bool CanPullNext(int index, int range) =>
            IsIndexInRange(index + 1, range);
        private static bool IsIndexInRange(int index, int range) =>
            index < range;

    }
}
