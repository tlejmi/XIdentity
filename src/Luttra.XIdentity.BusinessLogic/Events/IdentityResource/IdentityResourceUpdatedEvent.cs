using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourceUpdatedEvent : AuditEvent
    {
        public IdentityResourceDto OriginalIdentityResource { get; set; }
        public IdentityResourceDto IdentityResource { get; set; }

        public IdentityResourceUpdatedEvent(IdentityResourceDto originalIdentityResource, IdentityResourceDto identityResource)
        {
            OriginalIdentityResource = originalIdentityResource;
            IdentityResource = identityResource;
        }
    }
}