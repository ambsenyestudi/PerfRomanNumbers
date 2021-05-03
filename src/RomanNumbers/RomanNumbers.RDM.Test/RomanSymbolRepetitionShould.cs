using RomanNumbers.RDM.Domain;
using RomanNumbers.RDM.Domain.Symbols;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanSymbolRepetitionShould
    {

        [Fact]
        public void CreateRepetition()
        {
            var arabicFive = new ArabicNumber(5);
            var result = RomanSymbolRepetition.CanCreateRepetition(RomanSymbols.V, arabicFive);
            Assert.True(result);
        }
        [Fact]
        public void NotCreateEmptyRepetition()
        {
            var arabicThree = new ArabicNumber(3);
            var result = RomanSymbolRepetition.CanCreateRepetition(RomanSymbols.V, arabicThree);
            Assert.False(result);

        }
    }
}
