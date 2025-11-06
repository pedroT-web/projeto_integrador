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
    public partial class editar_materiais : Form
    {
        public editar_materiais()
        {
            InitializeComponent();
            fnCarregarMateriais();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fnDeletarMaterial();
            fnCarregarMateriais();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string conexaoBanco()
        {
            string conexao = "server=localhost;user id=root;password=;database=projeto_integrador";
            return conexao;
        }
        private void fnCarregarMateriais()
        {
            conexaoBanco();

            using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
            {
                try
                {
                    string script = "SELECT * FROM materiais";
                    MySqlCommand cmd = new MySqlCommand(script, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);

                    GridMateriais.DataSource = tabela;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão com o banco de dados: \n{ex.Message}" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fnAtualizar()
        {

            if (GridMateriais.SelectedRows.Count > 0)
            {
                DataGridViewRow materialSelecionado = GridMateriais.SelectedRows[0];
                int idMaterial = Convert.ToInt32(materialSelecionado.Cells["id_material"].Value);
                string nomeMaterial = Convert.ToString(materialSelecionado.Cells["nome_material"].Value);
                string status = Convert.ToString(materialSelecionado.Cells["ativado"].Value);

                string textoStatus = char.ToUpper(status[0]) + status.Substring(1);

                if (textoStatus != "Ativo" && textoStatus != "Desativo")
                {
                    MessageBox.Show("O status deve ser (Ativo) ou (Desativo)", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult confirmacao = MessageBox.Show("Deseja Realmente alterar o material " + nomeMaterial + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacao == DialogResult.Yes)
                {
                    conexaoBanco();
                    using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
                    {
                        try
                        {
                            conn.Open();
                            string update = "UPDATE materiais SET nome_material = @novo_nome, ativado = @status WHERE id_material = @id";
                            MySqlCommand cmd = new MySqlCommand(update, conn);
                            cmd.Parameters.AddWithValue("@status", textoStatus);
                            cmd.Parameters.AddWithValue("@novo_nome", nomeMaterial);
                            cmd.Parameters.AddWithValue("@id", idMaterial);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Material Alterado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void fnDeletarMaterial()
        {
            if (GridMateriais.SelectedRows.Count > 0)
            {

                DialogResult confirmacao = MessageBox.Show("Você realmente deseja deletar esse material?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacao == DialogResult.Yes)
                {
                    conexaoBanco();

                    DataGridViewRow material = GridMateriais.SelectedRows[0];
                    int idMaterial = Convert.ToInt32(material.Cells["id_material"].Value);

                    using (MySqlConnection conn = new MySqlConnection(conexaoBanco()))
                    {
                        try
                        {
                            conn.Open();
                            string delete = "UPDATE materiais SET ativado = 'Desativo' WHERE id_material = @id";
                            MySqlCommand cmd = new MySqlCommand(delete, conn);
                            cmd.Parameters.AddWithValue("@id", idMaterial);
                            cmd.ExecuteNonQuery();


                            MessageBox.Show("Material Desativado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fnAtualizar();
        }
    }
}
