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
        //Array de todas as cartas do jogo
        public Cartas[] TodasCartas = new Cartas[50];
        //Array das cartas designadas
        public List<Cartas> MinhaMao = new List<Cartas>();
        //Definição do jogador
        public Jogador jogador = new Jogador();

        public int PartidaAberta;

        /// <summary>
        /// 1. Cria os objetos de cada as carta do jogo
        /// 2. Cria a lista com todos os objetos de carta 
        /// 3. Define o atributo de todas as cartas no jogador 
        /// </summary>
        public Main()
        {
            InitializeComponent();

            //Traz o menu como primeiro caso esteja codando
            pnlMenu.BringToFront();

            //Mostra a versão do servidor
            string Versao = BodeOfWarServer.Jogo.Versao;
            lblVersao.Text = Versao;

            //Parse do retorno de ListarCartas() em uma array
            //Cartas1 {1, 1, 5, 2, 2, 5, ...}
            string retCartas = BodeOfWarServer.Jogo.ListarCartas();
            retCartas = retCartas.Replace("\r", "");
            retCartas = retCartas.Substring(0, retCartas.Length - 1);
            retCartas = retCartas.Replace("\n", ",");;
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
            for (i = 0; i <= 149; i = i + 3)
            {
                Cartas2[(i / 3), 0] = IntCartas1[i];
            }

            for (i = 1; i <= 149; i = i + 3)
            {
                Cartas2[(i / 3), 1] = IntCartas1[i];
            }

            for (i = 2; i <= 149; i = i + 3)
            {
                Cartas2[(i / 3), 2] = IntCartas1[i];
            }

            //Criação da array de objetos com todas as cartas
            //TodasCartas {(id, bode, num),(id, bode num),(id, bode, num)}
            for (i = 0; i <= 49; i++)
            {
                //Utilizando o metodo construtor
                TodasCartas[i] = new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2]);
            }

            foreach(Cartas cartas in TodasCartas)
            {
                cartas.imagem = (Image)Properties.Resources.ResourceManager.GetObject("b" + cartas.imagemnum);
            }

            //Atribuição de TodasCartas para atributo TodasCartas do objeto jogador
            jogador.TodasCartas = TodasCartas;
        }

        /// <summary>
        /// Trata o retorno de "ListarPartidas" e adiciona cada partida como um item individual em uma lista.
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
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(PartidaAberta);
            if (Jogadores == "")
            {
                Jogadores = "Partida vazia";
            }

            Jogadores = Jogadores.Replace(",", " - ");

            txtListarJogadores.Text = Jogadores;
        }

        /// <summary>
        /// Atualiza as informações em txtVez, txtNarracao, txtJogadores
        /// Verifica se a partida foi iniciada e bloqueia o btnIniciarPartida caso tenha sido
        /// </summary>
        public void AtualizarDetalhes()
        { 
            ListarJogadores();
            txtVez.Text = VerificarVez();
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(PartidaAberta);
        }

        /// <summary>
        /// Trata o retorno de BodeOfWarServer.VerificarVez, bate com o retorno de BodeOfWarServer.ListarJogadores
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

            string Status = StatusPartidaAberta();

            if (Status == "E" || Status == "")
            {
                pnlPartidaIndisponivel.BringToFront();
                btnVoltarListarPartidas2.Enabled = true;
            }
            else if (Status == "J" && NaPartida())
            {
                btnAutomatico.Enabled = true;
                btnManual.Enabled = true;
                btnEstrategia.Enabled = true;
                btnIniciarPartida.Enabled = false;
            }
            else
            {
                pnlPartidaIndisponivel.BringToFront();
                btnVoltarListarPartidas2.Enabled = true;
            }

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

            PartidaAberta = idPartida;

            if(NaPartida() && StatusPartidaAberta() == "A")
            {
                pnlDentroPartida.BringToFront();
                btnAutomatico.Enabled = false;
                btnManual.Enabled = false;
                btnEstrategia.Enabled = false;
                btnIniciarPartida.Enabled = true;
            }
            else if(NaPartida() && StatusPartidaAberta() == "J")
            {
                pnlDentroPartida.BringToFront();
                btnAutomatico.Enabled = true;
                btnManual.Enabled = true;
                btnEstrategia.Enabled = true;
                btnIniciarPartida.Enabled = false;
            }
            AtualizarDetalhes();
        }

        /// <summary>
        /// 1. Cria uma partida usando as informações em txtNomeCriarPartida e txtSenhaCriarPartida
        /// 2. Define o atributo idPartida em jogador para o id da partida criada 
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

            //Abrir detalhes da partida diretamente após criar

            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas("T");

            //Parse da retPartidas para uma array
            //Partidas {id,nomePartida,DataCriação,Status, , id,nomePartida,DataCriação,Status, , id,nomePartida,DataCriação,Status, }
            retPartidas = retPartidas.Replace("\r", "");
            retPartidas = retPartidas.Substring(0, retPartidas.Length - 1);
            retPartidas = retPartidas.Replace("\n", ",");
            string[] Partidas = retPartidas.Split(',');

            //Isolar a id da partida mais recente
            int idPartida = Int32.Parse(Partidas[((Partidas.Length) - 4)]);

            //Recomentar
            //Define o atributo idPartida em jogador para o id da partida criada 
            //jogador.idPartida = idPartida;
            PartidaAberta = idPartida;

            //Atualizar detalhes
            AtualizarDetalhes();

            //Chamar o painel de detalhes
            pnlDetalhesPartida.BringToFront();
        }

        /// <summary>
        /// 1. Entra na partida usando as informações em txtNome e txtSenhaPartida
        /// 2. Traz para frente detalhes da partida recém entrada
        /// 3. Define atributos Id, Senha e Nome do objeto jogador 
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
                jogador.idPartida = PartidaAberta;

                pnlDentroPartida.BringToFront();
            }

            //Mandar senha e Id pro objeto
            string[] senhaPartida = new string[2];
            senhaPartida = chamada.Split(',');

            //Define atributos Id, Senha e Nome do objeto jogador 
            jogador.Id = Int32.Parse(senhaPartida[0]);
            jogador.Senha = senhaPartida[1];
            jogador.Nome = nome;

            AtualizarDetalhes();
        }

        /// <summary>
        /// 1. Inicia a partida em que o jogador está registrado
        /// 2. Define os botões de escolha de moto de jogo como habilitados (naturalmente desabilitados)
        /// </summary>
        private void IniciarPartida()
        {
            string retIniciar;

            //Iniciando partida
            retIniciar = BodeOfWarServer.Jogo.IniciarPartida(jogador.Id, jogador.Senha);

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
            if(jogador.idPartida == PartidaAberta)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string StatusPartidaAberta()
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
        /// 1. Cria uma array com os objetos de cartas baseado no retorno de BodeOfWarServer.VerificarMao
        /// 2. Define o atributo Mao do jogador como a array de objetos da Mão
        /// 3. Chama o formulário de Mão manual (sem automação)
        /// </summary>
        private void MostrarMaoManual()
        {
            string StringMao = BodeOfWarServer.Jogo.VerificarMao(jogador.Id, jogador.Senha);

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

            //Criação da lista de objetos apenas de cartas próprias
            for (int j = 0; j < Mao.Length; j++)
            {
                for (int i = 0; i < TodasCartas.Length; i++)
                {
                    if (TodasCartas[i].id == Mao[j])
                    {
                        MinhaMao.Add(TodasCartas[i]);
                    }
                }
            }

            jogador.Mao = MinhaMao;

            //Chamar a janela do jogo manual
            MãoManual FormMao = new MãoManual(jogador);
            FormMao.ShowDialog();
        }

        /// <summary>
        /// 1. Cria uma array com os objetos de cartas baseado no retorno de BodeOfWarServer.VerificarMao
        /// 2. Define o atributo Mao do jogador como a array de objetos da Mão
        /// 3. Chama o formulário de Mão automatizada
        /// </summary>
        private void MostrarMaoAutomatica()
        {
            int id = jogador.Id;
            string senha = jogador.Senha;

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

            //Criação da Lista de objetos apenas de cartas próprias
            for (int j = 0; j < Mao.Length; j++)
            {
                for (int i = 0; i < TodasCartas.Length; i++)
                {
                    if (TodasCartas[i].id == Mao[j])
                    {
                        MinhaMao.Add(TodasCartas[i]);
                    }
                }
            }

            jogador.Mao = MinhaMao;

            //Chamar a janela do jogo automático
            MaoAuto FormMaoAuto = new MaoAuto(jogador);
            FormMaoAuto.ShowDialog();
        }

        /// <summary>
        /// 1. Cria uma array com os objetos de cartas baseado no retorno de BodeOfWarServer.VerificarMao
        /// 2. Define o atributo Mao do jogador como a array de objetos da Mão
        /// 3. Chama o formulário de Mão com a estratégia do grupo
        /// </summary>
        private void MostrarMaoEstrategia()
        {
            int id = jogador.Id;
            string senha = jogador.Senha;

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

            //Criação da Lista de objetos apenas de cartas próprias
            for (int j = 0; j < Mao.Length; j++)
            {
                for (int i = 0; i < TodasCartas.Length; i++)
                {
                    if (TodasCartas[i].id == Mao[j])
                    {
                        MinhaMao.Add(TodasCartas[i]);
                    }
                }
            }

            jogador.Mao = MinhaMao;

            //Chamar a janela do jogo automático
            MaoEstrategia FormMaoEstrategia = new MaoEstrategia(jogador, this);
            FormMaoEstrategia.ShowDialog();
        }

        //Duplo clique na partida
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

        //Chamadas de listar partidas
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

        //Entrar na partida
        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            EntrarPartida();

            //Limpa os campos
            txtSenhaPartida.Text = "";
        }

        //Iniciar a partida
        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            IniciarPartida();
        }

        //Atualizar a caixa de narração
        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes();
        }

        //Criar partida
        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            CriarPartida();

            //Limpa os campos
            txtNomeCriarPartida.Text = "";
            txtSenhaCriarPartida.Text = "";
        }

        //Abrir uma nova janela para mostrar suas cartas de forma manual
        private void btnMostrarMao_Click(object sender, EventArgs e)
        {
            MostrarMaoManual();
        }

        //Abrir uma nvoa janela para mostrar suas cartas de forma automatizada
        private void btnAutomatico_Click(object sender, EventArgs e)
        {
            MostrarMaoAutomatica();
        }

        //Abrir uma nvoa janela para mostrar suas cartas com a estratégia do grupo
        private void btnEstrategia_Click(object sender, EventArgs e)
        {
            MostrarMaoEstrategia();
        }


        //Dinâmica UI

        /// <summary>
        /// Todas as funções abaixo são da dinâmica de telas
        /// </summary>

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
            if (StatusPartidaAberta() == "J" && NaPartida())
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

        /// <summary>
        /// Fecha o jogo
        /// </summary>
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}