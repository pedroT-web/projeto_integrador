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
            if (GridFuncionarios.SelectedRows.Count > 0)
            {

                DataGridViewRow funcionarioSelecionado = GridFuncionarios.SelectedRows[0];
                int idFuncionario = Convert.ToInt32(funcionarioSelecionado.Cells["id_funcionario"].Value);
                string nomeFuncionario = (funcionarioSelecionado.Cells["nome_do_funcionario"].Value).ToString();
                string status = Convert.ToString(funcionarioSelecionado.Cells["ativado"].Value);

                string textoStatus = char.ToUpper(status[0]) + status.Substring(1);

                if (textoStatus != "Ativo" && textoStatus != "Desativo")
                {
                    MessageBox.Show("O status deve ser (Ativo) ou (Desativo)", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult confirmacao = MessageBox.Show("Deseja Realmente alterar o funcionario " + nomeFuncionario + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacao == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
                    {
                        try
                        {
                            conn.Open();

                            string update = "UPDATE tb_funcionarios SET nome_do_funcionario = @novoNomeFuncionario, ativado = @status WHERE id_funcionario = @id";
                            MySqlCommand cmd = new MySqlCommand(update, conn);
                            cmd.Parameters.AddWithValue("@status", textoStatus);
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
            else
            {
                MessageBox.Show("Selecione um registro para executar a alteração", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            fnAtualizarFuncionario();
        }

        private void buttonDeletar_Click(object sender, EventArgs e)
        {
            fnDeletarFuncionario();
            fnCarregarFuncionarios();
        }

        private void fnDeletarFuncionario()
        {
            if (GridFuncionarios.SelectedRows.Count > 0)
            {

                DialogResult confirmacao = MessageBox.Show("Você realmente deseja desativar esse funcionario?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacao == DialogResult.Yes)
                {
                    conexaoBanco();

                    DataGridViewRow funcionario = GridFuncionarios.SelectedRows[0];
                    int idFuncionario = Convert.ToInt32(funcionario.Cells["id_funcionario"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
                    {
                        try
                        {
                            conn.Open();
                            string delete = "UPDATE tb_funcionarios SET ativado = 'Desativo' WHERE id_funcionario = @id";
                            MySqlCommand cmd = new MySqlCommand(delete, conn);
                            cmd.Parameters.AddWithValue("@id", idFuncionario);
                            cmd.ExecuteNonQuery();


                            MessageBox.Show("Funcionario Desativado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Selecione um registro para executar a alteração", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
