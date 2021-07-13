using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot.Types;

namespace GogasheBot.TextCommands
{
    class CPasta
    {
        public void SendPasta(Message msg)
        {
            try
            {
                string[] Pastas = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Pastes");
                Random rand = new Random((int)DateTime.Now.Ticks);
                string Pasta = Pastas[rand.Next(0, Pastas.Length)];
                StreamReader ReadPasta = new StreamReader(Pasta);
                string RawText = ReadPasta.ReadToEnd();
                ReadPasta.Close();
                List<string> Messages = new List<string>();
                while (true)
                {
                    try
                    {
                        char t = RawText[4097];
                        Messages.Add(RawText.Remove(0, 4096));
                        RawText = RawText.Remove(4096);
                    }
                    catch(IndexOutOfRangeException)
                    {
                        Messages.Add(RawText);
                        break;
                    }
                }
                Messages.Reverse();
                foreach(string i in Messages){
                    Sender.SendMessage(msg, i);
                }

            }
            catch (IOException)
            {

            }
        }

        public bool Exists(char T)
        {
            try
            {
                char t = T;
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}
