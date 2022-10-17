namespace Sistema_de_sanciones
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAdministrador = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonParticular = new System.Windows.Forms.Button();
            this.buttonPublicos = new System.Windows.Forms.Button();
            this.buttonCapturar = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMenuProv = new System.Windows.Forms.Panel();
            this.buttonCapturarParticulares = new System.Windows.Forms.Button();
            this.buttonCapturarPublicos = new System.Windows.Forms.Button();
            this.buttonCaptura = new System.Windows.Forms.Button();
            this.panelMenuUser = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelMenuProv.SuspendLayout();
            this.panelMenuUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdministrador
            // 
            this.buttonAdministrador.BackColor = System.Drawing.Color.White;
            this.buttonAdministrador.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdministrador.FlatAppearance.BorderSize = 0;
            this.buttonAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdministrador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdministrador.Location = new System.Drawing.Point(0, 83);
            this.buttonAdministrador.Name = "buttonAdministrador";
            this.buttonAdministrador.Size = new System.Drawing.Size(199, 35);
            this.buttonAdministrador.TabIndex = 2;
            this.buttonAdministrador.Text = "Administrador datos";
            this.buttonAdministrador.UseVisualStyleBackColor = false;
            this.buttonAdministrador.Click += new System.EventHandler(this.buttonAdministrador_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Sistema_de_sanciones.Properties.Resources.Logo_SEA390X194_Mesa_de_trabajo_1_Mesa_de_trabajo_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonParticular
            // 
            this.buttonParticular.BackColor = System.Drawing.Color.White;
            this.buttonParticular.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonParticular.FlatAppearance.BorderSize = 0;
            this.buttonParticular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParticular.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonParticular.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonParticular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonParticular.Location = new System.Drawing.Point(0, 35);
            this.buttonParticular.Name = "buttonParticular";
            this.buttonParticular.Size = new System.Drawing.Size(199, 35);
            this.buttonParticular.TabIndex = 1;
            this.buttonParticular.Text = "Particulares Sancionados";
            this.buttonParticular.UseVisualStyleBackColor = false;
            this.buttonParticular.Click += new System.EventHandler(this.buttonParticular_Click);
            // 
            // buttonPublicos
            // 
            this.buttonPublicos.BackColor = System.Drawing.Color.White;
            this.buttonPublicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPublicos.FlatAppearance.BorderSize = 0;
            this.buttonPublicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPublicos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPublicos.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonPublicos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPublicos.Location = new System.Drawing.Point(0, 0);
            this.buttonPublicos.Name = "buttonPublicos";
            this.buttonPublicos.Size = new System.Drawing.Size(199, 35);
            this.buttonPublicos.TabIndex = 0;
            this.buttonPublicos.Text = "Servidores Sancionados";
            this.buttonPublicos.UseVisualStyleBackColor = false;
            this.buttonPublicos.Click += new System.EventHandler(this.buttonPublicos_Click);
            // 
            // buttonCapturar
            // 
            this.buttonCapturar.BackColor = System.Drawing.Color.White;
            this.buttonCapturar.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCapturar.FlatAppearance.BorderSize = 0;
            this.buttonCapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCapturar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCapturar.Location = new System.Drawing.Point(0, 196);
            this.buttonCapturar.Name = "buttonCapturar";
            this.buttonCapturar.Size = new System.Drawing.Size(199, 35);
            this.buttonCapturar.TabIndex = 6;
            this.buttonCapturar.Text = "Cargar datos";
            this.buttonCapturar.UseVisualStyleBackColor = false;
            this.buttonCapturar.Click += new System.EventHandler(this.buttonCapturar_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mainPanel.Location = new System.Drawing.Point(199, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1135, 801);
            this.mainPanel.TabIndex = 3;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.panelMenuProv);
            this.panelMenu.Controls.Add(this.buttonCaptura);
            this.panelMenu.Controls.Add(this.buttonCapturar);
            this.panelMenu.Controls.Add(this.panelMenuUser);
            this.panelMenu.Controls.Add(this.buttonAdministrador);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(199, 801);
            this.panelMenu.TabIndex = 2;
            // 
            // panelMenuProv
            // 
            this.panelMenuProv.Controls.Add(this.buttonCapturarParticulares);
            this.panelMenuProv.Controls.Add(this.buttonCapturarPublicos);
            this.panelMenuProv.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuProv.Location = new System.Drawing.Point(0, 266);
            this.panelMenuProv.Name = "panelMenuProv";
            this.panelMenuProv.Size = new System.Drawing.Size(199, 77);
            this.panelMenuProv.TabIndex = 8;
            // 
            // buttonCapturarParticulares
            // 
            this.buttonCapturarParticulares.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCapturarParticulares.FlatAppearance.BorderSize = 0;
            this.buttonCapturarParticulares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCapturarParticulares.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCapturarParticulares.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonCapturarParticulares.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCapturarParticulares.Location = new System.Drawing.Point(0, 35);
            this.buttonCapturarParticulares.Name = "buttonCapturarParticulares";
            this.buttonCapturarParticulares.Size = new System.Drawing.Size(199, 35);
            this.buttonCapturarParticulares.TabIndex = 7;
            this.buttonCapturarParticulares.Text = "Particulares Sancionados";
            this.buttonCapturarParticulares.UseVisualStyleBackColor = true;
            this.buttonCapturarParticulares.Click += new System.EventHandler(this.buttonCapturarParticulares_Click);
            // 
            // buttonCapturarPublicos
            // 
            this.buttonCapturarPublicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCapturarPublicos.FlatAppearance.BorderSize = 0;
            this.buttonCapturarPublicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCapturarPublicos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCapturarPublicos.Image = global::Sistema_de_sanciones.Properties.Resources.flechaAzul;
            this.buttonCapturarPublicos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCapturarPublicos.Location = new System.Drawing.Point(0, 0);
            this.buttonCapturarPublicos.Name = "buttonCapturarPublicos";
            this.buttonCapturarPublicos.Size = new System.Drawing.Size(199, 35);
            this.buttonCapturarPublicos.TabIndex = 6;
            this.buttonCapturarPublicos.Text = "Servidores Sancionados";
            this.buttonCapturarPublicos.UseVisualStyleBackColor = true;
            this.buttonCapturarPublicos.Click += new System.EventHandler(this.buttonCapturarPublicos_Click);
            // 
            // buttonCaptura
            // 
            this.buttonCaptura.BackColor = System.Drawing.Color.White;
            this.buttonCaptura.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCaptura.FlatAppearance.BorderSize = 0;
            this.buttonCaptura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCaptura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCaptura.Location = new System.Drawing.Point(0, 231);
            this.buttonCaptura.Name = "buttonCaptura";
            this.buttonCaptura.Size = new System.Drawing.Size(199, 35);
            this.buttonCaptura.TabIndex = 7;
            this.buttonCaptura.Text = "Capturar datos";
            this.buttonCaptura.UseVisualStyleBackColor = false;
            this.buttonCaptura.Click += new System.EventHandler(this.buttonCaptura_Click);
            // 
            // panelMenuUser
            // 
            this.panelMenuUser.Controls.Add(this.buttonParticular);
            this.panelMenuUser.Controls.Add(this.buttonPublicos);
            this.panelMenuUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuUser.Location = new System.Drawing.Point(0, 118);
            this.panelMenuUser.Name = "panelMenuUser";
            this.panelMenuUser.Size = new System.Drawing.Size(199, 78);
            this.panelMenuUser.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 801);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenuProv.ResumeLayout(false);
            this.panelMenuUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonAdministrador;
        private PictureBox pictureBox1;
        private Button buttonParticular;
        private Button buttonPublicos;
        private Button buttonCapturar;
        private Panel mainPanel;
        private Panel panelMenu;
        private Panel panelMenuUser;
        private Panel panelMenuProv;
        private Button buttonCapturarParticulares;
        private Button buttonCapturarPublicos;
        private Button buttonCaptura;
    }
}