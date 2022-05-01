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
    public partial class MaoAuto : Form
    {
        int ilha1Global;
        int ilha2Global;

        int rodada = 0;

        public List<string> Mesa = new List<string>();

        public List<string> idJogadores = new List<string>();

        public int[] idJogadoresInt = new int[4]; //DEBUG

        public List<int>[] CartasPorJogador = new List<int>[4];

        public string[,] MatrizMesa = new string[32, 2];

        Jogador jogador = new Jogador();

        Random random = new Random();

        Timer timer = new Timer()
        {
            Interval = 10000
        };

        List<PictureBox> imagens = new List<PictureBox>();
        List<Label> bodes = new List<Label>();
        List<Label> ids = new List<Label>();
        Panel[] panels = new Panel[8];

        List<PictureBox> Jogador1 = new List<PictureBox>();
        List<PictureBox> Jogador2 = new List<PictureBox>();
        List<PictureBox> Jogador3 = new List<PictureBox>();
        List<PictureBox> Jogador4 = new List<PictureBox>();


        public MaoAuto(Jogador user)
        {
            InitializeComponent();
            jogador = user;
        }

        private void Mão_Load(object sender, EventArgs e)
        {
            ListarJogadores(jogador.idPartida);

            CartasPorJogador[0] = new List<int>();
            CartasPorJogador[1] = new List<int>();
            CartasPorJogador[2] = new List<int>();
            CartasPorJogador[3] = new List<int>();

            lblJogador.Text = jogador.Nome;

            AtualizarDetalhes();

            //Criação de listas com todas as PictureBoxes e Labels do formulário
            imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8 };
            bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8 };
            ids = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8 };
            
            int count = 0;
            foreach (PictureBox p in imagens)
            {
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

            PopularJogadores();

            timer.Start();
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

        private void PopularJogadores()
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(jogador.idPartida);
            Jogadores = Jogadores.Replace("\r", "");
            string[] Players = Jogadores.Split('\n');

            foreach (string a in Players)
            {
                string[] aux = a.Split(',');

                int[] auxInt = new int[aux.Length];

                if (!(idJogadores.Contains(aux[0])) && !(aux[0] == "") && !(aux[0].StartsWith(" ")))
                {
                    idJogadores.Add((aux[0]));
                }
            }

            idJogadoresInt = idJogadores.Select(int.Parse).ToArray();
        }

        //Função de atualizar os detalhes da partida
        private void AtualizarDetalhes()
        {
            ListarJogadores(jogador.idPartida);
            txtVez.Text = VerificarVez();
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(jogador.idPartida);
            VerificarMesaAtual(jogador.idPartida, rodada);
        }

        //Função para verificar a vez a qualquer momento
        private string VerificarVez()
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(jogador.idPartida);
            string vez = BodeOfWarServer.Jogo.VerificarVez(jogador.idPartida);

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

        private bool Jogar(int index)
        {
            panels = new Panel[8] { pnlCarta1, pnlCarta2, pnlCarta3, pnlCarta4, pnlCarta5, pnlCarta6, pnlCarta7, pnlCarta8 };
            string ret = BodeOfWarServer.Jogo.Jogar(jogador.Id, jogador.Senha, jogador.Mao[index].id);
            if (ret.StartsWith("ERRO"))
            {
                MessageBox.Show(ret);
                return false;
            }
            else
            {
                rodada++;
                AtualizarDetalhes();
                VerMesa();
                panels[index].BringToFront();
                return true;
            }
        }

        private void VerIlhas()
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

        private void VerificarMesaAtual(int idPartida, int rodada)
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

            int count = 0;
            foreach (string b in Mesa)
            {
                string[] aux2 = b.Split(',');

                MatrizMesa[count, 0] = aux2[0];
                MatrizMesa[count, 1] = aux2[1];

                count++;
            }
        }

        private void VerMesa()
        {
            AtualizarDetalhes();

            foreach (string a in Mesa)
            {
                string[] b = a.Split(',');

                int id = Int32.Parse(b[0]);
                int carta = Int32.Parse(b[1]);

                foreach (int index in idJogadoresInt)
                {
                    if (index == id)
                    {
                        if (!(CartasPorJogador[Array.IndexOf<int>(idJogadoresInt, id)].Contains(carta)))
                        {
                            CartasPorJogador[Array.IndexOf<int>(idJogadoresInt, id)].Add(carta);
                        }
                    }
                }
            }

            Jogador1 = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            Jogador2 = new List<PictureBox>() { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            Jogador3 = new List<PictureBox>() { pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox20, pictureBox22, pictureBox23, pictureBox24 };
            Jogador4 = new List<PictureBox>() { pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32 };

            foreach (PictureBox p in Jogador1)
            {
                foreach (int cartas in CartasPorJogador[0])
                {
                    if (Jogador1.IndexOf(p) == CartasPorJogador[0].IndexOf(cartas))
                    {
                        foreach (Cartas carta in jogador.TodasCartas)
                        {
                            if (carta.id == cartas)
                            {
                                p.Image = carta.imagem;
                                p.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }

            foreach (PictureBox p in Jogador2)
            {
                foreach (int cartas in CartasPorJogador[1])
                {
                    if (Jogador1.IndexOf(p) == CartasPorJogador[1].IndexOf(cartas))
                    {
                        foreach (Cartas carta in jogador.TodasCartas)
                        {
                            if (carta.id == cartas)
                            {
                                p.Image = carta.imagem;
                                p.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }

            foreach (PictureBox p in Jogador3)
            {
                foreach (int cartas in CartasPorJogador[2])
                {
                    if (Jogador1.IndexOf(p) == CartasPorJogador[2].IndexOf(cartas))
                    {
                        foreach (Cartas carta in jogador.TodasCartas)
                        {
                            if (carta.id == cartas)
                            {
                                p.Image = carta.imagem;
                                p.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }

            foreach (PictureBox p in Jogador4)
            {
                foreach (int cartas in CartasPorJogador[3])
                {
                    if (Jogador1.IndexOf(p) == CartasPorJogador[3].IndexOf(cartas))
                    {
                        foreach (Cartas carta in jogador.TodasCartas)
                        {
                            if (carta.id == cartas)
                            {
                                p.Image = carta.imagem;
                                p.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }
        }

        private void pcbCarta1_DoubleClick(object sender, EventArgs e)
        {
            Jogar(0);
        }

        private void pcbCarta2_DoubleClick(object sender, EventArgs e)
        {
            Jogar(1);
        }

        private void pcbCarta3_DoubleClick(object sender, EventArgs e)
        {
            Jogar(2);
        }

        private void pcbCarta4_DoubleClick(object sender, EventArgs e)
        {
            Jogar(3);
        }

        private void pcbCarta5_DoubleClick(object sender, EventArgs e)
        {
            Jogar(4);
        }

        private void pcbCarta6_DoubleClick(object sender, EventArgs e)
        {
            Jogar(5);
        }

        private void pcbCarta7_DoubleClick(object sender, EventArgs e)
        {
            Jogar(6);
        }

        private void pcbCarta8_DoubleClick(object sender, EventArgs e)
        {
            Jogar(7);
        }

        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes();
        }

        //Ver as opções de ilha
        private void btnVerIlhas_Click(object sender, EventArgs e)
        {
            VerIlhas();
        }

        //Escolher a ilha
        private void btnIlha1_Click(object sender, EventArgs e)
        {
            BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha1Global);
            AtualizarDetalhes();
            pnlVerIlhas.BringToFront();
        }

        private void btnIlha2_Click(object sender, EventArgs e)
        {
            BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha2Global);
            AtualizarDetalhes();
            pnlVerIlhas.BringToFront();
        }

        private void btnVerMesa_Click(object sender, EventArgs e)
        {
            VerMesa();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Automação

            bool running = true;

            while (running)
            {
                if (timer.Interval % 10000 == 0)
                {
                    timer.Stop();
                    AtualizarDetalhes();

                    if (VerificarVez() == jogador.Nome.ToString())
                    {
                        string[] ret = BodeOfWarServer.Jogo.VerificarVez(jogador.idPartida).Split(',');
                        
                        if (ret[3] == "I")
                        {
                            int random = new Random().Next(1,2);
                            if (random == 1)
                            {
                                BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha1Global);
                                AtualizarDetalhes();
                            }
                            else
                            {
                                BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha2Global);
                                AtualizarDetalhes();
                            }
                        }

                        if (ret[3] == "B")
                        {
                            int rand = random.Next(0, jogador.Mao.Length);
                            while (!(Jogar(rand)))
                            {
                                rand = random.Next(jogador.Mao.Length);
                                Jogar(rand);
                            }
                            timer.Start();
                        }
                    }
                }
            }
        }
    }
}
