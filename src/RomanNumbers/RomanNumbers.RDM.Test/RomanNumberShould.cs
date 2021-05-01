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

        [Fact]
        public void HaveOneBeforeV()
        {
            int input = 4;
            Assert.True(RomanNumber.IsOneBefore(input, RomanSymbol.V));
        }
    }
}
