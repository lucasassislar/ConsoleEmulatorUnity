using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class TelasDeConclusao : ObjetoDeJogo
    {
        Jogo jogo;
        public ObjetoDeJogo textoConclusivo;

        public TelasDeConclusao(Jogo jogo, bool quemVenceu)
        {
            if (quemVenceu == true)
            {
                textoConclusivo = new ObjetoDeJogo("Você Venceu", jogo.telaDoJogo.largura / 2 - 5, jogo.telaDoJogo.altura / 2 - 1, false, new char[] { 'V', 'o', 'c', 'ê', ' ', 'V', 'e', 'n', 'c', 'e', 'u' });
                jogo.objetosDeJogo.Add(textoConclusivo);

            }

            else if (quemVenceu == false)
            {
                textoConclusivo = new ObjetoDeJogo("Game Over", jogo.telaDoJogo.largura / 2 - 4, jogo.telaDoJogo.altura / 2 - 1, false, new char[] { 'G', 'a', 'm', 'e', ' ', 'O', 'v', 'e', 'r' });
                jogo.objetosDeJogo.Add(textoConclusivo);

            }

            else
            {
                return;
            }

        }

    }
}
