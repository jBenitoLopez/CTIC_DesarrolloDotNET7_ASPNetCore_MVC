using System.ComponentModel.DataAnnotations;

namespace DEMOValidaciones.Models
{
    public class Friend
    {
        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Name { get; set; }
        public int Age { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
