using RomanNumbers.RDM.Domain;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanSymbolCompositionShould
    {
        [Theory]
        [InlineData(4,"IV")]
        [InlineData(9, "IX")]
        public void RepresentCompositeCharacters(int input, string exptected)
        {
            var sut = RomanSymbolComposition.Create(input);
            Assert.Equal(exptected, sut.ToString());
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(8, "VIII")]
        public void RepetitionCharacters(int input, string exptected)
        {
            var sut = RomanSymbolComposition.Create(input);
            Assert.Equal(exptected, sut.ToString());
        }
    }
}
