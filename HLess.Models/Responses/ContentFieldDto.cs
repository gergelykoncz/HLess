using HLess.Models.Enums;

namespace HLess.Models.Responses
{
    /// <summary>
    /// Model representing a field in a content type.
    /// </summary>
    public class ContentFieldDto : BaseDto
    {
        /// <summary>
        /// The type of the field.
        /// </summary>
        public ContentFieldType FieldType { get; set; }
    }
}
