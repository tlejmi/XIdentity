using Luttra.XIdentity.BusinessLogic.Dtos.Log;
using System;
using System.Threading.Tasks;

namespace Luttra.XIdentity.BusinessLogic.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}
