﻿using System.Collections.Generic;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanConvertibleCollection
    {
        public static RomanConvertibleCollection Empty { get; } = new RomanConvertibleCollection(new RomanSymbol[0]);
        public RomanConvertible[] Items { get; }

        
        private RomanConvertibleCollection(RomanConvertible[] items)
        {
            Items = items;
        }

        public static RomanSymbol[] FromRepetition(RomanSymbol romanSymbol, int count) =>
            Enumerable.Repeat(romanSymbol, count).ToArray();

        public static RomanConvertibleCollection FromArabic(ArabicNumber arabic)
        {
            var num = arabic.Value;
            var romanConvertibleList = ComposeSymbolsFromNum(num);
            return new RomanConvertibleCollection(romanConvertibleList);
        }
        private static RomanSymbol[] ComposeSymbolsFromNum(int num)
        {
            var symbolList = RomanSymbol.GetAll()
                .Reverse().ToArray();

            List<RomanSymbol> result = new List<RomanSymbol>();
            var currNum = num;
            var count = 0;

            while(currNum > 0 && count < symbolList.Length)
            {
                currNum = currNum - RomanConvertible.ToArabicValue(result.ToArray());
                var currSymbol = symbolList[count];
                var part = ExtractSymbolPart(currNum, currSymbol);
                result.AddRange(part);
                count++;
            }
            
            return result.ToArray();
        }
        private static IEnumerable<RomanSymbol> ExtractSymbolPart(int num, RomanSymbol romanSymbol)
        {
            if (SpecialRomanSymbol.ContainsEquivalent(num))
            {
                return SpecialRomanSymbol.GetItemsFromEquivalent(num);
            }
            if (romanSymbol.IsSmallerOrEqualTo(num))
            {
                if(romanSymbol.IsRepitable)
                {
                    var count = num / romanSymbol.ArabicValue;
                    return FromRepetition(romanSymbol, count);
                }
                return new RomanSymbol[] { romanSymbol };
            }
            return new RomanSymbol[0];
        }

        public override string ToString() =>
            string.Join("", Items.Select(ro => ro.RomanValue));
    }
}
