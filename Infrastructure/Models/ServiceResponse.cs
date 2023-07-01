namespace Infrastructure.Models
{
    public class ServiceResponse
    {
        public bool Status { get; set; } 
        public int HttpStatusCode { get; set; } 
        public dynamic? ResponseData { get; set; }
        public string? ResponseMessage { get; set; }


        public ServiceResponse HandleSuccess<TResponseDto>(int code, TResponseDto responseData = null, string responseMessage=null ) where TResponseDto : class
        {
            Status = true;
            HttpStatusCode = code;
            ResponseData = responseData; 
            ResponseMessage = responseMessage;

            return this;
        }

        public ServiceResponse HandleError(int code, dynamic? responseData, string? responseMessage )
        {
            Status = false;
            HttpStatusCode = code;
            ResponseData = responseData;
            ResponseMessage = string.IsNullOrEmpty(responseMessage) ? "Something went wrong"  : responseMessage;
            return this;
        }

    }
}
