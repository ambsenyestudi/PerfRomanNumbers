using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanSymbolComposition
    {
        public static RomanSymbolComposition Empty { get; } = new RomanSymbolComposition(new RomanSymbol[0]);
        public static RomanSymbolComposition IV { get; } = new RomanSymbolComposition(new RomanSymbol[] { RomanSymbol.I, RomanSymbol.V });
        public static RomanSymbolComposition IX { get; } = new RomanSymbolComposition(new RomanSymbol[] { RomanSymbol.I, RomanSymbol.X });
        public RomanSymbol[] Items { get; }

        private RomanSymbolComposition(RomanSymbol[] items)
        {
            Items = items;
        }
        public static RomanSymbolComposition Create(int num)
        {
            if(IV.IsArabicEquivalent(num))
            {
                return IV;
            }
            if(IX.IsArabicEquivalent(num))
            {
                return IX;
            }
            return Empty;
        }
        public bool IsArabicEquivalent(int num) =>

            ToArabicValue() == num;
        public int ToArabicValue()
        {
            if(Items.First()==RomanSymbol.I)
            {
                return Items[1].ArabicValue - Items[0].ArabicValue;
            }
            return Items.Sum(x => x.ArabicValue);
        }

        public override string ToString() =>
            string.Join("", Items.ToList());
    }
}
