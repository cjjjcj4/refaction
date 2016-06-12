using System.Net.Http;

namespace refactor_me.Utilities
{
    public static class HttpResponseFactory
    {
        public static HttpResponseMessage ConstructResponse(System.Net.HttpStatusCode status, string errMessage)
        {
            var response = new HttpResponseMessage(status)
            {
                Content = new StringContent(errMessage, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = status
            };

            return response;
        }
    }
}