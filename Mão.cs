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
        int ilha1Global;
        int ilha2Global;

        int rodada = 1;

        public List<string> Mesa = new List<string>();

        public List<string> idJogadores = new List<string>();

        public List<string>[] CartasPorJogador = new List<string>[4];

        Jogador jogador = new Jogador();

        public string[,] MatrizMesa = new string[32, 2];

        public Mão(Jogador user)
        {
            InitializeComponent();

            jogador = user;

            AtualizarDetalhes(jogador.idPartida);

            //Criação de listas com todas as PictureBoxes e Labels do formulário
            List<PictureBox> imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8 };
            List<Label> bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8 };
            List<Label> ids = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8 };
            Panel[] panels = new Panel[8] { pnlCarta1, pnlCarta2, pnlCarta3, pnlCarta4, pnlCarta5, pnlCarta6, pnlCarta7, pnlCarta8 };

            List<PictureBox> Jogador1 = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            List<PictureBox> Jogador2 = new List<PictureBox>() { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            List<PictureBox> Jogador3 = new List<PictureBox>() { pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox20, pictureBox22, pictureBox23, pictureBox24 };
            List<PictureBox> Jogador4 = new List<PictureBox>() { pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32 };

            int count = 0;
            foreach (PictureBox p in imagens)
            {
                /*
                p.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[count].imagem);
                count++;
                */
                p.Image = jogador.Mao[count].imagem;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                count++;
            }

            //Loop para troca do texto da label Bode para o atributo do objeto
            count = 0;
            foreach (Label label in bodes)
            {
                label.Text = jogador.Mao[count].bode.ToString();
                count++;
            }

            //Loop para troca do texto da label Numero para o atributo do objeto
            count = 0;
            foreach (Label l in ids)
            {
                l.Text = jogador.Mao[count].id.ToString();
                count++;
            }
        }

        //Função para atualizar a lista de jogadores a qualquer momento
        private string[] ListarJogadores(int idPartida)
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            if (Jogadores == "")
            {
                Jogadores = "Partida vazia";
            }

            txtListarJogadores.Text = Jogadores;

            Jogadores = Jogadores.Replace("\r", "");
            Jogadores = Jogadores.Replace("\n", ",");
            string[] Players = Jogadores.Split(',');

            for (int i = 0; i < Players.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (!(idJogadores.Contains(Players[i])) && !(Players[i] == "") && !(Players[i].StartsWith(" ")))
                    {
                        idJogadores.Add(Players[i]);
                    }
                }
            }

            return Players;
        }

        //Função de atualizar os detalhes da partida
        private void AtualizarDetalhes(int idPartida)
        {
            lsvMesa.Items.Clear();
            ListarJogadores(idPartida);
            txtVez.Text = VerificarVez(idPartida);
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);
            VerificarMesaAtual(idPartida, rodada);

            foreach (string a in Mesa)
            {
                lsvMesa.Items.Add(a);
            }
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

        private bool Jogar(int index, Jogador jogador)
        {
            string ret = BodeOfWarServer.Jogo.Jogar(jogador.Id, jogador.Senha, jogador.Mao[index].id);
            if (ret.StartsWith("ERRO"))
            {
                MessageBox.Show(ret);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void VerificarMesaAtual(int idPartida, int rodada)
        {
            string[] aux;

            string ret = BodeOfWarServer.Jogo.VerificarMesa(idPartida, rodada);

            MessageBox.Show(ret);

            ret = ret.Replace("\r", "");
            aux = ret.Split('\n');

            foreach (string a in aux)
            {
                if (!(Mesa.Contains(a)) && !(a.StartsWith("I")) && !(a == "") && !(a == " "))
                {
                    Mesa.Add(a);
                }
            }
            /*
            int count = 0;
            foreach(string b in Mesa)
            {
                string[] aux2 = b.Split(',');

                MatrizMesa[count, 0] = aux2[0];
                MatrizMesa[count, 1] = aux2[1];

                count++;
            }
            */
        }

        private void pcbCarta1_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(0, jogador))
            {
                pnlCarta1.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta2_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(1, jogador))
            {
                pnlCarta2.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta3_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(2, jogador))
            {
                pnlCarta3.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta4_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(3, jogador))
            {
                pnlCarta4.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta5_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(4, jogador))
            {
                pnlCarta5.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta6_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(5, jogador))
            {
                pnlCarta6.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta7_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(6, jogador))
            {
                pnlCarta7.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void pcbCarta8_DoubleClick(object sender, EventArgs e)
        {
            if (Jogar(7, jogador))
            {
                pnlCarta8.BringToFront();
                AtualizarDetalhes(jogador.idPartida);
                rodada++;
            }
        }

        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes(jogador.idPartida);
        }

        //Ver as opções de ilha
        private void btnVerIlhas_Click(object sender, EventArgs e)
        {
            string retIlha = BodeOfWarServer.Jogo.VerificarIlha(jogador.Id, jogador.Senha);

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
            BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha1Global);
            AtualizarDetalhes(jogador.idPartida);
            pnlVerIlhas.BringToFront();
        }

        private void btnIlha2_Click(object sender, EventArgs e)
        {
            BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha2Global);
            AtualizarDetalhes(jogador.idPartida);
            pnlVerIlhas.BringToFront();
        }

        //Debug

        private Image Imagem(int id)
        {
            foreach (Cartas carta in jogador.TodasCartas)
            {
                if (carta.id == id)
                {
                    return carta.imagem;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        private void Mão_Load(object sender, EventArgs e)
        {
            ListarJogadores(jogador.idPartida);
            
            /*
             * Debug
             * 
            foreach(string jogador in idJogadores)
            {
                MessageBox.Show(jogador);
            }
            */

            CartasPorJogador[0] = new List<string>();
            CartasPorJogador[1] = new List<string>();
            CartasPorJogador[2] = new List<string>();
            CartasPorJogador[3] = new List<string>();

            lblJogador.Text = jogador.Nome;
        }

        private void btnVerMesa_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes(jogador.idPartida);

            /*
            foreach (string id in Mesa)
            {
                string[] a = id.Split(',');

                foreach (string jogador in idJogadores)
                {
                    CartasPorJogador[jogador.IndexOf(a[0])].Add(a[1]); //Tá dando indice fora
                }
            }
            */
            /*
            for (int i = 0; i < 4; i++) {
                foreach (string id in MatrizMesa)
                {
                    foreach (var cartas in CartasPorJogador[i])
                    {
                        if (MatrizMesa[Int32.Parse(id), 0] == idJogadores[0])
                        {
                            CartasPorJogador[Int32.Parse(cartas)].Add(MatrizMesa[Int32.Parse(id), 1]);
                        }
                    }
                }
            }
            */

            for (int i = 0; i < 32; i++)
            {
                foreach (string id in idJogadores) {
                    if (MatrizMesa[i, 0] == id)
                    {
                        CartasPorJogador[idJogadores.IndexOf(id)].Add(MatrizMesa[i, 1]);
                    }
                }               
            }

            List<PictureBox> Jogador1 = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            List<PictureBox> Jogador2 = new List<PictureBox>() { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            List<PictureBox> Jogador3 = new List<PictureBox>() { pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox20, pictureBox22, pictureBox23, pictureBox24 };
            List<PictureBox> Jogador4 = new List<PictureBox>() { pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32 };

            
            foreach(PictureBox p in Jogador1)
            {
                foreach(string cartas in CartasPorJogador[0])
                {
                    if(Jogador1.IndexOf(p) == CartasPorJogador[0].IndexOf(cartas))
                    {
                        foreach(Cartas carta in jogador.TodasCartas)
                        {
                            if(carta.id == Int32.Parse(cartas))
                            {
                                p.Image = carta.imagem;
                                p.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }
        }
    }
}
