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
        public string nome { get; set; }
        public int QntBodes { get; set; }
        public int IndexJogador { get; set; }
        public List<int> CartasJogadas { get; set; }

        public Adversário(int id, string nome, int indexJogador)
        {
            this.id = id;
            this.nome = nome;
            this.QntBodes = 0;
            this.CartasJogadas = new List<int>();
            IndexJogador = indexJogador;
        }

        public void AdicionarCartasJogadas(int id)
        {
            if (!(this.CartasJogadas.Contains(id)))
            {
                this.CartasJogadas.Add(id);
            }
        }

        public void AdicionarBodes(int qnt)
        {
            this.QntBodes += qnt;
        }
    }
}
