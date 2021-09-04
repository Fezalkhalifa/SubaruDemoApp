using ProjectApi.Models;

namespace ProjectApi.Utilities
{
    public static class ApiHttpUtility
    {

        public static ApiResponse CreateResponse(bool isAuthenticated, MessageType messageType, string message, object responseToReturn, int total = 0)
        {
            ApiResponse response = new ApiResponse();
            response.isAuthenticated = isAuthenticated;
            response.Result = responseToReturn ?? string.Empty;
            response.Message = message;
            response.MessageType = (int)messageType;
            response.Total = total == 0 ? null : total.ToString();
            return response;
        }
    }
}