namespace CognitusBackend.Application.DTOs.Request
{
    public class GenerateRequest
    {
        public string Token { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
