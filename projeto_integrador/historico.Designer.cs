namespace projeto_integrador
{
    partial class historico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BotaoHistorico = new System.Windows.Forms.Button();
            this.TabelaHistorico = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.BoxDataInicio = new System.Windows.Forms.DateTimePicker();
            this.BoxDataFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1603, 100);
            this.panel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(714, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 22;
            this.button4.Text = "Pesagem";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(554, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 19;
            this.button2.Text = "Início";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(868, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 21;
            this.button3.Text = "Histórico";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BotaoHistorico
            // 
            this.BotaoHistorico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.BotaoHistorico.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoHistorico.ForeColor = System.Drawing.Color.White;
            this.BotaoHistorico.Location = new System.Drawing.Point(1298, 138);
            this.BotaoHistorico.Name = "BotaoHistorico";
            this.BotaoHistorico.Size = new System.Drawing.Size(145, 41);
            this.BotaoHistorico.TabIndex = 3;
            this.BotaoHistorico.Text = "Gerar Histórico";
            this.BotaoHistorico.UseVisualStyleBackColor = false;
            this.BotaoHistorico.Click += new System.EventHandler(this.Botao_Anual_Click);
            // 
            // TabelaHistorico
            // 
            this.TabelaHistorico.AllowUserToOrderColumns = true;
            this.TabelaHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabelaHistorico.Location = new System.Drawing.Point(555, 197);
            this.TabelaHistorico.Name = "TabelaHistorico";
            this.TabelaHistorico.Size = new System.Drawing.Size(574, 625);
            this.TabelaHistorico.TabIndex = 4;
            this.TabelaHistorico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(148)))), ((int)(((byte)(30)))));
            this.button6.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(1298, 767);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(167, 55);
            this.button6.TabIndex = 18;
            this.button6.Text = "Gerar Relário";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // BoxDataInicio
            // 
            this.BoxDataInicio.CalendarFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxDataInicio.Location = new System.Drawing.Point(438, 143);
            this.BoxDataInicio.Name = "BoxDataInicio";
            this.BoxDataInicio.Size = new System.Drawing.Size(335, 26);
            this.BoxDataInicio.TabIndex = 20;
            // 
            // BoxDataFim
            // 
            this.BoxDataFim.CalendarFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxDataFim.Location = new System.Drawing.Point(857, 143);
            this.BoxDataFim.Name = "BoxDataFim";
            this.BoxDataFim.Size = new System.Drawing.Size(335, 26);
            this.BoxDataFim.TabIndex = 21;
            this.BoxDataFim.ValueChanged += new System.EventHandler(this.BoxDataFim_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(378, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(75)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(810, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Fim";
            // 
            // historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 881);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoxDataFim);
            this.Controls.Add(this.BoxDataInicio);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.TabelaHistorico);
            this.Controls.Add(this.BotaoHistorico);
            this.Controls.Add(this.panel1);
            this.Name = "historico";
            this.Text = "historico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.historico_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabelaHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BotaoHistorico;
        private System.Windows.Forms.DataGridView TabelaHistorico;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DateTimePicker BoxDataInicio;
        private System.Windows.Forms.DateTimePicker BoxDataFim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}