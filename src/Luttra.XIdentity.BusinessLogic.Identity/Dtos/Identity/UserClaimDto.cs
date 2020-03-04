using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Interfaces;
using System.ComponentModel.DataAnnotations;
using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Base;

namespace Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity
{
    public class UserClaimDto<TUserDtoKey> : BaseUserClaimDto<TUserDtoKey>, IUserClaimDto
    {
        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }
    }
}