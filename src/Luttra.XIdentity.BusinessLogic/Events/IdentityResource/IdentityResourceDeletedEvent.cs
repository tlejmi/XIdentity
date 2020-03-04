using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourceDeletedEvent : AuditEvent
    {
        public IdentityResourceDto IdentityResource { get; set; }

        public IdentityResourceDeletedEvent(IdentityResourceDto identityResource)
        {
            IdentityResource = identityResource;
        }
    }
}