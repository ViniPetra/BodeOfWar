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
        public int[] idJogadores { get; set; }
        public List<int>[] CartasPorJogador { get; set; }

        public Partida()
        {
            EmJogo = true;
            rodada = 0;
            List<int>[] CartasPorJogador = new List<int>[4];
            List<string> Mesa = new List<string>();
            int[] idJogadores = new int[4];
        }

        /// <summary>
        /// Função auxiliar para popular a array partida.idJogadores
        /// </summary>
        public void PopularJogadores(int idPartida)
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            Jogadores = Jogadores.Replace("\r", "");
            string[] Players = Jogadores.Split('\n');

            List<string> idJogadores = new List<string>();

            foreach (string a in Players)
            {
                string[] aux = a.Split(',');

                int[] auxInt = new int[aux.Length];

                if (!(idJogadores.Contains(aux[0])) && !(aux[0] == "") && !(aux[0].StartsWith(" ")))
                {
                    idJogadores.Add((aux[0]));
                }
            }

            this.idJogadores = idJogadores.Select(int.Parse).ToArray();
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
                if (!(this.Mesa.Contains(a)) && !(a.StartsWith("I")) && !(a == "") && !(a == " "))
                {
                    this.Mesa.Add(a);
                }
            }
        }

    }
}
