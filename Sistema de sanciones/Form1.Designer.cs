namespace Sistema_de_sanciones
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMenuProv = new System.Windows.Forms.Panel();
            this.buttonListarProveedor = new System.Windows.Forms.Button();
            this.buttonCrearProveedor = new System.Windows.Forms.Button();
            this.buttonProveedores = new System.Windows.Forms.Button();
            this.panelMenuUser = new System.Windows.Forms.Panel();
            this.buttonListarUsuarios = new System.Windows.Forms.Button();
            this.buttonCrearUsuario = new System.Windows.Forms.Button();
            this.buttonUsuarios = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelMenuProv.SuspendLayout();
            this.panelMenuUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.panelMenuProv);
            this.panelMenu.Controls.Add(this.buttonProveedores);
            this.panelMenu.Controls.Add(this.panelMenuUser);
            this.panelMenu.Controls.Add(this.buttonUsuarios);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(160, 801);
            this.panelMenu.TabIndex = 0;
            // 
            // panelMenuProv
            // 
            this.panelMenuProv.Controls.Add(this.buttonListarProveedor);
            this.panelMenuProv.Controls.Add(this.buttonCrearProveedor);
            this.panelMenuProv.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuProv.Location = new System.Drawing.Point(0, 231);
            this.panelMenuProv.Name = "panelMenuProv";
            this.panelMenuProv.Size = new System.Drawing.Size(160, 77);
            this.panelMenuProv.TabIndex = 5;
            // 
            // buttonListarProveedor
            // 
            this.buttonListarProveedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonListarProveedor.FlatAppearance.BorderSize = 0;
            this.buttonListarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListarProveedor.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonListarProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonListarProveedor.Location = new System.Drawing.Point(0, 35);
            this.buttonListarProveedor.Name = "buttonListarProveedor";
            this.buttonListarProveedor.Size = new System.Drawing.Size(160, 35);
            this.buttonListarProveedor.TabIndex = 7;
            this.buttonListarProveedor.Text = "Listar Proveedor";
            this.buttonListarProveedor.UseVisualStyleBackColor = true;
            this.buttonListarProveedor.Click += new System.EventHandler(this.buttonListarProveedor_Click);
            // 
            // buttonCrearProveedor
            // 
            this.buttonCrearProveedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCrearProveedor.FlatAppearance.BorderSize = 0;
            this.buttonCrearProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrearProveedor.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonCrearProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCrearProveedor.Location = new System.Drawing.Point(0, 0);
            this.buttonCrearProveedor.Name = "buttonCrearProveedor";
            this.buttonCrearProveedor.Size = new System.Drawing.Size(160, 35);
            this.buttonCrearProveedor.TabIndex = 6;
            this.buttonCrearProveedor.Text = "Crear Proveedor";
            this.buttonCrearProveedor.UseVisualStyleBackColor = true;
            this.buttonCrearProveedor.Click += new System.EventHandler(this.buttonCrearProveedor_Click);
            // 
            // buttonProveedores
            // 
            this.buttonProveedores.BackColor = System.Drawing.Color.White;
            this.buttonProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProveedores.FlatAppearance.BorderSize = 0;
            this.buttonProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProveedores.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonProveedores.Location = new System.Drawing.Point(0, 196);
            this.buttonProveedores.Name = "buttonProveedores";
            this.buttonProveedores.Size = new System.Drawing.Size(160, 35);
            this.buttonProveedores.TabIndex = 4;
            this.buttonProveedores.Text = "Proveedores";
            this.buttonProveedores.UseVisualStyleBackColor = false;
            this.buttonProveedores.Click += new System.EventHandler(this.buttonProveedores_Click);
            // 
            // panelMenuUser
            // 
            this.panelMenuUser.Controls.Add(this.buttonListarUsuarios);
            this.panelMenuUser.Controls.Add(this.buttonCrearUsuario);
            this.panelMenuUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuUser.Location = new System.Drawing.Point(0, 118);
            this.panelMenuUser.Name = "panelMenuUser";
            this.panelMenuUser.Size = new System.Drawing.Size(160, 78);
            this.panelMenuUser.TabIndex = 3;
            // 
            // buttonListarUsuarios
            // 
            this.buttonListarUsuarios.BackColor = System.Drawing.Color.White;
            this.buttonListarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonListarUsuarios.FlatAppearance.BorderSize = 0;
            this.buttonListarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListarUsuarios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonListarUsuarios.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonListarUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonListarUsuarios.Location = new System.Drawing.Point(0, 35);
            this.buttonListarUsuarios.Name = "buttonListarUsuarios";
            this.buttonListarUsuarios.Size = new System.Drawing.Size(160, 35);
            this.buttonListarUsuarios.TabIndex = 1;
            this.buttonListarUsuarios.Text = "Listar Usuarios";
            this.buttonListarUsuarios.UseVisualStyleBackColor = false;
            this.buttonListarUsuarios.Click += new System.EventHandler(this.buttonListarUsuarios_Click);
            // 
            // buttonCrearUsuario
            // 
            this.buttonCrearUsuario.BackColor = System.Drawing.Color.White;
            this.buttonCrearUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCrearUsuario.FlatAppearance.BorderSize = 0;
            this.buttonCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrearUsuario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCrearUsuario.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonCrearUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCrearUsuario.Location = new System.Drawing.Point(0, 0);
            this.buttonCrearUsuario.Name = "buttonCrearUsuario";
            this.buttonCrearUsuario.Size = new System.Drawing.Size(160, 35);
            this.buttonCrearUsuario.TabIndex = 0;
            this.buttonCrearUsuario.Text = "Crear Usuario";
            this.buttonCrearUsuario.UseVisualStyleBackColor = false;
            this.buttonCrearUsuario.Click += new System.EventHandler(this.buttonCrearUsuario_Click);
            // 
            // buttonUsuarios
            // 
            this.buttonUsuarios.BackColor = System.Drawing.Color.White;
            this.buttonUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUsuarios.FlatAppearance.BorderSize = 0;
            this.buttonUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsuarios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonUsuarios.Location = new System.Drawing.Point(0, 83);
            this.buttonUsuarios.Name = "buttonUsuarios";
            this.buttonUsuarios.Size = new System.Drawing.Size(160, 35);
            this.buttonUsuarios.TabIndex = 2;
            this.buttonUsuarios.Text = "Usuarios";
            this.buttonUsuarios.UseVisualStyleBackColor = false;
            this.buttonUsuarios.Click += new System.EventHandler(this.buttonUsuarios_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Sistema_de_sanciones.Properties.Resources.Logo_SEA390X194_Mesa_de_trabajo_1_Mesa_de_trabajo_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mainPanel.Location = new System.Drawing.Point(160, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1174, 801);
            this.mainPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 801);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelMenuProv.ResumeLayout(false);
            this.panelMenuUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenu;
        private Button buttonProveedores;
        private Panel panelMenuUser;
        private Button buttonListarUsuarios;
        private Button buttonCrearUsuario;
        private Button buttonUsuarios;
        private PictureBox pictureBox1;
        private Panel mainPanel;
        private Panel panelMenuProv;
        private Button buttonListarProveedor;
        private Button buttonCrearProveedor;
    }
}