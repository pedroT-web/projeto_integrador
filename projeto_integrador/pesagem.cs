using MySql.Data.MySqlClient;
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

           
            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string select = "SELECT hd.data AS data_do_historico, hd.soma_materiais, cp.id AS id_cadastro, cp.peso, cp.tipo_do_material, cp.id_funcionarios, cp.data AS data_cadastro FROM historico_diario hd JOIN cadastro_de_peso cp ON cp.id = hd.id";


                    MySqlCommand cmd = new MySqlCommand(select, conexao);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela_diario = new DataTable();
                    adaptador.Fill(tabela_diario);

                    GridHistoricoDiario.DataSource = tabela_diario;

                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }


            using (MySqlConnection conexaoFuncionarios = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexaoFuncionarios.Open();
                    string selectFuncionarios = "SELECT * FROM tb_funcionario";
                    MySqlCommand cmdFuncionarios = new MySqlCommand(selectFuncionarios, conexaoFuncionarios);
                    MySqlDataAdapter adaptarSelect = new MySqlDataAdapter();
                    comboBoxFuncionario.DataSource = adaptarSelect;
                    conexaoFuncionarios.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            this.Close();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Login acessarLogin = new Login();
            acessarLogin.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string conexaoBanco()
        {
            string conexaoBanco = "server=localhost;user id=root;password=;database=projeto_integrador";
            return conexaoBanco;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string funcionario = comboBoxFuncionario.Text;
            string material = comboBoxMaterial.Text;
            double peso = Convert.ToDouble(textBoxPeso.Text);
            string data = BoxData.Text;

            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection())
            {
                try
                {
                    conexao.Open();
                    string insert = "INSERT INTO cadastro_de_peso(peso, tipo_do_material, id_funcionarios, data) VALUES (@peso, @tipoMaterial, @funcinario, @data)";
                    MySqlCommand cmd = new MySqlCommand(insert, conexao);
                    cmd.Parameters.AddWithValue("@peso", peso);
                    cmd.Parameters.AddWithValue("@tipoMaterial", material);
                    cmd.Parameters.AddWithValue("@funcionario", funcionario);
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Peso Cadastrado Com sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {

            }
        }

        // Função para popular o ComboBox
        private void CarregarComboBox()
        {
            conexaoBanco();

            // 2.a consulta da tabela do banco 
            string query = "SELECT nome_do_funcionario, id_funcionario FROM tb_funcionarios";

            using (SqlConnection conn = new SqlConnection(conexaoBanco()))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Executa a Consulta, ExecuteReader() retorna os dados em formato de leitura, reader permite que voce leia linha por linha
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Cria uma lista para armazenar os dados
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Vinculamento dos dados com o combo box
                    comboBoxFuncionario.DataSource = dt;
                    comboBoxFuncionario.DisplayMember = "nome_do_funcionario";    // O que será exibido no ComboBox
                    comboBoxFuncionario.ValueMember = "id_funcionario"; // O valor associado ao item

                    conn.Close();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Erro de conexão com o banco de dados" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Opcional: Defina o estilo do ComboBox para não permitir digitação livre
            comboBoxFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
