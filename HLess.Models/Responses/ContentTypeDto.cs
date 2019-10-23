using System;
using System.Collections.Generic;

namespace HLess.Models.Responses
{
    /// <summary>
    /// Model class for content types.
    /// </summary>
    public class ContentTypeDto : BaseDto
    {
        /// <summary>
        /// The fields associated with this content type.
        /// </summary>
        public IEnumerable<ContentFieldDto> Fields { get; set; }

        /// <summary>
        /// Identifier of the site the new content type should belong to.
        /// </summary>
        public Guid? SiteId { get; set; }
    }
}
