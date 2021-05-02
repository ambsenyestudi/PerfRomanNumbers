using System.Collections.Generic;

namespace RomanNumbers.RDM.Domain
{
    public class RomanSymbolCollection
    {
        public static RomanSymbolCollection Empty { get; } = new RomanSymbolCollection(new RomanSymbol[0]);
        public static Dictionary<int, RomanSymbol[]> SpecialSymbolsDictionary = new Dictionary<int, RomanSymbol[]>
        {
            [4] = new RomanSymbol[] { RomanSymbol.I, RomanSymbol.V }, //IV
            [9] = new RomanSymbol[] { RomanSymbol.I, RomanSymbol.X }, //IX
        };
        public RomanSymbol[] Items { get; }
        private RomanSymbolCollection(RomanSymbol[] items)
        {
            Items = items;
        }
        public static bool ContainsCompostedSymbol(int num) =>
            SpecialSymbolsDictionary.ContainsKey(num);

        public static IEnumerable<RomanSymbol> GetComposedSymbolCollection(int num) =>
            ContainsCompostedSymbol(num)
            ? SpecialSymbolsDictionary[num]
            : new RomanSymbol[0];
    }
}
