using Microsoft.Extensions.Configuration;

namespace ChatTelegramBot_re_factoring.Bot
{
    public class ConfigService
    {
        private readonly IConfiguration _config;

        public ConfigService(IConfiguration config)
        {
            _config = config;
        }
        public string BotToken => _config["Telegram:BotToken"] ?? throw new Exception("нет бота токена");
        public string TogetherApiKey => _config["Together:ApiKey"] ?? throw new Exception("нету апи кея");
        public string Model => _config["Together:Model"] ?? "другая модель";
        public double Temperature => double.TryParse(_config["Together:Temperature"], out var t) ? t : 0.8;
        public int MaxTokens => int.TryParse(_config["Together:MaxTokens"], out var m) ? m : 1000;
    }
}
