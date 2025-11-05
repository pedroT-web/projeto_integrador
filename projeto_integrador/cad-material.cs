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
using System.Text.RegularExpressions;

namespace projeto_integrador
{
    public partial class cad_material : Form
    {
        public cad_material()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string material = textBoxNomeMat.Text;

            bool validarMaterial = Regex.IsMatch(material, @"^[A-Za-zÀ-ÿ\s]+$");
            if (!validarMaterial)
            {
                MessageBox.Show("Digite apenas letras", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Deseja Realmente Cadastrar esse Funcionario?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.Yes)
            {

                string conexaoBanco = "server=localhost;user id=root;password=;database=projeto_integrador";

                using (MySqlConnection conn = new MySqlConnection(conexaoBanco))
                {
                    try
                    {
                        conn.Open();
                        string script = "INSERT INTO materiais (nome_material) VALUE (@nome)";
                        MySqlCommand cmd = new MySqlCommand(script, conn);
                        cmd.Parameters.AddWithValue("@nome", material);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Material Cadastrado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        textBoxNomeMat.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao cadastrar material, ERRO DE CONEXÃO COM O BANCO DE DADOS: \n{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void cad_material_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNomeMat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
