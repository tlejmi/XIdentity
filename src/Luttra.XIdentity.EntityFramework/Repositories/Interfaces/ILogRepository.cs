using System;
using System.Threading.Tasks;
using Luttra.XIdentity.EntityFramework.Entities;
using Luttra.XIdentity.EntityFramework.Extensions.Common;

namespace Luttra.XIdentity.EntityFramework.Repositories.Interfaces
{
    public interface ILogRepository
    {
        Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}