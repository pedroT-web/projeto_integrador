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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = "SenacSp";
            string senha = "SenacSp";

            string user = textBoxUsuario.Text;
            string password = textBoxSenha.Text;

            if (usuario == user && senha == password)
            {
                index acessarPesagem = new index();
                acessarPesagem.Show();
            }else if(usuario != user && senha == password)
            {
                MessageBox.Show("Usuário Incorreto, Digite o Usuário Novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxUsuario.Clear();
                textBoxUsuario.Focus();

            }else if(usuario == user && senha != password)
            {
                MessageBox.Show("Senha Incorreta, Digite a senha novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxSenha.Clear();
                textBoxSenha.Focus();
            }
            else
            {
                MessageBox.Show("Ambos estão Incorretos, Digite os Novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxUsuario.Clear();
                textBoxSenha.Clear();
                textBoxUsuario.Focus();
            }

            this.Hide();
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
