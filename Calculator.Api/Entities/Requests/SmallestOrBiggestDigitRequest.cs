using Calculator.Api.Enums;

namespace Calculator.Api.Entities.Requests
{
    public class SmallestOrBiggestDigitRequest
    {
        public int[] Sequence { get; set; } = new int[5];
        public ReturnDigit ReturnDigit { get; set; }
    }
}
