using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Partida
    {
        public int Id { get; set; }
        public bool EmJogo { get; set; }
        public int Rodada { get; set; }
        public List<int> idJogadores { get; set; }
        public int QntJogadores { get; set; }
        public List<int>[] CartasPorJogador { get; set; }
        public List<string> Mesa { get; set; }
        public List<Cartas> TodasCartas { get; set; }

        public List<Jogador> Jogadores { get; set; }

        public Partida(int idPartida, List<Cartas> TodasCartas)
        {
            this.EmJogo = true;
            this.Rodada = 0;
            this.Mesa = new List<string>();
            this.idJogadores = new List<int>();
            this.CartasPorJogador = new List<int>[4];
            this.Jogadores = new List<Jogador>();
            this.Id = idPartida;
            this.TodasCartas = TodasCartas;
        }

        public Partida()
        {

        }

        /// <summary>
        /// Popula a lista idJogadores, Cria os adversários na lista Jogadores e define a quantidade de jogadores
        /// </summary>
        public void PopularJogadores()
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(this.Id);
            Jogadores = Jogadores.Replace("\r", "");
            string[] Players = Jogadores.Split('\n');

            List<string> auxidJogadores = new List<string>();

            foreach (string a in Players)
            {
                string[] aux = a.Split(',');

                if (!(auxidJogadores.Contains(aux[0])) && !(aux[0] == "") && !(aux[0].StartsWith(" ")))
                {
                    auxidJogadores.Add((aux[0]));
                }
            }

            foreach(string p in Players)
            { 
                string[] a = p.Split(',');
                if (!(a[0] == "") && !(a[0].StartsWith(" ")))
                {
                    int idJogador = Int32.Parse(a[0]);
                    string nomeJogador = a[1];
                    idJogadores.Add(idJogador);
                    //
                    this.Jogadores.Add(new Jogador(idJogador, nomeJogador, auxidJogadores.IndexOf(a[0])));
                }
            }
            QntJogadores = idJogadores.Count();
        }

        /// <summary>
        /// Função para texto da lista de jogadores
        /// </summary>
        /// <returns>Jogadores</returns>
        public string ListarJogadores()
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(this.Id);
            if (Jogadores == "")
            {
                Jogadores = "Partida vazia";
            }

            Jogadores = Jogadores.Replace(",", " - ");

            return Jogadores;
        }

        /// <summary>
        /// Trata o retorno de BodeOfWarServer.VerificarVez, bate com o retorno de BodeOfWarServer.ListarJogadores
        /// </summary>
        /// <returns>Nome do jogador que deve atuar</returns>
        public string VerificarVez()
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(this.Id);
            string vez = BodeOfWarServer.Jogo.VerificarVez(this.Id);

            //Gerenciamento de erros
            if (vez.Contains("ERRO:Partida não está em jogo"))
            {
                nome = "Partida não iniciada";
                return nome;
            }
            if (vez.Contains("ERRO"))
            {
                System.Windows.Forms.MessageBox.Show(vez, "Jogo");
                return vez;
            }

            if (jogadores.Contains("ERRO"))
            {
                System.Windows.Forms.MessageBox.Show(jogadores, "Jogo");
                return jogadores;
            }

            //Mostra apenas o nome do jogador da vez
            jogadores = jogadores.Replace("\r", "");
            jogadores = jogadores.Replace("\n", ",");
            string[] Jogadores = jogadores.Split(',');

            string[] Vez = vez.Split(',');

            //Vez[0] = id
            //Vez[1] = nome
            string x = Vez[1];

            //Comparação dos retornos
            for (int i = 0; i < Jogadores.Length; i++)
            {
                if (Jogadores[i] == x)
                {
                    nome = Jogadores[i + 1];
                }
            }
            return nome;
        }

        /// <summary>
        /// Popula a lista partida.Mesa com o retorno tratado e BodeOfWar.VerificarMesa
        /// </summary>
        public void PopularMesa()
        {
            string[] aux;

            string ret = BodeOfWarServer.Jogo.VerificarMesa(this.Id, this.Rodada);

            ret = ret.Replace("\r", "");
            aux = ret.Split('\n');

            foreach (string a in aux)
            {
                if (!(Mesa.Contains(a)) && !(a.StartsWith("I")) && !(a == "") && !(a == " "))
                {
                    Mesa.Add(a);
                }
            }
        }

        /// <summary>
        /// Analisar se o jogador no índice pasasado venceu a partida anterior à atual ([rodada-1])
        /// </summary>
        /// <param name="IndiceJogador"></param>
        /// <returns>true se o jogador no índice pasasado venceu a partida</returns>
        /// <returns>false se o jogador no índice pasasado não venceu a partida</returns>
        public bool Venceu(int IndiceJogador)
        {
            List<int> CartasRodada = new List<int>();
            for(int i = 0; i <= QntJogadores-1; i++)
            {
                CartasRodada.Add(CartasPorJogador[i][Rodada-1]);
            }

            int indexVencedor = CartasRodada.IndexOf(CartasRodada.Max());

            if(indexVencedor == IndiceJogador)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica tamanho atual da ilha
        /// </summary>
        /// <param name="idPartida"></param>
        /// <returns>tamanho atual da ilha</returns>
        public int TamanhoIlha()
        {
            string ret = BodeOfWarServer.Jogo.VerificarMesa(this.Id);
            ret = ret.Replace("\r", "");
            string[] aux = ret.Split('\n');

            if (aux[0] == "" || aux[0] == " " || aux[0] == null)
            {
                return 0;
            }
            string tamanhoString = aux[0];
            tamanhoString = tamanhoString.Replace("\n", "");
            tamanhoString = tamanhoString.Replace("I", "");

            int tamanho = Int32.Parse(tamanhoString);

            return tamanho;
        }

        /// <summary>
        /// Verifica se a partida já acabou e quem venceu
        /// </summary>
        /// <returns>Nome do vencedor em UpperCase</returns>
        public bool JaTemVencedor()
        {  
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(this.Id).Replace("\n", ",");
            string[] jogadoresAux = jogadores.Split(',');
            string[] VerificarVencedor = BodeOfWarServer.Jogo.VerificarVez(this.Id).Split(',');

            if (VerificarVencedor[0] == "E")
            {
                for (int i = 0; i <= jogadoresAux.Length; i++)
                {
                    if (jogadoresAux[i] == VerificarVencedor[1])
                    {
                        string Vencedor = jogadoresAux[i+1].ToString();
                        System.Windows.Forms.MessageBox.Show("O vencedor é " + Vencedor.ToUpper());
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Verifica quais cartas foram jogadas na rodada atual
        /// </summary>
        /// <returns>Lista de ids das cartas</returns>
        public List<int> CartasJogadas()
        {
            string[] aux;

            string ret = BodeOfWarServer.Jogo.VerificarMesa(this.Id, this.Rodada);

            ret = ret.Replace("\r", "");
            aux = ret.Split('\n');

            List<string> retAux = new List<string>();

            List<int> CartasJogadas = new List<int>();

            foreach (string a in aux)
            {
                if (!(Mesa.Contains(a)) && !(a.StartsWith("I")) && !(a == "") && !(a == " "))
                {
                    retAux.Add(a);
                }
            }

            foreach (string a in retAux)
            {
                string[] b = a.Split(',');

                int carta = Int32.Parse(b[1]);

                CartasJogadas.Add(carta);
            }
            return CartasJogadas;
        }

        /// <summary>
        /// Verifica quem perdeu a rodada anterior à que foi chamada e soma os bodes em quem perdeu
        /// </summary>
        /// <returns>índice do jogador que perdeu e número de bodes comprados</returns>
        public string VerificarQuemPerdeuAnterior()
        {
            List<int> CartasRodadaAnterior = new List<int>();

            foreach (Jogador adv in this.Jogadores)
            {
                CartasRodadaAnterior.Add(adv.CartasJogadas[Rodada - 1]);
            }

            List<Cartas> CartasJogadas = new List<Cartas>();

            int bodesJogados = 0;

            int IndexMin = CartasRodadaAnterior.IndexOf(CartasRodadaAnterior.Min());

            foreach(Cartas carta in this.TodasCartas)
            {
                foreach(int i in CartasRodadaAnterior)
                {
                    if(carta.id == i)
                    {
                        CartasJogadas.Add(carta);
                    }
                }
            }

            foreach(Cartas carta in CartasJogadas)
            {
                bodesJogados += carta.bode;
            }

            foreach(Jogador jogador in Jogadores)
            {
                if(jogador.IndexJogador == IndexMin)
                {
                    jogador.AdicionarBodes(bodesJogados);
                }
            }

            Jogadores[IndexMin].Perdidas++;
            return Jogadores[IndexMin].Nome;
        }

        public string VerificarQuemVenceuAnterior()
        {
            List<int> CartasRodadaAnterior = new List<int>();

            foreach (Jogador adv in this.Jogadores)
            {
                CartasRodadaAnterior.Add(adv.CartasJogadas[Rodada - 1]);
            }

            List<Cartas> CartasJogadas = new List<Cartas>();

            int IndexMax = CartasRodadaAnterior.IndexOf(CartasRodadaAnterior.Max());

            Jogadores[IndexMax].Vencidas++;
            return Jogadores[IndexMax].Nome;
        }

        public bool AlguémVaiEstourar()
        {
            string[] aux;

            string ret = BodeOfWarServer.Jogo.VerificarMesa(this.Id, this.Rodada);

            ret = ret.Replace("\r", "");
            aux = ret.Split('\n');

            List<string> retAux = new List<string>();

            List<int> CartasJogadas = new List<int>();

            List<int> Jogadores = new List<int>();

            foreach (string a in aux)
            {
                if (!(Mesa.Contains(a)) && !(a.StartsWith("I")) && !(a == "") && !(a == " "))
                {
                    retAux.Add(a);
                }
            }

            foreach (string a in retAux)
            {
                string[] b = a.Split(',');

                int carta = Int32.Parse(b[1]);
                int jogador = Int32.Parse(b[0]);

                CartasJogadas.Add(carta);
                Jogadores.Add(jogador);
            }

            int BodesNaMesa = 0;

            foreach (int cartaJogada in CartasJogadas)
            {
                foreach (Cartas carta in this.TodasCartas)
                {
                    if (cartaJogada == carta.id)
                    {
                        BodesNaMesa += carta.bode;
                    }
                }
            }

            foreach(Jogador adversário in this.Jogadores)
            {
                if (Jogadores.Contains(adversário.Id))
                {
                    if (BodesNaMesa + adversário.Bodes > this.TamanhoIlha())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Contagem de bodes que o jogador já comprou na partida inteira
        /// </summary>
        /// <returns>Quantidade de bodes que o jogador já comprou na partida inteira</returns>
        public void AtualizarBodesComprados()
        {
            string ret = BodeOfWarServer.Jogo.ExibirNarracao(this.Id);

            List<string> lista = new List<string>();

            ret = ret.Replace("\r", "");

            string[] ret2 = ret.Split('\n');

            foreach (string s in ret2)
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

            foreach (Jogador jogador in this.Jogadores) 
            {
                jogador.Bodes = 0;
                foreach (string s in lista)
                {
                    string[] aux = s.Split(',');
                    if (aux[0] == jogador.Nome)
                    {
                        jogador.AdicionarBodes(Int32.Parse(aux[1]));
                    }
                }
            }
        }
    }
}
