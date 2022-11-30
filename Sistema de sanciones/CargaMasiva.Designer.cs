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
            this.label2 = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPS = new System.Windows.Forms.Panel();
            this.btnGuardarSPS = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.MostrarPS = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelSPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(975, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Estatus";
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
            // buttonGuardar
            // 
            this.buttonGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.buttonGuardar.FlatAppearance.BorderSize = 0;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGuardar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGuardar.Location = new System.Drawing.Point(1010, 516);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(114, 37);
            this.buttonGuardar.TabIndex = 28;
            this.buttonGuardar.Text = "GUARDAR";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            // btnMostar
            // 
            this.btnMostar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMostar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnMostar.FlatAppearance.BorderSize = 0;
            this.btnMostar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMostar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMostar.Location = new System.Drawing.Point(825, 220);
            this.btnMostar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMostar.Name = "btnMostar";
            this.btnMostar.Size = new System.Drawing.Size(109, 40);
            this.btnMostar.TabIndex = 37;
            this.btnMostar.Text = "Mostrar";
            this.btnMostar.UseVisualStyleBackColor = false;
            this.btnMostar.Click += new System.EventHandler(this.btnMostar_Click);
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
            // panelSPS
            // 
            this.panelSPS.Controls.Add(this.label4);
            this.panelSPS.Controls.Add(this.dataGridView1);
            this.panelSPS.Controls.Add(this.buttonGuardar);
            this.panelSPS.Location = new System.Drawing.Point(0, 293);
            this.panelSPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSPS.Name = "panelSPS";
            this.panelSPS.Size = new System.Drawing.Size(1342, 562);
            this.panelSPS.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "PANEL PS";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1278, 471);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "PANEL CARGA SPS";
            // 
            // panelPS
            // 
            this.panelPS.Controls.Add(this.btnGuardarSPS);
            this.panelPS.Controls.Add(this.label3);
            this.panelPS.Controls.Add(this.dataGridView2);
            this.panelPS.Location = new System.Drawing.Point(0, 293);
            this.panelPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPS.Name = "panelPS";
            this.panelPS.Size = new System.Drawing.Size(1335, 562);
            this.panelPS.TabIndex = 41;
            // 
            // btnGuardarSPS
            // 
            this.btnGuardarSPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(1278, 475);
            this.dataGridView2.TabIndex = 38;
            this.dataGridView2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellLeave);
            // 
            // MostrarPS
            // 
            this.MostrarPS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MostrarPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.MostrarPS.FlatAppearance.BorderSize = 0;
            this.MostrarPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MostrarPS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MostrarPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MostrarPS.Location = new System.Drawing.Point(825, 220);
            this.MostrarPS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MostrarPS.Name = "MostrarPS";
            this.MostrarPS.Size = new System.Drawing.Size(109, 40);
            this.MostrarPS.TabIndex = 42;
            this.MostrarPS.Text = "Mostrar";
            this.MostrarPS.UseVisualStyleBackColor = false;
            this.MostrarPS.Click += new System.EventHandler(this.MostrarPS_Click);
            // 
            // CargaMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1342, 1051);
            this.Controls.Add(this.cboHojas);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.comboSistema);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.panelPS);
            this.Controls.Add(this.MostrarPS);
            this.Controls.Add(this.btnMostar);
            this.Controls.Add(this.panelSPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CargaMasiva";
            this.Text = "CargaMasiva";
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelSPS.ResumeLayout(false);
            this.panelSPS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelPS.ResumeLayout(false);
            this.panelPS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
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
        private Label label3;
        private Panel panelPS;
        private DataGridView dataGridView2;
        private Label label4;
        private Button MostrarPS;
        private Button btnGuardarSPS;
    }
}