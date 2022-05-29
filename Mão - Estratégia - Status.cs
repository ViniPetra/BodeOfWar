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
        public MãoEstratégiaStatus()
        {
            InitializeComponent();
        }

        public void UpdateJogadores(List<Jogador> adversários)
        {
            int index = adversários.Count;

            for(int i= 0; i<index; i++)
            {
                switch (i)
                {
                    case 0:
                        txtBodesJ1.Text = adversários[0].Bodes.ToString();
                        txtPerdidas1.Text = adversários[0].Perdidas.ToString();
                        txtVencidas1.Text = adversários[0].Vencidas.ToString();
                        break;
                    case 1:
                        txtBodesJ2.Text = adversários[1].Bodes.ToString();
                        txtPerdidas2.Text = adversários[1].Perdidas.ToString();
                        txtVencidas2.Text = adversários[1].Vencidas.ToString();
                        break;
                    case 2:
                        txtBodesJ3.Text = adversários[2].Bodes.ToString();
                        txtPerdidas3.Text = adversários[2].Perdidas.ToString();
                        txtVencidas3.Text = adversários[2].Vencidas.ToString();
                        break;
                    case 3:
                        txtBodesJ4.Text = adversários[3].Bodes.ToString();
                        txtPerdidas4.Text = adversários[3].Perdidas.ToString();
                        txtVencidas4.Text = adversários[3].Vencidas.ToString();
                        break;
                }
            }
        }

        public void Config_UpdateJogadores(List<Jogador> adversários)
        {
            List<GroupBox> groupBoxes = new List<GroupBox> { gpb1, gpb2, gpb3, gpb4 };

            int size = adversários.Count;

            for(int i = 0; i < size; i++)
            {
                groupBoxes[i].Visible = true;
                groupBoxes[i].Text = adversários[i].Id.ToString() + " - " + adversários[i].Nome.ToString();
            }

        }

        /// <summary>
        /// 1 parâmetro obrigatório e 4 opcionais.
        /// Escolher número de qual mensagem cada status deve assumir.
        /// </summary>
        /// <param name="CasoGeral"></param>
        /// <param name="Automacao"></param>
        /// <param name="Mao"></param>
        /// <param name="Mesa"></param>
        /// <param name="Decisao"></param>
        public void UpdateStatus(int CasoGeral = 0, int Automacao = 0, int Mao = 0, int Mesa = 0, int Decisao = 0)
        {
            switch (CasoGeral)
            {
                case 0:
                    break;
                case 1:
                    lblStatusAuto.Text = "Aguardando timer";
                    lblStatusAuto.ForeColor = Color.Green;

                    lblStatusMao.Text = "Aguardando timer";
                    lblStatusMao.ForeColor = Color.Green;

                    lblStatusMesa.Text = "Aguardando timer";
                    lblStatusMesa.ForeColor = Color.Green;

                    lblStatusDecisao.Text = "Aguardando timer";
                    lblStatusDecisao.ForeColor = Color.Green;
                    break;
                case 2:
                    lblStatusAuto.Text = "Analisando";
                    lblStatusAuto.ForeColor = Color.Orange;

                    lblStatusMao.Text = "Analisando";
                    lblStatusMao.ForeColor = Color.Orange;

                    lblStatusMesa.Text = "Analisando";
                    lblStatusMesa.ForeColor = Color.Orange;

                    lblStatusDecisao.Text = "Analisando";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 3:
                    lblStatusAuto.Text = "Partida encerrada";
                    lblStatusAuto.ForeColor = Color.Cyan;

                    lblStatusMao.Text = "Partida encerrada";
                    lblStatusMao.ForeColor = Color.Cyan;

                    lblStatusMesa.Text = "Partida encerrada";
                    lblStatusMesa.ForeColor = Color.Cyan;

                    lblStatusDecisao.Text = "Partida encerrada";
                    lblStatusDecisao.ForeColor = Color.Cyan;
                    break;
            }

            switch (Automacao)
            {
                case 0:
                    break;
                case 1:

                    lblStatusAuto.Text = "Aguardando timer...";
                    lblStatusAuto.ForeColor = Color.Green;
                    break;
                case 2:
                    lblStatusAuto.Text = "Analisando";
                    lblStatusAuto.ForeColor = Color.Orange;
                    break;
                case 3:
                    lblStatusAuto.Text = "Jogando ilha";
                    lblStatusAuto.ForeColor = Color.Yellow;
                    break;
                case 4:
                    lblStatusAuto.Text = "Jogando Carta";
                    lblStatusAuto.ForeColor = Color.Yellow;
                    break;
                case 5:
                    lblStatusAuto.Text = "Não é minha vez";
                    lblStatusAuto.ForeColor = Color.Cyan;
                    break;
            }

            switch (Mao)
            {
                case 0:
                    break;
                case 1:
                    lblStatusMao.Text = "Aguardando timer";
                    lblStatusMao.ForeColor = Color.Green;
                    break;
                case 2:
                    lblStatusMao.Text = "Analisando";
                    lblStatusMao.ForeColor = Color.Orange;
                    break;
                case 3:
                    lblStatusMao.Text = "Tenho muito bode";
                    lblStatusMao.ForeColor = Color.Red;
                    break;
                case 4:
                    lblStatusMao.Text = "Tenho pouco bode";
                    lblStatusMao.ForeColor = Color.LightGreen;
                    break;
                case 5:
                    lblStatusMao.Text = "Bodes ideais";
                    lblStatusMao.ForeColor = Color.LimeGreen;
                    break;
                case 6:
                    lblStatusMao.Text = "Bodes acima";
                    lblStatusMao.ForeColor = Color.LightPink;
                    break;
            }

            switch (Mesa)
            {
                case 0:
                    break;
                case 1:
                    lblStatusMesa.Text = "Tenho a maior carta";
                    lblStatusMesa.ForeColor = Color.Green;
                    break;
                case 2:
                    lblStatusMesa.Text = "Não tenho a maior carta";
                    lblStatusMesa.ForeColor = Color.Red;
                    break;
                case 3:
                    lblStatusMesa.Text = "Tenho a menor carta";
                    lblStatusMesa.ForeColor = Color.Green;
                    break;
                case 4:
                    lblStatusMesa.Text = "Não tenho a menor carta";
                    lblStatusMesa.ForeColor = Color.Red;
                    break;
                case 5:
                    lblStatusMesa.Text = "Aguardando timer...";
                    lblStatusMesa.ForeColor = Color.Green;
                    break;
                case 6:
                    lblStatusMesa.Text = "Escolhendo ilha";
                    lblStatusMesa.ForeColor = Color.Yellow;
                    break;
                case 7:
                    lblStatusMesa.Text = "Primeira rodada";
                    lblStatusMesa.ForeColor = Color.Yellow;
                    break;
                case 8:
                    lblStatusMesa.Text = "Alguém vai estourar";
                    lblStatusMesa.ForeColor = Color.OrangeRed;
                    break;
                case 9:
                    lblStatusMesa.Text = "Ninguém vai estourar";
                    lblStatusMesa.ForeColor = Color.OrangeRed;
                    break;
                case 10:
                    lblStatusMesa.Text = "Posso comprar";
                    lblStatusMesa.ForeColor = Color.Lime;
                    break;
                case 11:
                    lblStatusMesa.Text = "Não posso comprar";
                    lblStatusMesa.ForeColor = Color.Red;
                    break;
            }

            switch (Decisao)
            {
                case 0:
                    break;
                case 1:
                    lblStatusDecisao.Text = "Jogar carta alta";
                    lblStatusDecisao.ForeColor = Color.Lime;
                    break;
                case 2:
                    lblStatusDecisao.Text = "Jogar carta baixa";
                    lblStatusDecisao.ForeColor = Color.Red;
                    break;
                case 3:
                    lblStatusDecisao.Text = "Descartar";
                    lblStatusDecisao.ForeColor = Color.OrangeRed;
                    break;
                case 4:
                    lblStatusDecisao.Text = "Jogar bode alto";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 5:
                    lblStatusDecisao.Text = "Jogar bode baixo";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 6:
                    lblStatusDecisao.Text = "Jogar Ilha maior";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 7:
                    lblStatusDecisao.Text = "Jogar Ilha menor";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 8:
                    lblStatusDecisao.Text = "Jogar aleatória";
                    lblStatusDecisao.ForeColor = Color.Red;
                    break;
                case 9:
                    lblStatusDecisao.Text = "Jogar maior que mesa";
                    lblStatusDecisao.ForeColor = Color.Lime;
                    break;
                case 10:
                    lblStatusDecisao.Text = "Jogar menor que mesa";
                    lblStatusDecisao.ForeColor = Color.Lime;
                    break;
            }
        }

        public void UpdateUltimoVencedor(string vencedor)
        {
            txtUltimoVencedor.Text = vencedor;
        }

        public void UpdateUltimoPerdedor(string perdedor)
        {
            txtUltimoPerdedor.Text = perdedor;
        }

        public void UpdateMetricas(List<Jogador> jogadores, int rodada, int tamIlha)
        {
            List<int> BodesIndexes = new List<int>();
            List<int> VencedoresIndexes = new List<int>();
            List<int> PerdedoresIndexes = new List<int>();

            foreach(Jogador adversário in jogadores)
            {
                BodesIndexes.Add(adversário.Bodes);
                VencedoresIndexes.Add(adversário.Vencidas);
                PerdedoresIndexes.Add(adversário.Perdidas);
            }

            txtMaisBodes.Text = jogadores[BodesIndexes.IndexOf(BodesIndexes.Max())].Nome;
            txtMaisVenceu.Text = jogadores[VencedoresIndexes.IndexOf(VencedoresIndexes.Max())].Nome;
            txtMenosBodes.Text = jogadores[BodesIndexes.IndexOf(BodesIndexes.Min())].Nome;
            txtMaisPerdeu.Text = jogadores[PerdedoresIndexes.IndexOf(PerdedoresIndexes.Max())].Nome;

            txtRodada.Text = rodada.ToString();
            txtTamIlha.Text = tamIlha.ToString();
        }
    }
}
