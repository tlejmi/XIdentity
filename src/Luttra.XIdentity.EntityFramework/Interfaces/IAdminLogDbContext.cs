using Luttra.XIdentity.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Luttra.XIdentity.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
