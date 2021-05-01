﻿using System;
using System.Linq;

namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        private const int EMPTY_UNIT = 0;
        private const int SYMBOL_THRESHOLD = 5; 
        private const int MAX_ALLOWED_UNITS = 3;
        private static readonly string[] ROMAN_SYMBOL_LIST = new string[] { "I", "V", "X" };
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

        public static bool IsOneUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var evaluatedValue = romanSymbol.ArabicValue;
            var reminder = evaluatedValue - input;
            return reminder  == RomanSymbol.I.ArabicValue;
        }

        private string CalculateTensPart(int arabic)
        {
            var result = "";
            if (IsOneUnitBefore(arabic, RomanSymbol.X))
            {
                return $"{RomanSymbol.I}{RomanSymbol.X}";
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

        public static bool IsHundredUnitBefore(int input, RomanSymbol romanSymbol)
        {
            throw new NotImplementedException();
        }

        public static bool IsTenUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var evaluatedValue = romanSymbol.ArabicValue;
            var reminder = evaluatedValue - input;
            return reminder == RomanSymbol.X.ArabicValue; 
        }

        private string CalculateFivePart(int arabic)
        {
            if (IsOneUnitBefore(arabic, RomanSymbol.V))
            {
                return $"{RomanSymbol.I}{RomanSymbol.V}";
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

            var result = string.Empty;
            for (int i = 0; i < arabic; i++)
            {
                result += RomanSymbol.I.ToString();
            }
            return result;
        }

        private bool TryGetTenSymbol(int arabic, out string symbol) 
        {
            if (arabic < TEN_ARABIC)
            {
                symbol = string.Empty;
                return false;
            }
            symbol = ROMAN_SYMBOL_LIST[2];
            return true;
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
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
