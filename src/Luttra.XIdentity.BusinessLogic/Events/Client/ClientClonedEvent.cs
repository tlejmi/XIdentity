using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.Client
{
    public class ClientClonedEvent : AuditEvent
    {
        public ClientCloneDto Client { get; set; }

        public ClientClonedEvent(ClientCloneDto client)
        {
            Client = client;
        }
    }
}