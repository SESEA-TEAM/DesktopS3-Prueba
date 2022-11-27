using Sistema_de_sanciones.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class Listar_Proveedores : Form
    {
        // crea un nuevo objto de la clase controlado proveedor
        Controlador_Proveedor objp = new Controlador_Proveedor();
        DataTable dsTabla;
        private Proveedores proveedores = new Proveedores();
        private int id;

        public Listar_Proveedores()
        {
            InitializeComponent();
            CargarDG();
            List<string> sistema = new List<string>();
            sistema.Add("Sistema de los Servidores Públicos Sancionados");
            sistema.Add("Sistema de los Particulares Sancionados");
            sistema.Add("Sistema de los Servidores Públicos Sancionados, Sistema de los Particulares Sancionados");
            comboSistema.DataSource = sistema;

            List<string> estatus = new List<string>();
            estatus.Add("Vigente");
            estatus.Add("No vigente");
            comboEstatus.DataSource = estatus;

        }
        
        private void CargarDG()
        {
            
            dsTabla = objp.ControladorProveedor();

            dataGridView1.DataSource = dsTabla;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 305;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Width = 305;
            dataGridView1.Columns[4].Width = 305;
            dataGridView1.Columns[5].Visible = false;


        }

        private void Listar_Proveedores_Load(object sender, EventArgs e)
        {

            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 80;
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 80;
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 80;
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ver")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    textProveedorVer.Texts = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    comboSistemaVer.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboEstatusVer.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    dateFechaAltaVer.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    dateFechaActualizacionVer.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                    tabControl1.SelectedTab = VerProveedor;


                }
            }
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult resut = MessageBox.Show("Esta seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo);
                    if (resut == DialogResult.Yes)
                    {
                        objp.EliminarProveedor(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
                        MessageBox.Show("Registro Eliminado");
                       
                       
                    }
                    else if (resut == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    textProveedor.Texts = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    comboSistema.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboEstatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    tabControl1.SelectedTab = EditarProveedor;

                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                Image someImage = Properties.Resources.abajo;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.abajo.Width;
                var h = Properties.Resources.abajo.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 7)
            {
                Image someImage = Properties.Resources.basura;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.basura.Width;
                var h = Properties.Resources.basura.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 8)
            {
                Image someImage = Properties.Resources.lapiz;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.lapiz.Width;
                var h = Properties.Resources.lapiz.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(EditarProveedor);
            tabControl1.TabPages.Add(ListaProveedor);

            this.Controls.Clear();
            this.InitializeComponent();
            CargarDG();
            //Listar_Proveedores_Load();
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 80;
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 80;
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 80;
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);
        }

        private void btnVerProveedor_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(VerProveedor);
            tabControl1.TabPages.Add(ListaProveedor);

            this.Controls.Clear();
            this.InitializeComponent();
            CargarDG();
            //Listar_Proveedores_Load();
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 80;
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 80;
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 80;
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);
        }

        private void Guardar_Click(object sender, EventArgs e)
        {

            if (textProveedor.Texts == "Proveedor*" )
            {
                
                MessageBox.Show("Hay datos que aun no se han proporcionado");
            }
            else
            {

                objp.EditarProveedor(id, textProveedor.Texts, comboSistema.SelectedItem.ToString(), comboEstatus.SelectedItem.ToString());
                MessageBox.Show("Registro modificado");
                tabControl1.SelectedTab = ListaProveedor;

                this.Controls.Clear();
                this.InitializeComponent();
                CargarDG();
                //Listar_Proveedores_Load();
                DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
                Ver.HeaderText = "Ver";
                Ver.Name = "Ver";
                Ver.Width = 80;
                Ver.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(Ver);

                DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
                btnclm.HeaderText = "Eliminar";
                btnclm.Name = "Eliminar";
                btnclm.Width = 80;
                btnclm.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(btnclm);

                DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
                editar.HeaderText = "Editar";
                editar.Name = "Editar";
                editar.Width = 80;
                editar.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(editar);
            }
            

            

        }

        private void textProveedor_Enter(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "Proveedor*")
            {
                textProveedor.Texts = "";
                textProveedor.ForeColor = Color.Gray;

            }
        }

        private void textProveedor_Leave(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "")
            {
                textProveedor.Texts = "Proveedor*";
                errorProvider1.SetError(textProveedor, "Se necesita ingresar un proveedor");
                textProveedor.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textProveedor, String.Empty);

            }
            
        }

        private void textProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            proveedores.textBoxEvent.textKeyPress(e);
        }
        
   
        
    }
}

