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
                string[] Pastas = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/Pastes");
                Random rand = new Random((int)DateTime.Now.Ticks);
                string Pasta = Pastas[rand.Next(0, Pastas.Length)];
                StreamReader ReadPasta = new StreamReader(Pasta);
                string RawText = ReadPasta.ReadToEnd();
                ReadPasta.Close();
                List<string> Frames = new List<string>();
                while (RawText.Length > 4096)
                {
                    try
                    {
                        int i = 4095;
                        while (RawText[i]!=' ')
                        {
                            i--;
                        }
                        Frames.Add(RawText.Remove(i));
                        RawText = RawText.Remove(0,i);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }
                Frames.Add(RawText);
                Sender.SendMessage(msg, Frames);
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
