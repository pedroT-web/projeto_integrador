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
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pesagem acessarPesagem = new pesagem();
            acessarPesagem.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            historico acessarHistorico = new historico();
            acessarHistorico.Show();
            this.Close();
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
            carregarPeriodo();

            //conexaoBanco();

            //using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            //{
            //    try
            //    {
            //        conexao.Open();
            //        string script = "SELECT * FROM historico_anual";

            //        MySqlCommand cmd = new MySqlCommand(script, conexao);
            //        MySqlDataAdapter adaptar = new MySqlDataAdapter(cmd);
            //        DataTable tabela_anual = new DataTable();
            //        adaptar.Fill(tabela_anual);

            //        TabelaHistorico.DataSource = tabela_anual;
            //        conexao.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void carregarPeriodo()
        {
            string dataInicio = BoxDataInicio.Text;
            DateTime dataInicioAbreviada = DateTime.Parse(dataInicio);
            string dataInicioConvertida = dataInicioAbreviada.ToString("yyyy-MM-dd");

            string dataFim = BoxDataFim.Text;
            DateTime dataFimAbreviada = DateTime.Parse(dataFim);
            string dataFimConvertida = dataInicioAbreviada.ToString("yyyy-MM-dd");

            MessageBox.Show(dataFimConvertida);
            conexaoBanco();

            using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conn.Open();

                    string select = "SELECT cad_peso.peso, cad_peso.data, tb_func.nome_do_funcionario, tb_mate.nome_material FROM cadastro_de_peso AS cad_peso INNER JOIN tb_funcionarios AS tb_func ON tb_func.id_funcionario = cad_peso.id_funcionarios INNER JOIN materiais AS tb_mate ON tb_mate.id_material = cad_peso.id_material WHERE data BETWEEN @data_inicio AND @data_fim";
                    MySqlCommand cmd = new MySqlCommand(select, conn);
                    cmd.Parameters.AddWithValue("@data_inicio", dataInicioConvertida);
                    cmd.Parameters.AddWithValue("@data_fim", dataFimConvertida);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);

                    TabelaHistorico.DataSource = tabela;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BoxDataFim_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
