using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.ApiResource
{
    public class ApiScopesRequestedEvent : AuditEvent
    {
        public ApiScopesDto ApiScope { get; set; }

        public ApiScopesRequestedEvent(ApiScopesDto apiScope)
        {
            ApiScope = apiScope;
        }
    }
}