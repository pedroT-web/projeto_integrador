using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projeto_integrador
{
    public partial class historico : Form
    {
        public historico()
        {
            InitializeComponent();
        }

        private void historico_Load(object sender, EventArgs e)
        {
            

            
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

        private void button3_Click(object sender, EventArgs e)
        {
            historico acessarHistorico = new historico();
            acessarHistorico.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login acessarLogin = new Login();
            acessarLogin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string script = "SELECT * FROM historico_diario";

                    MySqlCommand cmd = new MySqlCommand(script, conexao);
                    MySqlDataAdapter adaptar = new MySqlDataAdapter(cmd);
                    DataTable tabela_diaria = new DataTable();
                    adaptar.Fill(tabela_diaria);

                    TabelaHistorico.DataSource = tabela_diaria;
                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string script = "SELECT * FROM historico_mensal";

                    MySqlCommand cmd = new MySqlCommand(script, conexao);
                    MySqlDataAdapter adaptar = new MySqlDataAdapter(cmd);
                    DataTable tabela_mensal = new DataTable();
                    adaptar.Fill(tabela_mensal);

                    TabelaHistorico.DataSource = tabela_mensal;
                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private string conexaoBanco()
        {
            string conexaoBanco = "server=localhost;user id=root;password=;database=projeto_integrador";
            return conexaoBanco;
        }

        private void Botao_Anual_Click(object sender, EventArgs e)
        {
            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string script = "SELECT * FROM historico_anual";

                    MySqlCommand cmd = new MySqlCommand(script, conexao);
                    MySqlDataAdapter adaptar = new MySqlDataAdapter(cmd);
                    DataTable tabela_anual = new DataTable();
                    adaptar.Fill(tabela_anual);

                    TabelaHistorico.DataSource = tabela_anual;
                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
