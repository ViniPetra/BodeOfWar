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

        public int MaiorBode()
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].bode);
            }

            int max = aux.Max();
            int IndexMax = 0;
            foreach(Cartas carta in Mao)
            {
                if(carta.bode == max)
                {
                    IndexMax = carta.id;
                }
            }

            return IndexMax;
        }

        public int MenorBode()
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].bode);
            }

            int min = aux.Min();
            int IndexMin = 0;
            foreach (Cartas carta in Mao)
            {
                if (carta.bode == min)
                {
                    IndexMin = carta.id;
                }
            }

            return IndexMin;
        }

        public int Descartar(List<int> CartasJogadas)
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            int minCJ = CartasJogadas.Min();
            int maxCJ = CartasJogadas.Max();

            if (minCJ == maxCJ)
            {
                return Mao[((Mao.Count())) / 2].id;
            }
            else
            {
                foreach (Cartas carta in Mao)
                {
                    if (carta.id > maxCJ && carta.id < minCJ)
                    {
                        return carta.id;
                    }
                }
            }

            return Mao[((Mao.Count())) / 2].id;
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

        /// <summary>
        /// Contagem de bodes que o jogador já comprou na partida inteira
        /// </summary>
        /// <returns>Quantidade de bodes que o jogador já comprou na partida inteira</returns>
        public int BodesComprados()
        {
            string ret = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);

            List<string> lista = new List<string>();

            ret = ret.Replace("\r", "");

            string[] ret2 = ret.Split('\n');

            int contagem = 0;

            foreach(string s in ret2)
            {
                if (s.Contains("venceu a rodada e recebeu"))
                {
                    string aux = s;
                    aux = aux.Replace("\n", "");
                    aux = aux.Replace(" venceu a rodada e recebeu ", ",");
                    aux = aux.Replace(" bodes", "");
                    lista.Add(aux);
                }
            }

            foreach(string s in lista)
            {
                string[] aux = s.Split(',');
                if(aux[0] == Nome)
                {
                    contagem += Int32.Parse(aux[1]);
                }
            }

            return contagem;
        }

        public bool TemMaiorCarta(List<int> CartasJogadas)
        {
            int maior = CartasJogadas.Max();

            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            int max = aux.Max();

            if (max > maior)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool TemMenorCarta(List<int> CartasJogadas)
        {
            int menor = CartasJogadas.Min();

            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            int min = aux.Min();

            if (min < menor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
