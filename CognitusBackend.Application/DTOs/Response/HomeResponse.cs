namespace CognitusBackend.Application.DTOs.Response
{
    public class HomeResponse
    {
        public string Name { get; set; } = string.Empty;
        public string LastSearch { get; set; } = string.Empty;

        public HomeResponse(string name, string lastsearch)
        {
            Name = name;
            LastSearch = lastsearch;
        }
    }
}
