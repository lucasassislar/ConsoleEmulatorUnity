using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class Menu : ObjetoDeJogo
    {
        Jogo jogo;
        ObjetoDeJogo tituloDoJogo;
        ObjetoDeJogo novoJogo;
        ObjetoDeJogo sairDoJogo;
        ObjetoDeJogo seta;

        public Menu(Jogo jogo)
        {
            this.jogo = jogo;
            tituloDoJogo = new ObjetoDeJogo("Título do Jogo", jogo.telaDoJogo.largura / 2 - 4, jogo.telaDoJogo.altura / 2 - 3, false, new char[] { 'P', 'o', 'l', 'a', 'i', 'b', 'a', 'l', 'u', 's' });
            jogo.objetosDeJogo.Add(tituloDoJogo);

            novoJogo = new ObjetoDeJogo("Novo Jogo", jogo.telaDoJogo.largura / 2 - 3, (jogo.telaDoJogo.altura / 2) + 1, false, new char[] { 'N', 'o', 'v', 'o', 'J', 'o', 'g', 'o' });
            jogo.objetosDeJogo.Add(novoJogo);

            sairDoJogo = new ObjetoDeJogo("Sair do Jogo", jogo.telaDoJogo.largura / 2 - 1, (jogo.telaDoJogo.altura / 2) + 3, false, new char[] { 'S', 'a', 'i', 'r' });
            jogo.objetosDeJogo.Add(sairDoJogo);

            seta = new ObjetoDeJogo("Seta Seleção", novoJogo.posX - 2, novoJogo.posY, '>');
            jogo.objetosDeJogo.Add(seta);

        }

        public override void Update()
        {
            switch (GerenciadorDeInput.teclaApertada)
            {

                case ConsoleKey.DownArrow:
                    seta.posX = sairDoJogo.posX - 2;
                    seta.posY = sairDoJogo.posY;
                    break;

                case ConsoleKey.UpArrow:
                    seta.posX = novoJogo.posX - 2;
                    seta.posY = novoJogo.posY;
                    break;

                case ConsoleKey.Enter:

                    if (seta.posY == novoJogo.posY)
                    {
                        jogo.comecarJogo();
                        jogo.objetosDeJogo.Remove(novoJogo);
                        jogo.objetosDeJogo.Remove(sairDoJogo);
                        jogo.objetosDeJogo.Remove(tituloDoJogo);
                        jogo.objetosDeJogo.Remove(seta);
                        jogo.objetosDeJogo.Remove(this);

                    }

                    if (seta.posY == sairDoJogo.posY)
                    {
                        jogo.rodando = false;
                    }

                    break;
            }
        }

        public void novoMenu()
        {
            jogo.objetosDeJogo.Add(novoJogo);
            jogo.objetosDeJogo.Add(sairDoJogo);
            jogo.objetosDeJogo.Add(tituloDoJogo);
            jogo.objetosDeJogo.Add(seta);
            jogo.objetosDeJogo.Add(this);
        }
    }
}
