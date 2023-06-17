using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace DEMOTagHelpers_Cache.Models.ViewModels
{
    public class CreateCustomerViewModel
    {
            [Required]
            public string Name { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            public CustomerType Type { get; set; }
    }

    public enum CustomerType
    {
        Vip,
        Prime,
        Standard
    }
}
