using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class Jogador : ObjetoDeJogo
    {
        Tela tela;
        Tiro tiroHeroi;
        Jogo jogo;
        Inimigo inimigo;
        public int pontosDeVida;

        public Jogador(int pontosDeVida, Tela tela, Jogo jogo)
        {
            
            this.jogo = jogo;
            this.tela = tela;
            this.pontosDeVida = pontosDeVida;
            nome = "Jogador";
            posX = tela.largura / 2 - 1;
            posY = 14;
            spriteCompleto = new char[] { '-', '^', '-' };
        }
        public void setInimigo(Inimigo inimigo)
        {
            this.inimigo = inimigo;
        } 
        public Jogador()
        {
            nome = "Jogador";
            posX = tela.largura / 2 - 1;
            posY = 14;
            sprite = 'Ô';
        }
        public override void Update()
        {
            LeInput();
        }
        public void LeInput()
        {

            switch (GerenciadorDeInput.teclaApertada) 
            {
                case ConsoleKey.LeftArrow:
                    Move(-2);
                    break;

                case ConsoleKey.RightArrow:
                    Move(+2);
                    break;

                case ConsoleKey.Spacebar:

                    if (pontosDeVida > 1)
                    {
                        tiroHeroi = new Tiro(1, 2, tela, this, inimigo);
                        jogo.objetosDeJogo.Add(tiroHeroi);
                        pontosDeVida--;
                        break;
                    }
                    else
                    {
                        break;
                    }

            }

        }
        public void Move(int deltaX)
        {
            posX += deltaX;

            if (posX > 58)
            {
                posX = 20;
            }
            else if (posX < 20)
            {
                posX = 58;
            }
        }
    }
}
