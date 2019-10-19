using HLess.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HLess.Models.Entities
{
    /// <summary>
    /// Entity representing an environment/site.
    /// </summary>
    public class Site : BaseEntity
    {
        /// <summary>
        /// The name of the site.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The owning account of the site.
        /// </summary>
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        /// <summary>
        /// The owning account's id.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Flag indicating that the site is the
        /// default for the account.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// The list of content types belonging to the site.
        /// </summary>
        [InverseProperty("Site")]
        public ICollection<ContentType> ContentTypes { get; set; }
    }
}
