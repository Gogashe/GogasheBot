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
                while (RawText.Length > 4096)
                {
                    try
                    {
                        Sender.SendMessage(msg, new string(RawText.Remove(4096)));
                        RawText = RawText.Remove(0, 4096);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }

                Sender.SendMessage(msg, RawText);

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
