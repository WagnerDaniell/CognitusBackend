using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CognitusBackend.Application.DTOs.Response
{
    public class AuthResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }

        public AuthResponse(string message, string token)
        {
            Message = message;
            Token = token;
        }
    }
}
