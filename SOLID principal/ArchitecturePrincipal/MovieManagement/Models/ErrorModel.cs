namespace MovieManagement.Models
{
    public class ErrorModel
    {
        public int code { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public string RequestId { get; set; }
        public string traceId { get; set; }
        public string HelpUrl { get; set; }



    }
}
