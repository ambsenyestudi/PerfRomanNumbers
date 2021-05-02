using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class SpecialRomanSymbol : RomanConvertible
    {
        public static SpecialRomanSymbol IV { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbol.I, RomanSymbol.V
            });
        public static SpecialRomanSymbol IX { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbol.I, RomanSymbol.X
            });

        public RomanSymbol[] Items { get; }

        private SpecialRomanSymbol(RomanSymbol[] items):base(items)
        {
            Items = items;       
         }
         
        public bool IsArabicEquivalent(int num) =>
            ArabicValue == num;
        
        public static bool ContainsEquivalent(int num) =>
            IV.ArabicValue == num || IX.ArabicValue == num;

        public static RomanSymbol[] GetItemsFromEquivalent(int num) =>
            IX.ArabicValue == num
            ? IX.Items
            : IV.Items;
    }
}
