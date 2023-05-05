namespace _19_5_1_DEMO_Retorno_handlers
{
    public class CalculatorServices : ICalculatorServices
    {
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    public interface ICalculatorServices
    {
        int Multiply(int a, int b);
    }
}
