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
        Controlador_Usuario objp = new Controlador_Usuario(); //Se genera un nuevo objeto a la clae Control Usuario
        DataTable dsTabla; //Representa una tabla de datos en memoria.

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Listar_Usuarios()
        {
            InitializeComponent();
            CargarDG(); //Se cargan los datos de los Usuarios registrados.

        }

        private void CargarDG()
        {
            dsTabla = objp.Seleccionar_Datos_User(); //La tabla se recarga con el procedimiento almacenado Seleccionar_Datos_User.

            dataGridView1.DataSource = dsTabla;
            dataGridView1.Columns[0].Visible = false; //Desactiva la columna ID
            dataGridView1.Columns[1].Width = 251;     //Se asigna tamaño a la columna Nombre Completo
            dataGridView1.Columns[2].Visible = false; //Desactiva la columna Nombre
            dataGridView1.Columns[3].Visible = false; //Desactiva la columna Primer Apellido
            dataGridView1.Columns[4].Visible = false; //Desactiva la columna Segundo Apellido
            dataGridView1.Columns[5].Visible = false; //Desactiva la columna Cargo
            dataGridView1.Columns[6].Width = 175;     //Se le asigna tamaño a la columna Usuario
            dataGridView1.Columns[7].Width = 196;     //Se le asigna tamaño a la columna correo
            dataGridView1.Columns[8].Width = 204;     //Se le asigna tamaño a la columna Proveedor
            dataGridView1.Columns[9].Visible = false; //Desactiva la columna Teléfono
            dataGridView1.Columns[10].Visible = false; //Desactiva la columna Extensión
            dataGridView1.Columns[11].Visible = false; //Desactiva la columna Sistemas
        }
        //
        private void Listar_Usuarios_Load(object sender, EventArgs e)
        {
            //Se genera 3 nuevas columas con botones.
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 120;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 120;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 105;
            dataGridView1.Columns.Add(editar);

        }
        
        //
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar") //Si la celda contiene el nombre Eliminar procedera a entrar en la condición.
            {
                if (dataGridView1.SelectedRows.Count > 0) //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                {
                    objp.EliminarUsuario(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)); //Manda a llamar le procedimiento almacenado Eliminar Usuario.
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
                    MessageBox.Show("Registro Eliminado"); //Muestra el siguiente mensaje.
                }
            }

            if(dataGridView1.Columns[e.ColumnIndex].Name == "Editar") //Si la celda contiene el nombre Editar procedera a entrar en la condición.
            {
                if (dataGridView1.SelectedRows.Count > 0) //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                {
                    objp.Seleccionar_Datos_User(); //Manda a llamar le procedimiento almacenado Seleccionar Datos Usuarios.
                    Editar_Usuarios frm = new Editar_Usuarios(); //Se genera el objeto para abrir la nueva pantalla.

                    //Manda a llamar todos los datos del Usuario a la otra pantalla para proceder a su correspondiente edición
                    frm.id = dataGridView1.CurrentRow.Cells[0].Value.ToString(); ;
                    frm.txtNombres.Texts = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    frm.textPApellido.Texts = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    frm.textSApellido.Texts = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    frm.textCargo.Texts = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    frm.textUser.Texts = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    frm.textCorreo.Texts = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    frm.comboProveedor.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    frm.textTelefono.Texts = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    frm.textExtension.Texts = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    frm.comboSistemas.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    frm.ShowDialog(); //Muestra la nueva ventana.
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //En el DataGridView se pintan las imagenes en sus respectivos botones.

            if (e.ColumnIndex == 12)
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
            if (e.ColumnIndex == 13)
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

            
            if (e.ColumnIndex == 14)
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
