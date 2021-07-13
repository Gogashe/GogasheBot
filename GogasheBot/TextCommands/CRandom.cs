using System;
using Telegram.Bot.Types;

namespace GogasheBot.TextCommands
{
    class CRandom
    {
        public void SendRandom(Message msg)
        {
            try
            {
                Sender.SendMessage(msg, StringsParcer.CutWords(msg.Text));
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
