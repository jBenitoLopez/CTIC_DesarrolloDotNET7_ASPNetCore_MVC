using System.ComponentModel.DataAnnotations;

namespace DEMOActionResults.Models
{
    public class PdfFile
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
