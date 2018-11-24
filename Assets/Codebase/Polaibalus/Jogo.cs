using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Atari_II
{
    class Jogo : Program
    {
        public Tela telaDoJogo;
        Jogador jogador;
        GerenciadorDeInput input;
        Inimigo inimigo;
        ObjetoDeJogo quantidadeDeVida;
        ObjetoDeJogo quantidadeDeVidaInimigo;
        ObjetoDeJogo baseHeroi;
        ObjetoDeJogo vidaInimigo;
        ObjetoDeJogo vidaHeroi;
        Menu menu;
        TelasDeConclusao telasDeConclusao;

        public List<ObjetoDeJogo> objetosDeJogo;
        public int intervaloTiroInimigo = 0;
        public bool rodando = true;
        public bool gameOver;
        bool estaNoJogo;
        bool seAdicionou;
        int resetaJogo;


        public Jogo(int larguraDaTela, int alturaDaTela)
        {
            telaDoJogo = new Tela(larguraDaTela, alturaDaTela);
            objetosDeJogo = new List<ObjetoDeJogo>();
            input = new GerenciadorDeInput();

            ObjetoDeJogo bordasJogo = new ObjetoDeJogo("Borda Esquerda", telaDoJogo.largura / 2 - 21, 0, 17, 43, true, new char[] { 'O', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'O',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|',
                                                                                                                                  'O', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'O'});
            objetosDeJogo.Add(bordasJogo);

            menu = new Menu(this);
            objetosDeJogo.Add(menu);

        }

        public void comecarJogo()
        {
            resetaJogo = 0;
            gameOver = false;
            estaNoJogo = true;

            jogador = new Jogador(5, telaDoJogo, this);
            objetosDeJogo.Add(jogador);


            inimigo = new Inimigo(7, this, jogador, telaDoJogo);
            objetosDeJogo.Add(inimigo);

            jogador.setInimigo(inimigo);

            baseHeroi = new ObjetoDeJogo("Base Herói", telaDoJogo.largura / 2 - 12, 15, false, new char[] { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|' });
            objetosDeJogo.Add(baseHeroi);

            string pontosDeVidaInimigoString = inimigo.pontosDeVida.ToString();

            string pontosDeVidaString = jogador.pontosDeVida.ToString();

            quantidadeDeVidaInimigo = new ObjetoDeJogo("Quantidade de Vidas Inimigo", telaDoJogo.largura / 2, 0, pontosDeVidaInimigoString[0]);
            objetosDeJogo.Add(quantidadeDeVidaInimigo);

            vidaInimigo = new ObjetoDeJogo("Vida Inimigo", quantidadeDeVidaInimigo.posX - 35, 0, false, new char[] { 'V', 'i', 'd', 'a', ' ', 'I', 'n', 'i', 'm', 'i', 'g', 'o' });
            objetosDeJogo.Add(vidaInimigo);


            quantidadeDeVida = new ObjetoDeJogo("Quantidade de Vidas", telaDoJogo.largura / 2, 16, pontosDeVidaString[0]);
            objetosDeJogo.Add(quantidadeDeVida);

            vidaHeroi = new ObjetoDeJogo("Vida Herói", quantidadeDeVida.posX - 33, 16, false, new char[] { 'V', 'i', 'd', 'a', ' ', 'H', 'e', 'r', 'ó', 'i' });
            objetosDeJogo.Add(vidaHeroi);






        }

        public void Update()
        {
            if (estaNoJogo)
            {
                string pontosDeVidaInimigoString = inimigo.pontosDeVida.ToString();
                quantidadeDeVidaInimigo.sprite = pontosDeVidaInimigoString[0];

                string pontosDeVidaString = jogador.pontosDeVida.ToString();
                quantidadeDeVida.sprite = pontosDeVidaString[0];
                intervaloTiroInimigo += 10;
                checaResultado();

            }

            ChecaInput();
            AtualizaObjetoDeJogo();
            Renderiza();
            Thread.Sleep(60);
        }

        public void checaResultado()
        {
            if (gameOver)
            {
                return;
            }

            if (inimigo.pontosDeVida <= 0)
            {

                if (seAdicionou == false)
                {
                    seAdicionou = true;
                    telasDeConclusao = new TelasDeConclusao(this, true);
                    objetosDeJogo.Add(telasDeConclusao);
                    objetosDeJogo.Remove(inimigo);
                    objetosDeJogo.Remove(jogador);
                    objetosDeJogo.Remove(baseHeroi);
                    objetosDeJogo.Remove(quantidadeDeVida);
                    objetosDeJogo.Remove(quantidadeDeVidaInimigo);
                    objetosDeJogo.Remove(vidaHeroi);
                    objetosDeJogo.Remove(vidaInimigo);


                }
                else
                {
                    resetaJogo += 33;
                    if (resetaJogo >= 1200)
                    {
                        gameOver = true;
                        seAdicionou = false;
                        menu.novoMenu();
                        objetosDeJogo.Remove(telasDeConclusao);
                        objetosDeJogo.Remove(telasDeConclusao.textoConclusivo);
                    }
                }

            }

            else if (jogador.pontosDeVida <= 0)
            {
                if (seAdicionou == false)
                {
                    seAdicionou = true;
                    telasDeConclusao = new TelasDeConclusao(this, false);
                    objetosDeJogo.Add(telasDeConclusao);
                    objetosDeJogo.Remove(inimigo);
                    objetosDeJogo.Remove(jogador);
                    objetosDeJogo.Remove(baseHeroi);
                    objetosDeJogo.Remove(quantidadeDeVida);
                    objetosDeJogo.Remove(quantidadeDeVidaInimigo);
                    objetosDeJogo.Remove(vidaHeroi);
                    objetosDeJogo.Remove(vidaInimigo);

                }
                else
                {
                    resetaJogo += 33;
                    if (resetaJogo >= 1200)
                    {
                        gameOver = true;
                        seAdicionou = false;
                        menu.novoMenu();
                        objetosDeJogo.Remove(telasDeConclusao);
                        objetosDeJogo.Remove(telasDeConclusao.textoConclusivo);
                    }
                }

            }
        }

        public void Renderiza()
        {
            telaDoJogo.LimpaTela('\u0020');
            foreach (ObjetoDeJogo objeto in objetosDeJogo)
            {
                telaDoJogo.RenderizaObjetoDejogo(objeto);
            }
            telaDoJogo.Renderizacanvas();

        }

        public void ChecaInput()
        {
            input.ChecaInput();
        }

        public void AtualizaObjetoDeJogo()
        {
            for (int i = 0; i < objetosDeJogo.Count; i++)
            {
                objetosDeJogo[i].Update();
            }
        }

    }
}
