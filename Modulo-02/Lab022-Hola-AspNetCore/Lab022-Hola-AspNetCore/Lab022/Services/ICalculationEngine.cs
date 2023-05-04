namespace Lab022.Services
{
    public interface ICalculationEngine
    {
        int Add(int a, int b);
        int Substract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }
}