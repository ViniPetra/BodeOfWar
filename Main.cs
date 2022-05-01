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
    public partial class Main : Form
    {
        //Array de todas as cartas do jogo
        public Cartas[] TodasCartas = new Cartas[50];
        //Array das cartas designadas
        public Cartas[] MinhaMao = new Cartas[8];

        public Jogador jogador = new Jogador();

        public Main()
        {
            InitializeComponent();

            //Mostra a versão do servidor
            string Versao = BodeOfWarServer.Jogo.Versao;
            lblVersao.Text = Versao;

            //Linhas 34 até 81 é a criação da matriz de cartas

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

            jogador.TodasCartas = TodasCartas;
        }

        //Função para atualizar a lista a qualquer momento
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

            for (int i = 0; i < Partidas.Length; i++)
            {
                lstPartidas.Items.Add(Partidas[i]);
            }

            pnlListarPartidas2.BringToFront();
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

        //Função de atualizar os detalhes da partida
        public void AtualizarDetalhes(int idPartida)
        { 
            ListarJogadores(jogador.idPartida);
            txtVez.Text = VerificarVez(jogador.idPartida);
            txtNarracao.Text = BodeOfWarServer.Jogo.ExibirNarracao(jogador.idPartida);

            if (txtVez.Text != "Partida não iniciada")
            {
                btnIniciarPartida.Enabled = false;
            }
        }

        //Função para verificar a vez a qualquer momento
        private string VerificarVez(int idPartida)
        {
            string nome = "";
            string jogadores = BodeOfWarServer.Jogo.ListarJogadores(jogador.idPartida);
            string vez = BodeOfWarServer.Jogo.VerificarVez(jogador.idPartida);

            //Gerenciamento de erros
            if (vez.StartsWith("ERRO:Partida não está em jogo"))
            {
                nome = "Partida não iniciada";
                return nome;
            }
            if (vez.StartsWith("ERRO"))
            {
                MessageBox.Show(vez, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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

            string[] Vez = vez.Split(',');

            string x = Vez[1];

            for (int i = 0; i < Jogadores.Length; i++)
            {
                if (Jogadores[i] == x)
                {
                    nome = Jogadores[i + 1];
                }
            }
            return nome;
        }

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

            jogador.idPartida = idPartida;

            //Atualizar detalhes
            AtualizarDetalhes(jogador.idPartida);

            //Chamar o painel de detalhes
            pnlDetalhesPartida.BringToFront();
        }

        private void EntrarPartida()
        {
            string nome = txtNome.Text;
            string senha = txtSenhaPartida.Text;
            string chamada = BodeOfWarServer.Jogo.EntrarPartida(jogador.idPartida, nome, senha);

            if (chamada.StartsWith("ERRO"))
            {
                MessageBox.Show(chamada, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                MessageBox.Show("Entrada com sucesso!");

                pnlDentroPartida.BringToFront();
            }

            //Mandar senha e Id pro objeto
            string[] senhaPartida = new string[2];
            senhaPartida = chamada.Split(',');

            jogador.Id = Int32.Parse(senhaPartida[0]);
            jogador.Senha = senhaPartida[1];
            jogador.Nome = nome;

            lblNomeJogador.Text = jogador.Nome;

            AtualizarDetalhes(jogador.idPartida);
        }

        private void IniciarPartida()
        {
            string index = "";
            string retIniciar = "";
            int id = jogador.Id;
            string senha = jogador.Senha;

            //Iniciando partida
            retIniciar = BodeOfWarServer.Jogo.IniciarPartida(id, senha);

            //Gerenciamento de erros
            if (index.StartsWith("ERRO"))
            {
                MessageBox.Show(index, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            if (retIniciar.StartsWith("ERRO"))
            {
                MessageBox.Show(retIniciar, "Jogo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else MessageBox.Show("Partida iniciada com sucesso");

            btnManual.Enabled = true;
            btnAutomatico.Enabled = true;

            AtualizarDetalhes(jogador.idPartida);
        }

        private void MostrarMaoManual()
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

            //Criação da array de objetos apenas de cartas próprias
            int count = 0;
            for (int j = 0; j < Mao.Length; j++)
            {
                for (int i = 0; i < TodasCartas.Length; i++)
                {
                    if (TodasCartas[i].id == Mao[j])
                    {
                        MinhaMao[count] = TodasCartas[i];
                    }
                }
                count++;
            }

            jogador.Mao = MinhaMao;

            //Chamar a janela de cartas próprias
            MãoManual FormMao = new MãoManual(jogador);
            FormMao.ShowDialog();
        }

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

            //Criação da array de objetos apenas de cartas próprias
            int count = 0;
            for (int j = 0; j < Mao.Length; j++)
            {
                for (int i = 0; i < TodasCartas.Length; i++)
                {
                    if (TodasCartas[i].id == Mao[j])
                    {
                        MinhaMao[count] = TodasCartas[i];
                    }
                }
                count++;
            }

            jogador.Mao = MinhaMao;

            //Chamar a janela de cartas próprias
            MaoAuto FormMaoAuto = new MaoAuto(jogador);
            FormMaoAuto.ShowDialog();
        }

        //Abrir uma nvoa janela para mostrar suas cartas de forma manual
        private void btnMostrarMao_Click(object sender, EventArgs e)
        {
            MostrarMaoManual();
        }

        //Abrir uma nvoa janela para mostrar suas cartas de forma automatizada
        private void btnAutomatico_Click(object sender, EventArgs e)
        {
            MostrarMaoAutomatica();
        }

        //Duplo clique na partida
        private void lstPartidas_DoubleClick(object sender, EventArgs e)
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

            pnlDetalhesPartida.BringToFront();

            //Parse da string para extração do id
            string[] Partidas = PartidaSelecionada.Split(',');
            int idPartida = Int32.Parse(Partidas[0]);
            
            jogador.idPartida = idPartida;

            AtualizarDetalhes(jogador.idPartida);
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
        }

        //Iniciar a partida
        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            IniciarPartida();
        }

        //Atualizar a caixa de narração
        private void btnAtualizarNarracao_Click(object sender, EventArgs e)
        {
            AtualizarDetalhes(jogador.idPartida);
        }

        //Criar partida
        private void btnCriarPartida_Click(object sender, EventArgs e)
        {
            CriarPartida();
        }

        //Dinâmica UI
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            pnlListarCriar.BringToFront();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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
            pnlListarPartidas2.BringToFront();
        }

        private void btnVoltarListarCriar2_Click(object sender, EventArgs e)
        {
            pnlListarCriar.BringToFront();
        }
    }
}
