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
    public partial class Mão : Form
    {
        public Mão(string mao)
        {
            InitializeComponent();

            string[] StringMao1 = mao.Split(',');
            int[] Mao = new int[StringMao1.Length];

            for (int i = 0; i < StringMao1.Length; i++)
            {
                Mao[i] = Int32.Parse(StringMao1[i]);
            }

            button1.Text = mao.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
