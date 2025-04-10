namespace CognitusBackend.Application.DTOs.Request
{
    public class GenerateRequest
    {
        public string Message { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
