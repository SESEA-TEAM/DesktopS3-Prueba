namespace Sistema_de_sanciones
{
    partial class Editar_Proveedor
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
            this.textProveedor = new Sistema_de_sanciones.Templates.TextBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSistema = new System.Windows.Forms.ComboBox();
            this.comboEstatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textProveedor
            // 
            this.textProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.textProveedor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textProveedor.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textProveedor.BorderSize = 2;
            this.textProveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textProveedor.Location = new System.Drawing.Point(117, 107);
            this.textProveedor.Multiline = false;
            this.textProveedor.Name = "textProveedor";
            this.textProveedor.Padding = new System.Windows.Forms.Padding(7);
            this.textProveedor.PasswordChar = false;
            this.textProveedor.Size = new System.Drawing.Size(266, 31);
            this.textProveedor.TabIndex = 14;
            this.textProveedor.Texts = "";
            this.textProveedor.UnderlinedStyle = true;
            this.textProveedor.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textProveedor.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Guardar
            // 
            this.Guardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.Guardar.FlatAppearance.BorderSize = 0;
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Guardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Guardar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Guardar.Location = new System.Drawing.Point(833, 283);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(115, 35);
            this.Guardar.TabIndex = 19;
            this.Guardar.Text = "GUARDAR";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonEntrar.FlatAppearance.BorderSize = 0;
            this.buttonEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEntrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEntrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonEntrar.Location = new System.Drawing.Point(687, 283);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(126, 35);
            this.buttonEntrar.TabIndex = 18;
            this.buttonEntrar.Text = "CANCELAR";
            this.buttonEntrar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(501, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Editar Proveedor";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(117, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Estatus*";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(531, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Selecciona los sistemas aplicables*";
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
            this.comboSistema.Location = new System.Drawing.Point(531, 114);
            this.comboSistema.Name = "comboSistema";
            this.comboSistema.Size = new System.Drawing.Size(524, 24);
            this.comboSistema.TabIndex = 28;
            this.comboSistema.Text = "Sistemas aplicable*";
            // 
            // comboEstatus
            // 
            this.comboEstatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboEstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.comboEstatus.FormattingEnabled = true;
            this.comboEstatus.Items.AddRange(new object[] {
            "Vigente",
            "No vigente"});
            this.comboEstatus.Location = new System.Drawing.Point(117, 214);
            this.comboEstatus.Name = "comboEstatus";
            this.comboEstatus.Size = new System.Drawing.Size(172, 24);
            this.comboEstatus.TabIndex = 29;
            this.comboEstatus.Text = "Seleccionar Estatus*";
            // 
            // Editar_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1174, 801);
            this.ControlBox = false;
            this.Controls.Add(this.comboEstatus);
            this.Controls.Add(this.comboSistema);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.textProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Editar_Proveedor";
            this.Text = "Editar_Proveedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Guardar;
        private Button buttonEntrar;
        private Label label1;
        public Templates.TextBox textProveedor;
        public Label label2;
        public Label label4;
        public ComboBox comboSistema;
        public ComboBox comboEstatus;
    }
}