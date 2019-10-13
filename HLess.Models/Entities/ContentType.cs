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
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Slug { get; set; }
        
        public Guid OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }

        public virtual ICollection<ContentField> Fields { get; set; }
    }
}
