using RomanNumbers.RDM.Domain.Symbols;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class SpecialRomanSymbol : RomanConvertible
    {
        
        public RomanSymbol[] Items { get; }

        internal SpecialRomanSymbol(RomanSymbol[] items):base(items)
        {
            Items = items;
         }
         
        public bool IsArabicEquivalent(int num) =>
            ArabicValue == num;

        
    }
}
