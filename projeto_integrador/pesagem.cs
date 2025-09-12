using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            CarregarComboBoxFuncionario();
            CarregarComboBoxMaterial();

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
            int funcionario = Convert.ToInt32(comboBoxFuncionario.SelectedValue);
            int material = Convert.ToInt32(comboBoxMaterial.SelectedValue);

            double peso = 0;


            string data = BoxData.Text;
            if(comboBoxTipoPeso.Text == "G")
            {
                double pesoG = Convert.ToDouble(textBoxPeso.Text);
                peso = pesoG / 1000;
            }
            else
            {
                peso = Convert.ToDouble(textBoxPeso.Text);
            }

            DateTime dataCad = DateTime.Parse(data);
            string dataConvertida = dataCad.ToString("yyyy-MM-dd");

            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string insert = "INSERT INTO cadastro_de_peso(peso, tipo_do_material, id_funcionarios, data) VALUES (@peso, @tipoMaterial, @funcionario, @data)";
                    MySqlCommand cmd = new MySqlCommand(insert, conexao);
                    cmd.Parameters.AddWithValue("@peso", peso);
                    cmd.Parameters.AddWithValue("@tipoMaterial", material);
                    cmd.Parameters.AddWithValue("@funcionario", funcionario);
                    cmd.Parameters.AddWithValue("@data", dataConvertida);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Peso Cadastrado Com sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Refresh();
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
        private void CarregarComboBoxFuncionario()
        {
            conexaoBanco();

            using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conn.Open();
                    // 2.a consulta da tabela do banco 
                    string query = "SELECT nome_do_funcionario, id_funcionario FROM tb_funcionarios";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);
                    comboBoxFuncionario.ValueMember = "id_funcionario";
                    comboBoxFuncionario.DisplayMember = "nome_do_funcionario";
                    comboBoxFuncionario.DataSource = tabela;


                }catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a lista de clientes: " + ex.Message);
                }
            }
        }
        private void CarregarComboBoxMaterial()
        {
            conexaoBanco();
            using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT nome_material, id FROM materiais";
                    MySqlCommand cmd = new MySqlCommand(consulta, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);
                    comboBoxMaterial.ValueMember = "id";
                    comboBoxMaterial.DisplayMember = "nome_material";
                    comboBoxMaterial.DataSource = tabela;
                }catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            cad_funcionario acessarCad = new cad_funcionario();
            acessarCad.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
