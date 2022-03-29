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
    public partial class Form1 : Form
    {
        public Cartas[] TodasCartas = new Cartas[50];
        //Criando a variável que vai guardar as cartas após a filtragem
        public Cartas[] cartasMaoSelecionadas = new Cartas[8];
        public Form1()
        {
            InitializeComponent();
            string Versao = BodeOfWarServer.Jogo.Versao;
            lblVersao.Text = Versao;

            //Array do retorno
            string retCartas = BodeOfWarServer.Jogo.ListarCartas();
            retCartas = retCartas.Replace("\r", "");
            retCartas = retCartas.Substring(0, retCartas.Length - 1);
            retCartas = retCartas.Replace("\n", ",");
            string[] Cartas1 = retCartas.Split(',');

            int[] IntCartas1 = new int[Cartas1.Length];
            int[,] Cartas2 = new int[50, 3];
            
            int i;

            //Converter a array em int
            for (i = 0; i < Cartas1.Length; i++)
            {
                IntCartas1[i] = Int32.Parse(Cartas1[i]);
            }

            //Criar a matriz
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

            //Criação dos objetos
            for (i = 0; i <= 49; i++)
            {
                //Utilizando o metodo construtor
                TodasCartas[i] = new Cartas(Cartas2[i, 0], Cartas2[i, 1], Cartas2[i, 2]);
            }
        }

        //Listar Partidas - Falta a escolha do parâmetro
        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
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
            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas(opc);

            if (retPartidas == "")
            {
                MessageBox.Show("Nenhuma partida desse tipo encontrada", "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            retPartidas = retPartidas.Replace("\r", "");
            retPartidas = retPartidas.Substring(0, retPartidas.Length - 1);
            string[] Partidas = retPartidas.Split('\n');

            for(int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
            }
        }

        //Void listar partidas
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
                MessageBox.Show("Nenhuma partida desse tipo encontrada");
                return;
            }

            retPartidas = retPartidas.Replace("\r", "");
            retPartidas = retPartidas.Substring(0, retPartidas.Length - 1);

            string[] Partidas = retPartidas.Split('\n');

            for (int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
            }
        }

        //Void listar jogadores após entrar na partida
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
            //atualizar status do programa
            ListarPartidas();
            //esvaziando os inputs 
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
            
            string[] senhas = chamada.Split('\n');
            for (int i = 0; i < senhas.Length; i++)
            {
                lstSenhas.Items.Add(senhas[i]);
            }
            ListarJogadores(idPartida);
            //Atualizando campos de texto
            txtNome.Text = "";
            txtSenhaPartida.Text = "";
        }

        //Clicar na lista - Mostrar jogadores
        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PartidaSelecionada = lstPartidas.SelectedItem.ToString();
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);
            ListarJogadores(idPartida);
            string vez = VerificarVez(idPartida);
            string narracao = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);
            txtNarracao.Text = narracao;

            txtVez.Text = vez;
        }

        //VerificarVez
        private string VerificarVez(int idPartida)
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            string vez = BodeOfWarServer.Jogo.VerificarVez(idPartida);
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

        private void txtIniciarPartida_Click(object sender, EventArgs e)
        {
            //Inicializando variaveis
            string index = "";
            string retIniciar = "";
            int id = 0;
            string senha = "";

            //verificando se foi selecionado alguma senha para inicio de partida
            if (lstSenhas.SelectedItem != null)
            {
                index = lstSenhas.SelectedItem.ToString();
                string[] info = index.Split(',');
                id = Int32.Parse(info[0]);
                senha = info[1];
            } 

            //Iniciando partida
            retIniciar = BodeOfWarServer.Jogo.IniciarPartida(id, senha);

            //Caso alguma das variavies tenham erros, mensagens serão mostradas
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
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);
            string vez = VerificarVez(idPartida);
            string narracao = BodeOfWarServer.Jogo.ExibirNarracao(idPartida);
            txtNarracao.Text = narracao;
            txtVez.Text = vez;
        }
        private void btnMostrarMao_Click(object sender, EventArgs e)
        {
            string index;
            string senha = "";
            int id = 0;

            if (lstSenhas.SelectedItem != null)
            {
                index = lstSenhas.SelectedItem.ToString();
                string[] info = index.Split(',');
                id = Int32.Parse(info[0]);
                senha = info[1];
            }
            string StringMao = BodeOfWarServer.Jogo.VerificarMao(id, senha);
            StringMao = StringMao.Replace("\r", "");
            StringMao = StringMao.Substring(0, StringMao.Length - 1);
            StringMao = StringMao.Replace("\n", ",");

            Mão FormMao = new Mão(StringMao);
            //FormMao.ShowDialog();

            //criando a array com as IDs que vão ser usadas de filtragem para as cartas da mão
            string[] newMao = StringMao.Split(',');
            if (lstSenhas.SelectedItem != null)
            {
                //Servira de indice para cartasMaoSeleionadas
                int cont = 0;
          
                    for (int j = 0; j < newMao.Length; j++)
                    {
                        for(int i = 0; i < this.TodasCartas.Length; i++)
                        {
                            if (Convert.ToString(this.TodasCartas[i].id) == newMao[j])
                            {
                                this.cartasMaoSelecionadas[cont] = this.TodasCartas[i];
                            }
                        }
                        cont++;
                    }
            }

            string texto = "";

            for(int i = 0; i < cartasMaoSelecionadas.Length; i++)
            {
                texto = texto + "Id carta: " + Convert.ToString(cartasMaoSelecionadas[i].id) + " ||| Numero de Bodes: " + Convert.ToString(cartasMaoSelecionadas[i].numero) + "\n"; 
            }

            MessageBox.Show(texto);
        }
    }
}
