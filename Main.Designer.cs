namespace BodeOfWar
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.pnlListarCriar = new System.Windows.Forms.Panel();
            this.btnVoltarListarCriar = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.pnlCriarPartida = new System.Windows.Forms.Panel();
            this.btnVoltarListarCriar2 = new System.Windows.Forms.Button();
            this.lblNomeCriarPartida = new System.Windows.Forms.Label();
            this.lblSenhaCriarPartida = new System.Windows.Forms.Label();
            this.txtSenhaCriarPartida = new System.Windows.Forms.TextBox();
            this.txtNomeCriarPartida = new System.Windows.Forms.TextBox();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.pnlListarPartidas = new System.Windows.Forms.Panel();
            this.btnVoltarCriarListar = new System.Windows.Forms.Button();
            this.btnEncerradas = new System.Windows.Forms.Button();
            this.btnJogando = new System.Windows.Forms.Button();
            this.btnAbertas = new System.Windows.Forms.Button();
            this.btnTodas = new System.Windows.Forms.Button();
            this.pnlListarPartidas2 = new System.Windows.Forms.Panel();
            this.btnVoltarListarPartidas = new System.Windows.Forms.Button();
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.lblPartidas = new System.Windows.Forms.Label();
            this.pnlDetalhesPartida = new System.Windows.Forms.Panel();
            this.btnVoltarListarPartidas2 = new System.Windows.Forms.Button();
            this.txtSenhaPartida = new System.Windows.Forms.TextBox();
            this.btnEntrarPartida = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblSenhaPartida = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblVez = new System.Windows.Forms.Label();
            this.txtVez = new System.Windows.Forms.TextBox();
            this.txtNarracao = new System.Windows.Forms.TextBox();
            this.lblJogadores = new System.Windows.Forms.Label();
            this.txtListarJogadores = new System.Windows.Forms.TextBox();
            this.lblNarracao = new System.Windows.Forms.Label();
            this.btnAtualizarNarracao = new System.Windows.Forms.Button();
            this.pnlDentroPartida = new System.Windows.Forms.Panel();
            this.btnAutomatico = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlListarCriar.SuspendLayout();
            this.pnlCriarPartida.SuspendLayout();
            this.pnlListarPartidas.SuspendLayout();
            this.pnlListarPartidas2.SuspendLayout();
            this.pnlDetalhesPartida.SuspendLayout();
            this.pnlDentroPartida.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.BackColor = System.Drawing.Color.Silver;
            this.btnIniciarPartida.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnIniciarPartida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnIniciarPartida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIniciarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarPartida.Location = new System.Drawing.Point(85, 10);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(91, 23);
            this.btnIniciarPartida.TabIndex = 25;
            this.btnIniciarPartida.Text = "Iniciar partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = false;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.Silver;
            this.btnManual.Enabled = false;
            this.btnManual.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnManual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnManual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManual.Location = new System.Drawing.Point(27, 54);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(91, 23);
            this.btnManual.TabIndex = 32;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnMostrarMao_Click);
            // 
            // pnlListarCriar
            // 
            this.pnlListarCriar.BackgroundImage = global::BodeOfWar.Properties.Resources.MainBg;
            this.pnlListarCriar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlListarCriar.Controls.Add(this.btnVoltarListarCriar);
            this.pnlListarCriar.Controls.Add(this.btnCriar);
            this.pnlListarCriar.Controls.Add(this.btnListar);
            this.pnlListarCriar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListarCriar.Location = new System.Drawing.Point(0, 0);
            this.pnlListarCriar.Name = "pnlListarCriar";
            this.pnlListarCriar.Size = new System.Drawing.Size(716, 559);
            this.pnlListarCriar.TabIndex = 6;
            // 
            // btnVoltarListarCriar
            // 
            this.btnVoltarListarCriar.BackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarCriar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarCriar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarCriar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltarListarCriar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltarListarCriar.Location = new System.Drawing.Point(12, 13);
            this.btnVoltarListarCriar.Name = "btnVoltarListarCriar";
            this.btnVoltarListarCriar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltarListarCriar.TabIndex = 21;
            this.btnVoltarListarCriar.Text = "Voltar";
            this.btnVoltarListarCriar.UseVisualStyleBackColor = false;
            this.btnVoltarListarCriar.Click += new System.EventHandler(this.btnVoltarListarCriar_Click);
            // 
            // btnCriar
            // 
            this.btnCriar.BackColor = System.Drawing.Color.Silver;
            this.btnCriar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnCriar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCriar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCriar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriar.Location = new System.Drawing.Point(301, 297);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(100, 23);
            this.btnCriar.TabIndex = 1;
            this.btnCriar.Text = "Criar partida";
            this.btnCriar.UseVisualStyleBackColor = false;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.Silver;
            this.btnListar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnListar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Location = new System.Drawing.Point(301, 228);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(100, 23);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar partidas";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // pnlCriarPartida
            // 
            this.pnlCriarPartida.BackgroundImage = global::BodeOfWar.Properties.Resources.MainBg;
            this.pnlCriarPartida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCriarPartida.Controls.Add(this.btnVoltarListarCriar2);
            this.pnlCriarPartida.Controls.Add(this.lblNomeCriarPartida);
            this.pnlCriarPartida.Controls.Add(this.lblSenhaCriarPartida);
            this.pnlCriarPartida.Controls.Add(this.txtSenhaCriarPartida);
            this.pnlCriarPartida.Controls.Add(this.txtNomeCriarPartida);
            this.pnlCriarPartida.Controls.Add(this.btnCriarPartida);
            this.pnlCriarPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCriarPartida.Location = new System.Drawing.Point(0, 0);
            this.pnlCriarPartida.Name = "pnlCriarPartida";
            this.pnlCriarPartida.Size = new System.Drawing.Size(716, 559);
            this.pnlCriarPartida.TabIndex = 34;
            // 
            // btnVoltarListarCriar2
            // 
            this.btnVoltarListarCriar2.BackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarCriar2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarCriar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarCriar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltarListarCriar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltarListarCriar2.Location = new System.Drawing.Point(12, 13);
            this.btnVoltarListarCriar2.Name = "btnVoltarListarCriar2";
            this.btnVoltarListarCriar2.Size = new System.Drawing.Size(75, 23);
            this.btnVoltarListarCriar2.TabIndex = 20;
            this.btnVoltarListarCriar2.Text = "Voltar";
            this.btnVoltarListarCriar2.UseVisualStyleBackColor = false;
            this.btnVoltarListarCriar2.Click += new System.EventHandler(this.btnVoltarListarCriar2_Click);
            // 
            // lblNomeCriarPartida
            // 
            this.lblNomeCriarPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNomeCriarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCriarPartida.Location = new System.Drawing.Point(298, 231);
            this.lblNomeCriarPartida.Name = "lblNomeCriarPartida";
            this.lblNomeCriarPartida.Size = new System.Drawing.Size(100, 12);
            this.lblNomeCriarPartida.TabIndex = 18;
            this.lblNomeCriarPartida.Text = "Nome da partida";
            // 
            // lblSenhaCriarPartida
            // 
            this.lblSenhaCriarPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSenhaCriarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaCriarPartida.Location = new System.Drawing.Point(301, 284);
            this.lblSenhaCriarPartida.Name = "lblSenhaCriarPartida";
            this.lblSenhaCriarPartida.Size = new System.Drawing.Size(100, 13);
            this.lblSenhaCriarPartida.TabIndex = 17;
            this.lblSenhaCriarPartida.Text = "Senha";
            // 
            // txtSenhaCriarPartida
            // 
            this.txtSenhaCriarPartida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtSenhaCriarPartida.Location = new System.Drawing.Point(301, 300);
            this.txtSenhaCriarPartida.Name = "txtSenhaCriarPartida";
            this.txtSenhaCriarPartida.PasswordChar = '*';
            this.txtSenhaCriarPartida.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaCriarPartida.TabIndex = 16;
            // 
            // txtNomeCriarPartida
            // 
            this.txtNomeCriarPartida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNomeCriarPartida.Location = new System.Drawing.Point(298, 246);
            this.txtNomeCriarPartida.Name = "txtNomeCriarPartida";
            this.txtNomeCriarPartida.Size = new System.Drawing.Size(100, 20);
            this.txtNomeCriarPartida.TabIndex = 15;
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.BackColor = System.Drawing.Color.Silver;
            this.btnCriarPartida.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnCriarPartida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCriarPartida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCriarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarPartida.Location = new System.Drawing.Point(314, 326);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(75, 23);
            this.btnCriarPartida.TabIndex = 14;
            this.btnCriarPartida.Text = "Criar partida";
            this.btnCriarPartida.UseVisualStyleBackColor = false;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // pnlListarPartidas
            // 
            this.pnlListarPartidas.BackgroundImage = global::BodeOfWar.Properties.Resources.MainBg;
            this.pnlListarPartidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlListarPartidas.Controls.Add(this.btnVoltarCriarListar);
            this.pnlListarPartidas.Controls.Add(this.btnEncerradas);
            this.pnlListarPartidas.Controls.Add(this.btnJogando);
            this.pnlListarPartidas.Controls.Add(this.btnAbertas);
            this.pnlListarPartidas.Controls.Add(this.btnTodas);
            this.pnlListarPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListarPartidas.Location = new System.Drawing.Point(0, 0);
            this.pnlListarPartidas.Name = "pnlListarPartidas";
            this.pnlListarPartidas.Size = new System.Drawing.Size(716, 559);
            this.pnlListarPartidas.TabIndex = 2;
            // 
            // btnVoltarCriarListar
            // 
            this.btnVoltarCriarListar.BackColor = System.Drawing.Color.Silver;
            this.btnVoltarCriarListar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnVoltarCriarListar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVoltarCriarListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltarCriarListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltarCriarListar.Location = new System.Drawing.Point(12, 13);
            this.btnVoltarCriarListar.Name = "btnVoltarCriarListar";
            this.btnVoltarCriarListar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltarCriarListar.TabIndex = 27;
            this.btnVoltarCriarListar.Text = "Voltar";
            this.btnVoltarCriarListar.UseVisualStyleBackColor = false;
            this.btnVoltarCriarListar.Click += new System.EventHandler(this.btnVoltarCriarListar_Click);
            // 
            // btnEncerradas
            // 
            this.btnEncerradas.BackColor = System.Drawing.Color.Silver;
            this.btnEncerradas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnEncerradas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEncerradas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEncerradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncerradas.Location = new System.Drawing.Point(307, 337);
            this.btnEncerradas.Name = "btnEncerradas";
            this.btnEncerradas.Size = new System.Drawing.Size(75, 23);
            this.btnEncerradas.TabIndex = 26;
            this.btnEncerradas.Text = "Encerradas";
            this.btnEncerradas.UseVisualStyleBackColor = false;
            this.btnEncerradas.Click += new System.EventHandler(this.btnEncerradas_Click);
            // 
            // btnJogando
            // 
            this.btnJogando.BackColor = System.Drawing.Color.Silver;
            this.btnJogando.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnJogando.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnJogando.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnJogando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogando.Location = new System.Drawing.Point(307, 297);
            this.btnJogando.Name = "btnJogando";
            this.btnJogando.Size = new System.Drawing.Size(75, 23);
            this.btnJogando.TabIndex = 25;
            this.btnJogando.Text = "Jogando";
            this.btnJogando.UseVisualStyleBackColor = false;
            this.btnJogando.Click += new System.EventHandler(this.btnJogando_Click);
            // 
            // btnAbertas
            // 
            this.btnAbertas.BackColor = System.Drawing.Color.Silver;
            this.btnAbertas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnAbertas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAbertas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAbertas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbertas.Location = new System.Drawing.Point(307, 257);
            this.btnAbertas.Name = "btnAbertas";
            this.btnAbertas.Size = new System.Drawing.Size(75, 23);
            this.btnAbertas.TabIndex = 24;
            this.btnAbertas.Text = "Abertas";
            this.btnAbertas.UseVisualStyleBackColor = false;
            this.btnAbertas.Click += new System.EventHandler(this.btnAbertas_Click);
            // 
            // btnTodas
            // 
            this.btnTodas.BackColor = System.Drawing.Color.Silver;
            this.btnTodas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnTodas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnTodas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodas.Location = new System.Drawing.Point(307, 217);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(75, 23);
            this.btnTodas.TabIndex = 23;
            this.btnTodas.Text = "Todas";
            this.btnTodas.UseVisualStyleBackColor = false;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // pnlListarPartidas2
            // 
            this.pnlListarPartidas2.BackgroundImage = global::BodeOfWar.Properties.Resources.MainBg;
            this.pnlListarPartidas2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlListarPartidas2.Controls.Add(this.btnVoltarListarPartidas);
            this.pnlListarPartidas2.Controls.Add(this.lstPartidas);
            this.pnlListarPartidas2.Controls.Add(this.lblPartidas);
            this.pnlListarPartidas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListarPartidas2.Location = new System.Drawing.Point(0, 0);
            this.pnlListarPartidas2.Name = "pnlListarPartidas2";
            this.pnlListarPartidas2.Size = new System.Drawing.Size(716, 559);
            this.pnlListarPartidas2.TabIndex = 24;
            // 
            // btnVoltarListarPartidas
            // 
            this.btnVoltarListarPartidas.BackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarPartidas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarPartidas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltarListarPartidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltarListarPartidas.Location = new System.Drawing.Point(12, 13);
            this.btnVoltarListarPartidas.Name = "btnVoltarListarPartidas";
            this.btnVoltarListarPartidas.Size = new System.Drawing.Size(75, 22);
            this.btnVoltarListarPartidas.TabIndex = 22;
            this.btnVoltarListarPartidas.Text = "Voltar";
            this.btnVoltarListarPartidas.UseVisualStyleBackColor = false;
            this.btnVoltarListarPartidas.Click += new System.EventHandler(this.btnVoltarListarPartidas_Click);
            // 
            // lstPartidas
            // 
            this.lstPartidas.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.Location = new System.Drawing.Point(260, 110);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(194, 368);
            this.lstPartidas.TabIndex = 21;
            this.lstPartidas.DoubleClick += new System.EventHandler(this.lstPartidas_DoubleClick);
            // 
            // lblPartidas
            // 
            this.lblPartidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPartidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPartidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartidas.Location = new System.Drawing.Point(260, 86);
            this.lblPartidas.Name = "lblPartidas";
            this.lblPartidas.Size = new System.Drawing.Size(194, 21);
            this.lblPartidas.TabIndex = 20;
            this.lblPartidas.Text = "Partidas";
            this.lblPartidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDetalhesPartida
            // 
            this.pnlDetalhesPartida.BackgroundImage = global::BodeOfWar.Properties.Resources.MainBg;
            this.pnlDetalhesPartida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDetalhesPartida.Controls.Add(this.btnVoltarListarPartidas2);
            this.pnlDetalhesPartida.Controls.Add(this.txtSenhaPartida);
            this.pnlDetalhesPartida.Controls.Add(this.btnEntrarPartida);
            this.pnlDetalhesPartida.Controls.Add(this.txtNome);
            this.pnlDetalhesPartida.Controls.Add(this.lblSenhaPartida);
            this.pnlDetalhesPartida.Controls.Add(this.lblNome);
            this.pnlDetalhesPartida.Controls.Add(this.lblVez);
            this.pnlDetalhesPartida.Controls.Add(this.txtVez);
            this.pnlDetalhesPartida.Controls.Add(this.txtNarracao);
            this.pnlDetalhesPartida.Controls.Add(this.lblJogadores);
            this.pnlDetalhesPartida.Controls.Add(this.txtListarJogadores);
            this.pnlDetalhesPartida.Controls.Add(this.lblNarracao);
            this.pnlDetalhesPartida.Controls.Add(this.btnAtualizarNarracao);
            this.pnlDetalhesPartida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalhesPartida.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalhesPartida.Name = "pnlDetalhesPartida";
            this.pnlDetalhesPartida.Size = new System.Drawing.Size(716, 559);
            this.pnlDetalhesPartida.TabIndex = 33;
            // 
            // btnVoltarListarPartidas2
            // 
            this.btnVoltarListarPartidas2.BackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarPartidas2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltarListarPartidas2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVoltarListarPartidas2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltarListarPartidas2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltarListarPartidas2.Location = new System.Drawing.Point(12, 13);
            this.btnVoltarListarPartidas2.Name = "btnVoltarListarPartidas2";
            this.btnVoltarListarPartidas2.Size = new System.Drawing.Size(75, 23);
            this.btnVoltarListarPartidas2.TabIndex = 44;
            this.btnVoltarListarPartidas2.Text = "Voltar";
            this.btnVoltarListarPartidas2.UseVisualStyleBackColor = false;
            this.btnVoltarListarPartidas2.Click += new System.EventHandler(this.btnVoltarListarPartidas2_Click);
            // 
            // txtSenhaPartida
            // 
            this.txtSenhaPartida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtSenhaPartida.Location = new System.Drawing.Point(341, 480);
            this.txtSenhaPartida.Name = "txtSenhaPartida";
            this.txtSenhaPartida.PasswordChar = '*';
            this.txtSenhaPartida.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaPartida.TabIndex = 35;
            // 
            // btnEntrarPartida
            // 
            this.btnEntrarPartida.BackColor = System.Drawing.Color.Silver;
            this.btnEntrarPartida.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEntrarPartida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEntrarPartida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEntrarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrarPartida.Location = new System.Drawing.Point(292, 514);
            this.btnEntrarPartida.Name = "btnEntrarPartida";
            this.btnEntrarPartida.Size = new System.Drawing.Size(100, 23);
            this.btnEntrarPartida.TabIndex = 34;
            this.btnEntrarPartida.Text = "Entrar na partida";
            this.btnEntrarPartida.UseVisualStyleBackColor = false;
            this.btnEntrarPartida.Click += new System.EventHandler(this.btnEntrarPartida_Click);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNome.Location = new System.Drawing.Point(235, 480);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 37;
            // 
            // lblSenhaPartida
            // 
            this.lblSenhaPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSenhaPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaPartida.Location = new System.Drawing.Point(341, 464);
            this.lblSenhaPartida.Name = "lblSenhaPartida";
            this.lblSenhaPartida.Size = new System.Drawing.Size(100, 13);
            this.lblSenhaPartida.TabIndex = 36;
            this.lblSenhaPartida.Text = "Senha";
            // 
            // lblNome
            // 
            this.lblNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(235, 464);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(100, 13);
            this.lblNome.TabIndex = 38;
            this.lblNome.Text = "Nome";
            // 
            // lblVez
            // 
            this.lblVez.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblVez.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVez.Location = new System.Drawing.Point(341, 80);
            this.lblVez.Name = "lblVez";
            this.lblVez.Size = new System.Drawing.Size(111, 13);
            this.lblVez.TabIndex = 39;
            this.lblVez.Text = "Vez de:";
            // 
            // txtVez
            // 
            this.txtVez.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtVez.Location = new System.Drawing.Point(341, 96);
            this.txtVez.Name = "txtVez";
            this.txtVez.ReadOnly = true;
            this.txtVez.Size = new System.Drawing.Size(111, 20);
            this.txtVez.TabIndex = 40;
            // 
            // txtNarracao
            // 
            this.txtNarracao.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNarracao.Location = new System.Drawing.Point(192, 163);
            this.txtNarracao.Multiline = true;
            this.txtNarracao.Name = "txtNarracao";
            this.txtNarracao.ReadOnly = true;
            this.txtNarracao.Size = new System.Drawing.Size(303, 239);
            this.txtNarracao.TabIndex = 41;
            // 
            // lblJogadores
            // 
            this.lblJogadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJogadores.Location = new System.Drawing.Point(214, 53);
            this.lblJogadores.Name = "lblJogadores";
            this.lblJogadores.Size = new System.Drawing.Size(100, 13);
            this.lblJogadores.TabIndex = 33;
            this.lblJogadores.Text = "Jogadores";
            // 
            // txtListarJogadores
            // 
            this.txtListarJogadores.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtListarJogadores.Location = new System.Drawing.Point(214, 69);
            this.txtListarJogadores.Multiline = true;
            this.txtListarJogadores.Name = "txtListarJogadores";
            this.txtListarJogadores.ReadOnly = true;
            this.txtListarJogadores.Size = new System.Drawing.Size(100, 60);
            this.txtListarJogadores.TabIndex = 32;
            // 
            // lblNarracao
            // 
            this.lblNarracao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNarracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarracao.Location = new System.Drawing.Point(192, 144);
            this.lblNarracao.Name = "lblNarracao";
            this.lblNarracao.Size = new System.Drawing.Size(303, 16);
            this.lblNarracao.TabIndex = 42;
            this.lblNarracao.Text = "Narração";
            // 
            // btnAtualizarNarracao
            // 
            this.btnAtualizarNarracao.BackColor = System.Drawing.Color.Silver;
            this.btnAtualizarNarracao.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAtualizarNarracao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAtualizarNarracao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAtualizarNarracao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarNarracao.Location = new System.Drawing.Point(301, 423);
            this.btnAtualizarNarracao.Name = "btnAtualizarNarracao";
            this.btnAtualizarNarracao.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizarNarracao.TabIndex = 43;
            this.btnAtualizarNarracao.Text = "Atualizar";
            this.btnAtualizarNarracao.UseVisualStyleBackColor = false;
            this.btnAtualizarNarracao.Click += new System.EventHandler(this.btnAtualizarNarracao_Click);
            // 
            // pnlDentroPartida
            // 
            this.pnlDentroPartida.BackColor = System.Drawing.Color.Transparent;
            this.pnlDentroPartida.Controls.Add(this.btnAutomatico);
            this.pnlDentroPartida.Controls.Add(this.btnManual);
            this.pnlDentroPartida.Controls.Add(this.btnIniciarPartida);
            this.pnlDentroPartida.Location = new System.Drawing.Point(209, 452);
            this.pnlDentroPartida.Name = "pnlDentroPartida";
            this.pnlDentroPartida.Size = new System.Drawing.Size(277, 85);
            this.pnlDentroPartida.TabIndex = 44;
            // 
            // btnAutomatico
            // 
            this.btnAutomatico.BackColor = System.Drawing.Color.Silver;
            this.btnAutomatico.Enabled = false;
            this.btnAutomatico.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnAutomatico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAutomatico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAutomatico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutomatico.Location = new System.Drawing.Point(150, 54);
            this.btnAutomatico.Name = "btnAutomatico";
            this.btnAutomatico.Size = new System.Drawing.Size(91, 23);
            this.btnAutomatico.TabIndex = 33;
            this.btnAutomatico.Text = "Automático";
            this.btnAutomatico.UseVisualStyleBackColor = false;
            this.btnAutomatico.Click += new System.EventHandler(this.btnAutomatico_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackgroundImage = global::BodeOfWar.Properties.Resources.MainBg;
            this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlMenu.Controls.Add(this.btnSair);
            this.pnlMenu.Controls.Add(this.btnIniciar);
            this.pnlMenu.Controls.Add(this.lblVersao);
            this.pnlMenu.Controls.Add(this.lblTitulo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(716, 559);
            this.pnlMenu.TabIndex = 33;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Silver;
            this.btnSair.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(319, 494);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(73, 23);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciar.BackColor = System.Drawing.Color.Silver;
            this.btnIniciar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.btnIniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Location = new System.Drawing.Point(319, 462);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIniciar.Size = new System.Drawing.Size(73, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.BackColor = System.Drawing.Color.Transparent;
            this.lblVersao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVersao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.ForeColor = System.Drawing.Color.Black;
            this.lblVersao.Location = new System.Drawing.Point(0, 51);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(716, 51);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Tag = "lblVersao";
            this.lblVersao.Text = "Versão";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(716, 51);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Tag = "";
            this.lblTitulo.Text = "Bode of War - Teletubbies";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(716, 559);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlDetalhesPartida);
            this.Controls.Add(this.pnlCriarPartida);
            this.Controls.Add(this.pnlListarPartidas2);
            this.Controls.Add(this.pnlListarPartidas);
            this.Controls.Add(this.pnlListarCriar);
            this.Controls.Add(this.pnlDentroPartida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BodeOfWar ";
            this.pnlListarCriar.ResumeLayout(false);
            this.pnlCriarPartida.ResumeLayout(false);
            this.pnlCriarPartida.PerformLayout();
            this.pnlListarPartidas.ResumeLayout(false);
            this.pnlListarPartidas2.ResumeLayout(false);
            this.pnlDetalhesPartida.ResumeLayout(false);
            this.pnlDetalhesPartida.PerformLayout();
            this.pnlDentroPartida.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlListarCriar;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Panel pnlCriarPartida;
        private System.Windows.Forms.Label lblNomeCriarPartida;
        private System.Windows.Forms.Label lblSenhaCriarPartida;
        private System.Windows.Forms.TextBox txtSenhaCriarPartida;
        private System.Windows.Forms.TextBox txtNomeCriarPartida;
        private System.Windows.Forms.Button btnCriarPartida;
        private System.Windows.Forms.Panel pnlListarPartidas;
        private System.Windows.Forms.Panel pnlListarPartidas2;
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.Label lblPartidas;
        private System.Windows.Forms.Panel pnlDetalhesPartida;
        private System.Windows.Forms.Label lblVez;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtVez;
        private System.Windows.Forms.TextBox txtNarracao;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblSenhaPartida;
        private System.Windows.Forms.TextBox txtSenhaPartida;
        private System.Windows.Forms.Button btnEntrarPartida;
        private System.Windows.Forms.Label lblJogadores;
        private System.Windows.Forms.TextBox txtListarJogadores;
        private System.Windows.Forms.Label lblNarracao;
        private System.Windows.Forms.Button btnAtualizarNarracao;
        private System.Windows.Forms.Button btnVoltarListarPartidas;
        private System.Windows.Forms.Button btnEncerradas;
        private System.Windows.Forms.Button btnJogando;
        private System.Windows.Forms.Button btnAbertas;
        private System.Windows.Forms.Button btnTodas;
        private System.Windows.Forms.Panel pnlDentroPartida;
        private System.Windows.Forms.Button btnVoltarCriarListar;
        private System.Windows.Forms.Button btnVoltarListarPartidas2;
        private System.Windows.Forms.Button btnVoltarListarCriar2;
        private System.Windows.Forms.Button btnAutomatico;
        private System.Windows.Forms.Button btnVoltarListarCriar;
    }
}

