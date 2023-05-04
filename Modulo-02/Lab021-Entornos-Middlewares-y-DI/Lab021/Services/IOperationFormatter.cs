namespace Lab021.Services
{
    public interface IOperationFormatter
    {
        string Format(int a, string operation, int b, int result);
    }
}