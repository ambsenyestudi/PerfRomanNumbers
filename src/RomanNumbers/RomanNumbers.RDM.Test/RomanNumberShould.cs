using RomanNumbers.RDM.Domain;
using System;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanNumberShould
    {
        [Theory]
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        public void ParseOne(int input, string exptected)
        {
            var sut = new RomanNumber(input);
            Assert.True(sut.Equals(exptected));
        }
    }
}
