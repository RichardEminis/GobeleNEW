using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;

namespace GobeleNEW
{
    public class TGbot
    {
        ITelegramBotClient _bot;

        public TGbot ()
        {
            string token = @"5949583454:AAFlr-rcBB0BxcKCfZflphAEBHT2w8Ej33w";
            _bot = new TelegramBotClient(token);

            Console.WriteLine("Запущен бот " + _bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };

            _bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );  
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(update.Message.Chat.FirstName + " " + update.Message.Chat.LastName);
            if (update.Message.Text is not null)
            {
                Console.WriteLine(update.Message.Text);
                if (update.Message.Text.ToLower() == "/start")
                {
                    _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Скажи что-нибудь ( ͡❛ . ͡❛)");
                }
                else
                {
                    _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Я люблю {update.Message.Text}, а больше всего тебя (ɔ˘ ³(ˆ‿ˆc)");
                }
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
