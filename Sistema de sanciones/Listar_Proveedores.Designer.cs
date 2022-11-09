namespace Sistema_de_sanciones
{
    partial class Listar_Proveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ListaProveedor = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EditarProveedor = new System.Windows.Forms.TabPage();
            this.textProveedor = new Sistema_de_sanciones.Templates.TextBox();
            this.comboEstatus = new System.Windows.Forms.ComboBox();
            this.comboSistema = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Guardar = new System.Windows.Forms.Button();
            this.btnCancelarEditar = new System.Windows.Forms.Button();
            this.VerProveedor = new System.Windows.Forms.TabPage();
            this.btnVerProveedor = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTitulo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ListaProveedor.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.EditarProveedor.SuspendLayout();
            this.VerProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.panelTitulo.Controls.Add(this.panel4);
            this.panelTitulo.Controls.Add(this.panel1);
            this.panelTitulo.Controls.Add(this.label8);
            this.panelTitulo.Controls.Add(this.label7);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1174, 54);
            this.panelTitulo.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(141, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(298, 25);
            this.panel4.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 25);
            this.panel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(891, -21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "S3";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(481, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sistema de Carga de Datos";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ListaProveedor);
            this.tabControl1.Controls.Add(this.EditarProveedor);
            this.tabControl1.Controls.Add(this.VerProveedor);
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1162, 512);
            this.tabControl1.TabIndex = 21;
            // 
            // ListaProveedor
            // 
            this.ListaProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.ListaProveedor.Controls.Add(this.label1);
            this.ListaProveedor.Controls.Add(this.panel2);
            this.ListaProveedor.Controls.Add(this.dataGridView1);
            this.ListaProveedor.Location = new System.Drawing.Point(4, 24);
            this.ListaProveedor.Name = "ListaProveedor";
            this.ListaProveedor.Padding = new System.Windows.Forms.Padding(3);
            this.ListaProveedor.Size = new System.Drawing.Size(1154, 484);
            this.ListaProveedor.TabIndex = 0;
            this.ListaProveedor.Text = "Lista Proveedor";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(41)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(513, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lista de proveedores";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(2, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1159, 36);
            this.panel2.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(992, -4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Acciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(761, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fecha de actualización";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(633, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(489, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estatus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(261, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sistemas Aplicables";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(88, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Proveedor";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1174, 334);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // EditarProveedor
            // 
            this.EditarProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.EditarProveedor.Controls.Add(this.textProveedor);
            this.EditarProveedor.Controls.Add(this.comboEstatus);
            this.EditarProveedor.Controls.Add(this.comboSistema);
            this.EditarProveedor.Controls.Add(this.label10);
            this.EditarProveedor.Controls.Add(this.label11);
            this.EditarProveedor.Controls.Add(this.label12);
            this.EditarProveedor.Controls.Add(this.Guardar);
            this.EditarProveedor.Controls.Add(this.btnCancelarEditar);
            this.EditarProveedor.Location = new System.Drawing.Point(4, 24);
            this.EditarProveedor.Name = "EditarProveedor";
            this.EditarProveedor.Padding = new System.Windows.Forms.Padding(3);
            this.EditarProveedor.Size = new System.Drawing.Size(1154, 484);
            this.EditarProveedor.TabIndex = 1;
            this.EditarProveedor.Text = "Editar Proveedor";
            // 
            // textProveedor
            // 
            this.textProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.textProveedor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textProveedor.BorderFocusColor = System.Drawing.Color.IndianRed;
            this.textProveedor.BorderSize = 2;
            this.textProveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textProveedor.Location = new System.Drawing.Point(102, 99);
            this.textProveedor.Multiline = false;
            this.textProveedor.Name = "textProveedor";
            this.textProveedor.Padding = new System.Windows.Forms.Padding(7);
            this.textProveedor.PasswordChar = false;
            this.textProveedor.Size = new System.Drawing.Size(266, 31);
            this.textProveedor.TabIndex = 38;
            this.textProveedor.Texts = "Proveedor*";
            this.textProveedor.UnderlinedStyle = true;
            this.textProveedor.Enter += new System.EventHandler(this.textProveedor_Enter);
            this.textProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textProveedor_KeyPress);
            this.textProveedor.Leave += new System.EventHandler(this.textProveedor_Leave);
            // 
            // comboEstatus
            // 
            this.comboEstatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboEstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.comboEstatus.FormattingEnabled = true;
            this.comboEstatus.Items.AddRange(new object[] {
            "Vigente",
            "No vigente"});
            this.comboEstatus.Location = new System.Drawing.Point(102, 206);
            this.comboEstatus.Name = "comboEstatus";
            this.comboEstatus.Size = new System.Drawing.Size(172, 24);
            this.comboEstatus.TabIndex = 37;
            this.comboEstatus.Text = "Seleccionar Estatus*";
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
            this.comboSistema.Location = new System.Drawing.Point(516, 106);
            this.comboSistema.Name = "comboSistema";
            this.comboSistema.Size = new System.Drawing.Size(524, 24);
            this.comboSistema.TabIndex = 36;
            this.comboSistema.Text = "Sistemas aplicable*";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(516, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(255, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Selecciona los sistemas aplicables*";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(102, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 34;
            this.label11.Text = "Estatus*";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.Firebrick;
            this.label12.Location = new System.Drawing.Point(516, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 21);
            this.label12.TabIndex = 33;
            this.label12.Text = "Editar Proveedor";
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
            this.Guardar.Location = new System.Drawing.Point(925, 242);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(115, 35);
            this.Guardar.TabIndex = 32;
            this.Guardar.Text = "GUARDAR";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // btnCancelarEditar
            // 
            this.btnCancelarEditar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelarEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnCancelarEditar.FlatAppearance.BorderSize = 0;
            this.btnCancelarEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarEditar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarEditar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelarEditar.Location = new System.Drawing.Point(779, 242);
            this.btnCancelarEditar.Name = "btnCancelarEditar";
            this.btnCancelarEditar.Size = new System.Drawing.Size(126, 35);
            this.btnCancelarEditar.TabIndex = 31;
            this.btnCancelarEditar.Text = "CANCELAR";
            this.btnCancelarEditar.UseVisualStyleBackColor = false;
            this.btnCancelarEditar.Click += new System.EventHandler(this.btnCancelarEditar_Click);
            // 
            // VerProveedor
            // 
            this.VerProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.VerProveedor.Controls.Add(this.btnVerProveedor);
            this.VerProveedor.Controls.Add(this.label13);
            this.VerProveedor.Location = new System.Drawing.Point(4, 24);
            this.VerProveedor.Name = "VerProveedor";
            this.VerProveedor.Padding = new System.Windows.Forms.Padding(3);
            this.VerProveedor.Size = new System.Drawing.Size(1154, 484);
            this.VerProveedor.TabIndex = 2;
            this.VerProveedor.Text = "Ver Proveedor";
            // 
            // btnVerProveedor
            // 
            this.btnVerProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVerProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.btnVerProveedor.FlatAppearance.BorderSize = 0;
            this.btnVerProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerProveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVerProveedor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerProveedor.Location = new System.Drawing.Point(916, 419);
            this.btnVerProveedor.Name = "btnVerProveedor";
            this.btnVerProveedor.Size = new System.Drawing.Size(126, 35);
            this.btnVerProveedor.TabIndex = 32;
            this.btnVerProveedor.Text = "CANCELAR";
            this.btnVerProveedor.UseVisualStyleBackColor = false;
            this.btnVerProveedor.Click += new System.EventHandler(this.btnVerProveedor_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.Firebrick;
            this.label13.Location = new System.Drawing.Point(507, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 19);
            this.label13.TabIndex = 6;
            this.label13.Text = "Ver proveedores";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(17, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 31);
            this.panel3.TabIndex = 23;
            // 
            // Listar_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1174, 788);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Listar_Proveedores";
            this.Text = "Listar_Proveedores";
            this.Load += new System.EventHandler(this.Listar_Proveedores_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ListaProveedor.ResumeLayout(false);
            this.ListaProveedor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.EditarProveedor.ResumeLayout(false);
            this.EditarProveedor.PerformLayout();
            this.VerProveedor.ResumeLayout(false);
            this.VerProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelTitulo;
        private Label label8;
        private Label label7;
        private TabControl tabControl1;
        private TabPage ListaProveedor;
        private DataGridView dataGridView1;
        private TabPage EditarProveedor;
        public ComboBox comboEstatus;
        public ComboBox comboSistema;
        public Label label10;
        public Label label11;
        private Label label12;
        private Button Guardar;
        private Button btnCancelarEditar;
        private TabPage VerProveedor;
        private Button btnVerProveedor;
        private Label label13;
        private Panel panel2;
        private Label label14;
        private Label label2;
        private Label label9;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label1;
        private Panel panel1;
        private Panel panel4;
        private ErrorProvider errorProvider1;
        private Templates.TextBox textProveedor;
        private Panel panel3;
    }
}