using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Bodes { get; set; }
        public int IndexJogador { get; set; }
        public int Perdidas { get; set; }
        public int Vencidas { get; set; }
        public List<int> CartasJogadas { get; set; }

        public Jogador(int id, string nome, int indexJogador)
        {
            this.Id = id;
            this.Nome = nome;
            this.Bodes = 0;
            this.Perdidas = 0;
            this.Vencidas = 0;
            this.CartasJogadas = new List<int>();
            this.IndexJogador = indexJogador;
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
            this.Bodes += qnt;
        }
    }
}
