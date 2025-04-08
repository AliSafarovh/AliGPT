using OpenAI_API;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Ali_GPT_bot_
{
	internal class Program
	{

		static TelegramBotClient Bot= new TelegramBotClient	("7344686743:AAEJOYdh7z7ub2wTrzZkwkjV3H_X-ZHWpxo");
		static async Task Main(string[] args)
		{
			var receiverOptions = new ReceiverOptions()
			{
				AllowedUpdates = new UpdateType[]
			   {
					UpdateType.Message,
				    UpdateType.ChatMember,   
                    UpdateType.MyChatMember
			   }
			};
			Bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);
			Console.ReadLine();
			#region testgpt
			//await Console.Out.WriteLineAsync("Sual üçün 1 düyməsini seçin \nÇıxış üçün 0 düyməsini seçin");

			//int choose = int.Parse(Console.ReadLine());

			//while (choose != 0)
			//{
			//	switch (choose)
			//	{
			//		case 1:
			//			await Console.Out.WriteLineAsync("Sualınızı daxil edin:");
			//			string question = Console.ReadLine();

			//			try
			//			{
			//				// ChatGPT-yə sualı göndəririk və cavabı alırıq
			//				var completion = await openAi.Completions.CreateCompletionAsync(question, temperature: 1, max_tokens: 300);
			//				string response = completion.Completions[0].Text.Trim();
			//				await Console.Out.WriteLineAsync(response);
			//			}
			//			catch (Exception ex)
			//			{
			//				await Console.Out.WriteLineAsync("Xəta baş verdi: " + ex.Message);
			//			}

			//			break; // `break` burada olmalıdır ki, `case 1` blokunu düzgün tamamlasın

			//		default:
			//			await Console.Out.WriteLineAsync("Yanlış seçim!");
			//			break;
			//	}

			// Yeni seçim istəyirik
			//	await Console.Out.WriteLineAsync("Sual üçün 1 düyməsini seçin \nÇıxış üçün 0 düyməsini seçin");
			// choose = int.Parse(Console.ReadLine());
			//}

			#endregion
		}
		private static async Task ErrorHandler(ITelegramBotClient bot, Exception error, CancellationToken token)
		{
			await Console.Out.WriteLineAsync(error.Message);
		}

		private async static Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken token)
		{
			if (update.Type == UpdateType.Message && update.Message != null)
			{
				// Yalnız mətn mesajlarını qəbul etmək üçün
				if (update.Message.Type == MessageType.Text)
				{
					string userName = update.Message.Chat.Username;
					string textMessage = update.Message.Text;
					string response = await SendResponse(textMessage);
					long chatId = update.Message.Chat.Id;

					// Mesajın hansı növ çatdan gəldiyini yoxla
					if (update.Message.Chat.Type == ChatType.Group || update.Message.Chat.Type == ChatType.Supergroup)
					{
						// Qrup mesajıdırsa
						await bot.SendTextMessageAsync(chatId, $"Qrupdakı mesaj: {response}");
					}
					else if (update.Message.Chat.Type == ChatType.Private)
					{
						// Şəxsi mesajdırsa
						await bot.SendTextMessageAsync(chatId, $"Şəxsi mesaj: {response}");
					}
				}
			}
		}


		private static async Task<string> SendResponse(string question)
		{
			try
			{
                var openAi = new OpenAIAPI(Key.Token);

                var compilation = await openAi.Completions.CreateCompletionAsync(question, temperature: 0, max_tokens: 500);
				string response = compilation.Completions[0].Text;
				return response;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

		}
	}
}
