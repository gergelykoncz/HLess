using HLess.Models.Entities.Base;
using System.Collections.Generic;

namespace HLess.Models.Entities
{
    /// <summary>
    /// Entity representing an account (company)
    /// </summary>
    public class Account : BaseEntity
    {
        /// <summary>
        /// The name of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The users belonging to the account.
        /// </summary>
        public ICollection<AccountUser> AccountUsers { get; set; }
    }
}
