using System.ComponentModel.DataAnnotations;

namespace Luttra.XIdentity.Provider.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}






