namespace CognitusBackend.Application.DTOs.Request
{
    public class SearchRequest
    {
        public Guid UserId { get; set; }
        public string LastSearch { get; set; } = string.Empty;
    }
}
