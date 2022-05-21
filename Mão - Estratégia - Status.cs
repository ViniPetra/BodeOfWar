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
        public MãoEstratégiaStatus(Jogador jogador, Partida partida)
        {
            this.jogador = jogador;
            this.partida = partida;
            InitializeComponent();
        }
    }
}
