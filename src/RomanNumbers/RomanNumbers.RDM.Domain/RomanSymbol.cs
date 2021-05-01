using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RomanNumbers.RDM.Domain
{
    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    public class RomanSymbol
    {
        public static RomanSymbol I = new RomanSymbol(1, "I");
        public static RomanSymbol V = new RomanSymbol(5, "V");
        public static RomanSymbol X = new RomanSymbol(10, "X");
        public static RomanSymbol L = new RomanSymbol(50, "L");
        public static RomanSymbol C = new RomanSymbol(100, "C");
        public static RomanSymbol D = new RomanSymbol(500, "D");
        public static RomanSymbol M = new RomanSymbol(1000, "M");

        public int ArabicValue { get; }
        public string RomanValue { get; }
        
        private RomanSymbol(int arabicValue, string romanValue)
        {
            ArabicValue = arabicValue;
            RomanValue = romanValue;
        }

        public static IEnumerable<RomanSymbol> GetAll() =>
            typeof(RomanSymbol).GetFields(BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<RomanSymbol>();

        public static bool IsMember(string romanRaw) =>
            GetAll().Any(x => x.RomanValue == romanRaw);

        public static bool TryParse(string romanRaw, out RomanSymbol romanSymbol)
        {
            romanSymbol = Parse(romanRaw);
            return romanSymbol != null; 
        }
        public static RomanSymbol Parse(string romanRaw) =>
            GetAll().FirstOrDefault(x => x.RomanValue.Equals(romanRaw));

        public int CalculateNumberOfOcurrances(int num)
        {
            if(num == 0)
            {
                return 0;
            }
            var result = num / ArabicValue;
            return result;
        }

        public RomanSymbol[] GetOccurances(int num) =>
            Enumerable.Repeat(this, CalculateNumberOfOcurrances(num))
            .ToArray();
        


        public override bool Equals(object obj)
        {
            var otherRoman = obj as RomanSymbol;
            if(otherRoman != null)
            {
                return ArabicValue == otherRoman.ArabicValue &&
                    RomanValue == otherRoman.RomanValue;
            }
            var romanRaw = obj as string;
            if(string.IsNullOrWhiteSpace(romanRaw))
            {
                return false;
            }
            return RomanValue == romanRaw;

        }
        public override int GetHashCode() =>
            ArabicValue.GetHashCode() + RomanValue.GetHashCode();

        public override string ToString() =>
            RomanValue;

    }
}
