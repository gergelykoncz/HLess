using HLess.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HLess.Models.Entities
{
    /// <summary>
    /// Represents a user-created content type.
    /// </summary>
    public class ContentType : BaseEntity
    {
        /// <summary>
        /// The name of the content type.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// The slug of the content type.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Slug { get; set; }
        
        /// <summary>
        /// The optional site id of the content type,
        /// if belonging to a specific site.
        /// </summary>
        public Guid? SiteId { get; set; }

        /// <summary>
        /// The site reference.
        /// </summary>
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        /// <summary>
        /// The fields configured for the content type.
        /// </summary>
        public virtual ICollection<ContentField> Fields { get; set; }
    }
}
