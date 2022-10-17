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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombres = new Sistema_de_sanciones.Templates.TextBox();
            this.textPApellido = new Sistema_de_sanciones.Templates.TextBox();
            this.textSApellido = new Sistema_de_sanciones.Templates.TextBox();
            this.textCargo = new Sistema_de_sanciones.Templates.TextBox();
            this.textUser = new Sistema_de_sanciones.Templates.TextBox();
            this.textExtension = new Sistema_de_sanciones.Templates.TextBox();
            this.textTelefono = new Sistema_de_sanciones.Templates.TextBox();
            this.textCorreo = new Sistema_de_sanciones.Templates.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(364, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Crear Usuario";
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombres.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombres.BorderColor = System.Drawing.Color.DimGray;
            this.txtNombres.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtNombres.BorderSize = 2;
            this.txtNombres.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombres.ForeColor = System.Drawing.Color.Gray;
            this.txtNombres.Location = new System.Drawing.Point(12, 91);
            this.txtNombres.Multiline = false;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Padding = new System.Windows.Forms.Padding(7);
            this.txtNombres.PasswordChar = false;
            this.txtNombres.Size = new System.Drawing.Size(173, 30);
            this.txtNombres.TabIndex = 9;
            this.txtNombres.Texts = "Nombres *";
            this.txtNombres.UnderlinedStyle = true;
            this.txtNombres.Enter += new System.EventHandler(this.txtNombres_Enter);
            this.txtNombres.Leave += new System.EventHandler(this.txtNombres_Leave);
            // 
            // textPApellido
            // 
            this.textPApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPApellido.BackColor = System.Drawing.SystemColors.Control;
            this.textPApellido.BorderColor = System.Drawing.Color.DimGray;
            this.textPApellido.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textPApellido.BorderSize = 2;
            this.textPApellido.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPApellido.ForeColor = System.Drawing.Color.Gray;
            this.textPApellido.Location = new System.Drawing.Point(221, 91);
            this.textPApellido.Multiline = false;
            this.textPApellido.Name = "textPApellido";
            this.textPApellido.Padding = new System.Windows.Forms.Padding(7);
            this.textPApellido.PasswordChar = false;
            this.textPApellido.Size = new System.Drawing.Size(173, 30);
            this.textPApellido.TabIndex = 10;
            this.textPApellido.Texts = "Primer Apellido *";
            this.textPApellido.UnderlinedStyle = true;
            this.textPApellido.Enter += new System.EventHandler(this.textPApellido_Enter);
            this.textPApellido.Leave += new System.EventHandler(this.textPApellido_Leave);
            // 
            // textSApellido
            // 
            this.textSApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textSApellido.BackColor = System.Drawing.SystemColors.Control;
            this.textSApellido.BorderColor = System.Drawing.Color.DimGray;
            this.textSApellido.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textSApellido.BorderSize = 2;
            this.textSApellido.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textSApellido.ForeColor = System.Drawing.Color.Gray;
            this.textSApellido.Location = new System.Drawing.Point(426, 91);
            this.textSApellido.Multiline = false;
            this.textSApellido.Name = "textSApellido";
            this.textSApellido.Padding = new System.Windows.Forms.Padding(7);
            this.textSApellido.PasswordChar = false;
            this.textSApellido.Size = new System.Drawing.Size(173, 30);
            this.textSApellido.TabIndex = 11;
            this.textSApellido.Texts = "Segundo Apellido";
            this.textSApellido.UnderlinedStyle = true;
            this.textSApellido.Enter += new System.EventHandler(this.textSApellido_Enter);
            this.textSApellido.Leave += new System.EventHandler(this.textSApellido_Leave);
            // 
            // textCargo
            // 
            this.textCargo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textCargo.BackColor = System.Drawing.SystemColors.Control;
            this.textCargo.BorderColor = System.Drawing.Color.DimGray;
            this.textCargo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textCargo.BorderSize = 2;
            this.textCargo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textCargo.ForeColor = System.Drawing.Color.Gray;
            this.textCargo.Location = new System.Drawing.Point(625, 91);
            this.textCargo.Multiline = false;
            this.textCargo.Name = "textCargo";
            this.textCargo.Padding = new System.Windows.Forms.Padding(7);
            this.textCargo.PasswordChar = false;
            this.textCargo.Size = new System.Drawing.Size(173, 30);
            this.textCargo.TabIndex = 12;
            this.textCargo.Texts = "Cargo *";
            this.textCargo.UnderlinedStyle = true;
            this.textCargo.Enter += new System.EventHandler(this.textCargo_Enter);
            this.textCargo.Leave += new System.EventHandler(this.textCargo_Leave);
            // 
            // textUser
            // 
            this.textUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textUser.BackColor = System.Drawing.SystemColors.Control;
            this.textUser.BorderColor = System.Drawing.Color.DimGray;
            this.textUser.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textUser.BorderSize = 2;
            this.textUser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textUser.ForeColor = System.Drawing.Color.Gray;
            this.textUser.Location = new System.Drawing.Point(625, 171);
            this.textUser.Multiline = false;
            this.textUser.Name = "textUser";
            this.textUser.Padding = new System.Windows.Forms.Padding(7);
            this.textUser.PasswordChar = false;
            this.textUser.Size = new System.Drawing.Size(173, 30);
            this.textUser.TabIndex = 16;
            this.textUser.Texts = "Nombre de Usuario *";
            this.textUser.UnderlinedStyle = true;
            this.textUser.Enter += new System.EventHandler(this.textUser_Enter);
            this.textUser.Leave += new System.EventHandler(this.textUser_Leave);
            // 
            // textExtension
            // 
            this.textExtension.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textExtension.BackColor = System.Drawing.SystemColors.Control;
            this.textExtension.BorderColor = System.Drawing.Color.DimGray;
            this.textExtension.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textExtension.BorderSize = 2;
            this.textExtension.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textExtension.ForeColor = System.Drawing.Color.Gray;
            this.textExtension.Location = new System.Drawing.Point(426, 171);
            this.textExtension.Multiline = false;
            this.textExtension.Name = "textExtension";
            this.textExtension.Padding = new System.Windows.Forms.Padding(7);
            this.textExtension.PasswordChar = false;
            this.textExtension.Size = new System.Drawing.Size(173, 30);
            this.textExtension.TabIndex = 15;
            this.textExtension.Texts = "Extensión";
            this.textExtension.UnderlinedStyle = true;
            this.textExtension.Enter += new System.EventHandler(this.textExtension_Enter);
            this.textExtension.Leave += new System.EventHandler(this.textExtension_Leave);
            // 
            // textTelefono
            // 
            this.textTelefono.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textTelefono.BackColor = System.Drawing.SystemColors.Control;
            this.textTelefono.BorderColor = System.Drawing.Color.DimGray;
            this.textTelefono.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textTelefono.BorderSize = 2;
            this.textTelefono.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textTelefono.ForeColor = System.Drawing.Color.Gray;
            this.textTelefono.Location = new System.Drawing.Point(221, 171);
            this.textTelefono.Multiline = false;
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Padding = new System.Windows.Forms.Padding(7);
            this.textTelefono.PasswordChar = false;
            this.textTelefono.Size = new System.Drawing.Size(173, 30);
            this.textTelefono.TabIndex = 14;
            this.textTelefono.Texts = "Número de teléfono *";
            this.textTelefono.UnderlinedStyle = true;
            this.textTelefono.Enter += new System.EventHandler(this.textTelefono_Enter);
            this.textTelefono.Leave += new System.EventHandler(this.textTelefono_Leave);
            // 
            // textCorreo
            // 
            this.textCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textCorreo.BackColor = System.Drawing.SystemColors.Control;
            this.textCorreo.BorderColor = System.Drawing.Color.DimGray;
            this.textCorreo.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textCorreo.BorderSize = 2;
            this.textCorreo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textCorreo.ForeColor = System.Drawing.Color.Gray;
            this.textCorreo.Location = new System.Drawing.Point(12, 171);
            this.textCorreo.Multiline = false;
            this.textCorreo.Name = "textCorreo";
            this.textCorreo.Padding = new System.Windows.Forms.Padding(7);
            this.textCorreo.PasswordChar = false;
            this.textCorreo.Size = new System.Drawing.Size(173, 30);
            this.textCorreo.TabIndex = 13;
            this.textCorreo.Texts = "Correo eléctronico *";
            this.textCorreo.UnderlinedStyle = true;
            this.textCorreo.Enter += new System.EventHandler(this.textCorreo_Enter);
            this.textCorreo.Leave += new System.EventHandler(this.textCorreo_Leave);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(542, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 17;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(678, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 35);
            this.button2.TabIndex = 18;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.ForeColor = System.Drawing.Color.Gray;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 253);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 23);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "  Proveedor de Datos *";
            // 
            // Crear_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
    }
}