using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Texts == "Nombre de usuario*")
            {
                textBox1.Texts = "";
                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Texts == "")
            {
                textBox1.Texts = "Nombre de usuario*";
                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Texts == "Contraseña*")
            {
                textBox2.Texts = "";
                textBox2.ForeColor = Color.Black;

            }
        }
        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textBox2.Texts == "")
            {
                textBox2.Texts = "Contraseña*";
                textBox2.ForeColor = Color.Black;

            }
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }
    }
}
