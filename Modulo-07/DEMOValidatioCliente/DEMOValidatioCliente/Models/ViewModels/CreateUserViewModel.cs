using System.ComponentModel.DataAnnotations;

namespace DEMOValidatioCliente.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required, StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(29, MinimumLength = 5)]
        public string Password { get; set; }

        [Required, StringLength(29, MinimumLength = 5)]
        public string RePassword { get; set; }

        public bool Enabled { get; set; }
    }
}
