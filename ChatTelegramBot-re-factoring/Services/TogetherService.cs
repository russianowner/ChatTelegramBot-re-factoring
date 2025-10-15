using System.Text;
using System.Text.Json;
using ChatTelegramBot_re_factoring.Bot;

namespace ChatTelegramBot_re_factoring.Services
{
    public class TogetherService
    {
        private readonly ConfigService _config;

        public TogetherService(ConfigService config)
        {
            _config = config;
        }
        public async Task<string?> GetReplyAsync(string userMessage)
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config.TogetherApiKey}");
            var payload = new
            {
                model = _config.Model,
                messages = new[]
                {
                    new { role = "user", content = userMessage }
                },
                temperature = _config.Temperature,
                max_tokens = _config.MaxTokens
            };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await http.PostAsync("https://api.together.xyz/v1/chat/completions", content);
                var body = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                using var doc = JsonDocument.Parse(body);
                return doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }
    }
}
