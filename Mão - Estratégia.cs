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
        User User;

        Partida partida;

        Main pai;

        MãoEstratégiaStatus status;

        int ilha1Global;
        int ilha2Global;

        List<PictureBox> imagens;
        List<Label> bodes;
        List<Label> ids;
        Panel[] panels;

        List<List<PictureBox>> MesaJogadoresImagem;
        List<List<Label>> MesaJogadoresBode;
        List<List<Label>> MesaJogadoresIds;
        List<PictureBox> ImagensJogadores;

        /// <summary>
        /// Define o jogador e inicializa partida
        /// </summary>
        /// <param name="user"></param>
        public MaoEstrategia(User user, Main pai, Partida partida)
        {
            this.User = user;
            this.partida = partida;
            //partida = new Partida(jogador.idPartida);
            this.status = new MãoEstratégiaStatus()
            {
                Owner = this
            };
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
            lblJogador.Text = "Você: " + User.Nome;

            //Popular a Jogador.MaoId
            for (int i = 0; i < User.Mao.Count; i++)
            {
                User.MaoId.Add(User.Mao[i].id);
            }

            //Criação de listas com todas as PictureBoxes e Labels do formulário
            imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8 };
            bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8 };
            ids = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8 };

            /*
            int count = 0;
            foreach (PictureBox p in imagens)
            {
                p.Image = User.Mao[count].imagem;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                count++;
            }

            //Loop para troca do texto da label Bode para o atributo do objeto
            count = 0;
            foreach (Label label in bodes)
            {
                label.Text = User.Mao[count].bode.ToString();
                count++;
            }

            //Loop para troca do texto da label Numero para o atributo do objeto
            count = 0;
            foreach (Label l in ids)
            {
                l.Text = User.Mao[count].id.ToString();
                count++;
            }
            */

            for (int i = 0; i < User.Mao.Count(); i++)
            {
                /*
                if (!(User.Mao[i] == null))
                {
                    imagens[i].Image = User.Mao[i].imagem;
                    imagens[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    bodes[i].Text = User.Mao[i].bode.ToString();
                    ids[i].Text = User.Mao[i].id.ToString();
                }
                */

                imagens[i].Image = User.Mao[i].imagem;
                imagens[i].SizeMode = PictureBoxSizeMode.StretchImage;
                bodes[i].Text = User.Mao[i].bode.ToString();
                ids[i].Text = User.Mao[i].id.ToString();
            }

            partida.PopularJogadores();

            //Lista de PictureBoxes dos jogadores
            ImagensJogadores = new List<PictureBox> { pcbJogador1, pcbJogador2, pcbJogador3, pcbJogador4 };

            //Mostrando as imagens
            for (int i = 0; i <= partida.QntJogadores - 1; i++)
            {
                ImagensJogadores[i].Visible = true;
            }

            User.IndiceJogador = partida.idJogadores.IndexOf(User.Id);

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
            txtListarJogadores.Text = partida.ListarJogadores();
            txtVez.Text = partida.VerificarVez();
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(partida.Id);
            partida.PopularMesa();
            VerMesa();
            status.UpdateJogadores(partida.Jogadores);
            if (partida.Rodada != 0)
            {
                status.UpdateMetricas(partida.Jogadores, partida.Rodada, partida.TamanhoIlha());
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
            string ret = BodeOfWarServer.Jogo.Jogar(User.Id, User.Senha, ID);
            if (ret.StartsWith("ERRO"))
            {
                MessageBox.Show(ret);
                return false;
            }
            else
            {
                int indexCarta = -1;
                foreach (Cartas carta in User.Mao)
                {
                    if (carta.id == ID)
                    {
                        indexCarta = User.Mao.IndexOf(carta);
                    }
                }
                User.Mao.RemoveAt(indexCarta);
                panels[User.MaoId.IndexOf(ID)].BringToFront();
                partida.Rodada++;

                AtualizarDetalhes();
                return true;
            }
        }

        /// <summary>
        /// 1. Trabalha os valores retornados em BodeOfWarServer.VerificarIlha e guarda cada valor em ilha1Global e ilha2Global
        /// </summary>
        private void VerIlhas()
        {
            string retIlha = BodeOfWarServer.Jogo.VerificarIlha(User.Id, User.Senha);

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
                foreach (Jogador adversário in partida.Jogadores)
                {
                    if (adversário.Id == id)
                    {
                        adversário.AdicionarCartasJogadas(carta);
                    }
                }
            }

            /// 2
            //Listas das PictureBoxes de cartas jogadas por cada jogador
            List<PictureBox> Jogador1 = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            List<PictureBox> Jogador2 = new List<PictureBox>() { pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            List<PictureBox> Jogador3 = new List<PictureBox>() { pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24 };
            List<PictureBox> Jogador4 = new List<PictureBox>() { pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32 };

            //Define a matriz de PictureBoxes de imagens
            MesaJogadoresImagem = new List<List<PictureBox>> { Jogador1, Jogador2, Jogador3, Jogador4 };

            /// 3
            //Listas de Labels de bodes das cartas jogadas por cada jogador
            List<Label> Jogador1Bodes = new List<Label>() { lblBodeJogador1, lblBodeJogador2, lblBodeJogador3, lblBodeJogador4, lblBodeJogador5, lblBodeJogador6, lblBodeJogador7, lblBodeJogador8 };
            List<Label> Jogador2Bodes = new List<Label>() { lblBodeJogador9, lblBodeJogador10, lblBodeJogador11, lblBodeJogador12, lblBodeJogador13, lblBodeJogador14, lblBodeJogador15, lblBodeJogador16 };
            List<Label> Jogador3Bodes = new List<Label>() { lblBodeJogador17, lblBodeJogador18, lblBodeJogador19, lblBodeJogador20, lblBodeJogador21, lblBodeJogador22, lblBodeJogador23, lblBodeJogador24 };
            List<Label> Jogador4Bodes = new List<Label>() { lblBodeJogador25, lblBodeJogador26, lblBodeJogador27, lblBodeJogador28, lblBodeJogador29, lblBodeJogador30, lblBodeJogador31, lblBodeJogador32 };

            //Matriz de labels de bodes
            MesaJogadoresBode = new List<List<Label>>() { Jogador1Bodes, Jogador2Bodes, Jogador3Bodes, Jogador4Bodes };

            /// 4
            //Listas de Labels de ids das cartas jogadas por cada jogador
            List<Label> Jogador1Ids = new List<Label>() { lblIdJogador1, lblIdJogador2, lblIdJogador3, lblIdJogador4, lblIdJogador5, lblIdJogador6, lblIdJogador7, lblIdJogador8 };
            List<Label> Jogador2Ids = new List<Label>() { lblIdJogador9, lblIdJogador10, lblIdJogador11, lblIdJogador12, lblIdJogador13, lblIdJogador14, lblIdJogador15, lblIdJogador16 };
            List<Label> Jogador3Ids = new List<Label>() { lblIdJogador17, lblIdJogador18, lblIdJogador19, lblIdJogador20, lblIdJogador21, lblIdJogador22, lblIdJogador23, lblIdJogador24 };
            List<Label> Jogador4Ids = new List<Label>() { lblIdJogador25, lblIdJogador26, lblIdJogador27, lblIdJogador28, lblIdJogador29, lblIdJogador30, lblIdJogador31, lblIdJogador32 };

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
                    foreach (int cartas in partida.CartasPorJogador[count])
                    {
                        if (label.IndexOf(l) == partida.CartasPorJogador[count].IndexOf(cartas))
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
                    foreach (int cartas in partida.CartasPorJogador[count])
                    {
                        if (label.IndexOf(l) == partida.CartasPorJogador[count].IndexOf(cartas))
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
        /// Preciso comentar ainda
        /// </summary>
        private void Analise()
        {
            status.UpdateStatus(CasoGeral: 2);
            AtualizarDetalhes();

            //Verifica se é a vez deste jogador
            if (partida.VerificarVez() == User.Nome)
            {
                if (partida.Rodada != 0)
                {
                    status.UpdateUltimoPerdedor(partida.VerificarQuemPerdeuAnterior());
                    status.UpdateUltimoVencedor(partida.VerificarQuemVenceuAnterior());
                }

                string[] ret = BodeOfWarServer.Jogo.VerificarVez(partida.Id).Split(',');

                //Verifica se é hora de escolher ilha
                if (ret[3].Contains("I"))
                {
                    status.UpdateStatus(Automacao: 3, Mesa: 6);
                    int bodes = partida.Jogadores[User.IndiceJogador].Bodes;
                    if (bodes > partida.TamanhoIlha())
                    {
                        status.UpdateStatus(Mao: 3, Decisao: 6);
                        VerIlhas();
                        BodeOfWarServer.Jogo.DefinirIlha(User.Id, User.Senha, Math.Max(ilha1Global, ilha2Global));
                        return;
                    }
                    else
                    {
                        status.UpdateStatus(Mao: 4, Decisao: 7);
                        VerIlhas();
                        BodeOfWarServer.Jogo.DefinirIlha(User.Id, User.Senha, Math.Min(ilha1Global, ilha2Global));
                        return;
                    }
                }

                //Verifica se é hora de jogar uma carta
                if (ret[3].Contains("B"))
                {
                    status.UpdateStatus(Automacao: 4);
                    //Se for a primeira rodada
                    if (partida.Rodada == 0)
                    {
                        status.UpdateStatus(Mesa: 7, Decisao: 8);
                        int rand = new Random().Next(0, 7);
                        Jogar(User.Mao[rand].id);
                        return;
                    }
                    else
                    {
                        int bodes = partida.Jogadores[User.IndiceJogador].Bodes;
                        int tamanhoIlha = partida.TamanhoIlha();

                        int fator = ((bodes * 100) / tamanhoIlha);

                        if (fator <= 75)
                        {
                            status.UpdateStatus(Mao: 4);
                            if (User.TemMaiorCarta(partida.CartasJogadas()))
                            {
                                status.UpdateStatus(Mesa: 1, Decisao: 1);
                                Jogar(User.MaiorCarta());
                                return;
                            }
                            else
                            {
                                status.UpdateStatus(Mesa: 4, Decisao: 4);
                                Jogar(User.MaiorBode());
                                return;
                            }
                        }
                        else if (fator > 75 && fator <= 100)
                        {
                            status.UpdateStatus(Mao: 5);
                            if (User.TemMaiorCarta(partida.CartasJogadas()))
                            {
                                status.UpdateStatus(Mesa: 1);
                                if (partida.AlguémVaiEstourar())
                                {
                                    status.UpdateStatus(Mesa: 8);
                                    if (User.TemCartaMenorQue(partida.CartasJogadas().Max()))
                                    {
                                        if (User.TemCartaClasse(4))
                                        {
                                            Jogar(User.CartaClasse(4));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(5))
                                        {
                                            Jogar(User.CartaClasse(5));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(6))
                                        {
                                            Jogar(User.CartaClasse(6));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(1))
                                        {
                                            Jogar(User.CartaClasse(1));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(2))
                                        {
                                            Jogar(User.CartaClasse(2));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(3))
                                        {
                                            Jogar(User.CartaClasse(3));
                                            return;
                                        }
                                        else
                                        {
                                            Jogar(User.Descartar(partida.CartasJogadas()));
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    status.UpdateStatus(Mesa: 9);
                                    if (User.FazSentidoComprar(partida.CartasJogadas(), partida.TamanhoIlha()))
                                    {
                                        status.UpdateStatus(Mesa: 9, Decisao: 9);
                                        Jogar(User.CartaMaiorQueMesa(partida.CartasJogadas()));
                                        return;
                                    }
                                    else
                                    {
                                        status.UpdateStatus(Mesa: 10, Decisao: 3);
                                        Jogar(User.Descartar(partida.CartasJogadas()));
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                status.UpdateStatus(Mesa: 4, Decisao: 4);
                                Jogar(User.MaiorBode());
                                return;
                            }
                        }
                        else if (fator > 100 && fator <= 110)
                        {
                            status.UpdateStatus(Mao: 6);
                            if (partida.Rodada <= 4)
                            {
                                if (User.TemMenorCarta(partida.CartasJogadas()))
                                {
                                    status.UpdateStatus(Mesa: 3, Decisao: 2);
                                    Jogar(User.MenorCarta());
                                    return;
                                }
                                else
                                {
                                    status.UpdateStatus(Mesa: 4, Decisao: 5);
                                    Jogar(User.MenorBode());
                                    return;
                                }
                            }
                            else
                            {
                                if (partida.AlguémVaiEstourar())
                                {
                                    status.UpdateStatus(Mesa: 8);
                                    if (User.TemCartaMenorQue(partida.CartasJogadas().Max()))
                                    {
                                        if (User.TemCartaClasse(4))
                                        {
                                            Jogar(User.CartaClasse(4));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(5))
                                        {
                                            Jogar(User.CartaClasse(5));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(6))
                                        {
                                            Jogar(User.CartaClasse(6));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(1))
                                        {
                                            Jogar(User.CartaClasse(1));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(2))
                                        {
                                            Jogar(User.CartaClasse(2));
                                            return;
                                        }
                                        else if (User.TemCartaClasse(3))
                                        {
                                            Jogar(User.CartaClasse(3));
                                            return;
                                        }
                                        else
                                        {
                                            Jogar(User.Descartar(partida.CartasJogadas()));
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (User.TemMenorCarta(partida.CartasJogadas()))
                                        {
                                            status.UpdateStatus(Mesa: 3, Decisao: 2);
                                            Jogar(User.MenorCarta());
                                            return;
                                        }
                                        else
                                        {
                                            status.UpdateStatus(Mesa: 4, Decisao: 5);
                                            Jogar(User.MenorBode());
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    status.UpdateStatus(Mesa: 9);
                                    if (User.TemMenorCarta(partida.CartasJogadas()))
                                    {
                                        status.UpdateStatus(Mesa: 3, Decisao: 2);
                                        Jogar(User.MenorCarta());
                                        return;
                                    }
                                    else
                                    {
                                        status.UpdateStatus(Mesa: 4, Decisao: 5);
                                        Jogar(User.MenorBode());
                                        return;
                                    }
                                }
                            }
                        }
                        if (fator > 110)
                        {
                            status.UpdateStatus(Mao: 3);
                            if (User.TemMenorCarta(partida.CartasJogadas()))
                            {
                                status.UpdateStatus(Mesa: 3, Decisao: 2);
                                Jogar(User.MenorCarta());
                                return;
                            }
                            else
                            {
                                status.UpdateStatus(Mesa: 4, Decisao: 5);
                                Jogar(User.MenorBode());
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                status.UpdateStatus(Automacao: 5);
                return;
            }
        }

        //Dinâmica dos controles
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            status.UpdateStatus(CasoGeral: 1);
            timer.Start();
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
            Analise();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            AtualizarDetalhes();
            if (partida.JaTemVencedor())
            {
                status.UpdateStatus(3);
                timer.Stop();
            }
            else
            {
                status.UpdateStatus(CasoGeral: 1);
                timer.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jogar(User.Mao[0].id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jogar(User.Mao[1].id);
        }
    }
}
