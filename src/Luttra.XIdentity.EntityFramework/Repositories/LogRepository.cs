﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Luttra.XIdentity.EntityFramework.Entities;
using Luttra.XIdentity.EntityFramework.Interfaces;
using Luttra.XIdentity.EntityFramework.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Luttra.XIdentity.EntityFramework.Extensions.Extensions;
using Luttra.XIdentity.EntityFramework.Extensions.Common;

namespace Luttra.XIdentity.EntityFramework.Repositories
{
    public class LogRepository<TDbContext> : ILogRepository
        where TDbContext : DbContext, IAdminLogDbContext
    {
        protected readonly TDbContext DbContext;

        public LogRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
        {
            var logsToDelete = await DbContext.Logs.Where(x => x.TimeStamp < deleteOlderThan.Date).ToListAsync();

            if(logsToDelete.Count == 0) return;

            DbContext.Logs.RemoveRange(logsToDelete);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<Log>();
            Expression<Func<Log, bool>> searchCondition = x => x.LogEvent.Contains(search) || x.Message.Contains(search) || x.Exception.Contains(search);
            var logs = await DbContext.Logs
                .WhereIf(!string.IsNullOrEmpty(search), searchCondition)                
                .PageBy(x => x.Id, page, pageSize)
                .ToListAsync();

            pagedList.Data.AddRange(logs);
            pagedList.PageSize = pageSize;
            pagedList.TotalCount = await DbContext.Logs.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();

            return pagedList;
        }
    }
}