using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseUserChangePasswordDto<TUserId> : IBaseUserChangePasswordDto
    {
        public TUserId UserId { get; set; }

        object IBaseUserChangePasswordDto.UserId => UserId;
    }
}