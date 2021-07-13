using System;

namespace GogasheBot
{
    class StringsParcer
    {
        public static string ReturnWord(string text)
        {
            string[] words = new string[text.Length / 6];
            byte WordNum = 0;

            for (int i = 0; i < text.Length - 4; i++)
            {
                if (text[i] == ' ' && text[i + 1] == 'и' && text[i + 2] == 'л' && text[i + 3] == 'и' && text[i + 4] == ' ')
                {
                    WordNum++;
                }
            }
            for (int j = 0; j < WordNum; j++)
            {
                for (int i = 0; i < text.Length - 4; i++)
                {
                    if (text[i] == ' ' && text[i + 1] == 'и' && text[i + 2] == 'л' && text[i + 3] == 'и' && text[i + 4] == ' ')
                    {
                        words[j] = text.Remove(i, text.Length - i);
                        text = text.Remove(0, i + 5);
                        break;
                    }
                }
            }
            words[WordNum] = text;
            Random rand = new Random((int)DateTime.Now.Ticks);
            int word = rand.Next(1, WordNum+2);
            return words[word-1];
        }

        public static string CutWords(string text)
        {
            int wnum = 0;
            string[] Words = new string[text.Length / 2];
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    Words[wnum] = text.Remove(i, text.Length - i);
                    text = text.Remove(0, i + 1);
                    i = 0;
                    wnum++;
                }
            }
            wnum++;
            Words[wnum - 1] = text;
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < wnum; i++)
            {
                string buf;
                int t = rand.Next(0, wnum - 1);
                buf = Words[i];
                Words[i] = Words[t];
                Words[t] = buf;
            }
            string mes = "";
            for (int i = 0; i < wnum - 1; i++)
            {
                mes += Words[i] + " ";
            }
            mes += Words[wnum - 1];
            return mes;
        }

        public static string GetCommand(ref string Comm)
        {
            try
            {
                int i = 0;
                for (; i < Comm.Length; i++)
                {
                    if (Comm[i] == ' ')
                    {
                        break;
                    }
                }
                string Command = Comm.Remove(i);
                Comm = Comm.Remove(0, i + 1);
                return Command;
            }
            catch (ArgumentOutOfRangeException)
            {
                return "";
            }
        }

        public static string GetId(ref string Comm)
        {
            try
            {
                int i = 0;
                for (; i < Comm.Length; i++)
                {
                    if (Comm[i] == ' ')
                    {
                        break;
                    }
                }
                string Command = Comm.Remove(i);
                Comm = Comm.Remove(0, i + 1);
                return Command;
            }
            catch (ArgumentOutOfRangeException)
            {
                return "";
            }
        }
    }
}
