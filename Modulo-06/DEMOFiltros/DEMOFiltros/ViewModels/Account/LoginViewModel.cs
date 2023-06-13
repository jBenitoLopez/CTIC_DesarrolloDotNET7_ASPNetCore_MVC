using System.ComponentModel.DataAnnotations;

namespace DEMOFiltros.ViewModels.Account
{
    public class LoginViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
    }
}
