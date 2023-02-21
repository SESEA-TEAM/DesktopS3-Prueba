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
        //log es la variable global que usaremos para mandar a llamar el logout
        logout log = new logout();
        //handler que nos ayudara a poder acceder a las funciones del form login
        private Login logHandler;
        //variable de tipo de usuario
        int t;
        //ariable de id de usuario
        int idper;
        //instancia de conexion que no se usa
        private Conexion ConexionBD = new Conexion();
        //para mandar a llamar a este form se necesita una instancia del login, el nombre del usuario, su tipo y su id
        public Form2(Login log, string nombre, int tipo, int id)
        {
            InitializeComponent();
            customDesing();
            //se asigna el nombre al label
            lblMensajeCap.Text = nombre;
            //se asigna el tipo a la variable global
            t= tipo;
            //se manda a llamar la funcion que hace la distincion entre los tipos de usuarios
            tipoUser();
            //asignamos la instancia que llega al mandar a llamar este form a nuestro handler para poder usarlo correctamente en el resto de la ejecucion de este form
            logHandler = log;
            //asignamos el id a la variable global
            idper= id;
        }
        private void customDesing()
        {
            panelMenuUser.Visible = false;
            panelMenuProv.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        //funcion que asigna los elementos disponibles segun el tipo de usuario
        private void tipoUser()
        {
            //en caso de ser administrador
            if (t== 0)
            {
                panel1.Visible = true;
                panel1.Enabled = true;
                label5.Text = "Administrador";
            }
            //en caso de ser capturador
            else if (t== 1)
            {
                panelMenu.Enabled = true;
                panelMenu.Visible = true;
                panel1.Visible = false;
                panel1.Enabled= false;
                label5.Text = "Capturador de datos";
            }
        }

        //funcion de submenus, para que se escondan al seleccionarlos o desseleccionarlos
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

        //funcion de submenus, para que se muestren
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
        //al presionar el boton de administrador se despliega su submenu
        private void buttonAdministrador_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenuUser);
        }
        //al presionar el boton de captura se despliega su submenu
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

        //Las siguientes lineas de codigo estan destinadas para cargar cada uno de los forms que conforman el programa, por lo que cada que se presione click
        //sobre uno de los botones, activara el evento asginado a dicho boton.
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
            loadform(new Captura_SPS(this));
        }

        private void buttonCapturarParticulares_Click(object sender, EventArgs e)
        {
            loadform(new CapPS(this));
        }

        //El evento para cerrar la seccion, en este caso no se cerrara automaticamente la sesion, pues nos preguntara si queremos salir o no, en el caso de que
        //la respuesta sea que no, no ocurrira nada, pues solo el mensaje desaparecera y volveremos a la pantalla en la que estuvieramos en ese momento, y en
        //el caso de que la opcion sea si, procedera a deslogearse ese usuario, para volver a regresarnos a la pantalla de inicio de sesion, por lo que podra
        //iniciar sesion con otro usuario.
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resut = MessageBox.Show("¿Está seguro de cerrar sesión?", "Warning", MessageBoxButtons.YesNo);
            if (resut == DialogResult.Yes)
            {
                log.logoutx(idper);
            //Login inicioSesion = new Login();
            //inicioSesion.Show();
            logHandler.Show();
            this.Hide();
            }
            else if (resut == DialogResult.No)
            {
                return;
            }
        }

        //Para el caso de los visualizar, estos cargaran el form en base al id del elemento seleccionado, por ejemplo, desplegar el form que contendran los
        //datos del registro 23 729, etc...
        public void visualizarSPS(int id)
        {
            loadform(new Datos_SPS(this, id));
        }

        public void visualizarPS(int id)
        {
            loadform(new Datos_PS(this, id));
        }

        //Los editar actualmente ya no tienen ninguna finalidad.
        public void editarPS(int id)
        {
            loadform(new modiPS(this, id));
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

        //evento que asegura que al cerrar el form se cierre la aplicacion y se haga un logout al usuario
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            log.logoutx(idper);
            logHandler.Close();
        }
    }
}
