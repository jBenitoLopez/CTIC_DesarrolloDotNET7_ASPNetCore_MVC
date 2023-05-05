using Microsoft.AspNetCore.Http.HttpResults;

namespace _19_4_1_DEMO_Binding
{
    public class CalculatorHandlers
    {
        public static Task<int> Add (int a, int b) => Task.FromResult(a + b);
        public static Task<int> Sub (int a, int b = 0) => Task.FromResult(a - b);
        public static Task<int> Mul (int a, int b) => Task.FromResult(a * b);
        
    }
}
