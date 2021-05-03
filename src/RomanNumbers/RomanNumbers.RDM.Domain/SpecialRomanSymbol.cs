using RomanNumbers.RDM.Domain.Symbols;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class SpecialRomanSymbol : RomanConvertible
    {
        public static SpecialRomanSymbol IV { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbols.I, RomanSymbols.V
            });
        public static SpecialRomanSymbol IX { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbols.I, RomanSymbols.X
            });
        public static SpecialRomanSymbol XL { get; } = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbols.X, RomanSymbols.L
            });
        private static SpecialRomanSymbol[] specialList = new SpecialRomanSymbol[]
            {
                IV, IX, XL
            };

        public RomanSymbol[] Items { get; }

        private SpecialRomanSymbol(RomanSymbol[] items):base(items)
        {
            Items = items;
         }
         
        public bool IsArabicEquivalent(int num) =>
            ArabicValue == num;

        public static bool ContainsEquivalent(int num) =>
            specialList.Any(ss => ss.ArabicValue == num);

        public static RomanSymbol[] GetItemsFromEquivalent(int num) =>
            ContainsEquivalent(num)
            ? specialList.First(ss => ss.ArabicValue == num).Items
            : new RomanSymbol[0];
    }
}
