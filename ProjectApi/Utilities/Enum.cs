namespace ProjectApi.Utilities
{
    #region MessageType Enum
    /// <summary>
    /// Type Of Message which is used to report the status of api call to identify 
    /// </summary>
    public enum MessageType
    {
        //Retuns if have error
        Error = 0,
        //Return as a success
        Success = 1,
        //Return as a warning
        Warning = 2,
        //Return as a information 
        Information = 3,
        //Return as a NotFound 
        NotFound = 4
    }
    #endregion
}