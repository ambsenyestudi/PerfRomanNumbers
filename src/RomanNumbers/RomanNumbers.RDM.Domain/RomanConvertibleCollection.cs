using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanConvertibleCollection
    {
        public static RomanConvertibleCollection Empty { get; } = new RomanConvertibleCollection(new RomanSymbol[0]);
        public RomanConvertible[] Items { get; }

        public static RomanSymbol[] FromRepetition(RomanSymbol romanSymbol, int count) =>
            Enumerable.Repeat(romanSymbol, count).ToArray();

        private RomanConvertibleCollection(RomanConvertible[] items)
        {
            Items = items;
        }
        public static RomanConvertibleCollection FromArabic(ArabicNumber arabic)
        {
            var num = arabic.Value;
            var romanConvertibleList = ComposeSymbolsFromNum(num);
            return new RomanConvertibleCollection(romanConvertibleList);
        }
        private static RomanSymbol[] ComposeSymbolsFromNum(int num)
        {
            if (SpecialRomanSymbol.ContainsEquivalent(num))
            {
                return SpecialRomanSymbol.GetItemsFromEquivalent(num);
            }
            if (num > 8)
            {
                return new RomanSymbol[0];
            }
            
            if(RomanSymbol.V.IsSmallerThan(num))
            {
                var currNum = num - RomanSymbol.V.ArabicValue;
                var symbolCollection = FromRepetition(RomanSymbol.I, currNum)
                    .AsEnumerable()
                    .Prepend(RomanSymbol.V);
                return symbolCollection.ToArray();
            }
            return FromRepetition(RomanSymbol.I, num);
        }

        public override string ToString() =>
            string.Join("", Items.Select(ro => ro.RomanValue));
    }
}
