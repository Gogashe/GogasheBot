using System;

namespace GogasheBot
{
    class ConsoleCommands
    {
        public void Send(string Comm)
        {
            long id;
            switch (StringsParcer.GetCommand(ref Comm))
            {
                case "/say" :
                    {
                        try
                        {
                            id = Convert.ToInt64(StringsParcer.GetId(ref Comm));
                            Sender.SendMessage(id, Comm);
                            string text = $"Successfully send {id} {Comm}";
                            Console.WriteLine(text);
                            Log.SWrite(text);
                            Comm = null;
                        }
                        catch (FormatException)
                        {

                        }
                        break;
                    }
                case "/sticker":
                    {
                        id = Convert.ToInt64(StringsParcer.GetId(ref Comm));
                        Sender.SendSticker(id, Comm);
                        string text = $"Successfully send {id} {Comm}";
                        Console.WriteLine(text);
                        Log.SWrite(text);
                        Comm = null;
                        break;
                    }
            }
        }

    }
}
