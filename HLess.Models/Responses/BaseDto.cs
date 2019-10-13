using System;

namespace HLess.Models.Responses
{
    public abstract class BaseDto
    {
        /// <summary>
        /// The Id of the resource.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user-friendly name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The API slug of the resource.
        /// </summary>
        public string Slug { get; set; }
    }
}
