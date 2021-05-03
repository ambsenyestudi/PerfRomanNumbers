using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RomanNumbers.RDM.Domain.Enumerations
{
    //https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    public abstract class RichEnumeration
    {
        public static IEnumerable<TOut> GetAll<TEnum, TOut>() where TEnum : RichEnumeration =>
        typeof(TEnum).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<TOut>();
    }
}
