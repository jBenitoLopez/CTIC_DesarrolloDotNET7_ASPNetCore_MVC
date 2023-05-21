namespace Calculadora.Services
{
    public class CalculatorServices : ICalculatorServices
    {
        private readonly ICalculationEngine calculationEngine;
        private readonly ILogger<CalculatorServices> logger;

        public CalculatorServices(ICalculationEngine calculationEngine, ILogger<CalculatorServices> logger)
        {
            this.calculationEngine = calculationEngine;
            this.logger = logger;
        }

        public int Calculate(int a, int b, string operation)
        {
            switch (operation)
            {
                case "+":
                    return calculationEngine.Add(a, b);
                case "-":
                    return calculationEngine.Substract(a, b);
                case "*":
                    return calculationEngine.Multiply(a, b);
                case "/":
                    return calculationEngine.Divide(a, b);
                default:
                    var message = $"Operation '{operation}' not supported";
                    logger.LogError(message);
                    throw new ArgumentOutOfRangeException(nameof(operation), message);
            }
        }
    }
}
