using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ChatTelegramBot_re_factoring.Services;

namespace ChatTelegramBot_re_factoring.Bot
{
    public class TelegramBotService
    {
        private readonly TelegramBotClient _botClient;
        private readonly MessageProcessor _processor;

        public TelegramBotService(ConfigService config, TogetherService togetherService)
        {
            _botClient = new TelegramBotClient(config.BotToken);
            _processor = new MessageProcessor(togetherService);
        }
        public async Task StartAsync()
        {
            var me = await _botClient.GetMe();
            Console.WriteLine($"Запущен @{me.Username}");
            _botClient.StartReceiving(UpdateHandler, ErrorHandler);
        }
        private async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken token)
        {
            if (update.Type != UpdateType.Message || update.Message?.Type != MessageType.Text)
                return;
            var message = update.Message;
            await _processor.HandleMessageAsync(bot, message);
        }
        private Task ErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken token)
        {
            Console.WriteLine($"{ex.Message}");
            return Task.CompletedTask;
        }
    }
}
