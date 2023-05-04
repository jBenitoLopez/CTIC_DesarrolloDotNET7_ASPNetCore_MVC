using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Lab022.Services
{
    public class CalculatorServices : ICalculatorServices
    {
        private readonly ICalculationEngine _calculationEngine;
        private readonly ILogger<CalculatorServices> _logger;

        public CalculatorServices(ICalculationEngine calculationEngine, ILogger<CalculatorServices> logger)
        {
            _calculationEngine = calculationEngine;
            _logger = logger;
        }

        public int Calculate(int a, int b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return _calculationEngine.Add(a, b);
                case "-":
                    return _calculationEngine.Substract(a, b);
                case "*":
                    return _calculationEngine.Multiply(a, b);
                case "/":
                    return _calculationEngine.Divide(a, b);
                default:
                    var message = $"Operation '{operation}' not supported";
                    _logger.LogError(message);
                    throw new ArgumentOutOfRangeException(nameof(operation), message);
            }
        }
    }
}
