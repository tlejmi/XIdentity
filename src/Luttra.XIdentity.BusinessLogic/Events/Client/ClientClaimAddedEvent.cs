using Luttra.XIdentity.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Events.Client
{
    public class ClientClaimAddedEvent : AuditEvent
    {
        public ClientClaimsDto ClientClaim { get; set; }

        public ClientClaimAddedEvent(ClientClaimsDto clientClaim)
        {
            ClientClaim = clientClaim;
        }
    }
}