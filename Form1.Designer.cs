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
            this.txtListarJogadores = new System.Windows.Forms.TextBox();
            this.lblJogadores = new System.Windows.Forms.Label();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.txtNomeCriarPartida = new System.Windows.Forms.TextBox();
            this.txtSenhaCriarPartida = new System.Windows.Forms.TextBox();
            this.lblSenhaCriarPartida = new System.Windows.Forms.Label();
            this.lblNomeCriarPartida = new System.Windows.Forms.Label();
            this.lblCriarPartida = new System.Windows.Forms.Label();
            this.btnEntrarPartida = new System.Windows.Forms.Button();
            this.txtSenhaPartida = new System.Windows.Forms.TextBox();
            this.lblSenhaPartida = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.cbbPartidas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnListarPartidas
            // 
            this.btnListarPartidas.Location = new System.Drawing.Point(12, 134);
            this.btnListarPartidas.Name = "btnListarPartidas";
            this.btnListarPartidas.Size = new System.Drawing.Size(96, 23);
            this.btnListarPartidas.TabIndex = 0;
            this.btnListarPartidas.Text = "Listar partidas";
            this.btnListarPartidas.UseVisualStyleBackColor = true;
            this.btnListarPartidas.Click += new System.EventHandler(this.btnListarPartidas_Click);
            // 
            // btnListarJogadores
            // 
            this.btnListarJogadores.Location = new System.Drawing.Point(11, 189);
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
            this.lblVersao.Location = new System.Drawing.Point(632, 428);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(40, 13);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Tag = "lblVersao";
            this.lblVersao.Text = "Versão";
            // 
            // txtPartidas
            // 
            this.txtPartidas.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtPartidas.Location = new System.Drawing.Point(182, 54);
            this.txtPartidas.Multiline = true;
            this.txtPartidas.Name = "txtPartidas";
            this.txtPartidas.ReadOnly = true;
            this.txtPartidas.Size = new System.Drawing.Size(256, 514);
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
            // txtListarJogadores
            // 
            this.txtListarJogadores.BackColor = System.Drawing.SystemColors.ControlDark;
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
            // btnCriarPartida
            // 
            this.btnCriarPartida.Location = new System.Drawing.Point(8, 366);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(75, 23);
            this.btnCriarPartida.TabIndex = 8;
            this.btnCriarPartida.Text = "Criar partida";
            this.btnCriarPartida.UseVisualStyleBackColor = true;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // txtNomeCriarPartida
            // 
            this.txtNomeCriarPartida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNomeCriarPartida.Location = new System.Drawing.Point(8, 298);
            this.txtNomeCriarPartida.Name = "txtNomeCriarPartida";
            this.txtNomeCriarPartida.Size = new System.Drawing.Size(100, 20);
            this.txtNomeCriarPartida.TabIndex = 9;
            // 
            // txtSenhaCriarPartida
            // 
            this.txtSenhaCriarPartida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtSenhaCriarPartida.Location = new System.Drawing.Point(8, 340);
            this.txtSenhaCriarPartida.Name = "txtSenhaCriarPartida";
            this.txtSenhaCriarPartida.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaCriarPartida.TabIndex = 10;
            // 
            // lblSenhaCriarPartida
            // 
            this.lblSenhaCriarPartida.AutoSize = true;
            this.lblSenhaCriarPartida.Location = new System.Drawing.Point(8, 321);
            this.lblSenhaCriarPartida.Name = "lblSenhaCriarPartida";
            this.lblSenhaCriarPartida.Size = new System.Drawing.Size(38, 13);
            this.lblSenhaCriarPartida.TabIndex = 11;
            this.lblSenhaCriarPartida.Text = "Senha";
            // 
            // lblNomeCriarPartida
            // 
            this.lblNomeCriarPartida.AutoSize = true;
            this.lblNomeCriarPartida.Location = new System.Drawing.Point(8, 279);
            this.lblNomeCriarPartida.Name = "lblNomeCriarPartida";
            this.lblNomeCriarPartida.Size = new System.Drawing.Size(85, 13);
            this.lblNomeCriarPartida.TabIndex = 12;
            this.lblNomeCriarPartida.Text = "Nome da partida";
            // 
            // lblCriarPartida
            // 
            this.lblCriarPartida.AutoSize = true;
            this.lblCriarPartida.Location = new System.Drawing.Point(8, 263);
            this.lblCriarPartida.Name = "lblCriarPartida";
            this.lblCriarPartida.Size = new System.Drawing.Size(63, 13);
            this.lblCriarPartida.TabIndex = 13;
            this.lblCriarPartida.Text = "Criar partida";
            // 
            // btnEntrarPartida
            // 
            this.btnEntrarPartida.Location = new System.Drawing.Point(244, 626);
            this.btnEntrarPartida.Name = "btnEntrarPartida";
            this.btnEntrarPartida.Size = new System.Drawing.Size(100, 23);
            this.btnEntrarPartida.TabIndex = 14;
            this.btnEntrarPartida.Text = "Entrar na partida";
            this.btnEntrarPartida.UseVisualStyleBackColor = true;
            this.btnEntrarPartida.Click += new System.EventHandler(this.btnEntrarPartida_Click);
            // 
            // txtSenhaPartida
            // 
            this.txtSenhaPartida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtSenhaPartida.Location = new System.Drawing.Point(298, 587);
            this.txtSenhaPartida.Name = "txtSenhaPartida";
            this.txtSenhaPartida.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaPartida.TabIndex = 15;
            // 
            // lblSenhaPartida
            // 
            this.lblSenhaPartida.AutoSize = true;
            this.lblSenhaPartida.Location = new System.Drawing.Point(327, 571);
            this.lblSenhaPartida.Name = "lblSenhaPartida";
            this.lblSenhaPartida.Size = new System.Drawing.Size(38, 13);
            this.lblSenhaPartida.TabIndex = 16;
            this.lblSenhaPartida.Text = "Senha";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNome.Location = new System.Drawing.Point(192, 587);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 17;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(229, 571);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 18;
            this.lblNome.Text = "Nome";
            // 
            // lstPartidas
            // 
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.Location = new System.Drawing.Point(701, 54);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(194, 485);
            this.lstPartidas.TabIndex = 19;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);
            // 
            // cbbPartidas
            // 
            this.cbbPartidas.FormattingEnabled = true;
            this.cbbPartidas.Items.AddRange(new object[] {
            "Todas",
            "Abertas",
            "Jogando",
            "Encerradas"});
            this.cbbPartidas.Location = new System.Drawing.Point(115, 135);
            this.cbbPartidas.Name = "cbbPartidas";
            this.cbbPartidas.Size = new System.Drawing.Size(52, 21);
            this.cbbPartidas.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ver possibilidade de \r\napagar esse botão\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(968, 743);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbPartidas);
            this.Controls.Add(this.lstPartidas);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblSenhaPartida);
            this.Controls.Add(this.txtSenhaPartida);
            this.Controls.Add(this.btnEntrarPartida);
            this.Controls.Add(this.lblCriarPartida);
            this.Controls.Add(this.lblNomeCriarPartida);
            this.Controls.Add(this.lblSenhaCriarPartida);
            this.Controls.Add(this.txtSenhaCriarPartida);
            this.Controls.Add(this.txtNomeCriarPartida);
            this.Controls.Add(this.btnCriarPartida);
            this.Controls.Add(this.lblJogadores);
            this.Controls.Add(this.txtListarJogadores);
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
        private System.Windows.Forms.TextBox txtListarJogadores;
        private System.Windows.Forms.Label lblJogadores;
        private System.Windows.Forms.Button btnCriarPartida;
        private System.Windows.Forms.TextBox txtNomeCriarPartida;
        private System.Windows.Forms.TextBox txtSenhaCriarPartida;
        private System.Windows.Forms.Label lblSenhaCriarPartida;
        private System.Windows.Forms.Label lblNomeCriarPartida;
        private System.Windows.Forms.Label lblCriarPartida;
        private System.Windows.Forms.Button btnEntrarPartida;
        private System.Windows.Forms.TextBox txtSenhaPartida;
        private System.Windows.Forms.Label lblSenhaPartida;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.ComboBox cbbPartidas;
        private System.Windows.Forms.Label label1;
    }
}

