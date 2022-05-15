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
        public string Senha { get; set; }
        public int idPartida { get; set; }
        public List<Cartas> Mao { get; set; }
        public Cartas[] TodasCartas { get; set; }
        public string Nome { get; set; }
        public List<int> MaoId { get; set; }
        public int IndiceJogador { get; set; }

        public Jogador(int id, string senha, int idpartida, List<Cartas> mao, Cartas[] todascartas, string nome)
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
            this.MaoId = new List<int>();
        }

        /// <summary>
        /// Calcula a menor carta na mão do jogador
        /// </summary>
        /// <returns>Id da menor carta</returns>
        public int MenorCarta()
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            int Min = aux.Min();
            return Min;
        }

        /// <summary>
        /// Calcula a maior carta na mão do jogador
        /// </summary>
        /// <returns>Id da maior carta</returns>
        public int MaiorCarta()
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            int max = aux.Max();
            return max;
        }

        /// <summary>
        /// Calcula quantidade de bodes na mão do jogador
        /// </summary>
        /// <returns>Quantidade de bodes na mão do jogador quando é chamada</returns>
        public int QuantidadeBodes()
        {
            int QuantidadeBodes = 0;
            for (int i = 0; i < this.Mao.Count; i++)
            {
                if (this.Mao[i] == null)
                {

                }
                else
                {
                    QuantidadeBodes += this.Mao[i].bode;
                }
            }
            return QuantidadeBodes;
        }
    }
}
