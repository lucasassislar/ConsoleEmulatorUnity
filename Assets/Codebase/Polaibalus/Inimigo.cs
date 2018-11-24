using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class Inimigo : ObjetoDeJogo
    {
        Tela tela;
        Jogo jogo;
        Jogador jogador;
        Random random;

        public int tempoEntreTiroInimigo = -100;
        public int tempoEntreMovimentoInimigo = 0;
        public int velocidadeInimigo = 2;
        bool velocidadeRapida = false;
        int mudançaVelocidade = 0;
        int nivelDoInimigo = 1;
        int waveTiro = 0;
        public int pontosDeVida;

        public Inimigo(int pontosDeVida, Jogo jogo, Jogador jogador, Tela tela)
        {
            random = new Random();
            nivelDoInimigo = random.Next(-1, 2);

            if (nivelDoInimigo == 0)
            {
                nivelDoInimigo = 1;
            }
            this.pontosDeVida = pontosDeVida;
            this.jogo = jogo;
            this.tela = tela;
            this.jogador = jogador;
            nome = "Nave Inimiga";
            posX = jogo.telaDoJogo.largura/2;
            posY = 1;
            spriteCompleto = new char[] { '|', '-', 'U', '-', '|' };
        }

        public override void Update()
        {
            tempoEntreMovimentoInimigo += 1;
            tempoEntreTiroInimigo += 10;
            move();

            if (tempoEntreTiroInimigo >= 0)
            {
                waveTiro += 1;
                TiroInimigo tiroInimigo = new TiroInimigo(1, 1, this, jogador);
                jogo.objetosDeJogo.Add(tiroInimigo);

                tempoEntreTiroInimigo = -120;

                if (waveTiro == 6)
                {
                    tempoEntreTiroInimigo = -600;
                    waveTiro = 0;
                }
            }
        }

        public void move()
        {
            if (tempoEntreMovimentoInimigo == velocidadeInimigo)
            {
                mudançaVelocidade += 1;
                tempoEntreMovimentoInimigo = 0;
                posX += nivelDoInimigo;

                if (posX >= 56)
                {
                    nivelDoInimigo = -nivelDoInimigo;
                }

                else if (posX <= 20)
                {
                    nivelDoInimigo = -nivelDoInimigo;
                }

                if (mudançaVelocidade == 20 && velocidadeRapida == false)
                {
                    mudançaVelocidade = 0;
                    velocidadeInimigo = 1;
                    velocidadeRapida = true;
                }

                if (mudançaVelocidade == 10 && velocidadeRapida == true)
                {
                    mudançaVelocidade = 0;
                    velocidadeInimigo = 2;
                    velocidadeRapida = false;
                }
            }

        }
    }
}
