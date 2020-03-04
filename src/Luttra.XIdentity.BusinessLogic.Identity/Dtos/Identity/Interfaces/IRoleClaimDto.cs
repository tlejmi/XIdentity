namespace Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IRoleClaimDto : IBaseRoleClaimDto
    {
        string ClaimType { get; set; }
        string ClaimValue { get; set; }
    }
}
