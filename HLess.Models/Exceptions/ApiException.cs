using System;
using System.Net;
using System.Runtime.Serialization;

namespace HLess.Models.Exceptions
{
    /// <summary>
    /// Main exception type, handled by middleware.
    /// </summary>
    public class ApiException : Exception
    {
        public HttpStatusCode ErrorCode { get; set; }

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiException(string message, HttpStatusCode code):base(message)
        {
            this.ErrorCode = code;
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
