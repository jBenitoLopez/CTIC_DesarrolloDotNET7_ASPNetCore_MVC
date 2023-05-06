namespace _20_PRACTICA_2_3.Services
{
    public class CalculatorServices : ICalculatorServices
    {
        private readonly ICalculationEngine calculationEngine;
        private readonly ILogger<CalculatorServices> logger;

        public CalculatorServices(
                ICalculationEngine calculationEngine, 
                ILogger<CalculatorServices> logger
            )
        {
            this.calculationEngine = calculationEngine;
            this.logger = logger;
        }
        public int Calculate(int a, int b, string operation)
        {
            switch (operation)
            {
                case "add":
                    return calculationEngine.Add(a, b);
                case "sub":
                    return calculationEngine.Substract(a, b);
                case "mul":
                    return calculationEngine.Multiply(a, b);
                case "div":
                    return calculationEngine.Divide(a, b);
                default:
                    return 0;
            }
        }
    }
}
