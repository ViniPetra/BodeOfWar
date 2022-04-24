using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Jogador
    {
        public Jogador(int id, string senha, int idPartida, Cartas[] mao)
        {
            Id = id;
            Senha = senha;
            this.idPartida = idPartida;
            Mao = mao;
        }

        public Jogador()
        {

        }

        public int Id { get; set; }
        public string Senha { get; set; }
        public int idPartida { get; set; }
        public Cartas[] Mao { get; set; }

    }
}
