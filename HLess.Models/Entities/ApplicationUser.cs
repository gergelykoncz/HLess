using HLess.Models.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HLess.Models.Entities
{
    /// <summary>
    /// Class for the application users.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        public bool Deleted { get; set; }

        public virtual ICollection<AccountUser> AccountUsers { get; set; }
    }
}
