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
        public Form1()
        {
            InitializeComponent();
            string Versao = BodeOfWarServer.Jogo.Versao;
            lblVersao.Text = Versao;
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
            }
            if (opc == "Abertas")
            {
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

        /*
        //Listar jogadores - botão desativado
        private void button2_Click(object sender, EventArgs e)
        {
            string idPartida = txtIdPartida.Text;
            int idPartidaInt = Int32.Parse(idPartida);
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartidaInt);
            txtListarJogadores.Text = Jogadores;
        }
        */

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
            if (senha == "")
            {
                MessageBox.Show("A senha não pode ser vazia");
                return;
            }
            string ret = BodeOfWarServer.Jogo.CriarPartida(nome, senha);
            if (ret.Contains("ERRO")){
                MessageBox.Show(ret);
                return;
            }else MessageBox.Show("Partida criada com sucesso!");
        }

        //Entrar na partida
        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            string PartidaSelecionada = lstPartidas.SelectedItem.ToString();
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);
            //MessageBox.Show(idPartida.ToString());
            string nome = txtNome.Text;
            string senha = txtSenhaPartida.Text;
            string chamada = BodeOfWarServer.Jogo.EntrarPartida(idPartida, nome, senha);

            if (chamada.Contains("ERRO"))
            {
                MessageBox.Show(chamada);
                return;
            }
            else MessageBox.Show("Entrada com sucesso!");
            MessageBox.Show(chamada);//(ID JOGADOR,SENHA)
            //colocar apend toda vez que entra
            
            txtPartidasSenhas.Text = chamada + "\n";
            string[] senhas = chamada.Split('\n');//.Split(',');
            for (int i = 0; i < senhas.Length; i++)
            {
                lstSenhas.Items.Add(senhas[i]);
            }
            ListarJogadores(idPartida);
        }

        //Clicar na lista - Mostrar jogadores
        private void lstPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PartidaSelecionada = lstPartidas.SelectedItem.ToString();
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);
            ListarJogadores(idPartida);
            string vez = VerificarVez(idPartida);

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
                MessageBox.Show(vez);
                return vez;
            }

            if (jogadores.Contains("ERRO"))
            {
                MessageBox.Show(jogadores);
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
            string index = lstSenhas.SelectedItem.ToString();
            if (index.Contains("ERRO"))
            {
                MessageBox.Show(index);
            }
            string[] info = index.Split(',');
            int id = Int32.Parse(info[0]);
            string senha = info[1];
            string retIniciar = BodeOfWarServer.Jogo.IniciarPartida(id, senha);
            if (retIniciar.Contains("ERRO"))
            {
                MessageBox.Show(retIniciar);
            }
            else MessageBox.Show("Partida iniciada com sucesso");
        }
    }
}
