using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace Sistema_de_sanciones
{
    
    public partial class Form2 : Form
     
    {
        logout log = new logout();
        private Login logHandler;
        int t;
        int idper;
        private Conexion ConexionBD = new Conexion();
        public Form2(Login log, string nombre, int tipo, int id)
        {
            InitializeComponent();
            customDesing();
            lblMensajeCap.Text = nombre;
            t= tipo;
            tipoUser();
            logHandler = log;
            idper= id;
        }
        private void customDesing()
        {
            panelMenuUser.Visible = false;
            panelMenuProv.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void tipoUser()
        {
            if (t== 0)
            {
                //panelMenu.Enabled = false;
                //panelMenu.Visible= false;
                panel1.Visible = true;
                panel1.Enabled = true;
                label5.Text = "Administrador";
            }
            else if (t== 1)
            {
                panelMenu.Enabled = true;
                panelMenu.Visible = true;
                panel1.Visible = false;
                panel1.Enabled= false;
                label5.Text = "Capturador de datos";
            }
        }

        private void hideSubMenu()
        {
            if (panelMenuUser.Visible == true)
                panelMenuUser.Visible = false;
            if (panelMenuProv.Visible == true)
                panelMenuProv.Visible = false;
            if (panel2.Visible == true)
                panel3.Visible = false;
            if (panel3.Visible == true)
                panel2.Visible = false;
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
            loadform(new FormListadoSPS(this));
        }

        public void ListaSPS()
        {
            loadform(new FormListadoSPS(this));
        }

        public void ListaPS()
        {
            loadform(new Listado_PS(this));
        }

        private void buttonParticular_Click(object sender, EventArgs e)
        {
            loadform(new Listado_PS(this));
        }

        private void buttonCapturar_Click(object sender, EventArgs e)
        {
            loadform(new CargaMasiva());
        }

        private void buttonCapturarPublicos_Click(object sender, EventArgs e)
        {
            loadform(new Captura_SPS());
        }

        private void buttonCapturarParticulares_Click(object sender, EventArgs e)
        {
            loadform(new CapturaPS());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            log.logoutx(idper);
            //Login inicioSesion = new Login();
            //inicioSesion.Show();
            logHandler.Show();
            this.Hide();
        }

        public void visualizarSPS(int id)
        {
            loadform(new Datos_SPS(this, id));
        }

        public void visualizarPS(int id)
        {
            loadform(new Datos_PS(this, id));
        }

        public void editarPS(int id)
        {
            loadform(new modPS(this, id));
        }

        public void editarSPS(int id)
        {
            loadform(new modSPS(this, id));
        }

        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            showSubMenu(panel3);
        }

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            loadform(new Crear_Usuarios());
        }

        private void buttonListarUsuarios_Click(object sender, EventArgs e)
        {
            loadform(new Listar_Usuarios());
        }

        private void buttonProveedores_Click(object sender, EventArgs e)
        {
            panel3.Visible= false;
            showSubMenu(panel2);
        }

        private void buttonCrearProveedor_Click(object sender, EventArgs e)
        {
            loadform(new Crear_Proveedores());
        }

        private void buttonListarProveedor_Click(object sender, EventArgs e)
        {
            loadform(new Listar_Proveedores());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new ReporteBitacora());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.logoutx(idper);
            //Login inicioSesion = new Login();
            //inicioSesion.Show();
            logHandler.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            log.logoutx(idper);
            //Login inicioSesion = new Login();
            //inicioSesion.Show();
            logHandler.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            log.logoutx(idper);
            logHandler.Close();
        }
    }
}
