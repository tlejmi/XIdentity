﻿using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Identity.Events.Identity
{
    public class UserClaimsDeletedEvent<TUserClaimsDto> : AuditEvent
    {
        public TUserClaimsDto Claim { get; set; }

        public UserClaimsDeletedEvent(TUserClaimsDto claim)
        {
            Claim = claim;
        }
    }
}