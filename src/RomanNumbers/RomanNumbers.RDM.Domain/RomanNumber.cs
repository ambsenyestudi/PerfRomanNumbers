using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private string value = "";
        public RomanNumber(int num)
        {
            var arabic = new ArabicNumber(num);
            var romanConvertibleCollection = new RomanConvertibleCollection(arabic);
            var result = romanConvertibleCollection.ToString();
            value = result;
        }

        public override bool Equals(object obj)
        {
            var romanValue = obj as string;
            if(string.IsNullOrWhiteSpace(romanValue))
            {
                return false;
            }
            return value == romanValue;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        public override string ToString() =>
            value;
    }
}
