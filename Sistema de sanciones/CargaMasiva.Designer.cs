namespace Sistema_de_sanciones
{
    partial class CargaMasiva
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
            this.btnGuardarPS = new System.Windows.Forms.Button();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboSistema = new System.Windows.Forms.ComboBox();
            this.btnMostrarPS = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.cboHojas = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelPS = new System.Windows.Forms.Panel();
            this.btnLimpar2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelSPS = new System.Windows.Forms.Panel();
            this.btnLimpiar1 = new System.Windows.Forms.Button();
            this.btnGuardarSPS = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnMostrarSPS = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelSPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(41)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(602, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Carga de datos";
            // 
            // btnGuardarPS
            // 
            this.btnGuardarPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnGuardarPS.FlatAppearance.BorderSize = 0;
            this.btnGuardarPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarPS.Location = new System.Drawing.Point(1010, 516);
            this.btnGuardarPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarPS.Name = "btnGuardarPS";
            this.btnGuardarPS.Size = new System.Drawing.Size(114, 37);
            this.btnGuardarPS.TabIndex = 28;
            this.btnGuardarPS.Text = "GUARDAR";
            this.btnGuardarPS.UseVisualStyleBackColor = false;
            this.btnGuardarPS.Click += new System.EventHandler(this.btnGuardarPS_Click);
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonSeleccionar.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeleccionar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSeleccionar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSeleccionar.Location = new System.Drawing.Point(778, 153);
            this.buttonSeleccionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(190, 40);
            this.buttonSeleccionar.TabIndex = 27;
            this.buttonSeleccionar.Text = "Seleccionar archivo";
            this.buttonSeleccionar.UseVisualStyleBackColor = false;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.panelTitulo.Controls.Add(this.label6);
            this.panelTitulo.Controls.Add(this.label9);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1342, 76);
            this.panelTitulo.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1575, -81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "S3";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(530, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(309, 27);
            this.label9.TabIndex = 1;
            this.label9.Text = "Sistema de Carga de Datos";
            // 
            // comboSistema
            // 
            this.comboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSistema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.comboSistema.FormattingEnabled = true;
            this.comboSistema.Items.AddRange(new object[] {
            "Sistema de los Servidores Públicos Sancionados",
            "Sistema de los Particulares Sancionados"});
            this.comboSistema.Location = new System.Drawing.Point(34, 159);
            this.comboSistema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboSistema.Name = "comboSistema";
            this.comboSistema.Size = new System.Drawing.Size(622, 26);
            this.comboSistema.TabIndex = 35;
            this.comboSistema.SelectedIndexChanged += new System.EventHandler(this.comboSistema_SelectedIndexChanged);
            // 
            // btnMostrarPS
            // 
            this.btnMostrarPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnMostrarPS.FlatAppearance.BorderSize = 0;
            this.btnMostrarPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMostrarPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMostrarPS.Location = new System.Drawing.Point(831, 220);
            this.btnMostrarPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMostrarPS.Name = "btnMostrarPS";
            this.btnMostrarPS.Size = new System.Drawing.Size(109, 40);
            this.btnMostrarPS.TabIndex = 37;
            this.btnMostrarPS.Text = "Validar";
            this.btnMostrarPS.UseVisualStyleBackColor = false;
            this.btnMostrarPS.Click += new System.EventHandler(this.btnMostrarPS_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(45, 212);
            this.txtRuta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(258, 27);
            this.txtRuta.TabIndex = 38;
            this.txtRuta.Visible = false;
            // 
            // cboHojas
            // 
            this.cboHojas.FormattingEnabled = true;
            this.cboHojas.Location = new System.Drawing.Point(371, 213);
            this.cboHojas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboHojas.Name = "cboHojas";
            this.cboHojas.Size = new System.Drawing.Size(138, 28);
            this.cboHojas.TabIndex = 39;
            this.cboHojas.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelPS
            // 
            this.panelPS.Controls.Add(this.btnLimpar2);
            this.panelPS.Controls.Add(this.dataGridView1);
            this.panelPS.Controls.Add(this.btnGuardarPS);
            this.panelPS.Location = new System.Drawing.Point(0, 293);
            this.panelPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPS.Name = "panelPS";
            this.panelPS.Size = new System.Drawing.Size(1342, 563);
            this.panelPS.TabIndex = 40;
            // 
            // btnLimpar2
            // 
            this.btnLimpar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnLimpar2.FlatAppearance.BorderSize = 0;
            this.btnLimpar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLimpar2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar2.Location = new System.Drawing.Point(34, 516);
            this.btnLimpar2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpar2.Name = "btnLimpar2";
            this.btnLimpar2.Size = new System.Drawing.Size(114, 37);
            this.btnLimpar2.TabIndex = 38;
            this.btnLimpar2.Text = "Limpiar";
            this.btnLimpar2.UseVisualStyleBackColor = false;
            this.btnLimpar2.Click += new System.EventHandler(this.btnLimpar2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1278, 471);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // panelSPS
            // 
            this.panelSPS.Controls.Add(this.btnLimpiar1);
            this.panelSPS.Controls.Add(this.btnGuardarSPS);
            this.panelSPS.Controls.Add(this.dataGridView2);
            this.panelSPS.Location = new System.Drawing.Point(0, 293);
            this.panelSPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSPS.Name = "panelSPS";
            this.panelSPS.Size = new System.Drawing.Size(1335, 563);
            this.panelSPS.TabIndex = 41;
            // 
            // btnLimpiar1
            // 
            this.btnLimpiar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnLimpiar1.FlatAppearance.BorderSize = 0;
            this.btnLimpiar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpiar1.Location = new System.Drawing.Point(31, 516);
            this.btnLimpiar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpiar1.Name = "btnLimpiar1";
            this.btnLimpiar1.Size = new System.Drawing.Size(114, 37);
            this.btnLimpiar1.TabIndex = 44;
            this.btnLimpiar1.Text = "Limpiar";
            this.btnLimpiar1.UseVisualStyleBackColor = false;
            this.btnLimpiar1.Click += new System.EventHandler(this.btnLimpiar1_Click);
            // 
            // btnGuardarSPS
            // 
            this.btnGuardarSPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnGuardarSPS.FlatAppearance.BorderSize = 0;
            this.btnGuardarSPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarSPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarSPS.Location = new System.Drawing.Point(1010, 516);
            this.btnGuardarSPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarSPS.Name = "btnGuardarSPS";
            this.btnGuardarSPS.Size = new System.Drawing.Size(114, 37);
            this.btnGuardarSPS.TabIndex = 43;
            this.btnGuardarSPS.Text = "GUARDAR";
            this.btnGuardarSPS.UseVisualStyleBackColor = false;
            this.btnGuardarSPS.Click += new System.EventHandler(this.btnGuardarSPS_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(31, 33);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(1278, 475);
            this.dataGridView2.TabIndex = 38;
            this.dataGridView2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellLeave);
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            // 
            // btnMostrarSPS
            // 
            this.btnMostrarSPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnMostrarSPS.FlatAppearance.BorderSize = 0;
            this.btnMostrarSPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarSPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMostrarSPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMostrarSPS.Location = new System.Drawing.Point(831, 220);
            this.btnMostrarSPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMostrarSPS.Name = "btnMostrarSPS";
            this.btnMostrarSPS.Size = new System.Drawing.Size(109, 40);
            this.btnMostrarSPS.TabIndex = 42;
            this.btnMostrarSPS.Text = "Validar";
            this.btnMostrarSPS.UseVisualStyleBackColor = false;
            this.btnMostrarSPS.Click += new System.EventHandler(this.btnMostrarSPS_Click);
            // 
            // CargaMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1342, 1051);
            this.Controls.Add(this.cboHojas);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.comboSistema);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.panelPS);
            this.Controls.Add(this.btnMostrarPS);
            this.Controls.Add(this.panelSPS);
            this.Controls.Add(this.btnMostrarSPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CargaMasiva";
            this.Text = "CargaMasiva";
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelSPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button btnGuardarPS;
        private Button buttonSeleccionar;
        private Panel panelTitulo;
        private Label label6;
        private Label label9;
        private ComboBox comboSistema;
        private Button btnMostrarPS;
        private TextBox txtRuta;
        private ComboBox cboHojas;
        private ErrorProvider errorProvider1;
        private Panel panelPS;
        private DataGridView dataGridView1;
        private Panel panelSPS;
        private DataGridView dataGridView2;
        private Button btnMostrarSPS;
        private Button btnGuardarSPS;
        private Button btnLimpiar1;
        private Button btnLimpar2;
    }
}