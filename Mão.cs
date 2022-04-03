using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodeOfWar
{
    public partial class Mão : Form
    {
        int idJogadorGlobal;
        string senhaGlobal;
        Cartas[] MinhaMaoGlobal;
        int idPartidaGlobal1;

        int ilha1Global;
        int ilha2Global;

        public Mão(Cartas[] MinhaMao, string[] jogadorGlobal, int idPartidaGlobal)
        {
            InitializeComponent();

            AtualizarDetalhes(idPartidaGlobal);
            
            //Acesso dos valores
            idJogadorGlobal = Int32.Parse(jogadorGlobal[0]);
            senhaGlobal = jogadorGlobal[1];
            MinhaMaoGlobal = MinhaMao;
            idPartidaGlobal1 = idPartidaGlobal;

            //Criação de listas com todas as PictureBoxes e Labels do formulário
            List<PictureBox> imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8};
            List<Label> bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8};
            List<Label> ids = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8};
            Panel[] panels = new Panel[8] { pnlCarta1, pnlCarta2, pnlCarta3, pnlCarta4, pnlCarta5, pnlCarta6, pnlCarta7, pnlCarta8 };

            //Loop para adição da imagem baseada no número de bodes
            int count = 0;
            foreach (PictureBox p in imagens)
            {
                p.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[count].imagem);
                count++;
            }

            //Loop para troca do texto da label Bode para o atributo do objeto
            count = 0;
            foreach (Label label in bodes)
            {
                    label.Text = MinhaMao[count].bode.ToString();
                    count++;
            }

            //Loop para troca do texto da label Numero para o atributo do objeto
            count = 0;
            foreach (Label l in ids)
            {
                l.Text = MinhaMao[count].id.ToString();
                count++;
            }
        }

        //Função para atualizar a lista de jogadores a qualquer momento
        private void ListarJogadores(int idPartida)
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            if (Jogadores == "")
            {
                Jogadores = "Partida vazia";
            }
            txtListarJogadores.Text = Jogadores;
        }

        //Função de atualizar os detalhes da partida
        private void AtualizarDetalhes(int idPartida)
        {
            ListarJogadores(idPartida);
            txtVez.Text = VerificarVez(idPartida);
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);
        }

        //Função para verificar a vez a qualquer momento
        private string VerificarVez(int idPartida)
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
                MessageBox.Show(vez, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return vez;
            }

            if (jogadores.Contains("ERRO"))
            {
                MessageBox.Show(jogadores, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return jogadores;
            }

            //Mostra apenas o nome do jogador da vez
            jogadores = jogadores.Replace("\r", "");
            jogadores = jogadores.Replace("\n", ",");
            string[] Jogadores = jogadores.Split(',');

            string[] Vez = vez.Split(',');

            string x = Vez[1];

            for (int i = 0; i < Jogadores.Length; i++)
            {
                if (Jogadores[i] == x)
                {
                    nome = Jogadores[i + 1];
                }
            }
            return nome;
        }


        private void Jogar(int index)
        {
            BodeOfWarServer.Jogo.Jogar(idJogadorGlobal, senhaGlobal, MinhaMaoGlobal[index].id);
        }

        private void pcbCarta1_DoubleClick(object sender, EventArgs e)
        {
            Jogar(0);
            pnlCarta1.BringToFront();
        }

        private void pcbCarta2_DoubleClick(object sender, EventArgs e)
        {
            Jogar(1);
            pnlCarta2.BringToFront();
        }

        private void pcbCarta3_DoubleClick(object sender, EventArgs e)
        {
            Jogar(2);
            pnlCarta3.BringToFront();
        }

        private void pcbCarta4_DoubleClick(object sender, EventArgs e)
        {
            Jogar(3);
            pnlCarta4.BringToFront();
        }

        private void pcbCarta5_DoubleClick(object sender, EventArgs e)
        {
            Jogar(4);
            pnlCarta5.BringToFront();
        }

        private void pcbCarta6_DoubleClick(object sender, EventArgs e)
        {
            Jogar(5);
            pnlCarta6.BringToFront();
        }

        private void pcbCarta7_DoubleClick(object sender, EventArgs e)
        {
            Jogar(6);
            pnlCarta7.BringToFront();
        }

        private void pcbCarta8_DoubleClick(object sender, EventArgs e)
        {
            Jogar(7);
            pnlCarta8.BringToFront();
        }

        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes(idPartidaGlobal1);
        }

        //Ver as opções de ilha
        private void btnVerIlhas_Click(object sender, EventArgs e)
        {
            string retIlha = BodeOfWarServer.Jogo.VerificarIlha(idJogadorGlobal, senhaGlobal);

            if (retIlha.Contains("ERRO"))
            {
                MessageBox.Show("Ainda não é a hora de escolher a ilha");
            }
            else
            {
                string[] opcIlha = retIlha.Split(',');
                ilha1Global = Int32.Parse(opcIlha[0]);
                ilha2Global = Int32.Parse(opcIlha[1]);
                btnIlha1.Text = opcIlha[0];
                btnIlha2.Text = opcIlha[1];
                pnlIlhas.BringToFront();
            }
        }

        //Escolher a ilha
        private void btnIlha1_Click(object sender, EventArgs e)
        {
            BodeOfWarServer.Jogo.DefinirIlha(idJogadorGlobal, senhaGlobal, ilha1Global);
            AtualizarDetalhes(idPartidaGlobal1);
            pnlVerIlhas.BringToFront();
        }

        private void btnIlha2_Click(object sender, EventArgs e)
        {
            BodeOfWarServer.Jogo.DefinirIlha(idJogadorGlobal, senhaGlobal, ilha2Global);
            AtualizarDetalhes(idPartidaGlobal1);
            pnlVerIlhas.BringToFront();
        }
    }
}
