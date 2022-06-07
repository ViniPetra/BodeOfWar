using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BodeOfWar
{
    public partial class Vencedor : Form
    {
        public Vencedor(string texto)
        {
            InitializeComponent();
            this.txtVencedor.Text = texto;
        }
        private void TocarSom()
        {
            SoundPlayer SomVencedor = new SoundPlayer(Properties.Resources.Screaming_Goat);
            SomVencedor.Play();
        }

        private void Vencedor_Load(object sender, EventArgs e)
        {
            TocarSom();
        }
    }
}
