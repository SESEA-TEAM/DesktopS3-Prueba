namespace Sistema_de_sanciones
{
    partial class Crear_Proveedores
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
            this.textProveedor = new Sistema_de_sanciones.Templates.TextBox();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSistema = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(487, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Crear Proveedor";
            // 
            // textProveedor
            // 
            this.textProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.textProveedor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textProveedor.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textProveedor.BorderSize = 2;
            this.textProveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textProveedor.Location = new System.Drawing.Point(143, 106);
            this.textProveedor.Multiline = false;
            this.textProveedor.Name = "textProveedor";
            this.textProveedor.Padding = new System.Windows.Forms.Padding(7);
            this.textProveedor.PasswordChar = false;
            this.textProveedor.Size = new System.Drawing.Size(266, 31);
            this.textProveedor.TabIndex = 13;
            this.textProveedor.Texts = "Proveedor*";
            this.textProveedor.UnderlinedStyle = true;
            this.textProveedor.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textProveedor.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonEntrar.FlatAppearance.BorderSize = 0;
            this.buttonEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEntrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEntrar.Location = new System.Drawing.Point(759, 279);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(126, 35);
            this.buttonEntrar.TabIndex = 15;
            this.buttonEntrar.Text = "CANCELAR";
            this.buttonEntrar.UseVisualStyleBackColor = false;
            // 
            // Guardar
            // 
            this.Guardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.Guardar.FlatAppearance.BorderSize = 0;
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Guardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Guardar.Location = new System.Drawing.Point(905, 279);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(115, 35);
            this.Guardar.TabIndex = 16;
            this.Guardar.Text = "GUARDAR";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(588, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Selecciona los sistemas aplicables*";
            // 
            // comboSistema
            // 
            this.comboSistema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.comboSistema.FormattingEnabled = true;
            this.comboSistema.Items.AddRange(new object[] {
            "Sistema de los Servidores Públicos Sancionados",
            "Sistema de los Particulares Sancionados",
            "Sistema de los Particulares Sancionados, Sistema de los Particulares Sancionados"});
            this.comboSistema.Location = new System.Drawing.Point(496, 125);
            this.comboSistema.Name = "comboSistema";
            this.comboSistema.Size = new System.Drawing.Size(524, 24);
            this.comboSistema.TabIndex = 26;
            this.comboSistema.Text = "Sistemas aplicable*";
            // 
            // Crear_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 788);
            this.Controls.Add(this.comboSistema);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.textProveedor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Crear_Proveedores";
            this.Text = "Crear_Proveedores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Templates.TextBox textProveedor;
        private Button buttonEntrar;
        private Button Guardar;
        public Label label2;
        private ComboBox comboSistema;
    }
}