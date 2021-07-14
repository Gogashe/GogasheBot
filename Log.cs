using System;
using System.IO;

namespace GogasheBot
{
    class Log
    {
        /// <summary>
        /// Пишет лог исходящих сообщений
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        public static void SWrite(string text)
        {
            StreamWriter SentStream = new StreamWriter("sendlogs.txt", true);
            SentStream.WriteLine($"[{DateTime.Now}] " + text);
            SentStream.Close();
        }
        /// <summary>
        /// Пишет лог полученных сообщений
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        public static void RWrite(string text)
        {
            StreamWriter RecieveStream = new StreamWriter("recievedlogs.txt", true);
            RecieveStream.WriteLine($"[{DateTime.Now}] " + text);
            RecieveStream.Close();
        }
    }
}
