using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab022.Services
{
    public interface ICalculatorServices
    {
        int Calculate(int a, int b, string operation);
    }
}
