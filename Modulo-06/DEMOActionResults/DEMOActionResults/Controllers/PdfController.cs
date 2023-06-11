using DEMOActionResults.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DEMOActionResults.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Download()
        {

            var defaultValues = new PdfFile
            {
                FileName = "default.pdf",
                Text = "Hello World!!"
            };

            return View(defaultValues);
        }

        [HttpPost]
        public IActionResult Download(PdfFile form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            //return Content($"Generate PDF File {form.FileName} with text '{form.Text}'");

            return new PdfFileResult(form.FileName, form.Text);
        }

    }
}
