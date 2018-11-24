using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atari_II
{
    class ObjetoDeJogo
    {
        public string nome;
        public int posX;
        public int posY;
        public int altura;
        public int largura;
        public char sprite;
        public char[] spriteCompleto;
        public bool eBordaDoJogo;


        public ObjetoDeJogo()
        {

        }

        public ObjetoDeJogo (string nome, int posX, int posY, char sprite)
        {
            this.nome = nome;
            this.posX = posX;
            this.posY = posY;
            this.sprite = sprite;

        }

        

        public virtual void Update()
        {
           
        }

        public ObjetoDeJogo (string nome, int posX, int posY, bool eBordaDoJogo, char[] spriteCompleto)
        {
            this.nome = nome;
            this.posX = posX;
            this.posY = posY;
            this.spriteCompleto = spriteCompleto;
            this.eBordaDoJogo = eBordaDoJogo;
        }

        public ObjetoDeJogo (string nome, int posX, int posY, int altura, int largura, bool eBordaDoJogo, char[] spriteCompleto)
        {
            this.nome = nome;
            this.posX = posX;
            this.posY = posY;
            this.largura = largura;
            this.altura = altura;
            this.spriteCompleto = spriteCompleto;
            this.eBordaDoJogo = eBordaDoJogo;
        }




    }
}
