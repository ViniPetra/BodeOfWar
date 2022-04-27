using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Jogador
    {
        public Jogador(int id, string senha, int idpartida, Cartas[] mao, Cartas[] todascartas, string nome)
        {
            Id = id;
            Senha = senha;
            idPartida = idpartida;
            Mao = mao;
            TodasCartas = todascartas;
            Nome = nome;
        }

        public Jogador()
        {

        }

        public int Id { get; set; }
        public string Senha { get; set; }
        public int idPartida { get; set; }
        public Cartas[] Mao { get; set; }
        public Cartas[] TodasCartas { get; set; }
        public string Nome { get; set; }

    }
}
