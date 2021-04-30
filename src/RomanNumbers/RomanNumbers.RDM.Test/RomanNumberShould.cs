using RomanNumbers.RDM.Domain;
using System;
using Xunit;

namespace RomanNumbers.RDM.Test
{
    public class RomanNumberShould
    {
        [Fact]
        public void ParseOne()
        {
            var exptected = "I";
            var sut = new RomanNumber(1);
            Assert.True(sut.Equals(exptected));
        }
    }
}
