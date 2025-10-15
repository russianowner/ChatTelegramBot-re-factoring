using Telegram.Bot;
using Telegram.Bot.Types;
using ChatTelegramBot_re_factoring.Services;

namespace ChatTelegramBot_re_factoring.Bot
{
    public class MessageProcessor
    {
        private readonly TogetherService _togetherService;

        public MessageProcessor(TogetherService togetherService)
        {
            _togetherService = togetherService;
        }
        public async Task HandleMessageAsync(ITelegramBotClient bot, Message message)
        {
            var chatId = message.Chat.Id;
            var text = message.Text?.Trim();
            if (string.IsNullOrEmpty(text)) return;
            if (text == "/start")
            {
                await bot.SendMessage(chatId, "Напиши что нибудь😶");
                return;
            }
            string reply = await _togetherService.GetReplyAsync(text) ?? "Не могу ответить 😶";
            await bot.SendMessage(chatId, reply);
        }
    }
}
