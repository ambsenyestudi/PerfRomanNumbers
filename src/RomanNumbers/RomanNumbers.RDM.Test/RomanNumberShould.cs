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
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(10, "X")]
        [InlineData(13, "XIII")]
        [InlineData(15, "XV")]
        [InlineData(17, "XVII")]
        public void ParseArabic(int input, string exptected)
        {
            var sut = new RomanNumber(input);
            Assert.True(sut.Equals(exptected));
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(14, "XIV")]
        [InlineData(19, "XIX")]
        public void ParseUnitBefore(int input, string exptected)
        {
            var sut = new RomanNumber(input);
            Assert.True(sut.Equals(exptected));
        }


        [Theory]
        [InlineData(4, "V")]
        [InlineData(9, "X")]
        public void OneUnitBeforNextSymbol(int input, string symbol)
        {
            var arabic = new ArabicNumber(input);
            Assert.True(RomanNumber.IsOneUnitBefore(arabic, RomanSymbol.Parse(symbol)));
        }

        [Theory]
        [InlineData(40, "L")]
        [InlineData(90, "C")]
        public void TenUnitBeforNextSymbolp(int input, string symbol)
        {
            var arabic = new ArabicNumber(input);
            Assert.True(RomanNumber.IsTenUnitBefore(arabic, RomanSymbol.Parse(symbol)));
        }

        [Theory]
        [InlineData(400, "D")]
        [InlineData(900, "M")]
        public void HundredUnitBeforNextSymbolp(int input, string symbol)
        {
            Assert.True(RomanNumber.IsHundredUnitBefore(input, RomanSymbol.Parse(symbol)));
        }

        [Theory]
        [InlineData(4,"IV")]
        [InlineData(9, "IX")]
        [InlineData(29, "XXIX")]
        [InlineData(80, "LXXX")]
        public void ParseAnyArabic(int input, string exptected)
        {
            var sut = new RomanNumber(input);
            Assert.True(sut.Equals(exptected));
        }


    }
}
