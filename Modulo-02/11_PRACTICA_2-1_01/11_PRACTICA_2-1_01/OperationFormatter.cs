namespace _11_PRACTICA_2_1_01
{
    public class OperationFormatter : IOperationFormatter
    {
        public string Format(int a, string operation, int b, int result)
        {
            return $"{a}{operation}{b}={result}";
        }
    
    }
}
