using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain.Symbols
{
    public class RomanSymbolRepetition
    {
        public static RomanSymbolRepetition Empty { get; } = new RomanSymbolRepetition(RomanSymbols.Empty, 0);
        public IEnumerable<RomanSymbol> Items { get; }

        public RomanSymbolRepetition(RomanSymbol romanSymbol, int count = 1)
        {
            Items = CreateRepetition(romanSymbol, count);
        }

        public static object CanCreateRepetition(RomanSymbol v, object arabic)
        {
            throw new System.NotImplementedException();
        }

        private static IEnumerable<RomanSymbol> CreateRepetition(RomanSymbol romanSymbol, int count = 1) =>
            !romanSymbol.IsRepitable || count == 1 
            ? new RomanSymbol[] { romanSymbol }
            : Enumerable.Repeat(romanSymbol, count);
        
        public static RomanSymbolRepetition FromOcurrancesOfSymbol(RomanSymbol romanSymbol, ArabicNumber arabic)
        {
            if (!CanCreateRepetition(romanSymbol, arabic))
            {
                return Empty;
            }
            var count = CalculateNumberOfOcurrances(romanSymbol, arabic);
            return new RomanSymbolRepetition(romanSymbol, count);
        }
        public static bool CanCreateRepetition(RomanSymbol romanSymbol, ArabicNumber arabic) =>
            CanCreateRepetition(romanSymbol, arabic.Value);

        public static bool CanCreateRepetition(RomanSymbol romanSymbol, int num) =>
            romanSymbol.IsSmallerOrEqualTo(num);

        public static int CalculateNumberOfOcurrances(RomanSymbol romanSymbol, ArabicNumber arabic)
        {
            if (arabic.Equals(ArabicNumber.Zero))
            {
                return 0;
            }
            var result = arabic.DevidedBy(romanSymbol);
            return result;
        }


    }
}
