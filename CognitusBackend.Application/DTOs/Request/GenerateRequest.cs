namespace CognitusBackend.Application.DTOs.Request
{
    public class GenerateRequest
    {
        public required string Token { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
