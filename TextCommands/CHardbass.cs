using System;
using System.IO;
using Telegram.Bot.Types;

namespace GogasheBot.TextCommands
{
    class CHardbass
    {
        public void SendHB(Message msg)
        {
            string[] HB = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/Hardbass");
            Random rand = new Random((int)DateTime.Now.Ticks);
            string Song = HB[rand.Next(0, HB.Length)];
            try
            {
                Sender.SendMessage(msg, new FileStream(Song, FileMode.Open));
            }
            catch (IOException)
            {
            }
            string text = $"Successfully send {msg.From.Id} - (@{msg.From.Username}) song:'{Song}'";
            Console.WriteLine(text);
            Log.SWrite(text);
        }
    }
}
