using System;
using System.Threading.Tasks;
using Luttra.XIdentity.BusinessLogic.Dtos.Log;
using Luttra.XIdentity.BusinessLogic.Events.Log;
using Skoruba.AuditLogging.Services;
using Luttra.XIdentity.BusinessLogic.Mappers;
using Luttra.XIdentity.BusinessLogic.Services.Interfaces;
using Luttra.XIdentity.EntityFramework.Repositories.Interfaces;

namespace Luttra.XIdentity.BusinessLogic.Services
{
    public class LogService : ILogService
    {
        protected readonly ILogRepository Repository;
        protected readonly IAuditEventLogger AuditEventLogger;

        public LogService(ILogRepository repository, IAuditEventLogger auditEventLogger)
        {
            Repository = repository;
            AuditEventLogger = auditEventLogger;
        }

        public virtual async Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = await Repository.GetLogsAsync(search, page, pageSize);
            var logs = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new LogsRequestedEvent());

            return logs;
        }

        public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
        {
            await Repository.DeleteLogsOlderThanAsync(deleteOlderThan);

            await AuditEventLogger.LogEventAsync(new LogsDeletedEvent(deleteOlderThan));
        }
    }
}
