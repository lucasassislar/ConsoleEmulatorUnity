using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class Tiro : ObjetoDeJogo
    {
        int dano;
        int casasTiro;
        bool acertou;
        Tela tela;
        Jogador jogador;
        Inimigo inimigo;

        public Tiro(int dano, int casasTiro, Tela tela, Jogador jogador, Inimigo inimigo)
        {
            this.inimigo = inimigo;
            this.jogador = jogador;
            this.tela = tela;
            this.dano = dano;
            this.casasTiro = casasTiro;

            sprite = 'A';
            posX = jogador.posX + 1;
            posY = jogador.posY;

        }

        public override void Update()
        {
            if (acertou)
            {
                return;
            }
            if (posX == inimigo.posX || posX == inimigo.posX + 1 || posX == inimigo.posX + 2 || posX == inimigo.posX + 3 || posX == inimigo.posX + 4)
            {
                if (posY <= inimigo.posY + 1)
                {
                    acertou = true;
                    posY = -10;
                    inimigo.pontosDeVida -= 1;
                }
            }

            else
            {

            }
            posY -= casasTiro;
        }
    }
}
