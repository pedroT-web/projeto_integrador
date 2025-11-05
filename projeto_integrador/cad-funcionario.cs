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
using System.Text.RegularExpressions;

namespace projeto_integrador
{
    public partial class cad_funcionario : Form
    {
        public cad_funcionario()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string conexaoBanco = "server=localhost;user id=root;password=;database=projeto_integrador";


            string nomeFuncionario = textBoxNomeFunc.Text;
            bool validarFuncionario = Regex.IsMatch(nomeFuncionario, @"^[A-Za-zÀ-ÿ\s]+$");
            if (!validarFuncionario)
            {
                MessageBox.Show("Digite apenas letras", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexaoBanco))
            {
                try
                {
                    conn.Open();
                    string insert = "INSERT INTO tb_funcionarios (nome_do_funcionario) VALUES (@nome)";
                    MySqlCommand cmd = new MySqlCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@nome", nomeFuncionario);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionário Cadastrado Com Sucesso!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNomeFunc.Clear();
                    conn.Close();
                }
                catch (Exception ex){
                   MessageBox.Show("ERRO DE CONEXÃO COM O BANCO DE DADOS: \n{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cad_funcionario_Load(object sender, EventArgs e)
        {

        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
