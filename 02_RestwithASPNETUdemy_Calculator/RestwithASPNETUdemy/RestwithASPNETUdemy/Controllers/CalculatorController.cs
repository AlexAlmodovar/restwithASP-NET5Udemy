using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestwithASPNETUdemy.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}/{thirtNumber}")]
        public IActionResult med(string firstNumber, string secondNumber, string thirtNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && Isnumber(thirtNumber))
            {
                var med = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2;
                return Ok(med.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("rai/{firstNumber}")]
        public IActionResult rai(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var rai = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(rai.ToString());
            }

            return BadRequest("Invalid input");
        }


        private bool Isnumber(string strNumber)
        {
            double number;
            bool isnumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isnumber;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isnumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isnumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
                return 0;
        }
    }
}