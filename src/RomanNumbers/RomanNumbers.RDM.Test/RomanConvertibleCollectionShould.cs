using RomanNumbers.RDM.Domain;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanConvertibleCollectionShould
    {

        
        [Theory]
        [InlineData(4,"IV")]
        [InlineData(9, "IX")]
        public void RepresentCompositeCharacters(int input, string exptected)
        {
            var arabic = new ArabicNumber(input);
            var sut = RomanConvertibleCollection.FromArabic(arabic);
            var actual = sut.ToString();
            Assert.Equal(exptected, actual);
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(8, "VIII")]
        public void RepetitionCharacters(int input, string exptected)
        {
            var arabic = new ArabicNumber(input);
            var sut = RomanConvertibleCollection.FromArabic(arabic);
            var actual = sut.ToString();
            Assert.Equal(exptected, actual);
        }
    }
}
