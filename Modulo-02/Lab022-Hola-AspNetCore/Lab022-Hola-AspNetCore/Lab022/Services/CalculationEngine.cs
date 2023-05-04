using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab022.Services
{
    public class CalculationEngine: ICalculationEngine
    {
        public int Add(int a, int b) => a + b;
        public int Substract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => a / b;
    }
}
