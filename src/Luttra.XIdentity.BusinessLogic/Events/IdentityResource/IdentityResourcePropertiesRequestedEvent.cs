using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcePropertiesRequestedEvent : AuditEvent
    {
        public IdentityResourcePropertiesDto IdentityResourceProperties { get; set; }

        public IdentityResourcePropertiesRequestedEvent(IdentityResourcePropertiesDto identityResourceProperties)
        {
            IdentityResourceProperties = identityResourceProperties;
        }
    }
}