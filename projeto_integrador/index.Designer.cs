namespace projeto_integrador
{
    partial class index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(index));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.botaoPesagem = new System.Windows.Forms.Button();
            this.botaoHistorico = new System.Windows.Forms.Button();
            this.botaoInicio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(510, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(620, 530);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(554, 75);
            this.label1.TabIndex = 2;
            this.label1.Text = "RECICLA SENAC";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(182)))), ((int)(((byte)(209)))));
            this.label2.Location = new System.Drawing.Point(282, 655);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1024, 75);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sistema de reciclagem do senac";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // botaoPesagem
            // 
            this.botaoPesagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.botaoPesagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoPesagem.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoPesagem.ForeColor = System.Drawing.Color.White;
            this.botaoPesagem.Location = new System.Drawing.Point(697, 29);
            this.botaoPesagem.Name = "botaoPesagem";
            this.botaoPesagem.Size = new System.Drawing.Size(112, 34);
            this.botaoPesagem.TabIndex = 18;
            this.botaoPesagem.Text = "Pesagem";
            this.botaoPesagem.UseVisualStyleBackColor = false;
            this.botaoPesagem.Click += new System.EventHandler(this.button4_Click);
            // 
            // botaoHistorico
            // 
            this.botaoHistorico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.botaoHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoHistorico.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoHistorico.ForeColor = System.Drawing.Color.White;
            this.botaoHistorico.Location = new System.Drawing.Point(851, 29);
            this.botaoHistorico.Name = "botaoHistorico";
            this.botaoHistorico.Size = new System.Drawing.Size(112, 34);
            this.botaoHistorico.TabIndex = 17;
            this.botaoHistorico.Text = "Histórico";
            this.botaoHistorico.UseVisualStyleBackColor = false;
            this.botaoHistorico.Click += new System.EventHandler(this.button3_Click);
            // 
            // botaoInicio
            // 
            this.botaoInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.botaoInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoInicio.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoInicio.ForeColor = System.Drawing.Color.White;
            this.botaoInicio.Location = new System.Drawing.Point(537, 29);
            this.botaoInicio.Name = "botaoInicio";
            this.botaoInicio.Size = new System.Drawing.Size(112, 34);
            this.botaoInicio.TabIndex = 16;
            this.botaoInicio.Text = "Início";
            this.botaoInicio.UseVisualStyleBackColor = false;
            this.botaoInicio.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.botaoPesagem);
            this.panel1.Controls.Add(this.botaoHistorico);
            this.panel1.Controls.Add(this.botaoInicio);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1608, 101);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1604, 881);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.Name = "index";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botaoPesagem;
        private System.Windows.Forms.Button botaoHistorico;
        private System.Windows.Forms.Button botaoInicio;
        private System.Windows.Forms.Panel panel1;
    }
}

