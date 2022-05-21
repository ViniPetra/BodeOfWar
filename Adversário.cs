using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Adversário
    {
        public int id { get; set; }
        public int QntBodes { get; set; }
        public List<int> CartasJogadas { get; set; }
    }
}
