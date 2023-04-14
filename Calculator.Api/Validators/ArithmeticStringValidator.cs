using Calculator.Api.Constants;

namespace Calculator.Api.Validators
{
    public static class ArithmeticStringValidator
    {
        private static readonly List<char> operators = new List<char> { OperatorConstants.Addition, OperatorConstants.Subtraction, OperatorConstants.Multiplication, OperatorConstants.Division };

        /// <summary>
        /// Validates if an expression string is in the format of - digit followed by an operator followed by a digit and continuing
        /// </summary>
        public static bool IsValidArithmeticDigitString(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return false;
            }

            var chars = expression.ToCharArray();
            var isValid = true;

            for (var i = 0; i < chars.Length && isValid; i++)
            {
                var isEven = i % 2 == 0;

                if (isEven)
                {
                    isValid = char.IsDigit(chars[i]);
                }
                else
                {
                    isValid = operators.Contains(chars[i]);
                }
            }

            return isValid;
        }

        public static bool ContainsDivisionByZero(string expression)
        {
            return expression.Contains("/0");
        }

        public static bool IsDigitCountMoreThan(int allowedDigitCount, string expression)
        {
            var operatorCount = 0;

            foreach (char c in expression)
            {
                if (operators.Contains(c))
                {
                    operatorCount++;
                }
            }

            var digitCount = expression.Length - operatorCount;
            return digitCount > allowedDigitCount;
        }
    }
}
