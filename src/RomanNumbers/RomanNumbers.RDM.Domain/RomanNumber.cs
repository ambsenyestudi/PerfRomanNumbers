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
            return CalculateFiftyPart(arabic.Value);
        }

        private string CalculateFiftyPart(int arabic)
        {
            var result = "";   
            if(arabic >= RomanSymbol.L.ArabicValue)
            {
                result += RomanSymbol.L;
                arabic -= RomanSymbol.L.ArabicValue;
            }
            return result += CalculateTensPart(arabic);
        }
        private string CalculateTensPart(int arabic)
        {
            var result = "";
            
            var xTimes = arabic / RomanSymbol.X.ArabicValue; 
            if(xTimes > 0)
            {
                for (int i = 0; i < xTimes; i++)
                {
                    result += RomanSymbol.X;
                    arabic -= RomanSymbol.X.ArabicValue;
                }
            }
            if (IsOneUnitBefore(arabic, RomanSymbol.X))
            {
                result += $"{RomanSymbol.I}{RomanSymbol.X}";
                arabic -= 9;
            }
            return result + CalculateFivePart(arabic);
        }


        private string CalculateFivePart(int num)
        {
            var arabic = new ArabicNumber(num);
            if (IsOneUnitBefore(num, RomanSymbol.V))
            {
                return $"{RomanSymbol.I}{RomanSymbol.V}";
            }
            var result = "";
            if (arabic.IsGreatherOrEqualTo(RomanSymbol.V))
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

        public static bool IsOneUnitBefore(int input, RomanSymbol romanSymbol)
        {
            var reminder = FigureDifference(romanSymbol, input);
            return reminder == RomanSymbol.I.ArabicValue;
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
