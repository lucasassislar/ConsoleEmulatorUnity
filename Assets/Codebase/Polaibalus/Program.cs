using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class Program
    {
        public static void Main(string[] args)
        {
#if !UNITY
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
#endif
            Jogo meuJogo = new Jogo(80,18);

            while (meuJogo.rodando)
            {
                meuJogo.Update();
            }
        }
    }
}
