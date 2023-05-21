namespace Calculadora.Services
{
    public class CalculationEngine:ICalculationEngine
    {
        public int Add(int a, int b) => a + b;
        public int Substract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => a / b;
    }
}
