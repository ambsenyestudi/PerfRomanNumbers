using RomanNumbers.RDM.Domain;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanConvertibleCollectionShould
    {

        
        [Theory]
        [InlineData(4,"IV")]
        [InlineData(9, "IX")]
        [InlineData(14, "XIV")]
        [InlineData(19, "XIX")]
        [InlineData(40, "XL")]
        public void RepresentCompositeCharacters(int input, string exptected)
        {
            var arabic = new ArabicNumber(input);
            var sut = new RomanConvertibleCollection(arabic);
            var actual = sut.ToString();
            Assert.Equal(exptected, actual);
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(8, "VIII")]
        [InlineData(30, "XXX")]
        public void RepetitionCharacters(int input, string exptected)
        {
            var arabic = new ArabicNumber(input);
            var sut = new RomanConvertibleCollection(arabic);
            var actual = sut.ToString();
            Assert.Equal(exptected, actual);
        }


        [Theory]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void TenUnitBeforNextSymbolp(int input, string exptected)
        {
            var arabic = new ArabicNumber(input);
            var sut = new RomanConvertibleCollection(arabic);
            var actual = sut.ToString();
            Assert.Equal(exptected, actual);
        }

    }
}
