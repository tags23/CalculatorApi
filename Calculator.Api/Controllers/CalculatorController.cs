using Calculator.Api.Entities.Requests;
using Calculator.Api.Entities.Responses;
using Calculator.Api.Enums;
using Calculator.Api.Interfaces;
using Calculator.Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api.Controllers
{
    [Route("api/v1/calculator")]
    [Produces("application/json")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService ?? throw new ArgumentNullException(nameof(calculatorService));
        }

        [HttpPost]
        [Route("CalculateTwoDigits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculationResult> CalculateTwoDigits(TwoDigitCalculationRequest request)
        {
            var response = new CalculationResult
            {
                Result = _calculatorService.Calculate(request.FirstDigit, request.Operator, request.SecondDigit)
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("CalculateStringExpression")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<CalculationResult> CalculateStringExpression(StringCalculationRequest request)
        {
            if (ArithmeticStringValidator.ContainsDivisionByZero(request.Expression)
                || !ArithmeticStringValidator.IsValidArithmeticDigitString(request.Expression)
                || ArithmeticStringValidator.IsDigitCountMoreThan(5, request.Expression))
            {
                return UnprocessableEntity();
            }

            var response = new CalculationResult();

            try
            {
                response.Result = _calculatorService.Calculate(request.Expression);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

            return response;
        }

        [HttpPost]
        [Route("CalculateSmallestOrBiggestDigit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CalculationResult> CalculateSmallestOrBiggestDigit(SmallestOrBiggestDigitRequest request)
        {
            var response = new CalculationResult()
            {
                Result = request.ReturnDigit == ReturnDigit.Smallest ? request.Sequence.Min() : request.Sequence.Max()
            };

            return Ok(response);
        }
    }
}
