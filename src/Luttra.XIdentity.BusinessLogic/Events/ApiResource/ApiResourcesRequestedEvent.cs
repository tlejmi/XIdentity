using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.ApiResource
{
    public class ApiResourcesRequestedEvent : AuditEvent
    {
        public ApiResourcesRequestedEvent(ApiResourcesDto apiResources)
        {
            ApiResources = apiResources;
        }

        public ApiResourcesDto ApiResources { get; set; }
    }
}