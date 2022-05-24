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
    public partial class MãoEstratégiaStatus : Form
    {
        Jogador jogador;
        Partida partida;
        MaoEstrategia Mao;
        public MãoEstratégiaStatus(Jogador jogador, Partida partida, MaoEstrategia mao)
        {
            this.jogador = jogador;
            this.partida = partida;
            this.Mao = mao;
            InitializeComponent();
        }

        public void UpdateJogador1Status(string id, string nome, string bodes)
        {
            txtJogador1.Text = "id: " + id + "\r\n" + "nome: " + nome + "\r\n" + "bodes: " + bodes;
        }
    }
}
