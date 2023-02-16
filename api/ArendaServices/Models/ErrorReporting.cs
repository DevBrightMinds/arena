namespace ArendaServices.Models
{
    public class ErrorReporting
    {
        public bool Error { get; set; }
        public string ErrorDetail { get; set; }
        public dynamic Results { get; set; }
    }

}