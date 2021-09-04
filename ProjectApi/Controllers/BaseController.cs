namespace ProjectApi.Controllers
{
    #region Namespace
    using ProjectApi.Utilities;
    using ProjectApi.Models;
    using System.Web.Http;
    #endregion

    #region BaseController class and Methods
    /// <summary>
    /// Base Controller
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// create response for request
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <param name="responseToReturn"></param>
        /// <param name="totalRecord"></param>
        /// <returns></returns>
        internal ApiResponse Response(MessageType messageType, string message = "", object responseToReturn = null, int totalRecord = 0)
        {
            return ApiHttpUtility.CreateResponse(isAuthenticated: true, messageType: messageType, message: message, responseToReturn: responseToReturn, total: totalRecord);
        }
    }
    #endregion
}
