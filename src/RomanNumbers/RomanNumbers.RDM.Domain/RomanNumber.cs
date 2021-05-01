namespace RomanNumbers.RDM.Domain
{
    public class RomanNumber
    {
        public static RomanNumber Zero { get; } = new RomanNumber(0);
        private string value = "";
        public RomanNumber(RomanSymbol romanSymbol)
        {
            value = romanSymbol.RomanValue;
        }
        public RomanNumber(int num)
        {
            var arabic = new ArabicNumber(num);
            value = FigureNumbers(arabic);
        }
        private string FigureNumbers(ArabicNumber arabic)
        {
            return CalculateFiftyPart(arabic);
        }

        private string CalculateFiftyPart(ArabicNumber arabic)
        {
            var result = "";   
            if(arabic.IsGreaterOrEqualTo(RomanSymbol.L))
            {
                result += RomanSymbol.L;
                arabic = arabic.Substract(RomanSymbol.L);
            }
            return result += CalculateTensPart(arabic);
        }
        private string CalculateTensPart(ArabicNumber arabic)
        {
            var result = "";
            
            while (arabic.IsGreaterOrEqualTo(RomanSymbol.X))
            {
                arabic = arabic.Substract(RomanSymbol.X);
                result += RomanSymbol.X;
            };
            
            if (IsOneUnitBefore(arabic, RomanSymbol.X))
            {
                result += $"{RomanSymbol.I}{RomanSymbol.X}";
                arabic = new ArabicNumber(arabic.Value - 9);
            }
            return result + CalculateFivePart(arabic);
        }


        private string CalculateFivePart(ArabicNumber arabic)
        {
            if (IsOneUnitBefore(arabic, RomanSymbol.V))
            {
                return $"{RomanSymbol.I}{RomanSymbol.V}";
            }
            var result = "";
            if (arabic.IsGreaterOrEqualTo(RomanSymbol.V))
            {
                result += RomanSymbol.V;
                arabic = arabic.Substract(RomanSymbol.V);
            }
            return result + CalculateUnitPart(arabic);
        }
        
        private string CalculateUnitPart(ArabicNumber arabic)
        {
            var result = string.Empty;
            while(arabic.Value > 0)
            {
                arabic = arabic.Substract(RomanSymbol.I);
                result += RomanSymbol.I;
            };
            return result;
        }

        public static bool IsOneUnitBefore(ArabicNumber arabicNumber, RomanSymbol romanSymbol)
        {
            var arabicReminder = arabicNumber.Substract(romanSymbol);
            return arabicReminder.IsNegativeRoman(RomanSymbol.I);           
        }

        public static bool IsHundredUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var reminder = FigureDifference(romanSymbol, input);
            return reminder == RomanSymbol.C.ArabicValue;
        }

        public static bool IsTenUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var reminder = FigureDifference(romanSymbol, input);
            return reminder == RomanSymbol.X.ArabicValue;
        }

        private static int FigureDifference(RomanSymbol romanSymbol, int arabicNumber)
        {
            var evaluatedValue = romanSymbol.ArabicValue;
            return evaluatedValue - arabicNumber;
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
