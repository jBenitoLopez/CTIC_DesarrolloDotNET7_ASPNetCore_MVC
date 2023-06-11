using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DEMOActionResults.Extensions.IActionResults
{
    public class PdfFileResult : IActionResult
    {
        private readonly string fileName;
        private readonly string text;

        public PdfFileResult(string fileName, string text)
        {
            this.fileName = fileName;
            this.text = text;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            using var stream = new MemoryStream();

            GeneratePdf(stream, text);
            context.HttpContext.Response.ContentType = "application/pdf";
            context.HttpContext.Response.Headers.Add("content-disposition", $"attachment; filename={fileName}");
            await context.HttpContext.Response.BodyWriter.WriteAsync(stream.GetBuffer());
        }

        private void GeneratePdf(Stream stream, string text)
        {
            var document = new Document();
            PdfWriter.GetInstance(document, stream);
            document.Open();

            var font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.Gray);
            document.Add(new Paragraph(text, font));
            document.Add(new Paragraph(DateTime.Now.ToString("M")));
            document.Close();
        }
    }
}
