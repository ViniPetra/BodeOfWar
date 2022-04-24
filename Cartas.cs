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
        public Cartas(int id, int bode, int imagemnum)
        {
            this.id = id;
            this.bode = bode;
            this.imagemnum = imagemnum;
        }

        public Cartas()
        {

        }

        public int id { get; set; }
        public int bode { get; set; }
        public int imagemnum { get; set; }
        public Image imagem { get; set; }
    }
}
