using System;

namespace GogasheBot
{
    class PhrasesSample : IDisposable
    {
        string[] Saystart = new string[2] { "Опять работа?", "Готов вкалывать" };
        string[] Tictoc = new string[4] { "Начальник, хули вы меня с сумашедшими поселили-то блять?", "Все-таки насрал, мудень", "Начальник, этот мудак опять обосрался", "АААААААААААААААААААААААААААААААААААА" };
        public string SayStart()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return Saystart[(Convert.ToInt64(rand.Next(0, Saystart.Length)) % 2)];
        }
        public string TicToc()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return Tictoc[(Convert.ToInt64(rand.Next(0, Tictoc.Length)) % 4)];
        }
        public void Dispose()
        {
            Saystart = null;
            Tictoc = null;
        }
    }
}
