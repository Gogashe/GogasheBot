using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;

namespace GogasheBot
{
    class Program
    {
        private static readonly ITelegramBotClient botClient = new TelegramBotClient(new StreamReader(Directory.GetCurrentDirectory() + @"\Docs\Token.txt").ReadToEnd());

        static void Main(string[] args)
        {
            botClient.OnMessage += Bot_OnMessage;
            var me = botClient.GetMeAsync().Result;
            Console.Title = me.Username;
            botClient.StartReceiving();
            PhrasesSample BeginWork = new PhrasesSample();
            Sender.SendMessage(457957611, BeginWork.SayStart());
            ConsoleCommands console = new ConsoleCommands();
            while (true)
            {
                string Comm = Console.ReadLine();
                console.Send(Comm);
            }
        }


        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            MessageWorker Work = new MessageWorker();
            Work.Recieve(msg);
        }
    }
}
