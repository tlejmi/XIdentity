using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Luttra.XIdentity.EntityFramework.Shared.Entities.Identity;

namespace Luttra.XIdentity.EntityFramework.Shared.Entities.Users
{
    public class Partner : ILuttraUser
    {
      
        public XIdentityUser XIdentityUser { get; set; }

        public Guid XIdentityUserId { get; set; }


    }

    public interface ILuttraUser
    {
        public Guid XIdentityUserId { get; set; }

        public XIdentityUser XIdentityUser { get; set; }

    }
}
