using Calculator.Api.Enums;

namespace Calculator.Api.Interfaces
{
    public interface ICalculatorService
    {
        public decimal Calculate(int firstDigit, Operator op, int secondDigit);
        public decimal Calculate(string expression);
    }
}
