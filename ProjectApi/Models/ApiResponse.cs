using System.Runtime.Serialization;

namespace ProjectApi.Models
{
    #region ApiResponse Class
    /// <summary>
    /// ApiResponse class which hold the all required information about result 
    /// </summary>
    [DataContract]
    public class ApiResponse
    {
        //To get and set weather user authenicated or not future perspective
        [DataMember]
        internal bool isAuthenticated { get; set; }
        //To get and set the returning object from api
        [DataMember]
        internal object Result { get; set; }
        //To get and set the message along withe message type 
        [DataMember]
        internal string Message { get; set; }
        //To get and set the total count of data which object holds
        //use when large data in tables and pagination
        [DataMember(EmitDefaultValue = false)]
        internal string Total { get; set; }
        //To get and set the status of response
        [DataMember]
        internal int MessageType { get; set; }
    }
    #endregion
}