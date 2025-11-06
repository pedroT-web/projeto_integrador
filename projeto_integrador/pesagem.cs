using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

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
            DateTime dataAtual = DateTime.Now;

            CarregarComboBoxFuncionario();

            carregarComboBoxMaterial();

            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string select = "SELECT cad_peso.peso, cad_peso.data, tb_func.nome_do_funcionario, tb_mate.nome_material FROM cadastro_de_peso AS cad_peso INNER JOIN tb_funcionarios AS tb_func ON tb_func.id_funcionario = cad_peso.id_funcionarios INNER JOIN materiais AS tb_mate ON tb_mate.id_material = cad_peso.id_material WHERE data = @data";


                    MySqlCommand cmd = new MySqlCommand(select, conexao);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@data", dataAtual);
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

            carregarComboBoxMaterial();
            carregarGrid();

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
            string funcionario = Convert.ToString(comboBoxFuncionario.SelectedValue);
            int id_funcionario = 0;

            string material = Convert.ToString(comboBoxMaterial.SelectedValue);
            int id_material = 0;

            string peso = "";
            peso = Convert.ToString(textBoxPeso.Text);
            double peso_convertido = 0;
            bool validarPeso = Regex.IsMatch(peso, @"^\d+([.,]\d+)?$");

            string data = BoxData.Text;


            if (funcionario == "")
            {
                MessageBox.Show("Selecione um funcionário na lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                id_funcionario = Convert.ToInt32(funcionario);

            }


            if (material == "")
            {
                MessageBox.Show("Selecione um material na lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                id_material = Convert.ToInt32(material);
            }


            if (peso == "")
            {
                MessageBox.Show("Digite o peso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }else if (!validarPeso)
            {
                MessageBox.Show("peso inválido, é aceito apenas números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                peso_convertido = Convert.ToDouble(peso);
            }




            DateTime dataAbreviada = DateTime.Parse(data);
            string dataConvertida = dataAbreviada.ToString("yyyy-MM-dd");

            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {

                //conexao.Open();
                //string insert = "INSERT INTO cadastro_de_peso(peso, tipo_do_material, id_funcionarios, data) VALUES (@peso, @tipoMaterial, @funcionario, @data)";
                //MySqlCommand cmd = new MySqlCommand(insert, conexao);

                using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
                {
                    try
                    {
                        conn.Open();
                        string insert = "INSERT INTO cadastro_de_peso(peso, id_funcionarios, id_material, data) VALUES (@peso, @funcionario, @id_material ,@data_cadastro)";
                        MySqlCommand cmd = new MySqlCommand(insert, conn);

                        cmd.Parameters.AddWithValue("@peso", peso_convertido);
                        cmd.Parameters.AddWithValue("@funcionario", id_funcionario);

                        cmd.Parameters.AddWithValue("@data", dataConvertida);

                        cmd.Parameters.AddWithValue("@id_material", id_material);
                        cmd.Parameters.AddWithValue("@data_cadastro", dataConvertida);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Peso Cadastrado Com sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        carregarGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Refresh();
                }

            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    string query = "SELECT nome_do_funcionario, id_funcionario FROM tb_funcionarios WHERE ativado = 'Ativo'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);

                    DataRow linhaVazia = tabela.NewRow(); // Nova linha de dados vazia utilizando a mesma estrutura da tabela declarada anteriormente
                    linhaVazia["id_funcionario"] = DBNull.Value; // define o valor da coluna id_funcionario como nulo
                    linhaVazia["nome_do_funcionario"] = ""; // define o valor da coluna nome_do_funcionario como vazio
                    tabela.Rows.InsertAt(linhaVazia, 0); // Insere a nova linha vazia no indice 0 da comboBox

                    comboBoxFuncionario.ValueMember = "id_funcionario";
                    comboBoxFuncionario.DisplayMember = "nome_do_funcionario";
                    comboBoxFuncionario.DataSource = tabela;

                    conn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao carregar a lista de clientes: " + ex.Message);
                }
            }
        }

        private void carregarComboBoxMaterial()
        {
            conexaoBanco();
            using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT nome_material, id_material FROM materiais WHERE ativado = 'Ativo'";
                    MySqlCommand cmd = new MySqlCommand(consulta, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);

                    DataRow linhaVazia = tabela.NewRow(); // Nova linha de dados vazia utilizando a mesma estrutura da tabela declarada anteriormente
                    linhaVazia["id_material"] = DBNull.Value; // define o valor da coluna id_funcionario como nulo
                    linhaVazia["nome_material"] = ""; // define o valor da coluna nome_do_funcionario como vazio
                    tabela.Rows.InsertAt(linhaVazia, 0); // Insere a nova linha vazia no indice 0 da comboBox

                    comboBoxMaterial.ValueMember = "id_material";
                    comboBoxMaterial.DisplayMember = "nome_material";
                    comboBoxMaterial.DataSource = tabela;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            cad_funcionario acessarCad = new cad_funcionario();
            acessarCad.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        { }

        private void carregarGrid()
        {
            // Pega a data do dia atua
            DateTime dataAtual = DateTime.Now;

            string dataFormatada = dataAtual.ToString("yyyy-MM-dd");

            conexaoBanco();

            using (MySqlConnection conexao = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conexao.Open();
                    string select = "SELECT cad_peso.peso,cad_peso.data, tb_func.nome_do_funcionario, tb_mate.nome_material FROM cadastro_de_peso AS cad_peso INNER JOIN tb_funcionarios AS tb_func ON tb_func.id_funcionario = cad_peso.id_funcionarios INNER JOIN materiais AS tb_mate ON tb_mate.id_material = cad_peso.id_material WHERE data = @data ORDER BY id";

                    MySqlCommand cmd = new MySqlCommand(select, conexao);
                    cmd.Parameters.AddWithValue("@data", dataFormatada);
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

        private void buttonCadMaterial_Click(object sender, EventArgs e)
        {
            this.Close();
            cad_material cadastrarMate = new cad_material();
            cadastrarMate.ShowDialog();
        }

        private void BoxData_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
