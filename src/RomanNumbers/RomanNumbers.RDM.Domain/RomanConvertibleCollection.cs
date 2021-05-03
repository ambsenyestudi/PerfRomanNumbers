using RomanNumbers.RDM.Domain.Symbols;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanConvertibleCollection
    {
        public static RomanConvertibleCollection Empty { get; } = new RomanConvertibleCollection();
        public RomanConvertible[] Items { get; }

        private RomanConvertibleCollection()
        {
            Items = new RomanSymbol[0];
        }

        public RomanConvertibleCollection(ArabicNumber arabic)
        {
            Items = ComposeSymbolsFromNum(arabic);
        }

        private static RomanSymbol[] ComposeSymbolsFromNum(ArabicNumber evaluatingArabic)
        {
            
            var symbolList = RomanSymbols.GetAll()
                .Reverse().ToArray();

            List<RomanSymbol> result = new List<RomanSymbol>();
            var arabic = evaluatingArabic;
            var count = 0;

            while(arabic.IsGreaterThan(ArabicNumber.Zero) && count < symbolList.Length)
            {   
                var currSymbol = symbolList[count];
                var part = ExtractSymbolPart(arabic, currSymbol);
                if (part.Any())
                {
                    result.AddRange(part);
                    arabic = evaluatingArabic.Substract(result.ToArray());
                }
                count++;
            }
            
            return result.ToArray();
        }
        private static IEnumerable<RomanSymbol> ExtractSymbolPart(ArabicNumber arabic, RomanSymbol romanSymbol)
        {
            var num = arabic.Value;
            if (SpecialRomanSymbols.ContainsEquivalent(num))
            {
                return SpecialRomanSymbols.GetItemsFromEquivalent(num);
            }
            var repetition = RomanSymbolRepetition.FromOcurrancesOfSymbol(romanSymbol, arabic);
            return repetition.Equals(RomanSymbolRepetition.Empty)
                ? new RomanSymbol[0]
                : repetition.Items;
        }

        public override string ToString() =>
            string.Join("", Items.Select(ro => ro.RomanValue));
    }
}
