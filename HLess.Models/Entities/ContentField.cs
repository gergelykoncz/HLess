using HLess.Models.Entities.Base;
using HLess.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HLess.Models.Entities
{
    /// <summary>
    /// Represents a field in a content type
    /// </summary>
    public class ContentField : BaseEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Slug { get; set; }

        [Required]
        public ContentFieldType FieldType { get; set; }
    }
}
