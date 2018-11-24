using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class TiroInimigo : ObjetoDeJogo
    {
        int dano;
        int casasTiro;
        Inimigo inimigo;
        Jogador jogador;

        public TiroInimigo(int dano, int casasTiro, Inimigo inimigo, Jogador jogador)
        {
            this.jogador = jogador;
            this.inimigo = inimigo;
            this.dano = dano;
            this.casasTiro = casasTiro;
            sprite = 'V';
            posX = inimigo.posX + 2;
            posY = inimigo.posY;

        }

        public override void Update()
        {

            if (posX == jogador.posX || posX == jogador.posX + 1 || posX == jogador.posX + 2)
            {
                if (posY == jogador.posY - 1)
                {
                    if (jogador.pontosDeVida < 5)
                    {
                        jogador.pontosDeVida += 1;

                    }

                    posY = 20;

                }
            }

            else if (posX >= 28 && posX <= 52)
            {
                if (posY == jogador.posY + 1)
                {
                    jogador.pontosDeVida -= 1;

                    if (inimigo.pontosDeVida < 8)
                    {
                        inimigo.pontosDeVida += 1;
                    }
                }
            }


            posY += casasTiro;

        }

    }
}
