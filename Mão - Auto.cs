﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BodeOfWar
{
    public partial class MaoAuto : Form
    {
        bool EmJogo = true;

        int ilha1Global;
        int ilha2Global;

        int rodada = 0;

        public List<string> Mesa = new List<string>();

        public List<string> idJogadores = new List<string>();

        public int[] idJogadoresInt = new int[4];

        public List<int>[] CartasPorJogador = new List<int>[4];

        List<int> CartasJogadas = new List<int>();

        User jogador = new User();

        Partida partida { get; set; }

        List<PictureBox> imagens;
        List<Label> bodes;
        List<Label> ids;
        Panel[] panels;

        List<PictureBox> Jogador1;
        List<PictureBox> Jogador2;
        List<PictureBox> Jogador3;
        List<PictureBox> Jogador4;

        List<List<PictureBox>> MesaJogadoresImagem;

        List<Label> Jogador1Bodes;
        List<Label> Jogador2Bodes;
        List<Label> Jogador3Bodes;
        List<Label> Jogador4Bodes;

        List<List<Label>> MesaJogadoresBode;

        List<Label> Jogador1Ids;
        List<Label> Jogador2Ids;
        List<Label> Jogador3Ids;
        List<Label> Jogador4Ids;

        List<List<Label>> MesaJogadoresIds;

        List<PictureBox> ImagensJogadores;

        /// <summary>
        /// Define o jogador
        /// </summary>
        /// <param name="user"></param>
        public MaoAuto(User user, Partida partida)
        {
            this.jogador = user;
            this.partida = partida;
            InitializeComponent();
        }

        /// <summary>
        /// 1. Inicializa as listas na array CartasPorJogador
        /// 2. Define as listas imagens, bodes e ids
        /// 3. Define as imagens das PictureBox da lista imagens baseado em cada jogador.Mao.imagem
        /// 4. Define os text de cada Label da lista bodes baseado em cada jogador.Mao.bode
        /// 5. Define os text de cada Label da lista ids baseado em cada jogador.Mao.id
        /// </summary>
        private void Mão_Load(object sender, EventArgs e)
        {
            AtualizarDetalhes();

            CartasPorJogador[0] = new List<int>();
            CartasPorJogador[1] = new List<int>();
            CartasPorJogador[2] = new List<int>();
            CartasPorJogador[3] = new List<int>();

            lblJogador.Text = "Você: " + jogador.Nome;

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

            //Lista de PictureBoxes dos jogadores
            ImagensJogadores = new List<PictureBox> { pcbJogador1, pcbJogador2, pcbJogador3, pcbJogador4 };

            //Mostrando as imagens
            for (int i = 0; i <= idJogadores.Count() - 1; i++)
            {
                ImagensJogadores[i].Visible = true;
            }
        }

        /// <summary>
        /// Atualiza o txtListarJogadores com o retorno de BodeOfWarServer.ListarJogadores
        /// </summary>
        private void ListarJogadores()
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(partida.Id);
            if (Jogadores == "")
            {
                Jogadores = "Partida vazia";
            }

            Jogadores = Jogadores.Replace(",", " - ");
            
            txtListarJogadores.Text = Jogadores;
        }

        /// <summary>
        /// Função auxiliar para popular a array idJogadoresInt
        /// </summary>
        private void PopularJogadores()
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(partida.Id);
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

        /// <summary>
        /// Atualiza as informações em txtVez, txtNarracao, txtJogadores e a mesa
        /// </summary>
        private void AtualizarDetalhes()
        {
            ListarJogadores();
            txtVez.Text = VerificarVez();
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(partida.Id);
            PopularMesa(rodada);
            if(txtNarracao.Text.Contains("é o grande BODE OF WAR!"))
            {
                EmJogo = false;
                MessageBox.Show("O vencedor é " + txtVez.Text);
            }
        }

        /// <summary>
        /// Trata o retorno de BodeOfWarServer.VerificarVez, bate com o retorno de BodeOfWarServer.ListarJogadores
        /// </summary>
        /// <returns>Nome do jogador que deve atuar</returns>
        private string VerificarVez()
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(partida.Id);
            string vez = BodeOfWarServer.Jogo.VerificarVez(partida.Id);

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
        /// 1. Joga uma carta baseada no índice da mesma na array em jogador.Mao
        /// 2. Incrementa a rodada
        /// 3. Traz o painel atrás da carta para frente
        /// </summary>
        /// <param name="index"></param>
        /// <returns>true se foi possível jogar e false se não foi possível jogar</returns>
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
                VerMesa();
                panels[index].BringToFront();
                return true;
            }
        }

        /// <summary>
        /// 1. Trabalha os valores retornados em BodeOfWarServer.VerificarIlha e guarda cada valor em ilha1Global e ilha2Global
        /// </summary>
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
            }
        }

        /// <summary>
        /// Popula a lista Mesa com o retorno tratado e BodeOfWar.VerificarMesa
        /// </summary>
        /// <param name="rodada"></param>
        private void PopularMesa(int rodada)
        {
            string[] aux;

            string ret = BodeOfWarServer.Jogo.VerificarMesa(partida.Id, rodada);

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


        //ATENÇÃO -> O código abaixo é o trecho que mais deu trabalho e eu tenho maior orgulho - Vinicius Petratti

        /// <summary>
        /// 1. Popula as listas na array CartasPorJogador de forma MAGNÍFICA
        /// 2. Define as listas de PictureBoxes de imagem das cartas jogadas por cada jogador e cria uma matriz com as mesmas (lista de lista)
        /// 3. Define as listas de Labels de bodes das cartas jogadas por cada jogador e cria uma matriz com as mesmas (lista de lista)
        /// 4. Define as listas de Labels de ids das cartas jogadas por cada jogador e cria uma matriz com as mesmas (lista de lista)
        /// </summary>
        private void VerMesa()
        {
            AtualizarDetalhes();

            /// 1
            //Compara cada item na Mesa com os Ids dos jogadores e adiciona a carta na lista na array CartasPorJogador que tem o mesmo índice do jogador em idJogadoresInt se a carta já não estiver adicionada
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

            /// 2
            //Listas das PictureBoxes de cartas jogadas por cada jogador
            Jogador1 = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            Jogador2 = new List<PictureBox>() { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            Jogador3 = new List<PictureBox>() { pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24 };
            Jogador4 = new List<PictureBox>() { pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32 };

            //Define a matriz de PictureBoxes de imagens
            MesaJogadoresImagem = new List<List<PictureBox>> { Jogador1, Jogador2, Jogador3, Jogador4 };

            /// 3
            //Listas de Labels de bodes das cartas jogadas por cada jogador
            Jogador1Bodes = new List<Label>() { lblBodeJogador1, lblBodeJogador2, lblBodeJogador3, lblBodeJogador4, lblBodeJogador5, lblBodeJogador6, lblBodeJogador7, lblBodeJogador8 };
            Jogador2Bodes = new List<Label>() { lblBodeJogador9, lblBodeJogador10, lblBodeJogador11, lblBodeJogador12, lblBodeJogador13, lblBodeJogador14, lblBodeJogador15, lblBodeJogador16 };
            Jogador3Bodes = new List<Label>() { lblBodeJogador17, lblBodeJogador18, lblBodeJogador19, lblBodeJogador20, lblBodeJogador21, lblBodeJogador22, lblBodeJogador23, lblBodeJogador24 };
            Jogador4Bodes = new List<Label>() { lblBodeJogador25, lblBodeJogador26, lblBodeJogador27, lblBodeJogador28, lblBodeJogador29, lblBodeJogador30, lblBodeJogador31, lblBodeJogador32 };

            //Matriz de labels de bodes
            MesaJogadoresBode = new List<List<Label>>() { Jogador1Bodes, Jogador2Bodes, Jogador3Bodes, Jogador4Bodes };

            /// 4
            //Listas de Labels de ids das cartas jogadas por cada jogador
            Jogador1Ids = new List<Label>() { lblIdJogador1, lblIdJogador2, lblIdJogador3, lblIdJogador4, lblIdJogador5, lblIdJogador6, lblIdJogador7, lblIdJogador8 };
            Jogador2Ids = new List<Label>() { lblIdJogador9, lblIdJogador10, lblIdJogador11, lblIdJogador12, lblIdJogador13, lblIdJogador14, lblIdJogador15, lblIdJogador16 };
            Jogador3Ids = new List<Label>() { lblIdJogador17, lblIdJogador18, lblIdJogador19, lblIdJogador20, lblIdJogador21, lblIdJogador22, lblIdJogador23, lblIdJogador24 };
            Jogador4Ids = new List<Label>() { lblIdJogador25, lblIdJogador26, lblIdJogador27, lblIdJogador28, lblIdJogador29, lblIdJogador30, lblIdJogador31, lblIdJogador32 };

            //Matriz de labels de ids
            MesaJogadoresIds = new List<List<Label>>() { Jogador1Ids, Jogador2Ids, Jogador3Ids, Jogador4Ids };

            int count = 0;

            ///Para cada item para cada lista de PictureBox na Matriz de Pictureboxes
            ///Para cada carta na lista de cartas da matriz CartasPorJogador
            ///Para cada objeto em TodasCartas
            ///O item recebe a imagem do objeto em TodasCartas cujo id é igual ao da carta 
            foreach (List<PictureBox> l in MesaJogadoresImagem)
            {
                foreach (PictureBox p in l)
                {
                    foreach (int cartas in CartasPorJogador[count])
                    {
                        if (l.IndexOf(p) == CartasPorJogador[count].IndexOf(cartas))
                        {
                            foreach (Cartas carta in partida.TodasCartas)
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
                count++;
            }

            ///Para cada item para cada lista de Labels na Matriz de Labels de bode
            ///Para cada carta na lista de cartas da matriz CartasPorJogador
            ///Para cada objeto em TodasCartas
            ///O item recebe o texto de bode do objeto em TodasCartas cujo id é igual ao da carta 
            count = 0;
            foreach (List<Label> label in MesaJogadoresBode)
            {
                foreach (Label l in label)
                {
                    foreach (int cartas in CartasPorJogador[count])
                    {
                        if (label.IndexOf(l) == CartasPorJogador[count].IndexOf(cartas))
                        {
                            foreach (Cartas carta in partida.TodasCartas)
                            {
                                if (carta.id == cartas)
                                {
                                    l.Text = carta.bode.ToString();
                                }
                            }
                        }
                    }
                }
                count++;
            }

            ///Para cada item para cada lista de Labels na Matriz de Labels de ids
            ///Para cada carta na lista de cartas da matriz CartasPorJogador
            ///Para cada objeto em TodasCartas
            ///O item recebe o texto de id do objeto em TodasCartas cujo id é igual ao da carta
            count = 0;
            foreach (List<Label> label in MesaJogadoresIds)
            {
                foreach (Label l in label)
                {
                    foreach (int cartas in CartasPorJogador[count])
                    {
                        if (label.IndexOf(l) == CartasPorJogador[count].IndexOf(cartas))
                        {
                            foreach (Cartas carta in partida.TodasCartas)
                            {
                                if (carta.id == cartas)
                                {
                                    l.Text = carta.id.ToString();
                                }
                            }
                        }
                    }
                }
                count++;
            }
        }

        /// <summary>
        /// Automação do jogo modo aleatório
        /// </summary>
        private void IniciarAutoRandom()
        {
            if(EmJogo == false)
            {
                timer.Stop();
                return;
            }

            bool loop = true;
            timer.Stop();
            AtualizarDetalhes();

            //Verifica se é a vez deste jogador
            if (VerificarVez() == jogador.Nome)
            {
                string[] ret = BodeOfWarServer.Jogo.VerificarVez(partida.Id).Split(',');

                //Verifica se é hora de escolher ilha
                if (ret[3].Contains("I"))
                {
                    VerIlhas();

                    int random = new Random().Next(1, 2);

                    //Escolher uma ilha aleatória
                    if (random == 1)
                    {
                        BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha1Global);
                        AtualizarDetalhes();
                        timer.Start();
                    }

                    if (random == 2)
                    {
                        BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, ilha2Global);
                        AtualizarDetalhes();
                        timer.Start();
                    }
                }

                //Verifica se é hora de jogar uma carta
                if (ret[3].Contains("B"))
                {
                    int rand = new Random().Next(0, 8);

                    while (loop)
                    {
                        ///Joga uma carta aleatória se o número gerado não está na lista de cartas jogadas
                        if (!(CartasJogadas.Contains(rand)))
                        {
                            Jogar(rand);
                            CartasJogadas.Add(rand);
                            timer.Start();
                            loop = false;
                        }
                        else
                        {
                            rand = new Random().Next(0, 8);
                        }
                    }
                }
            }
            timer.Start();
        }

        //Dinâmica dos botões
        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            IniciarAutoRandom();
        }
    }
}
