namespace HLess.Models.Enums
{
    /// <summary>
    /// Enum representing types for content fields.
    /// </summary>
    public enum ContentFieldType
    {
        /// <summary>
        /// Short text
        /// </summary>
        ShortText,

        /// <summary>
        /// Long text
        /// </summary>
        LongText,

        /// <summary>
        /// HTML (WYSIWYG editor)
        /// </summary>
        HTML,

        /// <summary>
        /// Date/time
        /// </summary>
        Date,

        /// <summary>
        /// Dropdown with pre-defined values
        /// </summary>
        Dropdown,

        /// <summary>
        /// Checkbox for boolean values
        /// </summary>
        Checkbox,

        /// <summary>
        /// Number
        /// </summary>
        Number,

        /// <summary>
        /// Media (image, video, etc.), mostly a link
        /// </summary>
        Media,

        /// <summary>
        /// Reference to another content type
        /// </summary>
        Reference
    }
}
