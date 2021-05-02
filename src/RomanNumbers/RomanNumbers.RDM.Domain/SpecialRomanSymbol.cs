using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class SpecialRomanSymbol : IRomanConvertible
    {
        public static SpecialRomanSymbol IV { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbol.I, RomanSymbol.V
            }, 4);
        public static SpecialRomanSymbol IX { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbol.I, RomanSymbol.X
            }, 9);

        public RomanSymbol[] Items { get; }

        public int ArabicValue { get; }

        public string RomanValue { get; }

        private SpecialRomanSymbol(RomanSymbol[] items, int value)
        {
            Items = items;
            RomanValue = string.Join("", items.AsEnumerable());
            ArabicValue = ToArabicValue(items);        
         }
         
        public bool IsArabicEquivalent(int num) =>
            ToArabicValue() == num;

        public int ToArabicValue() => 
            ToArabicValue(Items);
        private static int ToArabicValue(RomanSymbol[] romanSymbolList)
        {
            if (romanSymbolList.First() == RomanSymbol.I)
            {
                return romanSymbolList[1].ArabicValue - romanSymbolList[0].ArabicValue;
            }
            return romanSymbolList.Sum(x => x.ArabicValue);
        }

        public override string ToString() =>
            string.Join("", Items.ToList());

        public static bool ContainsEquivalent(int num) =>
            IV.ArabicValue == num || IX.ArabicValue == num;

        public static RomanSymbol[] GetItemsFromEquivalent(int num) =>
            IX.ArabicValue == num
            ? IX.Items
            : IV.Items;
    }
}
