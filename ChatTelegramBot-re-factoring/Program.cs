using ChatTelegramBot_re_factoring.Bot;
using ChatTelegramBot_re_factoring.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        var configService = new ConfigService(config);
        var togetherService = new TogetherService(configService);
        var botService = new TelegramBotService(configService, togetherService);
        await botService.StartAsync();
        Console.ReadLine();
    }
}
