using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace GogasheBot
{
    static class Sender
    {
        private static readonly ITelegramBotClient botClient = new TelegramBotClient(new StreamReader(Directory.GetCurrentDirectory() + @"\Docs\Token.txt").ReadToEnd());

        public static void SendMessage(long ChatId, string text)
        {
            botClient.SendTextMessageAsync(ChatId, text);
        }

        public static void SendMessage(Message msg, string text)
        {
            botClient.SendTextMessageAsync(msg.Chat.Id, text);
        }

        public static void SendMessage(Message msg, FileStream fs)
        {
            botClient.SendAudioAsync(msg.Chat.Id, fs);
        }

        public static void SendSticker(long ChatId, string StickerId)
        {
            botClient.SendStickerAsync(ChatId, StickerId);
        }

        public static void SendSticker(long ChatId, InputOnlineFile Sticker)
        {
            botClient.SendStickerAsync(ChatId, Sticker);
        }

        public static void SendPhoto(long ChatId, InputOnlineFile image)
        {
            botClient.SendPhotoAsync(ChatId, image);
        }
    }
}
