namespace _19_4_1_DEMO_Binding
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
