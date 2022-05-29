using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class User
    {
        public int Id { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public Partida Partida { get; set; }
        public List<Cartas> Mao { get; set; }
        public List<int> MaoId { get; set; }
        public int IndiceJogador { get; set; }

        public User(int id, string senha, Partida partida, List<Cartas> mao, string nome)
        {
            Id = id;
            Senha = senha;
            Partida = partida;
            Mao = mao;
            Nome = nome;
            this.MaoId = new List<int>();
        }

        public User()
        {
            this.MaoId = new List<int>();
            this.Partida = new Partida();
            this.Mao = new List<Cartas>();
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
        /// Descobre a carta com menor bode na mão do jogador
        /// </summary>
        /// <returns>Id da carta com menor bode</returns>
        public int MenorBode()
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].bode);
            }

            int min = aux.Min();
            int IdMin = 0;
            foreach (Cartas carta in this.Mao)
            {
                if (carta.bode == min)
                {
                    IdMin = carta.id;
                }
            }
            return IdMin;
        }

        /// <summary>
        /// Descobre a carta com maior bode na mão do jogador
        /// </summary>
        /// <returns>Id da carta com maior bode</returns>
        public int MaiorBode()
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].bode);
            }

            int max = aux.Max();
            int IdMax = 0;
            foreach(Cartas carta in Mao)
            {
                if(carta.bode == max)
                {
                    IdMax = carta.id;
                }
            }
            return IdMax;
        }

        /// <summary>
        /// Verifica se o jogador tem carta de uma classe 
        /// </summary>
        /// <param name="classe"></param>
        /// <returns></returns>
        public bool TemCartaClasse(int classe)
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].classe);
            }

            if (aux.Contains(classe))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Escolhe a primeira ocorrência da carta com a classe escolhida
        /// </summary>
        /// <param name="classe"></param>
        /// <returns>Índice da carta na mão</returns>
        public int CartaClasse(int classe)
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].bode);
            }

            int IndexClasse = 0;
            foreach (Cartas carta in this.Mao)
            {
                if (carta.classe == classe)
                {
                    IndexClasse = carta.id;
                }
            }

            return IndexClasse;
        }

        /// <summary>
        /// Joga uma carta entre a maior e a menor carta jogada na rodada
        /// </summary>
        /// <param name="CartasJogadas"></param>
        /// <returns>Id da carta</returns>
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
                foreach (Cartas carta in this.Mao)
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
        /// Verifica se o jogador tem uma carta maior que as já jogadas na mesa
        /// </summary>
        /// <param name="CartasJogadas"></param>
        /// <returns>bool</returns>
        public bool TemMaiorCarta(List<int> CartasJogadas)
        {
            int maior;

            if (CartasJogadas.Any())
            {
                maior = CartasJogadas.Max();
            }
            else
            {
                return true;
            }

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
        
        /// <summary>
        /// Verifica se o jogador tem uma carta menor que as já jogadas na mesa
        /// </summary>
        /// <param name="CartasJogadas"></param>
        /// <returns></returns>
        public bool TemMenorCarta(List<int> CartasJogadas)
        {
            int menor;
            if (CartasJogadas.Any())
            {
                menor = CartasJogadas.Min();
            }
            else
            {
                return true;
            }

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

        public bool TemCartaMenorQue(int numero)
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            foreach(int id in aux)
            {
                if(numero > id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool TemCartaMaiorQue(int numero)
        {
            List<int> aux = new List<int>();
            for (int i = 0; i < this.Mao.Count; i++)
            {
                aux.Add(this.Mao[i].id);
            }

            foreach (int id in aux)
            {
                if (numero < id)
                {
                    return true;
                }
            }
            return false;
        }

        public int CartaMaiorQueMesa(List<int> CartasJogadas)
        {
            if (CartasJogadas.Any())
            {
                List<int> aux = new List<int>();
                for (int i = 0; i < this.Mao.Count; i++)
                {
                    aux.Add(this.Mao[i].id);
                }

                foreach (int id in aux)
                {
                    if (id > CartasJogadas.Max())
                    {
                        return id;
                    }
                }
            }
            return -1;
        }

        public int CartaMenorQueMesa(List<int> CartasJogadas)
        {
            if (CartasJogadas.Any())
            {
                List<int> aux = new List<int>();
                for (int i = 0; i < this.Mao.Count; i++)
                {
                    aux.Add(this.Mao[i].id);
                }

                foreach (int id in aux)
                {
                    if (id < CartasJogadas.Max())
                    {
                        return id;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Verifica se o jogador vai estourar se comprar a mesa atual
        /// </summary>
        /// <param name="CartasJogadas"></param>
        /// <param name="TamIlha"></param>
        /// <returns></returns>
        public bool FazSentidoComprar(List<int> CartasJogadas, int TamIlha)
        {
            int BodesNaMesa = 0;

            if (CartasJogadas.Any())
            {
                foreach (int cartaJogada in CartasJogadas)
                {
                    foreach (Cartas carta in this.Partida.TodasCartas)
                    {
                        if (cartaJogada == carta.id)
                        {
                            BodesNaMesa += carta.bode;
                        }
                    }
                }

                if (BodesNaMesa > (TamIlha - this.Partida.Jogadores[IndiceJogador].Bodes))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Vrifica qual a classe da carta olhando id e bode
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bode"></param>
        /// <returns>Classe da carta</returns>
        public int VerClasse(int id, int bode)
        {
            if (id <= 16 && bode <= 2)
            {
                return 1;
            }
            else if (id > 16 && id <= 32 && bode <= 2)
            {
                return 2;
            }
            else if (id > 32 && bode <= 2)
            {
                return 3;
            }
            else if (id <= 16 && bode > 2)
            {
                return 4;
            }
            else if (id > 16 && id <= 32 && bode > 2)
            {
                return 5;
            }
            else if (id > 32 && bode > 2)
            {
                return 6;
            }
            return 0;
        }
    }
}
