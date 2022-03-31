using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BodeOfWar
{
    public class Cartas
    {
        public Cartas(int id, int bode, int imagem)
        {
            this.id = id;
            this.bode = bode;
            this.imagem = imagem;
        }

        public Cartas()
        {

        }

        public int id { get; set; }
        public int bode { get; set; }
        public int imagem { get; set; }
    }
}
