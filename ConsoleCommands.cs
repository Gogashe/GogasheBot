using System;

namespace GogasheBot
{
    class ConsoleCommands
    {
        public void Send(string Command)
        {
            switch (StringsParcer.GetCommand(ref Command))
            {
                case "/say":
                    {
                        try
                        {
                            Command_Say(Command);
                        }
                        catch (FormatException)
                        {

                        }
                        break;
                    }
                case "/sticker":
                    {
                        Command_Sticker(Command);
                        break;
                    }
            }
        }
        private void Command_Say(string Command)
        {
            long id = Convert.ToInt64(StringsParcer.GetId(ref Command));
            Sender.SendMessage(id, Command);
            string text = $"Successfully send {id} {Command}";
            Console.WriteLine(text);
            Log.SWrite(text);
            Command = null;
        }
        private void Command_Sticker(string Command)
        {
            long id = Convert.ToInt64(StringsParcer.GetId(ref Command));
            Sender.SendSticker(id, Command);
            string text = $"Successfully send {id} {Command}";
            Console.WriteLine(text);
            Log.SWrite(text);
            Command = null;
        }
    }
}
