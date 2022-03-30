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
        public Mão(Cartas[] MinhaMao)
        {
            InitializeComponent();
            
            List<Cartas> cartas = new List<Cartas>();

            foreach(Cartas c in MinhaMao)
            {
                cartas.Add(c);
            }

            List<PictureBox> imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8};
            List<Label> bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8};
            List<Label> numeros = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8};

            MessageBox.Show(MinhaMao.Length.ToString());

            int count = 0;
            foreach (PictureBox p in imagens)
            {
                p.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[count].bode);
                count++;
            }

           
            count = 0;
            foreach (Label label in bodes)
            {
                    label.Text = MinhaMao[count].bode.ToString();
                    count++;
            }

            count = 0;
            foreach (Label l in numeros)
            {
                l.Text = MinhaMao[count].numero.ToString();
                count++;
            }

            /*
            pcbCarta1.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[0].bode);
            pcbCarta2.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[1].bode);
            pcbCarta3.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[2].bode);
            pcbCarta4.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[3].bode);
            pcbCarta5.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[4].bode);
            pcbCarta6.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[5].bode);
            pcbCarta7.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[6].bode);
            pcbCarta8.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[7].bode);
            */
        }
    }
}
