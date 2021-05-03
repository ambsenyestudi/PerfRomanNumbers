using RomanNumbers.RDM.Domain.Enumerations;
using System.Linq;

namespace RomanNumbers.RDM.Domain.Symbols
{
    public class SpecialRomanSymbols : RichEnumeration
    {
        public static SpecialRomanSymbol IV  = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbols.I, RomanSymbols.V
            });
        public static SpecialRomanSymbol IX = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbols.I, RomanSymbols.X
            });
        public static SpecialRomanSymbol XL = new SpecialRomanSymbol(
            new RomanSymbol[]
            {
                RomanSymbols.X, RomanSymbols.L
            });

        private static SpecialRomanSymbol[] specialList = GetAll<SpecialRomanSymbols, SpecialRomanSymbol>().ToArray();
        public static bool ContainsEquivalent(ArabicNumber arabic) =>
            ContainsEquivalent(arabic.Value);
        public static bool ContainsEquivalent(int num) =>
            specialList.Any(ss => ss.ArabicValue == num);

        public static RomanSymbol[] GetItemsFromEquivalent(ArabicNumber arabic) =>
            GetItemsFromEquivalent(arabic.Value);

        public static RomanSymbol[] GetItemsFromEquivalent(int num) =>
            ContainsEquivalent(num)
            ? specialList.First(ss => ss.ArabicValue == num).Items
            : new RomanSymbol[0];
    }
}
