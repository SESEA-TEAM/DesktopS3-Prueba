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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboSistema = new System.Windows.Forms.ComboBox();
            this.btnMostar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.cboHojas = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelSPS = new System.Windows.Forms.Panel();
            this.btnLimpar2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelPS = new System.Windows.Forms.Panel();
            this.btnLimpiar1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnGuardarSPS = new System.Windows.Forms.Button();
            this.MostrarPS = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelSPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(41)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(527, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "Carga de datos";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonGuardar.FlatAppearance.BorderSize = 0;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGuardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGuardar.Location = new System.Drawing.Point(884, 387);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(100, 28);
            this.buttonGuardar.TabIndex = 28;
            this.buttonGuardar.Text = "GUARDAR";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonSeleccionar.FlatAppearance.BorderSize = 0;
            this.buttonSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeleccionar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSeleccionar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSeleccionar.Location = new System.Drawing.Point(681, 115);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(166, 30);
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
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1174, 57);
            this.panelTitulo.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1378, -61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "S3";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(464, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 21);
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
            this.comboSistema.Location = new System.Drawing.Point(30, 119);
            this.comboSistema.Name = "comboSistema";
            this.comboSistema.Size = new System.Drawing.Size(545, 24);
            this.comboSistema.TabIndex = 35;
            this.comboSistema.SelectedIndexChanged += new System.EventHandler(this.comboSistema_SelectedIndexChanged);
            // 
            // btnMostar
            // 
            this.btnMostar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnMostar.FlatAppearance.BorderSize = 0;
            this.btnMostar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMostar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMostar.Location = new System.Drawing.Point(727, 165);
            this.btnMostar.Name = "btnMostar";
            this.btnMostar.Size = new System.Drawing.Size(95, 30);
            this.btnMostar.TabIndex = 37;
            this.btnMostar.Text = "Validar";
            this.btnMostar.UseVisualStyleBackColor = false;
            this.btnMostar.Click += new System.EventHandler(this.btnMostar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(39, 159);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(226, 23);
            this.txtRuta.TabIndex = 38;
            this.txtRuta.Visible = false;
            // 
            // cboHojas
            // 
            this.cboHojas.FormattingEnabled = true;
            this.cboHojas.Location = new System.Drawing.Point(325, 160);
            this.cboHojas.Name = "cboHojas";
            this.cboHojas.Size = new System.Drawing.Size(121, 23);
            this.cboHojas.TabIndex = 39;
            this.cboHojas.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelSPS
            // 
            this.panelSPS.Controls.Add(this.btnLimpar2);
            this.panelSPS.Controls.Add(this.dataGridView1);
            this.panelSPS.Controls.Add(this.buttonGuardar);
            this.panelSPS.Location = new System.Drawing.Point(0, 220);
            this.panelSPS.Name = "panelSPS";
            this.panelSPS.Size = new System.Drawing.Size(1174, 422);
            this.panelSPS.TabIndex = 40;
            // 
            // btnLimpar2
            // 
            this.btnLimpar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnLimpar2.FlatAppearance.BorderSize = 0;
            this.btnLimpar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLimpar2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar2.Location = new System.Drawing.Point(30, 387);
            this.btnLimpar2.Name = "btnLimpar2";
            this.btnLimpar2.Size = new System.Drawing.Size(100, 28);
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
            this.dataGridView1.Location = new System.Drawing.Point(30, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 353);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // panelPS
            // 
            this.panelPS.Controls.Add(this.btnLimpiar1);
            this.panelPS.Controls.Add(this.btnGuardarSPS);
            this.panelPS.Controls.Add(this.dataGridView2);
            this.panelPS.Location = new System.Drawing.Point(0, 220);
            this.panelPS.Name = "panelPS";
            this.panelPS.Size = new System.Drawing.Size(1168, 422);
            this.panelPS.TabIndex = 41;
            // 
            // btnLimpiar1
            // 
            this.btnLimpiar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnLimpiar1.FlatAppearance.BorderSize = 0;
            this.btnLimpiar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpiar1.Location = new System.Drawing.Point(27, 387);
            this.btnLimpiar1.Name = "btnLimpiar1";
            this.btnLimpiar1.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar1.TabIndex = 44;
            this.btnLimpiar1.Text = "Limpiar";
            this.btnLimpiar1.UseVisualStyleBackColor = false;
            this.btnLimpiar1.Click += new System.EventHandler(this.btnLimpiar1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(27, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(1118, 356);
            this.dataGridView2.TabIndex = 38;
            this.dataGridView2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellLeave);
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView2_RowPostPaint);
            // 
            // btnGuardarSPS
            // 
            this.btnGuardarSPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnGuardarSPS.FlatAppearance.BorderSize = 0;
            this.btnGuardarSPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarSPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarSPS.Location = new System.Drawing.Point(884, 387);
            this.btnGuardarSPS.Name = "btnGuardarSPS";
            this.btnGuardarSPS.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarSPS.TabIndex = 43;
            this.btnGuardarSPS.Text = "GUARDAR";
            this.btnGuardarSPS.UseVisualStyleBackColor = false;
            this.btnGuardarSPS.Click += new System.EventHandler(this.btnGuardarSPS_Click);
            // 
            // MostrarPS
            // 
            this.MostrarPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.MostrarPS.FlatAppearance.BorderSize = 0;
            this.MostrarPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MostrarPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MostrarPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MostrarPS.Location = new System.Drawing.Point(727, 165);
            this.MostrarPS.Name = "MostrarPS";
            this.MostrarPS.Size = new System.Drawing.Size(95, 30);
            this.MostrarPS.TabIndex = 42;
            this.MostrarPS.Text = "Validar";
            this.MostrarPS.UseVisualStyleBackColor = false;
            this.MostrarPS.Click += new System.EventHandler(this.MostrarPS_Click);
            // 
            // CargaMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1174, 788);
            this.Controls.Add(this.cboHojas);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.comboSistema);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.btnMostar);
            this.Controls.Add(this.MostrarPS);
            this.Controls.Add(this.panelSPS);
            this.Controls.Add(this.panelPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargaMasiva";
            this.Text = "CargaMasiva";
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelSPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button buttonGuardar;
        private Button buttonSeleccionar;
        private Panel panelTitulo;
        private Label label6;
        private Label label9;
        private ComboBox comboSistema;
        private Button btnMostar;
        private TextBox txtRuta;
        private ComboBox cboHojas;
        private ErrorProvider errorProvider1;
        private Panel panelSPS;
        private DataGridView dataGridView1;
        private Panel panelPS;
        private DataGridView dataGridView2;
        private Button MostrarPS;
        private Button btnGuardarSPS;
        private Button btnLimpiar1;
        private Button btnLimpar2;
    }
}