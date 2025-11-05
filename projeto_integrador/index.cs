using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_integrador
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            historico acessarHistorico = new historico();
            acessarHistorico.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pesagem acessarPesagem = new pesagem();
            acessarPesagem.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index acessarIndex = new index();
            acessarIndex.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pesagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            pesagem acessarPesagem = new pesagem();
            acessarPesagem.Show();
        }

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historico acessarHistorico = new historico();
            acessarHistorico.Show();
            this.Close();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cad_funcionario acessarCad = new cad_funcionario();
            acessarCad.ShowDialog();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cad_material cadastrarMate = new cad_material();
            cadastrarMate.ShowDialog();
        }

        private void históricoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            historico acessarHistorico = new historico();
            acessarHistorico.Show();
        }

        private void ediçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editar_materiais acessarEditMate = new editar_materiais();
            acessarEditMate.ShowDialog();
        }

        private void ediçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editar_funcionarios acessarEditFunc = new editar_funcionarios();
            acessarEditFunc.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inícioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
