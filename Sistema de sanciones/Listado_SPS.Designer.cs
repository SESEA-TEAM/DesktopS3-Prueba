namespace WinFormsApp1
{
    partial class FormListadoSPS
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.textExpediente = new Sistema_de_sanciones.Templates.TextBox();
            this.textBox2 = new Sistema_de_sanciones.Templates.TextBox();
            this.textBox1 = new Sistema_de_sanciones.Templates.TextBox();
            this.textPA = new Sistema_de_sanciones.Templates.TextBox();
            this.textSA = new Sistema_de_sanciones.Templates.TextBox();
            this.textNombre = new Sistema_de_sanciones.Templates.TextBox();
            this.textISD = new Sistema_de_sanciones.Templates.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.botonPrimero = new System.Windows.Forms.Button();
            this.botonAnterior = new System.Windows.Forms.Button();
            this.botonSiguiente = new System.Windows.Forms.Button();
            this.botonFinal = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(371, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema de los servidores públicos sancionados";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.botonBuscar);
            this.panel1.Controls.Add(this.botonLimpiar);
            this.panel1.Controls.Add(this.textExpediente);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textPA);
            this.panel1.Controls.Add(this.textSA);
            this.panel1.Controls.Add(this.textNombre);
            this.panel1.Controls.Add(this.textISD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 209);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(888, 118);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(267, 23);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(24, 68);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(267, 23);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(600, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // botonBuscar
            // 
            this.botonBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botonBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.botonBuscar.Location = new System.Drawing.Point(1040, 160);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(100, 28);
            this.botonBuscar.TabIndex = 3;
            this.botonBuscar.Text = "BUSCAR";
            this.botonBuscar.UseVisualStyleBackColor = false;
            this.botonBuscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botonLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.botonLimpiar.Location = new System.Drawing.Point(900, 160);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(100, 28);
            this.botonLimpiar.TabIndex = 3;
            this.botonLimpiar.Text = "LIMPIAR";
            this.botonLimpiar.UseVisualStyleBackColor = false;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // textExpediente
            // 
            this.textExpediente.BackColor = System.Drawing.SystemColors.Control;
            this.textExpediente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textExpediente.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textExpediente.BorderSize = 2;
            this.textExpediente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textExpediente.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textExpediente.Location = new System.Drawing.Point(312, 60);
            this.textExpediente.Multiline = false;
            this.textExpediente.Name = "textExpediente";
            this.textExpediente.Padding = new System.Windows.Forms.Padding(7);
            this.textExpediente.PasswordChar = false;
            this.textExpediente.Size = new System.Drawing.Size(267, 31);
            this.textExpediente.TabIndex = 1;
            this.textExpediente.Texts = "Expediente";
            this.textExpediente.UnderlinedStyle = true;
            this.textExpediente.Enter += new System.EventHandler(this.textExpediente_Enter);
            this.textExpediente.Leave += new System.EventHandler(this.textExpediente_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textBox2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBox2.BorderSize = 2;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox2.Location = new System.Drawing.Point(888, 92);
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Padding = new System.Windows.Forms.Padding(7);
            this.textBox2.PasswordChar = false;
            this.textBox2.Size = new System.Drawing.Size(267, 31);
            this.textBox2.TabIndex = 1;
            this.textBox2.Texts = "Inhabilitación fecha final";
            this.textBox2.UnderlinedStyle = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBox1.BorderSize = 2;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox1.Location = new System.Drawing.Point(24, 42);
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(7);
            this.textBox1.PasswordChar = false;
            this.textBox1.Size = new System.Drawing.Size(267, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.Texts = "Última actualización";
            this.textBox1.UnderlinedStyle = true;
            // 
            // textPA
            // 
            this.textPA.BackColor = System.Drawing.SystemColors.Control;
            this.textPA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textPA.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textPA.BorderSize = 2;
            this.textPA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textPA.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textPA.Location = new System.Drawing.Point(24, 110);
            this.textPA.Multiline = false;
            this.textPA.Name = "textPA";
            this.textPA.Padding = new System.Windows.Forms.Padding(7);
            this.textPA.PasswordChar = false;
            this.textPA.Size = new System.Drawing.Size(267, 31);
            this.textPA.TabIndex = 1;
            this.textPA.Texts = "Primer apellido";
            this.textPA.UnderlinedStyle = true;
            this.textPA.Enter += new System.EventHandler(this.textPA_Enter);
            this.textPA.Leave += new System.EventHandler(this.textPA_Leave);
            // 
            // textSA
            // 
            this.textSA.BackColor = System.Drawing.SystemColors.Control;
            this.textSA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textSA.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textSA.BorderSize = 2;
            this.textSA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textSA.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textSA.Location = new System.Drawing.Point(312, 110);
            this.textSA.Multiline = false;
            this.textSA.Name = "textSA";
            this.textSA.Padding = new System.Windows.Forms.Padding(7);
            this.textSA.PasswordChar = false;
            this.textSA.Size = new System.Drawing.Size(264, 31);
            this.textSA.TabIndex = 1;
            this.textSA.Texts = "Segundo apellido";
            this.textSA.UnderlinedStyle = true;
            this.textSA.Enter += new System.EventHandler(this.textSA_Enter);
            this.textSA.Leave += new System.EventHandler(this.textSA_Leave);
            // 
            // textNombre
            // 
            this.textNombre.BackColor = System.Drawing.SystemColors.Control;
            this.textNombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textNombre.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textNombre.BorderSize = 2;
            this.textNombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textNombre.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textNombre.Location = new System.Drawing.Point(888, 60);
            this.textNombre.Multiline = false;
            this.textNombre.Name = "textNombre";
            this.textNombre.Padding = new System.Windows.Forms.Padding(7);
            this.textNombre.PasswordChar = false;
            this.textNombre.Size = new System.Drawing.Size(264, 31);
            this.textNombre.TabIndex = 1;
            this.textNombre.Texts = "Nombre(s)";
            this.textNombre.UnderlinedStyle = true;
            this.textNombre.Enter += new System.EventHandler(this.textNombre_Enter);
            this.textNombre.Leave += new System.EventHandler(this.textNombre_Leave);
            // 
            // textISD
            // 
            this.textISD.BackColor = System.Drawing.SystemColors.Control;
            this.textISD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.textISD.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textISD.BorderSize = 2;
            this.textISD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textISD.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textISD.Location = new System.Drawing.Point(600, 60);
            this.textISD.Multiline = false;
            this.textISD.Name = "textISD";
            this.textISD.Padding = new System.Windows.Forms.Padding(7);
            this.textISD.PasswordChar = false;
            this.textISD.Size = new System.Drawing.Size(264, 31);
            this.textISD.TabIndex = 1;
            this.textISD.Texts = "Institución / Dependencia";
            this.textISD.UnderlinedStyle = true;
            this.textISD.Enter += new System.EventHandler(this.textISD_Enter);
            this.textISD.Leave += new System.EventHandler(this.textISD_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Búsqueda";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 311);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 352);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 98);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1174, 252);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Resultados";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1174, 55);
            this.panel3.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(1087, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Acciones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(895, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tipo sanción";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(630, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Servidor público";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(345, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Institución";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(90, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Expediente";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1174, 57);
            this.panel4.TabIndex = 3;
            // 
            // botonPrimero
            // 
            this.botonPrimero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.botonPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPrimero.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botonPrimero.ForeColor = System.Drawing.SystemColors.Control;
            this.botonPrimero.Location = new System.Drawing.Point(713, 673);
            this.botonPrimero.Name = "botonPrimero";
            this.botonPrimero.Size = new System.Drawing.Size(100, 28);
            this.botonPrimero.TabIndex = 4;
            this.botonPrimero.Text = "|<";
            this.botonPrimero.UseVisualStyleBackColor = false;
            this.botonPrimero.Click += new System.EventHandler(this.button3_Click);
            // 
            // botonAnterior
            // 
            this.botonAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.botonAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAnterior.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botonAnterior.ForeColor = System.Drawing.SystemColors.Control;
            this.botonAnterior.Location = new System.Drawing.Point(822, 673);
            this.botonAnterior.Name = "botonAnterior";
            this.botonAnterior.Size = new System.Drawing.Size(100, 28);
            this.botonAnterior.TabIndex = 4;
            this.botonAnterior.Text = "<";
            this.botonAnterior.UseVisualStyleBackColor = false;
            this.botonAnterior.Click += new System.EventHandler(this.button4_Click);
            // 
            // botonSiguiente
            // 
            this.botonSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.botonSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonSiguiente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botonSiguiente.ForeColor = System.Drawing.SystemColors.Control;
            this.botonSiguiente.Location = new System.Drawing.Point(931, 673);
            this.botonSiguiente.Name = "botonSiguiente";
            this.botonSiguiente.Size = new System.Drawing.Size(100, 28);
            this.botonSiguiente.TabIndex = 4;
            this.botonSiguiente.Text = ">";
            this.botonSiguiente.UseVisualStyleBackColor = false;
            this.botonSiguiente.Click += new System.EventHandler(this.button5_Click);
            // 
            // botonFinal
            // 
            this.botonFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.botonFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonFinal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botonFinal.ForeColor = System.Drawing.SystemColors.Control;
            this.botonFinal.Location = new System.Drawing.Point(1040, 673);
            this.botonFinal.Name = "botonFinal";
            this.botonFinal.Size = new System.Drawing.Size(100, 28);
            this.botonFinal.TabIndex = 4;
            this.botonFinal.Text = ">|";
            this.botonFinal.UseVisualStyleBackColor = false;
            this.botonFinal.Click += new System.EventHandler(this.button6_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(96)))));
            this.label9.Location = new System.Drawing.Point(514, 679);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Registros:";
            // 
            // FormListadoSPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1174, 708);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.botonFinal);
            this.Controls.Add(this.botonSiguiente);
            this.Controls.Add(this.botonAnterior);
            this.Controls.Add(this.botonPrimero);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormListadoSPS";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Sistema_de_sanciones.Templates.TextBox textPA;
        private Sistema_de_sanciones.Templates.TextBox textSA;
        private Sistema_de_sanciones.Templates.TextBox textNombre;
        private Sistema_de_sanciones.Templates.TextBox textISD;
        private Button botonBuscar;
        private Button botonLimpiar;
        private Panel panel2;
        private Panel panel3;
        private Label label3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel4;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Button botonPrimero;
        private Button botonAnterior;
        private Button botonSiguiente;
        private Button botonFinal;
        private Label label9;
        private Sistema_de_sanciones.Templates.TextBox textExpediente;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Sistema_de_sanciones.Templates.TextBox textBox1;
        private Sistema_de_sanciones.Templates.TextBox textBox2;
    }
}