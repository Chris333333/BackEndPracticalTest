namespace FactoryAPI.Errors
{
    /// <summary>
    /// Just a extended DTO for 500 Server Error and Exception Middleware
    /// </summary>
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string? Details { get; set; }
    }
}
