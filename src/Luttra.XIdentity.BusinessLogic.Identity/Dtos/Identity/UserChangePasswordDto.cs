using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Interfaces;
using System.ComponentModel.DataAnnotations;
using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Base;

namespace Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity
{
    public class UserChangePasswordDto<TUserDtoKey> : BaseUserChangePasswordDto<TUserDtoKey>, IUserChangePasswordDto
    {
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
