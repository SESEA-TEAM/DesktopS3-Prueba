using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class Listar_Usuarios : Form
    {
        Controlador_Usuario objp = new Controlador_Usuario();
        DataTable dsTabla;

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Listar_Usuarios()
        {
            InitializeComponent();
            CargarDG();

        }

        private void CargarDG()
        {
            dsTabla = objp.ControladorUsuario();
           
            dataGridView1.DataSource = dsTabla;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 251;
            dataGridView1.Columns[2].Width = 175;
            dataGridView1.Columns[3].Width = 196;
            dataGridView1.Columns[4].Width = 204;
        }

        private void Listar_Usuarios_Load(object sender, EventArgs e)
        {

            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 120;
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 120;
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 105;
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult resut = MessageBox.Show("Esta seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo);
                    if (resut == DialogResult.Yes)
                    {
                        objp.EliminarUsuario(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
                Editar_Usuarios editar_Usuarios = new Editar_Usuarios();
                editar_Usuarios.Show();
            }


        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            if (e.ColumnIndex == 5)
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
            if (e.ColumnIndex == 6)
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

            
            if (e.ColumnIndex == 7)
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
    }
}
