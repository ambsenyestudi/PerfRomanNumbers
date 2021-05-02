using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public abstract class RomanConvertible
    {
        public int ArabicValue { get; }
        public string RomanValue { get; }
        protected RomanConvertible(string romanValue, int arabicValue) => (ArabicValue, RomanValue) = (arabicValue, romanValue);

        protected RomanConvertible(RomanSymbol[] romanSymbolList): this(string.Join("", romanSymbolList.ToList()), 
            ToArabicValue(romanSymbolList))
        {
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
                
                if(TryGetNextSymbol(i, romanSymbolList, out RomanSymbol nextSymbol) &&
                    TrySubstractNextFromCurrentSymbol(nextSymbol, currentSymbol, out int partialResult))
                {
                    currResult = partialResult;
                    i++;
                }
                
                result += currResult;

            }
            return result;
        }
        private static bool TrySubstractNextFromCurrentSymbol(RomanSymbol next, RomanSymbol current, out int result)
        {
            result = next.ArabicValue - current.ArabicValue;
            return result > 0;
        }
        private static bool TryGetNextSymbol(int index, RomanSymbol[] list, out RomanSymbol next)
        {
            var result = CanPullNext(index, list.Length);
            next = result 
                ? list[index + 1]
                : null;
            return result;
        }
        private static bool CanPullNext(int index, int range) =>
            IsIndexInRange(index + 1, range);
        private static bool IsIndexInRange(int index, int range) =>
            index < range;

    }
}
