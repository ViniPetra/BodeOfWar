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
    public partial class Main : Form
    {
        public List<Cartas> TodasCartas = new List<Cartas>();
        public User user = new User();

        //Variáeis de estado
        public int PartidaAberta;

        public Main()
        {
            InitializeComponent();
            Inicializar();
        }

        /// <summary>
        /// 1. Instancia um objeto para cada carta do jogo
        /// 2. Cria a lista com todos os objetos de carta 
        /// 3. Define o atributo de todas as cartas no jogador 
        /// </summary>
        public void Inicializar()
        {
            pnlMenu.BringToFront();

            //Mostra a versão do servidor
            string Versao = BodeOfWarServer.Jogo.Versao;
            lblVersao.Text = Versao;

            //Parse do retorno de ListarCartas() em uma array
            //Cartas1 {1, 1, 5, 2, 2, 5, ...}
            string retCartas = BodeOfWarServer.Jogo.ListarCartas();
            retCartas = retCartas.Replace("\r", "");
            retCartas = retCartas.Substring(0, retCartas.Length - 1);
            retCartas = retCartas.Replace("\n", ","); ;
            string[] Cartas1 = retCartas.Split(',');

            //Declaração da nova array que receberá int
            int[] IntCartas1 = new int[Cartas1.Length];

            //Declaração da matriz de todas as cartas
            int[,] Cartas2 = new int[50, 3];

            int i;

            //Converter a array em int
            for (i = 0; i < Cartas1.Length; i++)
            {
                IntCartas1[i] = Int32.Parse(Cartas1[i]);
            }

            //Criação da matriz
            for (i = 0; i <= 149; i += 3)
            {
                Cartas2[(i / 3), 0] = IntCartas1[i];
            }

            for (i = 1; i <= 149; i += 3)
            {
                Cartas2[(i / 3), 1] = IntCartas1[i];
            }

            for (i = 2; i <= 149; i += 3)
            {
                Cartas2[(i / 3), 2] = IntCartas1[i];
            }

            //Adição à lista com filtros
            for (i = 0; i <= 49; i++)
            {
                if (Cartas2[i, 0] <= 16 && Cartas2[i, 1] <= 2)
                {
                    this.TodasCartas.Add(new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2], 1));
                }
                else if (Cartas2[i, 0] > 16 && Cartas2[i, 0] <= 32 && Cartas2[i, 1] <= 2)
                {
                    this.TodasCartas.Add(new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2], 2));
                }
                else if (Cartas2[i, 0] > 32 && Cartas2[i, 1] <= 2)
                {
                    this.TodasCartas.Add(new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2], 3));
                }
                else if (Cartas2[i, 0] <= 16 && Cartas2[i, 1] > 2)
                {
                    this.TodasCartas.Add(new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2], 4));
                }
                else if (Cartas2[i, 0] > 16 && Cartas2[i, 0] <= 32 && Cartas2[i, 1] > 2)
                {
                    this.TodasCartas.Add(new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2], 5));
                }
                else if (Cartas2[i, 0] > 32 && Cartas2[i, 1] > 2)
                {
                    this.TodasCartas.Add(new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2], 6));
                }
                else
                {
                    throw new Exception("Algo deu ruim na instanciação das cartas");
                }
            }

            //Definição da imagem da Carta
            foreach (Cartas cartas in this.TodasCartas)
            {
                cartas.imagem = (Image)Properties.Resources.ResourceManager.GetObject("b" + cartas.imagemnum);
            }
        }

        /// <summary>
        /// Trata o retorno de BOW.ListarPartidas e adiciona cada partida como um item individual em uma lista.
        /// </summary>
        /// <param name="tipo"></param>
        private void ListarPartidas(string tipo)
        {
            lstPartidas.Items.Clear();

            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas(tipo);

            if (retPartidas == "")
            {
                MessageBox.Show("Nenhuma partida desse tipo encontrada", "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            //Parse da retPartidas para uma array
            //Partidas {(id,nomePartida,DataCriação,Status), (id,nomePartida,DataCriação,Status), (id,nomePartida,DataCriação,Status)}
            retPartidas = retPartidas.Replace("\r", "");
            retPartidas = retPartidas.Substring(0, retPartidas.Length - 1);
            string[] Partidas = retPartidas.Split('\n');

            //Loop de adição das partidas na lista
            for (int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
            }

            //Traz para frente o painel com o tipo de partida selecionada
            pnlListarPartidas2.BringToFront();
        }

        /// <summary>
        /// Mostra o retorno de ListarJogadores na textbox
        /// </summary>
        private void ListarJogadores()
        {
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(this.PartidaAberta);
            if (Jogadores == "")
            {
                Jogadores = "Partida vazia";
            }

            Jogadores = Jogadores.Replace(",", " - ");

            txtListarJogadores.Text = Jogadores;
        }

        /// <summary>
        /// Atualiza as informações em txtVez, txtNarracao, txtJogadores
        /// </summary>
        public void AtualizarDetalhes()
        { 
            ListarJogadores();
            txtVez.Text = VerificarVez();
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(PartidaAberta);
        }

        /// <summary>
        /// Trata o retorno de BOW.VerificarVez, bate com o retorno de BOW.ListarJogadores para trazer o nome do jogador da vez
        /// Controla a disponibilidade dos botões baseado no status da partida
        /// </summary>
        /// <returns>Nome do jogador que é a vez de atuar</returns>
        private string VerificarVez()
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(PartidaAberta);
            string vez = BodeOfWarServer.Jogo.VerificarVez(PartidaAberta);

            //Gerenciamento de erros
            if (vez.StartsWith("ERRO:Partida não está em jogo"))
            {
                nome = "Partida não iniciada";
                return nome;
            }
            if (vez.Contains("ERRO"))
            {
                MessageBox.Show(vez, "Jogo");
                return vez;
            }
            if (jogadores.StartsWith("ERRO"))
            {
                MessageBox.Show(jogadores, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return jogadores;
            }

            //Mostra apenas o nome do jogador da vez
            jogadores = jogadores.Replace("\r", "");
            jogadores = jogadores.Replace("\n", ",");
            string[] Jogadores = jogadores.Split(',');

            //Vez[0] = status da partida
            //Vez[1] = nome
            string[] Vez = vez.Split(',');

            string Status = StatusPartida();

            BotoesMao();

            string NomeJogador = Vez[1];

            //Comparação dos retornos
            for (int i = 0; i < Jogadores.Length; i++)
            {
                if (Jogadores[i] == NomeJogador)
                {
                    nome = Jogadores[i + 1];
                }
            }

            return nome;
        }

        /// <summary>
        /// Responsável pela tela de detalhes da partida
        /// Define a PartidaAberta
        /// </summary>
        /// <param name="PartidaSelecionada"></param>
        public void AbrirPartida(string PartidaSelecionada)
        {
            pnlDetalhesPartida.BringToFront();

            //Parse da string para extração do id
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);

            this.PartidaAberta = idPartida;

            BotoesMao();

            AtualizarDetalhes();
        }

        /// <summary>
        /// 1. Cria uma partida usando as informações em txtNomeCriarPartida e txtSenhaCriarPartida
        /// 2. Define a PartidaAberta
        /// 3. Traz para frente os detalhes da partida criada instantâneamente
        /// </summary>
        public void CriarPartida()
        {
            string nome = txtNomeCriarPartida.Text;
            string senha = txtSenhaCriarPartida.Text;
            string ret = BodeOfWarServer.Jogo.CriarPartida(nome, senha);
            
            if (ret.StartsWith("ERRO"))
            {
                MessageBox.Show(ret, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else MessageBox.Show("Partida criada com sucesso!");

            lstPartidas.Items.Clear();

            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas("T");

            //Parse da retPartidas para uma array
            //Partidas {id,nomePartida,DataCriação,Status, , id,nomePartida,DataCriação,Status, , id,nomePartida,DataCriação,Status, }
            retPartidas = retPartidas.Replace("\r", "");
            retPartidas = retPartidas.Substring(0, retPartidas.Length - 1);
            retPartidas = retPartidas.Replace("\n", ",");
            string[] Partidas = retPartidas.Split(',');

            //Isolar a id da partida mais recente
            int idPartida = Int32.Parse(Partidas[((Partidas.Length) - 4)]);

            PartidaAberta = idPartida;

            AtualizarDetalhes();

            pnlDetalhesPartida.BringToFront();

            txtNomeCriarPartida.Text = "";
            txtSenhaCriarPartida.Text = "";
        }

        /// <summary>
        /// 1. Entra na partida usando as informações em txtNome e txtSenhaPartida
        /// 2. Traz para frente detalhes da partida recém entrada
        /// 3. Define atributos Id, Senha, Nome, Partida.ID e Partida.TodasCartas do User;
        /// </summary>
        private void EntrarPartida()
        {
            string nome = txtNome.Text;
            string senha = txtSenhaPartida.Text;
            string chamada = BodeOfWarServer.Jogo.EntrarPartida(PartidaAberta, nome, senha);

            if (chamada.StartsWith("ERRO"))
            {
                MessageBox.Show(chamada, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                string[] senhaPartida = chamada.Split(',');

                user.Id = Int32.Parse(senhaPartida[0]);
                user.Senha = senhaPartida[1];
                user.Nome = nome;

                user.Partida = new Partida
                {
                    Id = this.PartidaAberta,
                    TodasCartas = this.TodasCartas
                };

                BotoesMao();

                txtNome.Text = "";
                txtSenhaPartida.Text = "";

                AtualizarDetalhes();
            }
        }

        /// <summary>
        /// 1. Inicia a partida em que o jogador está registrado
        /// </summary>
        private void IniciarPartida()
        {
            string retIniciar;

            //Iniciando partida
            retIniciar = BodeOfWarServer.Jogo.IniciarPartida(user.Id, user.Senha);

            //Gerenciamento de erros
            if (retIniciar.StartsWith("ERRO"))
            {
                MessageBox.Show(retIniciar, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            AtualizarDetalhes();
        }

        /// <summary>
        /// Verifica se o usuário está na partida atual
        /// </summary>
        /// <returns>true se está e false se não está</returns>
        private bool NaPartida()
        {
            if(user.Partida.Id == PartidaAberta)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica o status da partida ("A", "J", "E")
        /// </summary>
        /// <returns>status da partida</returns>
        private string StatusPartida()
        {
            string vez = BodeOfWarServer.Jogo.VerificarVez(PartidaAberta);

            //Vez[0] = status da partida
            //Vez[1] = nome
            string[] Vez = vez.Split(',');
            string Status = Vez[0];
            if (Status.StartsWith("ERRO:Partida não"))
            {
                return "A";
            }
            return Status;
        }

        /// <summary>
        /// Define o atributo Mao do User
        /// </summary>
        private void VerificarMao()
        {
            int id = user.Id;
            string senha = user.Senha;

            string StringMao = BodeOfWarServer.Jogo.VerificarMao(id, senha);

            //Parse no retorno e criação da array de ids das cartas da mão
            //StringMao1 {1, 2, 3, 4, 5, 6, 7, 8}
            StringMao = StringMao.Replace("\r", "");
            StringMao = StringMao.Substring(0, StringMao.Length - 1);
            StringMao = StringMao.Replace("\n", ",");
            string[] StringMao1 = StringMao.Split(',');

            //Conversão da array de ids em int
            int[] Mao = new int[StringMao1.Length];
            for (int i = 0; i < StringMao1.Length; i++)
            {
                Mao[i] = Int32.Parse(StringMao1[i]);
            }

            List<Cartas> MinhaMao = new List<Cartas>();

            //Criação da Lista de objetos apenas de cartas próprias
            for (int j = 0; j < Mao.Length; j++)
            {
                for (int i = 0; i < this.TodasCartas.Count; i++)
                {
                    if (this.TodasCartas[i].id == Mao[j])
                    {
                        MinhaMao.Add(this.TodasCartas[i]);
                    }
                }
            }

            user.Mao = MinhaMao;
        }

        /// <summary>
        /// 1. Manual;
        /// 2. Aleatório;
        /// 3. Estratégia;
        /// </summary>
        /// <param name="tipo"></param>
        private void MostrarMao(int tipo)
        {
            if (user.Mao.Any())
            {
                switch (tipo)
                {
                    case 1:
                        MãoManual FormMao = new MãoManual(this.user, this.user.Partida);
                        FormMao.ShowDialog();
                        break;
                    case 2:
                        MaoAuto FormMaoAuto = new MaoAuto(user, this.user.Partida);
                        FormMaoAuto.ShowDialog();
                        break;
                    case 3:
                        MaoEstrategia FormMaoEstrategia = new MaoEstrategia(user, this, this.user.Partida);
                        FormMaoEstrategia.ShowDialog();
                        break;
                }
            }
            else
            {
                VerificarMao();
                MostrarMao(tipo);
            }
        }

        //Dinâmica UI

        /// <summary>
        /// Todas as funções abaixo são da dinâmica de telas
        /// </summary>

        private void BotoesMao()
        {
            string status = StatusPartida();
            bool napartida = NaPartida();
            if (napartida && status == "A")
            {
                pnlDentroPartida.BringToFront();
                btnAutomatico.Enabled = false;
                btnManual.Enabled = false;
                btnEstrategia.Enabled = false;
                btnIniciarPartida.Enabled = true;
            }
            else if (napartida && status == "J")
            {
                pnlDentroPartida.BringToFront();
                btnAutomatico.Enabled = true;
                btnManual.Enabled = true;
                btnEstrategia.Enabled = true;
                btnIniciarPartida.Enabled = false;
            }
            else if (status == "J" || status == "" || status == "E")
            {
                pnlPartidaIndisponivel.BringToFront();
                btnVoltarListarPartidas2.Enabled = true;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            pnlListarCriar.BringToFront();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            pnlCriarPartida.BringToFront();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            pnlListarPartidas.BringToFront();
        }

        private void btnVoltarCriarListar_Click(object sender, EventArgs e)
        {
            pnlListarCriar.BringToFront();
        }

        private void btnVoltarListarPartidas_Click(object sender, EventArgs e)
        {
            pnlListarPartidas.BringToFront();
        }

        private void btnVoltarListarPartidas2_Click(object sender, EventArgs e)
        {
            if (StatusPartida() == "J" && NaPartida())
            {
                DialogResult dialogResult = MessageBox.Show("A partida está em jogo.\nVocê tem certeza que deseja sair?", "Partida em andamento", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pnlListarPartidas.BringToFront();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                pnlListarPartidas.BringToFront();
            }
        }

        private void btnVoltarListarCriar2_Click(object sender, EventArgs e)
        {
            pnlListarCriar.BringToFront();
        }

        private void btnVoltarListarCriar_Click(object sender, EventArgs e)
        {
            pnlMenu.BringToFront();
        }

        private void btnComoJogar_Click(object sender, EventArgs e)
        {
            pnlTutorial1.BringToFront();
        }

        private void btnTutorialProx1_Click(object sender, EventArgs e)
        {
            pnlTutorial2.BringToFront();
        }

        private void btnTutorialProx2_Click(object sender, EventArgs e)
        {
            pnlTutorial3.BringToFront();
        }

        private void btnTutorialProx3_Click(object sender, EventArgs e)
        {
            pnlTutorial4.BringToFront();
        }

        private void btnTutorialProx4_Click(object sender, EventArgs e)
        {
            pnlTutorial5.BringToFront();
        }

        private void btnTutorialProx5_Click(object sender, EventArgs e)
        {
            pnlTutorial6.BringToFront();
        }

        private void btnVoltarMenu_Click(object sender, EventArgs e)
        {
            pnlMenu.BringToFront();
        }

        private void btnVerNovamente_Click(object sender, EventArgs e)
        {
            pnlTutorial1.BringToFront();
        }

        private void btnMostrarMao_Click(object sender, EventArgs e)
        {
            MostrarMao(1);
        }

        private void btnAutomatico_Click(object sender, EventArgs e)
        {
            MostrarMao(2);
        }

        private void btnEstrategia_Click(object sender, EventArgs e)
        {
            MostrarMao(3);
        }

        private void lstPartidas_DoubleClick(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedItem == null)
            {
                MessageBox.Show("Nenhuma partida selecionada", "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                AbrirPartida(lstPartidas.SelectedItem.ToString());
            }
        }

        private void btnTodas_Click(object sender, EventArgs e)
        {
            ListarPartidas("T");
        }

        private void btnAbertas_Click(object sender, EventArgs e)
        {
            ListarPartidas("A");
        }

        private void btnJogando_Click(object sender, EventArgs e)
        {
            ListarPartidas("J");
        }

        private void btnEncerradas_Click(object sender, EventArgs e)
        {
            ListarPartidas("E");
        }

        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            EntrarPartida();
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            IniciarPartida();
        }

        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes();
        }

        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            CriarPartida();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}