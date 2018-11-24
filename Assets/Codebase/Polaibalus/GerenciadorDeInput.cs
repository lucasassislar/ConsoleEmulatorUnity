using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Atari_II
{
    class GerenciadorDeInput
    {
        public static ConsoleKey teclaApertada;

        public void ChecaInput()
        {
#if UNITY
            if (ConsoleU.KeyAvailable) 
            {
                teclaApertada = ConsoleU.ReadKey(true);
            }
#else
            if (Console.KeyAvailable)
            {
                teclaApertada = Console.ReadKey(true).Key;
            }
#endif
            else
            {
                teclaApertada = 0;
            }
        }
    }
}
