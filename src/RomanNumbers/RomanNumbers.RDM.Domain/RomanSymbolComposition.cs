using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanSymbolComposition
    {
        public const int IV_value = 4;
        public const int IX_value = 9;
        public static RomanSymbolComposition Empty { get; } = new RomanSymbolComposition(new RomanSymbol[0]);
        public RomanSymbol[] Items { get; }
        public static bool IsIV(int num) =>
            num == IV_value;
        private RomanSymbolComposition(RomanSymbol[] items)
        {
            Items = items;
        }
        public static RomanSymbolComposition Create(int num)
        {
            if(IsIV(num))
            {
                var symbolList = new RomanSymbol[] { RomanSymbol.I, RomanSymbol.V };
                return new RomanSymbolComposition(symbolList);
            }
            
            return Empty;
        }
        public override string ToString() =>
            string.Join("", Items.ToList());
    }
}
