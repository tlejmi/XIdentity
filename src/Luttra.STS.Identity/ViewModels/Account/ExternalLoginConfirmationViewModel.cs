using System.ComponentModel.DataAnnotations;

namespace Luttra.XIdentity.Provider.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_@\-\.\+]+$")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}






