﻿using Skoruba.AuditLogging.Events;

namespace Luttra.XIdentity.BusinessLogic.Identity.Events.Identity
{
    public class RoleClaimsSavedEvent<TRoleClaimsDto> : AuditEvent
    {
        public TRoleClaimsDto Claims { get; set; }

        public RoleClaimsSavedEvent(TRoleClaimsDto claims)
        {
            Claims = claims;
        }
    }
}