namespace Mango.Services.ProductsAPI.Models.Dto
{
    public class ResponseDto
    {
        public string Status { get; set; } = string.Empty;
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = string.Empty;
        public List<string>? ErrorMessage { get; set; }
    }
}
