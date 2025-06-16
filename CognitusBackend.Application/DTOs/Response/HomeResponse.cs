namespace CognitusBackend.Application.DTOs.Response
{
    public class HomeResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public List<string> LastSearch { get; set; } = new List<string>();

        public HomeResponse(string name, string message ,List<string> lastsearch)
        {
            Name = name;
            Message = message;
            LastSearch = lastsearch;
        }
    }
}
