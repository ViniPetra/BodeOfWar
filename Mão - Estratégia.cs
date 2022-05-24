using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace BodeOfWar
{
    public partial class MaoEstrategia : Form
    {
        Jogador jogador;

        Partida partida;

        Main pai;

        MãoEstratégiaStatus status;

        int ilha1Global;
        int ilha2Global;

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
        /// Define o jogador e inicializa partida
        /// </summary>
        /// <param name="user"></param>
        public MaoEstrategia(Jogador user, Main pai)
        {
            jogador = user;
            partida = new Partida();
            status = new MãoEstratégiaStatus(jogador, partida, this);
            status.Owner = this;
            this.pai = pai;
            InitializeComponent();
        }

        /// <summary>
        /// 1. Inicializa as listas da array partida.CartasPorJogador
        /// 2. Define as listas imagens, bodes e ids
        /// 3. Define a label de nome do jogador
        /// 4. Define as imagens das PictureBox da lista imagens baseado em cada jogador.Mao.imagem
        /// 5. Define os text de cada Label da lista bodes baseado em cada jogador.Mao.bode
        /// 6. Define os text de cada Label da lista ids baseado em cada jogador.Mao.id
        /// 7. Popula a partida.IdJogadores
        /// 8. Torna visível a mesma quantidade de PicturBoxes de imagem dos jogadores que a quantidade de jogadores na partida
        /// 9. Define o ídice do jogador na lista de jogadores
        /// </summary>
        private void Carregar()
        {
            //Inicializa as listas na array partida.CartasPorJogador
            partida.CartasPorJogador[0] = new List<int>();
            partida.CartasPorJogador[1] = new List<int>();
            partida.CartasPorJogador[2] = new List<int>();
            partida.CartasPorJogador[3] = new List<int>();

            AtualizarDetalhes();

            //Seu nome na tela!
            lblJogador.Text = "Você: " + jogador.Nome;

            //Popular a Jogador.MaoId
            for (int i = 0; i < jogador.Mao.Count; i++)
            {
                jogador.MaoId.Add(jogador.Mao[i].id);
            }

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

            partida.PopularJogadores(jogador.idPartida);

            //Lista de PictureBoxes dos jogadores
            ImagensJogadores = new List<PictureBox> { pcbJogador1, pcbJogador2, pcbJogador3, pcbJogador4 };

            //Mostrando as imagens
            for (int i = 0; i <= partida.QntJogadores - 1; i++)
            {
                ImagensJogadores[i].Visible = true;
            }

            jogador.IndiceJogador = partida.idJogadores.IndexOf(jogador.Id);

            status.Config_UpdateJogadores(partida.Jogadores);

            status.Show();

            status.Left = this.Location.X + this.Size.Width - 10;
            status.Top = this.Location.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AtualizarDetalhes()
        {
            txtListarJogadores.Text = partida.ListarJogadores(jogador.idPartida);
            txtVez.Text = partida.VerificarVez(jogador.idPartida);
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(jogador.idPartida);
            partida.PopularMesa(partida.rodada, jogador.idPartida);
            VerMesa();
            status.UpdateJogadores(partida.Jogadores);
            //
            if (partida.rodada != 0)
            {
                status.UpdateMetricas(partida.Jogadores, partida.rodada, partida.TamanhoIlha(jogador.idPartida));
            }

            if (partida.JaTemVencedor(jogador.idPartida))
            {
                timer.Stop();
                partida.EmJogo = false;
                status.UpdateStatusAuto(9);
                status.UpdateDecisao(9);
                status.UpdateStatusMao(9);
                status.UpdateStatusMesa(4);
            }
        }

        /// <summary>
        /// 1. Joga uma carta baseado no Id da mesma na classe
        /// 2. Incrementa a partida.rodada
        /// 3. Traz o painel atrás da carta para frente
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>true se foi possível jogar e false se não foi possível jogar</returns>
        private bool Jogar(int ID)
        {
            panels = new Panel[8] { pnlCarta1, pnlCarta2, pnlCarta3, pnlCarta4, pnlCarta5, pnlCarta6, pnlCarta7, pnlCarta8 };
            string ret = BodeOfWarServer.Jogo.Jogar(jogador.Id, jogador.Senha, ID);
            if (ret.StartsWith("ERRO"))
            {
                MessageBox.Show(ret);
                return false;
            }
            else
            {
                int indexCarta = -1;
                foreach (Cartas carta in jogador.Mao)
                {
                    if (carta.id == ID)
                    {
                        indexCarta = jogador.Mao.IndexOf(carta);
                    }
                }
                jogador.Mao.RemoveAt(indexCarta);
                panels[jogador.MaoId.IndexOf(ID)].BringToFront();
                partida.rodada++;

                status.UpdateStatusAuto(0);
                status.UpdateStatusMao(0);
                status.UpdateStatusMesa(4);
                status.UpdateDecisao(7);

                AtualizarDetalhes();
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

        //ATENÇÃO -> O código abaixo é o trecho que mais deu trabalho e eu tenho maior orgulho - Vinicius Petratti

        /// <summary>
        /// 1. Popula as listas na array CartasPorJogador de forma MAGNÍFICA
        /// 2. Define as listas de PictureBoxes de imagem das cartas jogadas por cada jogador e cria uma matriz com as mesmas (lista de lista)
        /// 3. Define as listas de Labels de bodes das cartas jogadas por cada jogador e cria uma matriz com as mesmas (lista de lista)
        /// 4. Define as listas de Labels de ids das cartas jogadas por cada jogador e cria uma matriz com as mesmas (lista de lista)
        /// </summary>
        private void VerMesa()
        {
            /// 1
            //Compara cada item na partida.Mesa com os Ids dos jogadores e adiciona a carta na lista na array CartasPorJogador que tem o mesmo índice do jogador em partida.idJogadores se a carta já não estiver adicionada

            foreach (string a in partida.Mesa)
            {
                string[] b = a.Split(',');

                int id = Int32.Parse(b[0]);
                int carta = Int32.Parse(b[1]);

                foreach (int index in partida.idJogadores)
                {
                    if (index == id)
                    {
                        if (!(partida.CartasPorJogador[partida.idJogadores.IndexOf(id)].Contains(carta)))
                        {
                            partida.CartasPorJogador[partida.idJogadores.IndexOf(id)].Add(carta);
                        }
                    }
                }

                //comentar
                foreach (Adversário adversário in partida.Jogadores)
                {
                    if (adversário.id == id)
                    {
                        adversário.AdicionarCartasJogadas(carta);
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
                    foreach (int cartas in partida.CartasPorJogador[count])
                    {
                        if (l.IndexOf(p) == partida.CartasPorJogador[count].IndexOf(cartas))
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
                    foreach (int cartas in partida.CartasPorJogador[count])
                    {
                        if (label.IndexOf(l) == partida.CartasPorJogador[count].IndexOf(cartas))
                        {
                            foreach (Cartas carta in jogador.TodasCartas)
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
                    foreach (int cartas in partida.CartasPorJogador[count])
                    {
                        if (label.IndexOf(l) == partida.CartasPorJogador[count].IndexOf(cartas))
                        {
                            foreach (Cartas carta in jogador.TodasCartas)
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

        //Dinâmica dos botões
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timer.Start();
            status.UpdateStatusAuto(0);
        }

        private void txtNarracao_DoubleClick(object sender, EventArgs e)
        {
            AtualizarDetalhes();
        }

        private void timer_Tick(object sender, EventArgs e)
        { 
            if (partida.EmJogo == true)
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// Preciso comentar ainda
        /// </summary>
        private void Analise()
        { 
            //timer.Stop();
            AtualizarDetalhes();

            //Verifica se é a vez deste jogador
            if (partida.VerificarVez(jogador.idPartida) == jogador.Nome)
            {
                if (partida.rodada != 0)
                {
                    status.UpdateUltimoPerdedor(partida.VerificarQuemPerdeuAnterior(jogador.TodasCartas));
                    status.UpdateUltimoVencedor(partida.VerificarQuemVenceuAnterior());
                }

                string[] ret = BodeOfWarServer.Jogo.VerificarVez(jogador.idPartida).Split(',');

                //Verifica se é hora de escolher ilha
                if (ret[3].Contains("I"))
                {
                    status.UpdateStatusAuto(2);
                    status.UpdateStatusMesa(5);

                    int bodes = jogador.BodesComprados();
                    if (bodes > partida.TamanhoIlha(jogador.idPartida))
                    {
                        status.UpdateStatusMao(1);
                        status.UpdateDecisao(5);

                        VerIlhas();

                        //Escolher maior ilha
                        BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, Math.Max(ilha1Global, ilha2Global));
                        AtualizarDetalhes();

                        status.UpdateStatusAuto(0);
                        status.UpdateStatusMao(0);
                        status.UpdateStatusMesa(4);
                        status.UpdateDecisao(7);

                        return;
                    }
                    else
                    {
                        status.UpdateStatusMao(2);
                        status.UpdateDecisao(6);

                        VerIlhas();

                        //Escolher menor ilha
                        BodeOfWarServer.Jogo.DefinirIlha(jogador.Id, jogador.Senha, Math.Min(ilha1Global, ilha2Global));
                        AtualizarDetalhes();

                        status.UpdateStatusAuto(0);
                        status.UpdateStatusMao(0);
                        status.UpdateStatusMesa(4);
                        status.UpdateDecisao(7);

                        return;
                    }
                }

                //Verifica se é hora de jogar uma carta
                if (ret[3].Contains("B"))
                {
                    status.UpdateStatusAuto(3);

                    //Se for a primeira rodada
                    if ((partida.rodada + 1) == 1)
                    {
                        int rand = new Random().Next(0, 7);
                        Jogar(jogador.Mao[rand].id);
                        return;
                    }
                    else
                    {
                        int bodes = jogador.BodesComprados();
                        int tamanhoIlha = partida.TamanhoIlha(jogador.idPartida);

                        int fator = ((bodes * 100) / tamanhoIlha);

                        if (fator <= 25)
                        {
                            status.UpdateStatusMao(2);
                            if (jogador.TemMaiorCarta(partida.CartasJogadas(jogador.idPartida)))
                            {
                                status.UpdateStatusMesa(0);
                                status.UpdateDecisao(0);
                                Jogar(jogador.MaiorCarta());
                                return;
                            }
                            else
                            {
                                status.UpdateStatusMesa(1);
                                status.UpdateDecisao(3);
                                Jogar(jogador.MaiorBode());
                                return;
                            }
                        }
                        if (fator > 25 && fator <= 150)
                        {
                            /*
                            if (!jogador.TemMaiorCarta(partida.CartasJogadas(jogador.idPartida)))
                            {
                                status.UpdateStatusMesa(1);
                                status.UpdateDecisao(2);
                                Jogar(jogador.Descartar(partida.CartasJogadas(jogador.idPartida)));
                                //timer.Start();
                                return;
                            }
                            else
                            {
                                status.UpdateStatusMesa(1);
                                status.UpdateDecisao(3);
                                Jogar(jogador.Mao[((jogador.Mao.Count())) / 2].id);
                                //timer.Start();
                                return;
                            }
                            */

                            status.UpdateStatusMesa(9);
                            status.UpdateDecisao(2);
                            Jogar(jogador.Descartar(partida.CartasJogadas(jogador.idPartida)));
                            return;
                        }
                        if (fator > 150)
                        {
                            status.UpdateStatusMao(1);
                            if (jogador.TemMenorCarta(partida.CartasJogadas(jogador.idPartida)))
                            {
                                status.UpdateStatusMesa(2);
                                status.UpdateDecisao(1);
                                Jogar(jogador.MenorCarta());
                                return;
                            }
                            else
                            {
                                status.UpdateStatusMesa(3);
                                status.UpdateDecisao(3);
                                Jogar(jogador.MaiorBode());
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                status.UpdateStatusAuto(4);
                status.UpdateStatusMao(0);
                status.UpdateStatusMesa(4);
                status.UpdateDecisao(7);
                return;
            }
        }

        private void MaoEstrategia_LocationChanged(object sender, EventArgs e)
        {
            status.Left = this.Location.X + this.Size.Width -10;
            status.Top = this.Location.Y;
        }

        private void Mão_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void MaoEstrategia_FormClosed(object sender, FormClosedEventArgs e)
        {
            pai.AtualizarDetalhes();
            timer.Stop();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            timer.Stop();
            status.UpdateStatusAuto(1);
            Analise();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AtualizarDetalhes();
            status.UpdateStatusAuto(0);
            timer.Start();
        }
    }
}
