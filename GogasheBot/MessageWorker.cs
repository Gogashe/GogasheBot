using System;
using System.IO;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using GogasheBot.TextCommands;

namespace GogasheBot
{
    class MessageWorker
    {
        public void Recieve(Message msg)
        {
            switch (msg.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text :
                    {
                        WorkOnText(msg);
                        break;
                    }
                case Telegram.Bot.Types.Enums.MessageType.Sticker:
                    {
                        WorkOnSticker(msg);
                        break;
                    }
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    {
                        WorkOnPhoto(msg);
                        break;
                    }
                case Telegram.Bot.Types.Enums.MessageType.Video:
                    {
                        WorkOnVideo(msg);
                        break;
                    }
                default:
                    {
                        WorkOnUndefined(msg);
                        break;
                    }
            }
        }

        private void WorkOnText(Message msg)
        {
            string text = $"{msg.Chat.Id} - (@{msg.From.Username}) Wrote:{msg.Text}";
            Console.WriteLine(text);
            Log.RWrite(text);
            string message = msg.Text;
            int i = 0;
            if (msg.Text.Contains("@"))
            {
                for (; i < msg.Text.Length; i++)
                    if (msg.Text[i] == '@')
                        break;
                message = msg.Text.Remove(i);
            }
            switch (message)
            {
                case "/start":
                    {
                        Sender.SendSticker(msg.Chat.Id, "CAACAgIAAxkBAAOEXo9r0tNuH1ydAAGRDrpwNmEvGb0JAAL8AAPr4EsbSu0qiEm1K0wYBA");
                        Sender.SendMessage(msg.Chat.Id, $"Привет, {msg.From.FirstName}!");
                        break;
                    }
                case "/hardbass":
                    {
                        CHardbass hb = new CHardbass();
                        hb.SendHB(msg);
                        break;
                    }
                case "/random":
                    {
                        CRandom cr = new CRandom();
                        cr.SendRandom(msg.ReplyToMessage);
                        break;
                    }
                case "/pasta":
                    {
                        CPasta cp = new CPasta();
                        cp.SendPasta(msg);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if ((msg.Text.Contains("Ты пидор")) || (msg.Text.Contains("ты пидор")))
            {
                Sender.SendMessage(msg.Chat.Id, "А может ты пидор?");
                text = $"Successfully send {msg.From.Id} - (@{msg.From.Username}) text:'А может ты пидор?'";
                Console.WriteLine(text);
                Log.RWrite(text);
            }
            else if ((msg.Text.Contains("тикток")) || (msg.Text.Contains("тик-ток")) || (msg.Text.Contains("Тик-ток")) || (msg.Text.Contains("Тикток")))
            {
                PhrasesSample Tic = new PhrasesSample();
                string tick = Tic.TicToc();
                Sender.SendMessage(msg.Chat.Id, tick);
                text = $"Successfully send {msg.From.Id} - (@{msg.From.Username}) text:{tick}";
                Console.WriteLine(text);
                Log.RWrite(text);
                tick = null;
                Tic.Dispose();
            }
            else if ((msg.Text.StartsWith("Гараж выбери ")) && (msg.Text.Contains("или")))
            {
                text = msg.Text;
                text = text.Remove(0, 13);
                string[] chars = { ",", ".", "?" };
                for (int j = 0; j < chars.Length; j++)
                {
                    text = text.Replace(chars[j], "");
                }
                Sender.SendMessage(msg.Chat.Id, StringsParcer.ReturnWord(text));
            }
        }

        private void WorkOnSticker(Message msg)
        {
            long StickerChatId = Convert.ToInt64(new StreamReader(Directory.GetCurrentDirectory() + @"\Docs\StickerChatId.txt").ReadToEnd());
            Sender.SendSticker(StickerChatId, new InputOnlineFile(msg.Sticker.FileId));
            Sender.SendMessage(StickerChatId, $"Send {msg.From.Id} (@{msg.From.Username})");
            string text = $"{msg.Chat.Id} - (@{msg.From.Username}) Sent sticker:{msg.Sticker.FileId}";
            Console.WriteLine(text);
            Log.RWrite(text);
        }

        private void WorkOnPhoto(Message msg)
        {
            try
            {
                var image = new InputOnlineFile(msg.Photo[2].FileId);
                SendPhoto(image, msg);
            }
            catch (IndexOutOfRangeException)
            {
                try
                {
                    var image = new InputOnlineFile(msg.Photo[1].FileId);
                    SendPhoto(image, msg);
                }
                catch (IndexOutOfRangeException)
                {
                    var image = new InputOnlineFile(msg.Photo[0].FileId);
                    SendPhoto(image, msg);
                }
            }
        }

        private async void WorkOnVideo(Message msg)
        {
            string text = $"{msg.Chat.Id} - (@{msg.From.Username}) Sent video";
            Console.WriteLine(text);
            Log.RWrite(text);
        }

        private void WorkOnUndefined(Message msg)
        {
            Sender.SendMessage(msg.Chat.Id, "Ты че высрал?");
            string text = $"{msg.Chat.Id} - (@{msg.From.Username}) Sent some shit";
            Console.WriteLine(text);
            Log.RWrite(text);
        }

        private void SendPhoto(InputOnlineFile image, Message msg)
        {
            long ImageChatId = Convert.ToInt64(new StreamReader(Directory.GetCurrentDirectory() + @"\Docs\ImageChatId.txt").ReadToEnd());
            Sender.SendPhoto(ImageChatId, image);
            Sender.SendMessage(ImageChatId, $"Send {msg.From.Id} (@{msg.From.Username})");
            string text = $"{msg.Chat.Id} - (@{msg.From.Username}) Sent image";
            Console.WriteLine(text);
            Log.RWrite(text);
        }
    }
}
