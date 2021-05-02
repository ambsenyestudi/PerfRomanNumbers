using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanSymbolComposition
    {
        public static RomanSymbolComposition Empty { get; } = new RomanSymbolComposition(new RomanSymbol[0]);
        public RomanSymbol[] Items { get; }

        private RomanSymbolComposition(RomanSymbol[] items)
        {
            Items = items;
        }
        public static RomanSymbolComposition Create(int num)
        {
            if(RomanSymbolCollection.ContainsCompostedSymbol(num))
            {
                var specialSymbolList = RomanSymbolCollection.GetComposedSymbolCollection(num)
                    .ToArray();
                return new RomanSymbolComposition(specialSymbolList);
            }
            return Empty;
        }

        public RomanSymbol[] PrependItems(RomanSymbol[] otherItems) =>
            otherItems.Concat(Items).ToArray();
 
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
