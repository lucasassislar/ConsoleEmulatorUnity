using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class Tela
    {

        public char[,] canvas;
        public int altura;
        public int largura;
        public string buffer;
        public int posicaoArray = 0;

        public Tela(int larguraDaTela, int alturaDaTela)
        {
            canvas = new char[larguraDaTela, alturaDaTela];
            largura = larguraDaTela;
            altura = alturaDaTela;
        }

        public void RenderizaObjetoDejogo(ObjetoDeJogo objetoParaRenderizar)
        {
            if (objetoParaRenderizar.posY < 0)
            {
                return;
            }

            if (objetoParaRenderizar.posY > 15 && objetoParaRenderizar.spriteCompleto == null && objetoParaRenderizar.nome != "Quantidade de Vidas")
            {
                return;
            }


            if (objetoParaRenderizar.spriteCompleto == null)
            {
                canvas[objetoParaRenderizar.posX, objetoParaRenderizar.posY] = objetoParaRenderizar.sprite;
            }


            else if (objetoParaRenderizar.eBordaDoJogo == false)
            {
                for (int i = 0; i < objetoParaRenderizar.spriteCompleto.Length; i++)
                {
                    canvas[objetoParaRenderizar.posX + i, objetoParaRenderizar.posY] = objetoParaRenderizar.spriteCompleto[i];
                }
            }

            if (objetoParaRenderizar.eBordaDoJogo == true)
            {
                buffer = string.Empty;
                objetoParaRenderizar.posY = 0;
                for (int y = 0; y < objetoParaRenderizar.altura; y++)
                {
                    for (int x = 0; x < objetoParaRenderizar.largura; x++)
                    {
                        canvas[objetoParaRenderizar.posX + x, objetoParaRenderizar.posY] = objetoParaRenderizar.spriteCompleto[posicaoArray];
                        posicaoArray += 1;
                    }

                    objetoParaRenderizar.posY += 1;
                }
                posicaoArray = 0;
            }


        }

        public void Renderizacanvas()
        {
#if UNITY
            ConsoleU.Clear();
#else
            Console.Clear();
#endif
            buffer = string.Empty;
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    buffer += canvas[x, y];
                }

                buffer += "\n";
            }
            Console.Write(buffer);

        }

        public void LimpaTela(char charLimpo)
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    canvas[x, y] = charLimpo;
                }
            }
        }
    }
}
