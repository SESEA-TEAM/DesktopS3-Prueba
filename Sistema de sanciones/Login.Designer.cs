namespace Sistema_de_sanciones
{
    partial class Login
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsuario = new Sistema_de_sanciones.Templates.TextBox();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.textContrasena = new Sistema_de_sanciones.Templates.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(309, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sistema de carga de datos S2 Y S3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Sistema_de_sanciones.Properties.Resources.Logo_SEA390X194_Mesa_de_trabajo_1_Mesa_de_trabajo_1;
            this.pictureBox1.Location = new System.Drawing.Point(353, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(41)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(486, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Iniciar sesión";
            // 
            // textUsuario
            // 
            this.textUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.textUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textUsuario.BorderFocusColor = System.Drawing.Color.DarkRed;
            this.textUsuario.BorderSize = 2;
            this.textUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textUsuario.Location = new System.Drawing.Point(448, 423);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textUsuario.Multiline = false;
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Padding = new System.Windows.Forms.Padding(7);
            this.textUsuario.PasswordChar = false;
            this.textUsuario.Size = new System.Drawing.Size(266, 31);
            this.textUsuario.TabIndex = 12;
            this.textUsuario.Texts = "Nombre de usuario*";
            this.textUsuario.UnderlinedStyle = true;
            this.textUsuario.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textUsuario.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonEntrar.FlatAppearance.BorderSize = 0;
            this.buttonEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEntrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEntrar.Location = new System.Drawing.Point(501, 562);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(160, 35);
            this.buttonEntrar.TabIndex = 14;
            this.buttonEntrar.Text = "Entrar";
            this.buttonEntrar.UseVisualStyleBackColor = false;
            this.buttonEntrar.Click += new System.EventHandler(this.buttonEntrar_Click);
            // 
            // textContrasena
            // 
            this.textContrasena.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textContrasena.BackColor = System.Drawing.SystemColors.Control;
            this.textContrasena.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textContrasena.BorderFocusColor = System.Drawing.Color.DarkRed;
            this.textContrasena.BorderSize = 2;
            this.textContrasena.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textContrasena.Location = new System.Drawing.Point(448, 491);
            this.textContrasena.Multiline = false;
            this.textContrasena.Name = "textContrasena";
            this.textContrasena.Padding = new System.Windows.Forms.Padding(7);
            this.textContrasena.PasswordChar = true;
            this.textContrasena.Size = new System.Drawing.Size(266, 31);
            this.textContrasena.TabIndex = 15;
            this.textContrasena.Texts = "Contraseña*";
            this.textContrasena.UnderlinedStyle = true;
            this.textContrasena.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textContrasena.Leave += new System.EventHandler(this.textBox2_Leave_1);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 749);
            this.Controls.Add(this.textContrasena);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        public Button buttonEntrar;
        private Templates.TextBox textUsuario;
        private Templates.TextBox textContrasena;
    }
}