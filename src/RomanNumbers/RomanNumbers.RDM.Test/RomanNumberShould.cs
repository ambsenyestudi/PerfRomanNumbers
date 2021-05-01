using RomanNumbers.RDM.Domain;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanNumberShould
    {
        [Theory]
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(13, "XIII")]
        [InlineData(15, "XV")]
        [InlineData(19, "XIX")]
        public void ParseOne(int input, string exptected)
        {
            var sut = new RomanNumber(input);
            Assert.True(sut.Equals(exptected));
        }

        [Theory]
        [InlineData(4, "V")]
        [InlineData(9, "X")]
        public void HaveOneBeforeV(int input, string symbol)
        {
            Assert.True(RomanNumber.IsOneUnitBefore(input, RomanSymbol.Parse(symbol)));
        }
    }
}
