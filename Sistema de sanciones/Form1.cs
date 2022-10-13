namespace Sistema_de_sanciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customDesing();
        }

        private void customDesing()
        {
            panelMenuUser.Visible = false;

        }

        private void hideSubMenu()
        {
            if(panelMenuUser.Visible ==true)
                panelMenuUser.Visible=false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible=true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenuUser);
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

        private void buttonListarUsuarios_Click(object sender, EventArgs e)
        {
            loadform(new Listar_Usuarios());
        }

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            loadform(new Crear_Usuario());
        }
    }
}