namespace BodeOfWar
{
    partial class MãoEstratégiaStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MãoEstratégiaStatus));
            this.txtJogador1 = new System.Windows.Forms.TextBox();
            this.txtJogador2 = new System.Windows.Forms.TextBox();
            this.txtJogador3 = new System.Windows.Forms.TextBox();
            this.txtJogador4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtJogador1
            // 
            this.txtJogador1.Location = new System.Drawing.Point(13, 13);
            this.txtJogador1.Multiline = true;
            this.txtJogador1.Name = "txtJogador1";
            this.txtJogador1.Size = new System.Drawing.Size(159, 120);
            this.txtJogador1.TabIndex = 0;
            // 
            // txtJogador2
            // 
            this.txtJogador2.Location = new System.Drawing.Point(13, 139);
            this.txtJogador2.Multiline = true;
            this.txtJogador2.Name = "txtJogador2";
            this.txtJogador2.Size = new System.Drawing.Size(159, 120);
            this.txtJogador2.TabIndex = 1;
            // 
            // txtJogador3
            // 
            this.txtJogador3.Location = new System.Drawing.Point(13, 265);
            this.txtJogador3.Multiline = true;
            this.txtJogador3.Name = "txtJogador3";
            this.txtJogador3.Size = new System.Drawing.Size(159, 120);
            this.txtJogador3.TabIndex = 2;
            // 
            // txtJogador4
            // 
            this.txtJogador4.Location = new System.Drawing.Point(13, 391);
            this.txtJogador4.Multiline = true;
            this.txtJogador4.Name = "txtJogador4";
            this.txtJogador4.Size = new System.Drawing.Size(159, 120);
            this.txtJogador4.TabIndex = 3;
            // 
            // MãoEstratégiaStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(184, 768);
            this.ControlBox = false;
            this.Controls.Add(this.txtJogador4);
            this.Controls.Add(this.txtJogador3);
            this.Controls.Add(this.txtJogador2);
            this.Controls.Add(this.txtJogador1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MãoEstratégiaStatus";
            this.ShowInTaskbar = false;
            this.Text = "Mão - Estratégia: Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJogador1;
        private System.Windows.Forms.TextBox txtJogador2;
        private System.Windows.Forms.TextBox txtJogador3;
        private System.Windows.Forms.TextBox txtJogador4;
    }
}