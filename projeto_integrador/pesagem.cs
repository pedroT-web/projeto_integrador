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
    public partial class pesagem : Form
    {
        public pesagem()
        {
            InitializeComponent();
        }

        private void pesagem_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            historico acessarHistorico = new historico();
            acessarHistorico.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index acessarIndex = new index();
            acessarIndex.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pesagem acessarPesagem = new pesagem();
            acessarPesagem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login acessarLogin = new Login();
            acessarLogin.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
