using RomanNumbers.RDM.Domain;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanSymbolCompositionShould
    {
        [Theory]
        [InlineData(4,"IV")]
        [InlineData(9, "IX")]
        public void Represent4(int input, string exptected)
        {
            var sut = RomanSymbolComposition.Create(input);
            Assert.Equal(exptected, sut.ToString());
        }
    }
}
