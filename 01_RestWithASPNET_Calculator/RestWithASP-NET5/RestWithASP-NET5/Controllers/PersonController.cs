using Microsoft.AspNetCore.Mvc;

namespace RestWithASP_NET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fristNumber}/{secondNumber}")]
        public IActionResult sum(string fristNumber, string secondNumber)
        {
            if(IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal (fristNumber) + ConvertToDecimal (secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{fristNumber}/{secondNumber}")]
        public IActionResult subtraction(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(fristNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{fristNumber}/{secondNumber}")]
        public IActionResult multiplication(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(fristNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divi/{fristNumber}/{secondNumber}")]
        public IActionResult divisio(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                var divi = ConvertToDecimal(fristNumber) / ConvertToDecimal(secondNumber);
                return Ok(divi.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{fristNumber}/{secondNumber}")]
        public IActionResult mean(string fristNumber, string secondNumber)
        {
            if (IsNumeric(fristNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(fristNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{fristNumber}")]
        public IActionResult squareRoot(string fristNumber)
        {
            if (IsNumeric(fristNumber))
            {
                var sqrt = Math.Sqrt ((double)ConvertToDecimal(fristNumber)) ;
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid Input");
        }


        private bool IsNumeric(string strNumber)
        {
            Double number;
            bool isNumber = Double.TryParse(
                strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
          
    }
}