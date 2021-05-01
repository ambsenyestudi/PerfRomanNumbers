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
    }
}
