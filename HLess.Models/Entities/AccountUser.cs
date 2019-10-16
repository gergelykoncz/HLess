using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HLess.Models.Entities
{
    /// <summary>
    /// Many-to-many mapping entity between Users and Accounts.
    /// </summary>
    public class AccountUser
    {
        /// <summary>
        /// The user id.
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// The account id.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// The user reference of the join.
        /// </summary>
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        /// <summary>
        /// The account reference of the join.
        /// </summary>
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
