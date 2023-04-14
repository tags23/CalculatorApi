using Calculator.Api.Enums;
using Calculator.Api.Interfaces;
using System.Data;

namespace Calculator.Api.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Calculate(int firstDigit, Operator op, int secondDigit)
        {
            switch (op)
            {
                case Operator.Addition:
                    return firstDigit + secondDigit;
                case Operator.Subtraction:
                    return firstDigit - secondDigit;
                case Operator.Multiplication:
                    return firstDigit * secondDigit;
                case Operator.Division:
                    return firstDigit / secondDigit;
                default:
                    throw new NotImplementedException($"Calculate doesnt support operator '{op}'.");
            }
        }

        public decimal Calculate(string expression)
        {
            var dt = new DataTable();
            var result = dt.Compute(expression, null);

            return decimal.Parse(result.ToString());
        }
    }
}
