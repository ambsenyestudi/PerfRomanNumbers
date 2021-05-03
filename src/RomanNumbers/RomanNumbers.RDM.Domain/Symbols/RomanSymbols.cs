using RomanNumbers.RDM.Domain.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain.Symbols
{
    public class RomanSymbols: RichEnumeration
    {
        public static RomanSymbol I = new RomanSymbol(1, "I");
        public static RomanSymbol V = new RomanSymbol(5, "V", false);
        public static RomanSymbol X = new RomanSymbol(10, "X");
        public static RomanSymbol L = new RomanSymbol(50, "L", false);
        public static RomanSymbol C = new RomanSymbol(100, "C");
        public static RomanSymbol D = new RomanSymbol(500, "D", false);
        public static RomanSymbol M = new RomanSymbol(1000, "M");
        
        private static RomanSymbol[] all = GetAll<RomanSymbols,RomanSymbol>().ToArray();
        public static IEnumerable<RomanSymbol> GetAll() => all;

        public static bool IsMember(string romanRaw) =>
            GetAll().Any(x => x.RomanValue == romanRaw);

        public static bool TryParse(string romanRaw, out RomanSymbol romanSymbol)
        {
            romanSymbol = Parse(romanRaw);
            return romanSymbol != null;
        }
        public static RomanSymbol Parse(string romanRaw) =>
            GetAll().FirstOrDefault(x => x.RomanValue.Equals(romanRaw));

        public static RomanSymbol GetCloserSymbol(int num) =>
            GetAll().LastOrDefault(x => x.ArabicValue <= num);
    }
}
