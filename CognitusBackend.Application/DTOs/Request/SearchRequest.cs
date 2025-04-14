namespace CognitusBackend.Application.DTOs.Request
{
    public class SearchRequest
    {
        public Guid Id { get; set; }
        public string token {  get; set; } = string.Empty;
        public string LastSearch { get; set; } = string.Empty;
    }
}
