using System.ComponentModel.DataAnnotations;

namespace DEMOApiController.Models
{
    public class Friend
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }
    }
}
