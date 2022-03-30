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
        public Cartas[] MinhaMao = new Cartas[8];

        public Main()
        {
            InitializeComponent();

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
        }

        //Listar Partidas
        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
            //Verificar qual tipo de partida está selecionado
            lstPartidas.Items.Clear();
            string opc = cbbPartidas.Text;
            if (opc == "Todas")
            {
                opc = "T";
            }
            if (opc == "Abertas") {
                opc = "A";
            }
            if (opc == "Jogando")
            {
                opc = "J";
            }
            if (opc == "Encerradas")
            {
                opc = "E";
            }
            if (cbbPartidas.Text == "")
            {
                MessageBox.Show("Selecione um tipo de partida", "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            
            //Guarda o retorno na retPartidas
            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas(opc);

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

            //Adicionar à lista
            for(int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
            }
        }

        
        //Função para atualizar a lista a qualquer momento
        //Praticamente uma cópia da função do botão
        private void ListarPartidas()
        {
            lstPartidas.Items.Clear();
            string opc = cbbPartidas.Text;
            if (opc == "Todas")
            {
                opc = "T";
            } else if (opc == "Abertas")
            {
                opc = "A";
            } else if (opc == "Jogando")
            {
                opc = "J";
            } else if (opc == "Encerradas")
            {
                opc = "E";
            } else if (cbbPartidas.Text == "")
            {
                MessageBox.Show("Selecione um tipo de partida");
                return;
            }

            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas(opc);

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

            for (int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
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

        //Criar partida
        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            string nome = txtNomeCriarPartida.Text;
            string senha = txtSenhaCriarPartida.Text;
            string ret = BodeOfWarServer.Jogo.CriarPartida(nome, senha);
            if (ret.Contains("ERRO")){
                MessageBox.Show(ret, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }else MessageBox.Show("Partida criada com sucesso!");
            
            //Atualizar lista de partidas quando uma é criada se algum filtro estiver aplicado
            if(cbbPartidas.Text != "")
            {
                ListarPartidas();
            }
            //Limpando as TextBoxes após a criação
            txtNomeCriarPartida.Text = "";
            txtSenhaCriarPartida.Text = "";
        }

        //Entrar na partida
        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            string PartidaSelecionada;
            if (lstPartidas.SelectedItem == null)
            {
                MessageBox.Show("Nenhuma partida selecionada", "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else 
            {
                PartidaSelecionada = lstPartidas.SelectedItem.ToString(); 
            }

            //Parse na string para extrair id
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);

            string nome = txtNome.Text;
            string senha = txtSenhaPartida.Text;
            string chamada = BodeOfWarServer.Jogo.EntrarPartida(idPartida, nome, senha);
            if (chamada.Contains("ERRO"))
            {
                MessageBox.Show(chamada, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else MessageBox.Show("Entrada com sucesso!");
            
            //Armazena as senhas na ListBox 
            //Precisa globalizar para usar em outras telas
            string[] senhas = chamada.Split('\n');
            for (int i = 0; i < senhas.Length; i++)
            {
                lstSenhas.Items.Add(senhas[i]);
            }
            ListarJogadores(idPartida);
            //Limpando as TextBoxes após a entrada
            txtNome.Text = "";
            txtSenhaPartida.Text = "";
        }

        //Lista os jogadores, verifica a vez e exibe a narração clicando na partida
        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedItem != null) //Para não gerar erro quando clica no vazio
            {
                //Parse da partida escolhida para extrair id
                string PartidaSelecionada = lstPartidas.SelectedItem.ToString();
                string[] Partidas = PartidaSelecionada.Split(',');
                int idPartida = Int32.Parse(Partidas[0]);
                //Chamadas do servidor
                ListarJogadores(idPartida);
                txtVez.Text = VerificarVez(idPartida);
                txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);
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
                    nome = Jogadores[i+1];
                }
            }
            return nome;
        }

        //Iniciar a partida
        private void txtIniciarPartida_Click(object sender, EventArgs e)
        {
            string index = "";
            string retIniciar = "";
            int id = 0;
            string senha = "";

            //verifica se foi selecionada alguma senha para inicio de partida
            if (lstSenhas.SelectedItem != null)
            {
                index = lstSenhas.SelectedItem.ToString();
                string[] info = index.Split(',');
                id = Int32.Parse(info[0]);
                senha = info[1];
            } 

            //Iniciando partida
            retIniciar = BodeOfWarServer.Jogo.IniciarPartida(id, senha);

            //Gerenciamento de erros
            if (index.Contains("ERRO"))
            {
                MessageBox.Show(index,
                    "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            
            if (retIniciar.Contains("ERRO"))
            {
                MessageBox.Show(retIniciar,
                    "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else MessageBox.Show("Partida iniciada com sucesso");
        }

        //Atualizar a caixa de narração
        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            string PartidaSelecionada;
            if (lstPartidas.SelectedItem == null)
            {
                MessageBox.Show("Nenhuma partida selecionada", "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                PartidaSelecionada = lstPartidas.SelectedItem.ToString();
            }
            //Parse da string para extração do id
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);
            txtVez.Text = VerificarVez(idPartida);
        }

        //Abrir uma nvoa janela para mostrar suas cartas
        private void btnMostrarMao_Click(object sender, EventArgs e)
        {
            string index;
            string senha = "";
            int id = 0;

            //Verifica se há uma senha selecionada e dá o parse no retorno para extração da senha
            if (lstSenhas.SelectedItem != null)
            {
                index = lstSenhas.SelectedItem.ToString();
                string[] info = index.Split(',');
                id = Int32.Parse(info[0]);
                senha = info[1];
            }

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

            //Criação da array de objetos apenas de cartas próprias
            if (lstSenhas.SelectedItem != null)
            {
                int count = 0;
                for (int j = 0; j < Mao.Length; j++)
                {
                    for(int i = 0; i < TodasCartas.Length; i++)
                    {
                        if (TodasCartas[i].id == Mao[j])
                        {
                            MinhaMao[count] = TodasCartas[i];
                        }
                    }
                    count++;
                }
            }

            //Chamar a janela de cartas próprias
            Mão FormMao = new Mão(MinhaMao);
            FormMao.ShowDialog();
        }
    }
}
