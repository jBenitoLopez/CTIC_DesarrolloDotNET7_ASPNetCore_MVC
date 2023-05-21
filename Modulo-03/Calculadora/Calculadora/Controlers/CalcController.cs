using Calculadora.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controlers
{
    public class CalcController: Controller
    {
        private readonly ICalculatorServices calculatorServices;
        private readonly ILogger logger;
        private const string BasePath = "/calc";

        public CalcController(ILogger<CalcController> logger, ICalculatorServices calculatorServices)
        {
            this.logger = logger;
            this.calculatorServices = calculatorServices;
        }

        public IActionResult Index()
        {
            var html = $@" <form method='post' action='{BasePath}/results'>
                                <input type='number' name='a'>
                                <select name='operation'>
                                    <option value='+'>+</option>
                                    <option value='-'>-</option>
                                    <option value='*'>*</option>
                                    <option value='/'>/</option>
                                </select>
                                <input type='number' name='b'>
                                <input type='submit' value='Calculate'>
                            </form>
                        ";

            return Content(html, contentType: "text/html");
        }

        public IActionResult Results(int a, int b, string operation)
        {
            var result = calculatorServices.Calculate(a, b, operation);
            var html = $@"<h2>{a}{operation}{b}={result}</h2>
                            <p><a href='{BasePath}'>Back</a></p>";

            return Content(html, contentType: "text/html");
        }

    }
}
