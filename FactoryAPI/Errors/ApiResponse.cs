namespace FactoryAPI.Errors
{
    /// <summary>
    /// This is just custom class that I set up for default messeges when I return Http status codes
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Custom Status Api Response
        /// </summary>
        /// <param name="statusCode">What status code is it</param>
        /// <param name="message">Default messege is shown of specifed in function</param>
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }


        public int StatusCode { get; set; }
        public string? Message { get; set; }


        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Opps! 404 Error Not Found",
                500 => "500 Internal server error",
                _ => null
            };
        }
    }
}
