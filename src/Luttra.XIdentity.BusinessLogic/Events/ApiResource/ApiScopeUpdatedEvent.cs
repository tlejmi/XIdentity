using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.ApiResource
{
    public class ApiScopeUpdatedEvent : AuditEvent
    {
        public ApiScopesDto OriginalApiScope { get; set; }
        public ApiScopesDto ApiScope { get; set; }

        public ApiScopeUpdatedEvent(ApiScopesDto originalApiScope, ApiScopesDto apiScope)
        {
            OriginalApiScope = originalApiScope;
            ApiScope = apiScope;
        }
    }
}