using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Interfaces;
using System.ComponentModel.DataAnnotations;
using Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity.Base;

namespace Luttra.XIdentity.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
    {      
        [Required]
        public string Name { get; set; }
    }
}