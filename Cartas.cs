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
        public Cartas(int id, int bode, int imagemnum, int ClasseNum)
        {
            this.id = id;
            this.bode = bode;
            this.imagemnum = imagemnum;
            this.classe = ClasseNum;
        }

        public int id { get; set; }
        public int bode { get; set; }
        public int imagemnum { get; set; }

        /// <summary>
        /// 1 para números até 16 e bodes <= 2;
        /// 2 para entre 17 e 32 e bodes <= 2;
        /// 3 para maiores que 32 e bodes <= 2;
        /// 4 para números até 16 e bodes > 2;
        /// 5 para entre 17 e 32 e bodes > 2;
        /// 6 para maiores que 32 e bodes > 2;
        /// </summary>
        public int classe { get; set; }

        public Image imagem { get; set; }
    }
}
