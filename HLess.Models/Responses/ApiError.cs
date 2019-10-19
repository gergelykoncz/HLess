namespace HLess.Models.Responses
{
    /// <summary>
    /// The generic error response of the API.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// The relevant HTTP status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The message (if any).
        /// </summary>
        public string Message { get; set; }
    }
}
