namespace Lab021.Services
{
    public class BasicCalculator : IAdder
    {
        private readonly IOperationFormatter _formatter;

        public BasicCalculator(IOperationFormatter formatter)
        {
            _formatter = formatter;
        }

        public string Add(int a, int b) => _formatter.Format(a, "+", b, a + b);
    }
}