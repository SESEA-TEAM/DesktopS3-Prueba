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
    public partial class Form2 : Form
    {
        public Form2(string nombre)
        {
            InitializeComponent();
            customDesing();
            lblMensajeCap.Text = nombre;
        }
        private void customDesing()
        {
            panelMenuUser.Visible = false;
            panelMenuProv.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panelMenuUser.Visible == true)
                panelMenuUser.Visible = false;
            if (panelMenuProv.Visible == true)
                panelMenuProv.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void buttonAdministrador_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenuUser);
        }
        private void buttonCaptura_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenuProv);
        }

        //Pestañas Añadidas
        public void loadform(object Form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }

        private void buttonPublicos_Click(object sender, EventArgs e)
        {
            loadform(new Datos_PS());
        }

        private void buttonParticular_Click(object sender, EventArgs e)
        {
            loadform(new Datos_SPS());
        }

        private void buttonCapturar_Click(object sender, EventArgs e)
        {
            loadform(new CargaMasiva());
        }

        private void buttonCapturarPublicos_Click(object sender, EventArgs e)
        {
            loadform(new CapturaPS());
        }

        private void buttonCapturarParticulares_Click(object sender, EventArgs e)
        {
            loadform(new Datos_SPS());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login inicioSesion = new Login();
            inicioSesion.Show();
            this.Hide();
        }
    }
}
