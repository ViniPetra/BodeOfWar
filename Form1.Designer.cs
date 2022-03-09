namespace BodeOfWar
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnListarPartidas = new System.Windows.Forms.Button();
            this.btnListarJogadores = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.txtPartidas = new System.Windows.Forms.TextBox();
            this.lblPartidas = new System.Windows.Forms.Label();
            this.txtIdPartida = new System.Windows.Forms.TextBox();
            this.txtListarJogadores = new System.Windows.Forms.TextBox();
            this.lblJogadores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnListarPartidas
            // 
            this.btnListarPartidas.Location = new System.Drawing.Point(53, 122);
            this.btnListarPartidas.Name = "btnListarPartidas";
            this.btnListarPartidas.Size = new System.Drawing.Size(96, 23);
            this.btnListarPartidas.TabIndex = 0;
            this.btnListarPartidas.Text = "Listar partidas";
            this.btnListarPartidas.UseVisualStyleBackColor = true;
            this.btnListarPartidas.Click += new System.EventHandler(this.btnListarPartidas_Click);
            // 
            // btnListarJogadores
            // 
            this.btnListarJogadores.Location = new System.Drawing.Point(12, 187);
            this.btnListarJogadores.Name = "btnListarJogadores";
            this.btnListarJogadores.Size = new System.Drawing.Size(96, 23);
            this.btnListarJogadores.TabIndex = 1;
            this.btnListarJogadores.Text = "Listar jogadores";
            this.btnListarJogadores.UseVisualStyleBackColor = true;
            this.btnListarJogadores.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(1071, 428);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(35, 13);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Tag = "lblVersao";
            this.lblVersao.Text = "label1";
            this.lblVersao.Click += new System.EventHandler(this.lvlVersao_Click);
            // 
            // txtPartidas
            // 
            this.txtPartidas.Location = new System.Drawing.Point(182, 54);
            this.txtPartidas.Multiline = true;
            this.txtPartidas.Name = "txtPartidas";
            this.txtPartidas.ReadOnly = true;
            this.txtPartidas.Size = new System.Drawing.Size(256, 335);
            this.txtPartidas.TabIndex = 3;
            // 
            // lblPartidas
            // 
            this.lblPartidas.AutoSize = true;
            this.lblPartidas.Location = new System.Drawing.Point(295, 27);
            this.lblPartidas.Name = "lblPartidas";
            this.lblPartidas.Size = new System.Drawing.Size(45, 13);
            this.lblPartidas.TabIndex = 4;
            this.lblPartidas.Text = "Partidas";
            // 
            // txtIdPartida
            // 
            this.txtIdPartida.Location = new System.Drawing.Point(114, 189);
            this.txtIdPartida.Name = "txtIdPartida";
            this.txtIdPartida.Size = new System.Drawing.Size(22, 20);
            this.txtIdPartida.TabIndex = 5;
            this.txtIdPartida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdPartida_KeyPress);
            // 
            // txtListarJogadores
            // 
            this.txtListarJogadores.Location = new System.Drawing.Point(478, 54);
            this.txtListarJogadores.Multiline = true;
            this.txtListarJogadores.Name = "txtListarJogadores";
            this.txtListarJogadores.Size = new System.Drawing.Size(100, 335);
            this.txtListarJogadores.TabIndex = 6;
            // 
            // lblJogadores
            // 
            this.lblJogadores.AutoSize = true;
            this.lblJogadores.Location = new System.Drawing.Point(502, 27);
            this.lblJogadores.Name = "lblJogadores";
            this.lblJogadores.Size = new System.Drawing.Size(56, 13);
            this.lblJogadores.TabIndex = 7;
            this.lblJogadores.Text = "Jogadores";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 450);
            this.Controls.Add(this.lblJogadores);
            this.Controls.Add(this.txtListarJogadores);
            this.Controls.Add(this.txtIdPartida);
            this.Controls.Add(this.lblPartidas);
            this.Controls.Add(this.txtPartidas);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnListarJogadores);
            this.Controls.Add(this.btnListarPartidas);
            this.Name = "Form1";
            this.Text = "BodeOfWar ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListarPartidas;
        private System.Windows.Forms.Button btnListarJogadores;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.TextBox txtPartidas;
        private System.Windows.Forms.Label lblPartidas;
        private System.Windows.Forms.TextBox txtIdPartida;
        private System.Windows.Forms.TextBox txtListarJogadores;
        private System.Windows.Forms.Label lblJogadores;
    }
}

