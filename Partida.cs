using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Partida
    {
        public bool EmJogo { get; set; }
        public int rodada { get; set; }
        public List<string> Mesa { get; set; }
        public List<int> idJogadores { get; set; }
        public List<int>[] CartasPorJogador { get; set; }
        public int QntJogadores { get; set; }

        public Partida()
        {
            EmJogo = true;
            rodada = 0;
            Mesa = new List<string>();
            idJogadores = new List<int>();
            CartasPorJogador = new List<int>[4];
        }

        /// <summary>
        /// Função auxiliar para popular a array partida.idJogadores
        /// </summary>
        public void PopularJogadores(int idPartida)
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            Jogadores = Jogadores.Replace("\r", "");
            string[] Players = Jogadores.Split('\n');

            List<string> auxidJogadores = new List<string>();

            foreach (string a in Players)
            {
                string[] aux = a.Split(',');

                int[] auxInt = new int[aux.Length];

                if (!(auxidJogadores.Contains(aux[0])) && !(aux[0] == "") && !(aux[0].StartsWith(" ")))
                {
                    auxidJogadores.Add((aux[0]));
                }
            }

            foreach(string a in auxidJogadores)
            {
                idJogadores.Add(Int32.Parse(a));
            }
            QntJogadores = idJogadores.Count();
        }

        /// <summary>
        /// Função para texto da lista de jogadores
        /// </summary>
        /// <param name="idPartida"></param>
        /// <returns>Jogadores</returns>
        public string ListarJogadores(int idPartida)
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
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
        public string VerificarVez(int idPartida)
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            string vez = BodeOfWarServer.Jogo.VerificarVez(idPartida);

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
        /// <param name="rodada"></param>
        public void PopularMesa(int rodada, int idPartida)
        {
            string[] aux;

            string ret = BodeOfWarServer.Jogo.VerificarMesa(idPartida, rodada);

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
                CartasRodada.Add(CartasPorJogador[i][rodada-1]);
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
        /// <param name="idJogador"></param>
        /// <returns>tamanho atual da ilha</returns>
        public int TamanhoIlha(int idJogador)
        {
            string ret = BodeOfWarServer.Jogo.VerificarMesa(idJogador);
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

        public bool JaTemVencedor(int idPartida)
        {  
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida).Replace("\n", ",");
            string[] jogadoresAux = jogadores.Split(',');
            string[] VerificarVencedor = BodeOfWarServer.Jogo.VerificarVez(idPartida).Split(',');

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
    }
}
