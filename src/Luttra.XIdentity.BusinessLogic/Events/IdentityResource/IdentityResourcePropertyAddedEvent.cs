using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.IdentityResource
{
    public class IdentityResourcePropertyAddedEvent : AuditEvent
    {
        public IdentityResourcePropertiesDto IdentityResourceProperty { get; set; }

        public IdentityResourcePropertyAddedEvent(IdentityResourcePropertiesDto identityResourceProperty)
        {
            IdentityResourceProperty = identityResourceProperty;
        }
    }
}