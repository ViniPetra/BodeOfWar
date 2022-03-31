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

            //Criação de listas com todas as PictureBoxes e Labels do formulário
            List<PictureBox> imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8};
            List<Label> bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8};
            List<Label> ids = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8};


            //Loop para adição da imagem baseada no número de bodes
            int count = 0;
            foreach (PictureBox p in imagens)
            {
                p.Image = (Image)Properties.Resources.ResourceManager.GetObject("b" + MinhaMao[count].imagem);
                count++;
            }

            //Loop para troca do texto da label Bode para o atributo do objeto
            count = 0;
            foreach (Label label in bodes)
            {
                    label.Text = MinhaMao[count].bode.ToString();
                    count++;
            }

            //Loop para troca do texto da label Numero para o atributo do objeto
            count = 0;
            foreach (Label l in ids)
            {
                l.Text = MinhaMao[count].id.ToString();
                count++;
            }
        }
    }
}
