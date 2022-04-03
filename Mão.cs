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
        int idJogadorGlobal;
        string senhaGlobal;
        Cartas[] MinhaMaoGlobal;
        public Mão(Cartas[] MinhaMao, string[] jogadorGlobal)
        {
            InitializeComponent();
            
            //Acesso dos valores
            idJogadorGlobal = Int32.Parse(jogadorGlobal[0]);
            senhaGlobal = jogadorGlobal[1];
            MinhaMaoGlobal = MinhaMao;

            //Criação de listas com todas as PictureBoxes e Labels do formulário
            List<PictureBox> imagens = new List<PictureBox>() { pcbCarta1, pcbCarta2, pcbCarta3, pcbCarta4, pcbCarta5, pcbCarta6, pcbCarta7, pcbCarta8};
            List<Label> bodes = new List<Label>() { lblBode1, lblBode2, lblBode3, lblBode4, lblBode5, lblBode6, lblBode7, lblBode8};
            List<Label> ids = new List<Label>() { lblNum1, lblNum2, lblNum3, lblNum4, lblNum5, lblNum6, lblNum7, lblNum8};
            Panel[] panels = new Panel[8] { pnlCarta1, pnlCarta2, pnlCarta3, pnlCarta4, pnlCarta5, pnlCarta6, pnlCarta7, pnlCarta8 };

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

        private void Jogar(int index)
        {
            BodeOfWarServer.Jogo.Jogar(idJogadorGlobal, senhaGlobal, MinhaMaoGlobal[index].id);
        }

        private void pcbCarta1_DoubleClick(object sender, EventArgs e)
        {
            Jogar(0);
            pnlCarta1.BringToFront();
        }

        private void pcbCarta2_DoubleClick(object sender, EventArgs e)
        {
            Jogar(1);
            pnlCarta2.BringToFront();
        }

        private void pcbCarta3_DoubleClick(object sender, EventArgs e)
        {
            Jogar(2);
            pnlCarta3.BringToFront();
        }

        private void pcbCarta4_DoubleClick(object sender, EventArgs e)
        {
            Jogar(3);
            pnlCarta4.BringToFront();
        }

        private void pcbCarta5_DoubleClick(object sender, EventArgs e)
        {
            Jogar(4);
            pnlCarta5.BringToFront();
        }

        private void pcbCarta6_DoubleClick(object sender, EventArgs e)
        {
            Jogar(5);
            pnlCarta6.BringToFront();
        }

        private void pcbCarta7_DoubleClick(object sender, EventArgs e)
        {
            Jogar(6);
            pnlCarta7.BringToFront();
        }

        private void pcbCarta8_DoubleClick(object sender, EventArgs e)
        {
            Jogar(7);
            pnlCarta8.BringToFront();
        }
    }
}
