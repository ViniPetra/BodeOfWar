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
        public Cartas(int id, int bode, int imagemnum, bool BodeAlto, int ClasseNum)
        {
            this.id = id;
            this.bode = bode;
            this.imagemnum = imagemnum;
            this.BodeAlto = BodeAlto;
            this.ClasseNum = ClasseNum;
        }

        public int id { get; set; }
        public int bode { get; set; }
        public int imagemnum { get; set; }

        /// <summary>
        /// true para bodes > 2
        /// </summary>
        public bool BodeAlto { get; set; }

        /// <summary>
        /// 1 para números até 16;
        /// 2 para entre 17 e 32;
        /// 3 para maiores que 32;
        /// </summary>
        public int ClasseNum { get; set; }

        public Image imagem { get; set; }
    }
}
