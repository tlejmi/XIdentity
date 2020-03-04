using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.ApiResource
{
    public class ApiScopeRequestedEvent : AuditEvent
    {
        public ApiScopesDto ApiScopes { get; set; }

        public ApiScopeRequestedEvent(ApiScopesDto apiScopes)
        {
            ApiScopes = apiScopes;
        }
    }
}