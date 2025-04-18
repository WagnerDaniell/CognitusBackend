using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CognitusBackend.Application.DTOs.Request;

public class OpenRouterService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://openrouter.ai/api/v1/chat/completions";
    private const string ApiKey = "";

    public OpenRouterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateTextAsync(GenerateRequest prompt)
    {
        var requestBody = new
        {
            model = "meta-llama/llama-4-scout:free", //deepseek/deepseek-chat-v3-0324:free
            messages = new[]
            {
                new { role = "system", content = "Você é um assistente útil que responde apenas em formato JSON. Retorne uma *array de objetos*, onde cada objeto representa uma questão com a seguinte estrutura:"
                + "\n\n- id: identificador único da questão" 
                + "\n- pergunta: texto da pergunta" 
                + "\n- alternativas: objeto com opções 'a', 'b', 'c' e 'd'" 
                + "\n- correta: letra da alternativa correta (\"a\", \"b\", \"c\" ou \"d\")\n- tema: tema da questão"},
                new { role = "user", content = $"Gerar 10 questões de múltipla escolha no formato descrito, com o tema: {prompt.Message}"}
            },
            max_tokens = 2000
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost:5117");
        _httpClient.DefaultRequestHeaders.Add("X-Title", "Minha API .NET");

        var response = await _httpClient.PostAsync(ApiUrl, jsonContent);
        var responseString = await response.Content.ReadAsStringAsync();

        var stringClear = responseString
            .Replace("```json", "")
            .Replace("```", "")
            .Trim();

        var doc = JsonDocument.Parse(stringClear);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "Error em obter a resposta!";

    }
}
