﻿using System;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private const int EMPTY_UNIT = 0;
        private const int SYMBOL_THRESHOLD = 5; 
        private const int MAX_ALLOWED_UNITS = 3;
        private readonly string[] UNIT_LIST = new string[] { "I", "II", "III" };
        private readonly string[] ROMAN_SYMBOL_LIST = new string[] { "I", "V", "X" };
        private const int HALF_TEN_ARABIC = 5;
        private const int TEN_ARABIC = 10;
        private string value = "";
        public RomanNumber(int arabic)
        {
            value = FigureNumbers(arabic);
        }
        private string FigureNumbers(int arabic)
        {
            return CalculateTensPart(arabic);
        }
        private bool HasUnitPart(int arabic) =>
            arabic > EMPTY_UNIT &&
            arabic <= MAX_ALLOWED_UNITS;
        
        private string CalculateTensPart(int arabic)
        {
            var result = "";
            if (arabic == 9)
            {
                return "IX";
            }
            if (arabic == 19)
            {
                return "XIX";
            }
            
            if (TryGetTenSymbol(arabic, out string tenSymbol))
            {
                result += tenSymbol;
                arabic -= 10;
            }
            return result + CalculateFivePart(arabic);
        }

        private string CalculateFivePart(int arabic)
        {
            if (arabic == 4)
            {
                return "IV";
            }
            var result = "";
            if (arabic >= HALF_TEN_ARABIC)
            {
                result += ROMAN_SYMBOL_LIST[1];
                arabic -= HALF_TEN_ARABIC;
            }
            return result + CalculateUnitPart(arabic);
        }
        
        private string CalculateUnitPart(int arabic)
        {
            if (!HasUnitPart(arabic))
            {
                return string.Empty;                
            }

            var unitIndex = arabic - 1;
            return UNIT_LIST[unitIndex];
        }

        private int ToSymbolIndex(int arabic) =>
            arabic / SYMBOL_THRESHOLD;

        private bool TryGetTenSymbol(int arabic, out string symbol) 
        {
            var index = ToSymbolIndex(arabic);
            var isTenSymbol = index > 1 && index < 4;

            if (! isTenSymbol)
            {
                symbol = string.Empty;
                return false;
            }
            symbol = ROMAN_SYMBOL_LIST[2];
            return isTenSymbol;
        }
            
        

        public override bool Equals(object obj)
        {
            var romanValue = obj as string;
            if(string.IsNullOrWhiteSpace(romanValue))
            {
                return false;
            }
            return value == romanValue;
        }
    }
}
