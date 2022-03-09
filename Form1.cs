﻿using System;
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

        private void lvlVersao_Click(object sender, EventArgs e)
        {

        }

        //Listar Partidas - Falta a escolha do parâmetro
        private void btnListarPartidas_Click(object sender, EventArgs e)
        {
            string x = BodeOfWarServer.Jogo.ListarPartidas("T");
            txtPartidas.Text = x;
        }

        //Void listar partidas - Falta a escolha do parâmetro
        private void ListarPartidas()
        {
            string x = BodeOfWarServer.Jogo.ListarPartidas("T");
            txtPartidas.Text = x;
        }

        //Listar jogadores - Fazer DropDown com as opções existentes
        private void button2_Click(object sender, EventArgs e)
        {
            string idPartida = txtIdPartida.Text;
            int idPartidaInt = Int32.Parse(idPartida);
            string Jogadores = BodeOfWarServer.Jogo.ListarJogadores(idPartidaInt);
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
            else BodeOfWarServer.Jogo.CriarPartida(nome, senha);
            MessageBox.Show("Partida criada com sucesso!");
            ListarPartidas();
        }
    }
}
