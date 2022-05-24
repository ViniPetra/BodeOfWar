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

        public void UpdateJogadores(List<Adversário> adversários)
        {
            int index = adversários.Count;

            for(int i= 0; i<index; i++)
            {
                switch (i)
                {
                    case 0:
                        txtBodesJ1.Text = adversários[0].QntBodes.ToString();
                        txtPerdidas1.Text = adversários[0].Perdidas.ToString();
                        txtVencidas1.Text = adversários[0].Vencidas.ToString();
                        break;
                    case 1:
                        txtBodesJ2.Text = adversários[1].QntBodes.ToString();
                        txtPerdidas2.Text = adversários[1].Perdidas.ToString();
                        txtVencidas2.Text = adversários[1].Vencidas.ToString();
                        break;
                    case 2:
                        txtBodesJ3.Text = adversários[2].QntBodes.ToString();
                        txtPerdidas3.Text = adversários[2].Perdidas.ToString();
                        txtVencidas3.Text = adversários[2].Vencidas.ToString();
                        break;
                    case 3:
                        txtBodesJ4.Text = adversários[3].QntBodes.ToString();
                        txtPerdidas4.Text = adversários[3].Perdidas.ToString();
                        txtVencidas4.Text = adversários[3].Vencidas.ToString();
                        break;
                }
            }
        }

        public void Config_UpdateJogadores(List<Adversário> adversários)
        {
            List<GroupBox> groupBoxes = new List<GroupBox> { gpb1, gpb2, gpb3, gpb4 };

            int size = adversários.Count;

            for(int i = 0; i < size; i++)
            {
                groupBoxes[i].Visible = true;
                groupBoxes[i].Text = adversários[i].id.ToString() + " - " + adversários[i].nome.ToString();
            }

        }

        /// <summary>
        /// 0 - Aguardando timer
        /// 1 - Analisando
        /// 2 - Jogando ilha
        /// 3 - Jogando carta
        /// 4 - Não é minha vez
        /// 9 - Partida encerrada
        /// </summary>
        /// <param name="caso"></param>
        public void UpdateStatusAuto(int caso)
        {
            switch (caso){
                //Aguardando
                case 0:
                    lblStatusAuto.Text = "Aguardando timer...";
                    lblStatusAuto.ForeColor = Color.Green;
                    break;
                //Analisando
                case 1:
                    lblStatusAuto.Text = "Analisando";
                    lblStatusMao.Text = "Analisando";
                    lblStatusMesa.Text = "Analisando";
                    lblStatusDecisao.Text = "Analisando";
                    lblStatusAuto.ForeColor = Color.Orange;
                    lblStatusMao.ForeColor = Color.Orange;
                    lblStatusMesa.ForeColor = Color.Orange;
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                //Jogando ilha
                case 2:
                    lblStatusAuto.Text = "Jogando ilha";
                    lblStatusAuto.ForeColor = Color.Yellow;
                    break;
                //Jogando carta
                case 3:
                    lblStatusAuto.Text = "Jogando Carta";
                    lblStatusAuto.ForeColor = Color.Yellow;
                    break;
                case 4:
                    lblStatusAuto.Text = "Não é minha vez";
                    lblStatusAuto.ForeColor = Color.Cyan;
                    break;
                case 9:
                    lblStatusAuto.Text = "Partida encerrada";
                    lblStatusAuto.ForeColor = Color.Cyan;
                    break;
            }
        }

        /// <summary>
        /// 0 - Aguardando timer
        /// 1 - Muito bode
        /// 2 - Pouco bode
        /// </summary>
        /// <param name="caso"></param>
        public void UpdateStatusMao(int caso)
        {
            switch (caso)
            {
                case 0:
                    lblStatusMao.Text = "Aguardando timer...";
                    lblStatusMao.ForeColor = Color.Green;
                    break;
                case 1:
                    lblStatusMao.Text = "Tenho muito bode";
                    lblStatusMao.ForeColor = Color.Red;
                    break;
                case 2:
                    lblStatusMao.Text = "Tenho pouco bode";
                    lblStatusMao.ForeColor = Color.Green;
                    break;
                case 3:
                    lblStatusMao.Text = "Aguardando timer...";
                    lblStatusMao.ForeColor = Color.Green;
                    break;
                case 9:
                    lblStatusMao.Text = "Partida encerrada";
                    lblStatusMao.ForeColor = Color.Cyan;
                    break;
            }
        }

        /// <summary>
        /// 0 - Tenho a maior carta
        /// 1 - Não tenho a maior carta
        /// 2 - Tenho a menor carta
        /// 3 - Não tenho a menor carta
        /// 4 - Aguardando timer
        /// 5 - Escolhendo ilha
        /// </summary>
        /// <param name="caso"></param>
        public void UpdateStatusMesa(int caso)
        {
            switch (caso)
            {
                case 0:
                    lblStatusMesa.Text = "Tenho a maior carta";
                    lblStatusMesa.ForeColor = Color.Green;
                    break;
                case 1:
                    lblStatusMesa.Text = "Não tenho a maior carta";
                    lblStatusMesa.ForeColor = Color.Red;
                    break;
                case 2:
                    lblStatusMesa.Text = "Tenho a menor carta";
                    lblStatusMesa.ForeColor = Color.Green;
                    break;
                case 3:
                    lblStatusMesa.Text = "Não tenho a menor carta";
                    lblStatusMesa.ForeColor = Color.Red;
                    break;
                case 4:
                    lblStatusMesa.Text = "Aguardando timer...";
                    lblStatusMesa.ForeColor = Color.Green;
                    break;
                case 5:
                    lblStatusMesa.Text = "Escolhendo ilha";
                    lblStatusMesa.ForeColor = Color.Cyan;
                    break;
                case 9:
                    lblStatusMesa.Text = "Partida encerrada";
                    lblStatusMesa.ForeColor = Color.Cyan;
                    break;
            }
        }

        /// <summary>
        /// 0 - Jogar carta alta
        /// 1 - Jogar carta baixa
        /// 2 - Descartar
        /// 3 - Jogar bode alto
        ///
        /// 5 - Ilha maior
        /// 6 - Ilha menor
        /// 7 - Aguardando timer
        /// </summary>
        /// <param name="caso"></param>
        public void UpdateDecisao(int caso)
        {
            switch (caso)
            {
                case 0:
                    lblStatusDecisao.Text = "Jogar carta alta";
                    lblStatusDecisao.ForeColor = Color.Green;
                    break;
                case 1:
                    lblStatusDecisao.Text = "Jogar carta baixa";
                    lblStatusDecisao.ForeColor = Color.Red;
                    break;
                case 2:
                    lblStatusDecisao.Text = "Descartar";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 3:
                    lblStatusDecisao.Text = "Jogar bode alto";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 5:
                    lblStatusDecisao.Text = "Jogar Ilha maior";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 6:
                    lblStatusDecisao.Text = "Jogar Ilha menor";
                    lblStatusDecisao.ForeColor = Color.Orange;
                    break;
                case 7:
                    lblStatusDecisao.Text = "Aguardando timer...";
                    lblStatusDecisao.ForeColor = Color.Green;
                    break;
                case 9:
                    lblStatusDecisao.Text = "Partida encerrada";
                    lblStatusDecisao.ForeColor = Color.Cyan;
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

        public void UpdateMetricas(List<Adversário> jogadores, int rodada, int tamIlha)
        {
            List<int> BodesIndexes = new List<int>();
            List<int> VencedoresIndexes = new List<int>();
            List<int> PerdedoresIndexes = new List<int>();

            foreach(Adversário adversário in jogadores)
            {
                BodesIndexes.Add(adversário.QntBodes);
                VencedoresIndexes.Add(adversário.Vencidas);
                PerdedoresIndexes.Add(adversário.Perdidas);
            }

            txtMaisBodes.Text = jogadores[BodesIndexes.IndexOf(BodesIndexes.Max())].nome;
            txtMaisVenceu.Text = jogadores[VencedoresIndexes.IndexOf(VencedoresIndexes.Max())].nome;
            txtMenosBodes.Text = jogadores[BodesIndexes.IndexOf(BodesIndexes.Min())].nome;
            txtMaisPerdeu.Text = jogadores[PerdedoresIndexes.IndexOf(PerdedoresIndexes.Max())].nome;

            txtRodada.Text = rodada.ToString();
            txtTamIlha.Text = tamIlha.ToString();
        }
    }
}
