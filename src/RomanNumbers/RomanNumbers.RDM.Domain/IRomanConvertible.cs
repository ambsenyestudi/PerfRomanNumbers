namespace RomanNumbers.RDM.Domain
{
    public interface IRomanConvertible
    {
        public int ArabicValue { get; }
        public string RomanValue { get; }
    }
}
