using Calculator.Api.Enums;

namespace Calculator.Api.Entities.Requests
{
    public class TwoDigitCalculationRequest
    {
        public int FirstDigit { get; set; }
        public Operator Operator { get; set; }
        public int SecondDigit { get; set; }
    }
}
