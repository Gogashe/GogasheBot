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
                string[] Pastas = new string[31];
                Pastas = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Pastes");
                Random rand = new Random((int)DateTime.Now.Ticks);
                string Pasta = Pastas[rand.Next(0, Pastas.Length)];
                StreamReader ReadPasta = new StreamReader(Pasta);
                string RawText = ReadPasta.ReadToEnd();
                ReadPasta.Close();
                List<string> Messages = new List<string>();
                try
                {
                    while (Exists(RawText[4096]))
                    {
                        Messages.Add(RawText.Remove(0, 4095));
                        RawText = RawText.Remove(4096);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Messages.Add(RawText);
                }
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
