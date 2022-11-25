namespace Sistema_de_sanciones
{
    partial class Crear_Usuarios
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombres = new Sistema_de_sanciones.Templates.TextBox();
            this.textPApellido = new Sistema_de_sanciones.Templates.TextBox();
            this.textSApellido = new Sistema_de_sanciones.Templates.TextBox();
            this.textCargo = new Sistema_de_sanciones.Templates.TextBox();
            this.textUser = new Sistema_de_sanciones.Templates.TextBox();
            this.textExtension = new Sistema_de_sanciones.Templates.TextBox();
            this.textTelefono = new Sistema_de_sanciones.Templates.TextBox();
            this.textCorreo = new Sistema_de_sanciones.Templates.TextBox();
            this.comboProveedor = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textContraseña = new Sistema_de_sanciones.Templates.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboPerfil = new System.Windows.Forms.ComboBox();
            this.textConfirmarContra = new Sistema_de_sanciones.Templates.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbMostrar = new System.Windows.Forms.PictureBox();
            this.pbOcultar = new System.Windows.Forms.PictureBox();
            this.pbMostrar1 = new System.Windows.Forms.PictureBox();
            this.pbOcultar1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMostrar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOcultar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(530, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Crear Usuario";
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombres.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombres.BorderColor = System.Drawing.Color.DimGray;
            this.txtNombres.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.txtNombres.BorderSize = 2;
            this.txtNombres.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombres.ForeColor = System.Drawing.Color.Gray;
            this.txtNombres.Location = new System.Drawing.Point(184, 133);
            this.txtNombres.Multiline = false;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Padding = new System.Windows.Forms.Padding(7);
            this.txtNombres.PasswordChar = false;
            this.txtNombres.Size = new System.Drawing.Size(173, 31);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.Texts = "Nombres *";
            this.txtNombres.UnderlinedStyle = true;
            this.txtNombres.Enter += new System.EventHandler(this.txtNombres_Enter);
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            this.txtNombres.Leave += new System.EventHandler(this.txtNombres_Leave);
            // 
            // textPApellido
            // 
            this.textPApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPApellido.BackColor = System.Drawing.SystemColors.Control;
            this.textPApellido.BorderColor = System.Drawing.Color.DimGray;
            this.textPApellido.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textPApellido.BorderSize = 2;
            this.textPApellido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPApellido.ForeColor = System.Drawing.Color.Gray;
            this.textPApellido.Location = new System.Drawing.Point(393, 133);
            this.textPApellido.Multiline = false;
            this.textPApellido.Name = "textPApellido";
            this.textPApellido.Padding = new System.Windows.Forms.Padding(7);
            this.textPApellido.PasswordChar = false;
            this.textPApellido.Size = new System.Drawing.Size(173, 31);
            this.textPApellido.TabIndex = 2;
            this.textPApellido.Texts = "Primer Apellido *";
            this.textPApellido.UnderlinedStyle = true;
            this.textPApellido.Enter += new System.EventHandler(this.textPApellido_Enter);
            this.textPApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPApellido_KeyPress);
            this.textPApellido.Leave += new System.EventHandler(this.textPApellido_Leave);
            // 
            // textSApellido
            // 
            this.textSApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textSApellido.BackColor = System.Drawing.SystemColors.Control;
            this.textSApellido.BorderColor = System.Drawing.Color.DimGray;
            this.textSApellido.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textSApellido.BorderSize = 2;
            this.textSApellido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textSApellido.ForeColor = System.Drawing.Color.Gray;
            this.textSApellido.Location = new System.Drawing.Point(598, 133);
            this.textSApellido.Multiline = false;
            this.textSApellido.Name = "textSApellido";
            this.textSApellido.Padding = new System.Windows.Forms.Padding(7);
            this.textSApellido.PasswordChar = false;
            this.textSApellido.Size = new System.Drawing.Size(173, 31);
            this.textSApellido.TabIndex = 3;
            this.textSApellido.Texts = "Segundo Apellido";
            this.textSApellido.UnderlinedStyle = true;
            this.textSApellido.Enter += new System.EventHandler(this.textSApellido_Enter);
            this.textSApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSApellido_KeyPress);
            this.textSApellido.Leave += new System.EventHandler(this.textSApellido_Leave);
            // 
            // textCargo
            // 
            this.textCargo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textCargo.BackColor = System.Drawing.SystemColors.Control;
            this.textCargo.BorderColor = System.Drawing.Color.DimGray;
            this.textCargo.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textCargo.BorderSize = 2;
            this.textCargo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textCargo.ForeColor = System.Drawing.Color.Gray;
            this.textCargo.Location = new System.Drawing.Point(797, 133);
            this.textCargo.Multiline = false;
            this.textCargo.Name = "textCargo";
            this.textCargo.Padding = new System.Windows.Forms.Padding(7);
            this.textCargo.PasswordChar = false;
            this.textCargo.Size = new System.Drawing.Size(173, 31);
            this.textCargo.TabIndex = 4;
            this.textCargo.Texts = "Cargo *";
            this.textCargo.UnderlinedStyle = true;
            this.textCargo.Enter += new System.EventHandler(this.textCargo_Enter);
            this.textCargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCargo_KeyPress);
            this.textCargo.Leave += new System.EventHandler(this.textCargo_Leave);
            // 
            // textUser
            // 
            this.textUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textUser.BackColor = System.Drawing.SystemColors.Control;
            this.textUser.BorderColor = System.Drawing.Color.DimGray;
            this.textUser.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textUser.BorderSize = 2;
            this.textUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textUser.ForeColor = System.Drawing.Color.Gray;
            this.textUser.Location = new System.Drawing.Point(797, 220);
            this.textUser.Multiline = false;
            this.textUser.Name = "textUser";
            this.textUser.Padding = new System.Windows.Forms.Padding(7);
            this.textUser.PasswordChar = false;
            this.textUser.Size = new System.Drawing.Size(173, 31);
            this.textUser.TabIndex = 8;
            this.textUser.Texts = "Nombre de Usuario *";
            this.textUser.UnderlinedStyle = true;
            this.textUser.Enter += new System.EventHandler(this.textUser_Enter);
            this.textUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUser_KeyPress);
            this.textUser.Leave += new System.EventHandler(this.textUser_Leave);
            // 
            // textExtension
            // 
            this.textExtension.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textExtension.BackColor = System.Drawing.SystemColors.Control;
            this.textExtension.BorderColor = System.Drawing.Color.DimGray;
            this.textExtension.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textExtension.BorderSize = 2;
            this.textExtension.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textExtension.ForeColor = System.Drawing.Color.Gray;
            this.textExtension.Location = new System.Drawing.Point(598, 220);
            this.textExtension.Multiline = false;
            this.textExtension.Name = "textExtension";
            this.textExtension.Padding = new System.Windows.Forms.Padding(7);
            this.textExtension.PasswordChar = false;
            this.textExtension.Size = new System.Drawing.Size(173, 31);
            this.textExtension.TabIndex = 7;
            this.textExtension.Texts = "Extensión";
            this.textExtension.UnderlinedStyle = true;
            this.textExtension.Enter += new System.EventHandler(this.textExtension_Enter);
            this.textExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textExtension_KeyPress);
            this.textExtension.Leave += new System.EventHandler(this.textExtension_Leave);
            // 
            // textTelefono
            // 
            this.textTelefono.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textTelefono.BackColor = System.Drawing.SystemColors.Control;
            this.textTelefono.BorderColor = System.Drawing.Color.DimGray;
            this.textTelefono.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textTelefono.BorderSize = 2;
            this.textTelefono.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textTelefono.ForeColor = System.Drawing.Color.Gray;
            this.textTelefono.Location = new System.Drawing.Point(393, 220);
            this.textTelefono.Multiline = false;
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Padding = new System.Windows.Forms.Padding(7);
            this.textTelefono.PasswordChar = false;
            this.textTelefono.Size = new System.Drawing.Size(173, 31);
            this.textTelefono.TabIndex = 6;
            this.textTelefono.Texts = "Número de teléfono *";
            this.textTelefono.UnderlinedStyle = true;
            this.textTelefono.Enter += new System.EventHandler(this.textTelefono_Enter);
            this.textTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTelefono_KeyPress);
            this.textTelefono.Leave += new System.EventHandler(this.textTelefono_Leave);
            // 
            // textCorreo
            // 
            this.textCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textCorreo.BackColor = System.Drawing.SystemColors.Control;
            this.textCorreo.BorderColor = System.Drawing.Color.DimGray;
            this.textCorreo.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textCorreo.BorderSize = 2;
            this.textCorreo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textCorreo.ForeColor = System.Drawing.Color.Gray;
            this.textCorreo.Location = new System.Drawing.Point(184, 220);
            this.textCorreo.Multiline = false;
            this.textCorreo.Name = "textCorreo";
            this.textCorreo.Padding = new System.Windows.Forms.Padding(7);
            this.textCorreo.PasswordChar = false;
            this.textCorreo.Size = new System.Drawing.Size(173, 31);
            this.textCorreo.TabIndex = 5;
            this.textCorreo.Texts = "Correo eléctronico *";
            this.textCorreo.UnderlinedStyle = true;
            this.textCorreo.Enter += new System.EventHandler(this.textCorreo_Enter);
            this.textCorreo.Leave += new System.EventHandler(this.textCorreo_Leave);
            // 
            // comboProveedor
            // 
            this.comboProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboProveedor.BackColor = System.Drawing.SystemColors.Menu;
            this.comboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboProveedor.ForeColor = System.Drawing.Color.Gray;
            this.comboProveedor.FormattingEnabled = true;
            this.comboProveedor.Location = new System.Drawing.Point(598, 311);
            this.comboProveedor.Name = "comboProveedor";
            this.comboProveedor.Size = new System.Drawing.Size(173, 24);
            this.comboProveedor.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(855, 417);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 35);
            this.button3.TabIndex = 14;
            this.button3.Text = "GUARDAR";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonEntrar.FlatAppearance.BorderSize = 0;
            this.buttonEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEntrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEntrar.Location = new System.Drawing.Point(696, 417);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(126, 35);
            this.buttonEntrar.TabIndex = 13;
            this.buttonEntrar.Text = "CANCELAR";
            this.buttonEntrar.UseVisualStyleBackColor = false;
            this.buttonEntrar.Click += new System.EventHandler(this.buttonEntrar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textContraseña
            // 
            this.textContraseña.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textContraseña.BackColor = System.Drawing.SystemColors.Control;
            this.textContraseña.BorderColor = System.Drawing.Color.DimGray;
            this.textContraseña.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textContraseña.BorderSize = 2;
            this.textContraseña.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textContraseña.ForeColor = System.Drawing.Color.Black;
            this.textContraseña.Location = new System.Drawing.Point(184, 304);
            this.textContraseña.Multiline = false;
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Padding = new System.Windows.Forms.Padding(7);
            this.textContraseña.PasswordChar = true;
            this.textContraseña.Size = new System.Drawing.Size(173, 31);
            this.textContraseña.TabIndex = 9;
            this.textContraseña.Texts = "";
            this.textContraseña.UnderlinedStyle = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(184, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "Ingresa Contraseña*";
            // 
            // comboPerfil
            // 
            this.comboPerfil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboPerfil.BackColor = System.Drawing.SystemColors.Menu;
            this.comboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPerfil.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboPerfil.ForeColor = System.Drawing.Color.Gray;
            this.comboPerfil.FormattingEnabled = true;
            this.comboPerfil.Location = new System.Drawing.Point(797, 311);
            this.comboPerfil.Name = "comboPerfil";
            this.comboPerfil.Size = new System.Drawing.Size(173, 24);
            this.comboPerfil.TabIndex = 12;
            // 
            // textConfirmarContra
            // 
            this.textConfirmarContra.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textConfirmarContra.BackColor = System.Drawing.SystemColors.Control;
            this.textConfirmarContra.BorderColor = System.Drawing.Color.DimGray;
            this.textConfirmarContra.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textConfirmarContra.BorderSize = 2;
            this.textConfirmarContra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textConfirmarContra.ForeColor = System.Drawing.Color.Black;
            this.textConfirmarContra.Location = new System.Drawing.Point(393, 304);
            this.textConfirmarContra.Multiline = false;
            this.textConfirmarContra.Name = "textConfirmarContra";
            this.textConfirmarContra.Padding = new System.Windows.Forms.Padding(7);
            this.textConfirmarContra.PasswordChar = true;
            this.textConfirmarContra.Size = new System.Drawing.Size(173, 31);
            this.textConfirmarContra.TabIndex = 10;
            this.textConfirmarContra.Texts = "";
            this.textConfirmarContra.UnderlinedStyle = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(393, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 16);
            this.label3.TabIndex = 66;
            this.label3.Text = "Confirmar Contraseña*";
            // 
            // pbMostrar
            // 
            this.pbMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMostrar.Image = global::Sistema_de_sanciones.Properties.Resources.ojo;
            this.pbMostrar.Location = new System.Drawing.Point(323, 311);
            this.pbMostrar.Name = "pbMostrar";
            this.pbMostrar.Size = new System.Drawing.Size(34, 20);
            this.pbMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMostrar.TabIndex = 67;
            this.pbMostrar.TabStop = false;
            this.pbMostrar.Click += new System.EventHandler(this.pbMostrar_Click);
            // 
            // pbOcultar
            // 
            this.pbOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOcultar.Image = global::Sistema_de_sanciones.Properties.Resources.ojo_cruzado;
            this.pbOcultar.Location = new System.Drawing.Point(323, 311);
            this.pbOcultar.Name = "pbOcultar";
            this.pbOcultar.Size = new System.Drawing.Size(34, 20);
            this.pbOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOcultar.TabIndex = 68;
            this.pbOcultar.TabStop = false;
            this.pbOcultar.Click += new System.EventHandler(this.pbOcultar_Click);
            // 
            // pbMostrar1
            // 
            this.pbMostrar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMostrar1.Image = global::Sistema_de_sanciones.Properties.Resources.ojo;
            this.pbMostrar1.Location = new System.Drawing.Point(530, 311);
            this.pbMostrar1.Name = "pbMostrar1";
            this.pbMostrar1.Size = new System.Drawing.Size(34, 20);
            this.pbMostrar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMostrar1.TabIndex = 69;
            this.pbMostrar1.TabStop = false;
            this.pbMostrar1.Click += new System.EventHandler(this.pbMostrar1_Click);
            // 
            // pbOcultar1
            // 
            this.pbOcultar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOcultar1.Image = global::Sistema_de_sanciones.Properties.Resources.ojo_cruzado;
            this.pbOcultar1.Location = new System.Drawing.Point(530, 311);
            this.pbOcultar1.Name = "pbOcultar1";
            this.pbOcultar1.Size = new System.Drawing.Size(34, 20);
            this.pbOcultar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOcultar1.TabIndex = 70;
            this.pbOcultar1.TabStop = false;
            this.pbOcultar1.Click += new System.EventHandler(this.pbOcultar1_Click);
            // 
            // Crear_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 801);
            this.Controls.Add(this.pbMostrar1);
            this.Controls.Add(this.pbOcultar1);
            this.Controls.Add(this.pbMostrar);
            this.Controls.Add(this.pbOcultar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textConfirmarContra);
            this.Controls.Add(this.comboPerfil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textContraseña);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.comboProveedor);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.textExtension);
            this.Controls.Add(this.textTelefono);
            this.Controls.Add(this.textCorreo);
            this.Controls.Add(this.textCargo);
            this.Controls.Add(this.textSApellido);
            this.Controls.Add(this.textPApellido);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Crear_Usuarios";
            this.Text = "Crear_Usuarios";
            this.Load += new System.EventHandler(this.Crear_Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMostrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMostrar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOcultar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Templates.TextBox txtNombres;
        private Templates.TextBox textPApellido;
        private Templates.TextBox textSApellido;
        private Templates.TextBox textCargo;
        private Templates.TextBox textUser;
        private Templates.TextBox textExtension;
        private Templates.TextBox textTelefono;
        private Templates.TextBox textCorreo;
        private ComboBox comboProveedor;
        private Button button3;
        private Button buttonEntrar;
        private ErrorProvider errorProvider1;
        private Templates.TextBox textContraseña;
        private Label label2;
        private ComboBox comboPerfil;
        private Label label3;
        private Templates.TextBox textConfirmarContra;
        private PictureBox pbOcultar;
        private PictureBox pbMostrar;
        private PictureBox pbMostrar1;
        private PictureBox pbOcultar1;
    }
}