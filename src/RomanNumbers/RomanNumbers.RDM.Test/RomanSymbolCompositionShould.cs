using RomanNumbers.RDM.Domain;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanSymbolCompositionShould
    {
        [Fact]
        public void Represent4()
        {
            var exptected = "IV";
            var sut = RomanSymbolComposition.Create(4);
            Assert.Equal(exptected, sut.ToString());
        }
    }
}
