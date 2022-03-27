using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    class Cartas
    {
        public Cartas(int id, int bode, int numero)
        {
            this.id = id;
            this.bode = bode;
            this.numero = numero;
        }

        public int id { get; private set; }
        public int bode { get; private set; }
        public int numero { get; private set; }
    }
}
