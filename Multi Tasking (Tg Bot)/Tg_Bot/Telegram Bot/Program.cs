using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Telegram_Bot
{
	internal class Program
	{
         static TelegramBotClient bot= new TelegramBotClient("7344686743:AAEJOYdh7z7ub2wTrzZkwkjV3H_X-ZHWpxo");
		static void Main(string[] args)
		{
			ReceiverOptions options = new ReceiverOptions()
			{
				AllowedUpdates = new Telegram.Bot.Types.Enums.UpdateType[]
				{
				   Telegram.Bot.Types.Enums.UpdateType.Message,
				   Telegram.Bot.Types.Enums.UpdateType.EditedMessage,
				   
				}
			};
			bot.StartReceiving(UpdateHandler,ErrorHandler, options);
			Console.ReadLine();
		}

		private static async Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		private static async Task UpdateHandler(ITelegramBotClient botclient, Update update, CancellationToken token)
		{
			long chatId =update .Message.Chat.Id;
			string username = update.Message.Chat.Username;
			string firstname= update.Message.Chat.FirstName;
			string lastname= update.Message.Chat.LastName;
			await botclient.SendTextMessageAsync(chatId, "salam, men basqa soz bilmirem");
		}
	}
}
