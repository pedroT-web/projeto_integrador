using MySql.Data.MySqlClient;
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
    public partial class editar_funcionarios : Form
    {
        public editar_funcionarios()
        {
            InitializeComponent();
        }

        private void editar_funcionarios_Load(object sender, EventArgs e)
        {
            fnCarregarFuncionarios();
        }

        private string conexaoBanco()
        {
            string conexao = "server=localhost;user id=root;password=;database=projeto_integrador";
            return conexao;
        }

        private void fnCarregarFuncionarios()
        {
            conexaoBanco();

            using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    conn.Open();

                    string select = "SELECT * FROM tb_funcionarios";
                    MySqlCommand cmd = new MySqlCommand(select, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();

                    adaptador.Fill(tabela);

                    GridFuncionarios.DataSource = tabela;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fnAtualizarFuncionario()
        {
            DataGridViewRow funcionarioSelecionado = GridFuncionarios.SelectedRows[0];
            int idFuncionario = Convert.ToInt32(funcionarioSelecionado.Cells["id_funcionario"].Value);
            string nomeFuncionario = (funcionarioSelecionado.Cells["nome_do_funcionario"].Value).ToString();

            DialogResult confirmacao = MessageBox.Show("Deseja Realmente alterar o funcionario " + nomeFuncionario + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
                {
                    try
                    {
                        conn.Open();

                        string update = "UPDATE tb_funcionarios SET nome_do_funcionario = @novoNomeFuncionario WHERE id_funcionario = @id";
                        MySqlCommand cmd = new MySqlCommand(update, conn);
                        cmd.Parameters.AddWithValue("@novoNomeFuncionario", nomeFuncionario);
                        cmd.Parameters.AddWithValue("@id", idFuncionario);
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Funcionario Alterado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de conexão com o banco de dados: \n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            fnAtualizarFuncionario();
        }
    }
}
