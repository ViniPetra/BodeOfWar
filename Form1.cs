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
            lstPartidas.Items.Clear(); //Limpa lista
            
            string retPartidas = BodeOfWarServer.Jogo.ListarPartidas("T");
            txtPartidas.Text = retPartidas; //Será apagado

            retPartidas = retPartidas.Replace("\r", "");
            retPartidas = retPartidas.Substring(0, retPartidas.Length - 1);

            string[] Partidas = retPartidas.Split('\n');

            for(int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
            }
        }

        //Void listar partidas - Falta a escolha do parâmetr o
        private void ListarPartidas()
        {
            string x = BodeOfWarServer.Jogo.ListarPartidas("T");
            txtPartidas.Text = x;
        }

        //Listar jogadores - Fazer DropDown com as opções existentes e mensagem de vazio
        private void button2_Click(object sender, EventArgs e)
        {
            string idPartida = txtIdPartida.Text;
            int idPartidaInt = Int32.Parse(idPartida);
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartidaInt);
            txtListarJogadores.Text = Jogadores;

        }

        //Void listar jogadores após entrar na partida
        private void ListarJogadores(int id)
        {
            int idPartida = id;
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartida);
            txtListarJogadores.Text = Jogadores;

        }

        //IdPartida apenas números
        private void txtIdPartida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Criar partida
        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            string nome = txtNomeCriarPartida.Text;
            string senha = txtSenhaCriarPartida.Text;
            if (senha.Length > 10)
            {
                MessageBox.Show("A senha só pode ter até 10 caracteres e você inseriu mais.");
                return;
            }
            if (BodeOfWarServer.Jogo.CriarPartida(nome, senha).Contains("ERRO")){
                MessageBox.Show("Erro na criação da partida");
                return;
            }else MessageBox.Show("Partida criada com sucesso!");
            ListarPartidas();
        }

        //Entrar na partida
        //Arrumar tamanho de nome e senha para <= 10 erro se idPartida = 0
        private void btnEntrarPartida_Click(object sender, EventArgs e)
        {
            int idPartida = 7;
            string nome = txtNome.Text;
            string senha = txtSenhaPartida.Text;

            if (nome.Length <= 0 || senha.Length <0)
            {
                MessageBox.Show("Nome ou senha vazios");
                return;
            }

            string chamada = BodeOfWarServer.Jogo.EntrarPartida(idPartida, nome, senha);

            if (chamada.Contains("ERRO"))
            {
                MessageBox.Show("Algo deu errado");
                return;
            }
            else MessageBox.Show("Entrada com sucesso!");
            ListarJogadores(idPartida);
        }
    }
}
