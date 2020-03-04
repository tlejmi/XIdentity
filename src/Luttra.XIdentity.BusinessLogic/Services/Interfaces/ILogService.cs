using Luttra.XIdentity.BusinessLogic.Dtos.Log;
using System;
using System.Threading.Tasks;

namespace Luttra.XIdentity.BusinessLogic.Services.Interfaces
{
    public interface ILogService
    {
        Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}