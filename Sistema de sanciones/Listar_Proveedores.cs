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
        //crea un nuevo objeto de la clase controlado proveedor
        Controlador_Proveedor objp = new Controlador_Proveedor();
        DataTable dsTabla;
        //llama al controlador proveedor
        private Proveedores proveedores = new Proveedores();
        private int id;

        public Listar_Proveedores()
        {
            //inicilaiza los componentes del form
            InitializeComponent();
            //Inicializa el data gridview 
            CargarDG();
            //Asigna opciones a la lista desplegable
            List<string> sistema = new List<string>();
            sistema.Add("Sistema de los Servidores Públicos Sancionados");
            sistema.Add("Sistema de los Particulares Sancionados");
            sistema.Add("Sistema de los Servidores Públicos Sancionados, Sistema de los Particulares Sancionados");
            comboSistema.DataSource = sistema;
            //Asigna opciones a la lista desplegable
            List<string> estatus = new List<string>();
            estatus.Add("Vigente");
            estatus.Add("No vigente");
            comboEstatus.DataSource = estatus;

        }
        //En esta parte añade tamaño a las columnas del componete data gridview 
        private void CargarDG()
        {
            int p = panel2.Width;
            dsTabla = objp.ControladorProveedor();
            
            dataGridView1.DataSource = dsTabla;
            //columna 0 es ID, no es visible 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = Convert.ToInt32(p * 0.260);
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Width = Convert.ToInt32(p * 0.275);
            dataGridView1.Columns[4].Width = Convert.ToInt32(p * 0.250);
            dataGridView1.Columns[5].Visible = false;
        }
        // En el componente data gridview añade en la parte derecha las imagenes ver,eliminar y editar 
        private void Listar_Proveedores_Load(object sender, EventArgs e)
        {
            int p = panel2.Width;
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            //tamaño de la celda
            Ver.Width = Convert.ToInt32(p * 0.071);
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = Convert.ToInt32(p * 0.071);
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = Convert.ToInt32(p * 0.071);
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);

        }
        //evento del componente data gridview, se activa al dar clic en la celda 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si la celda contiene el nombre ver procedera a entrar en la condición.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ver")
            {
                //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    //Manda a llamar todos los datos del Usuario a la otra pantalla para proceder a su correspondiente visualización  
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
                //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo. 
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // al entrar a la condición, manda un mensaje.
                    DialogResult resut = MessageBox.Show("¿Está seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo);
                    if (resut == DialogResult.Yes)
                    {
                        //manda a llamar el procedimieto almacenado elimiar 
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
            //Si la celda contiene el nombre Editar procedera a entrar en la condición.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
            {
                //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    //Manda a llamar todos los datos del Usuario a la otra pantalla para proceder a su correspondiente edición
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    textProveedor.Texts = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    comboSistema.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboEstatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                    tabControl1.SelectedTab = EditarProveedor;

                }
            }
        }
        //Evento del componente data gridview, agrega las imagenes en la tabla 
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                //En el DataGridView se pintan las imagenes en sus respectivos botones.

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
            //Cambia de panel de editar a lista de proveedores.
            tabControl1.TabPages.Remove(EditarProveedor);
            tabControl1.TabPages.Add(ListaProveedor);

            //Incializan los componentes y se visualizan en el componente data gridview los botones ver, eliminar y editar. 
            this.Controls.Clear();
            this.InitializeComponent();
            CargarDG();
            //Listar_Proveedores_Load();
            int p = panel2.Width;
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = Convert.ToInt32(p * 0.071);
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = Convert.ToInt32(p * 0.071);
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = Convert.ToInt32(p * 0.071);
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);
        }

        private void btnVerProveedor_Click(object sender, EventArgs e)
        {
            //Cambia de panel de ver a lista de proveedores.
            tabControl1.TabPages.Remove(VerProveedor);
            tabControl1.TabPages.Add(ListaProveedor);

            //Inicializan los componentes y se visualizan en el componente data gridview los botones ver, eliminar y editar. 

            this.Controls.Clear();
            this.InitializeComponent();
            CargarDG();
            //Listar_Proveedores_Load();
            int p = panel2.Width;
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = Convert.ToInt32(p * 0.071);
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = Convert.ToInt32(p * 0.071);
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = Convert.ToInt32(p * 0.071);
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);
        }
        
        private void Guardar_Click(object sender, EventArgs e)
        {

            if (textProveedor.Texts == "Proveedor*" )
            {
                
                MessageBox.Show("Hay datos que aún no se han proporcionado");
            }
            else
            {
                //En caso de editar información, manda a llamar el procedimiento almacenado para editar los campos  
                objp.EditarProveedor(id, textProveedor.Texts, comboSistema.SelectedItem.ToString(), comboEstatus.SelectedItem.ToString());
                MessageBox.Show("Registro modificado");
                tabControl1.SelectedTab = ListaProveedor;
                //limpia los coltroles 
                this.Controls.Clear();
                this.InitializeComponent();
                //vuelve a cargar el componente data gridview, con los datos que se editaron 
                CargarDG();
                //Listar_Proveedores_Load();
                int p = panel2.Width;
                DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
                Ver.HeaderText = "Ver";
                Ver.Name = "Ver";
                Ver.Width = Convert.ToInt32(p * 0.071);
                Ver.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(Ver);

                DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
                btnclm.HeaderText = "Eliminar";
                btnclm.Name = "Eliminar";
                btnclm.Width = Convert.ToInt32(p * 0.071);
                btnclm.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(btnclm);

                DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
                editar.HeaderText = "Editar";
                editar.Name = "Editar";
                editar.Width = Convert.ToInt32(p * 0.071);
                editar.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(editar);
            }
            

            

        }
        // Cambia el color a gris 
        private void textProveedor_Enter(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "Proveedor*")
            {
                textProveedor.Texts = "";
                textProveedor.ForeColor = Color.Gray;

            }
        }
        // cambia el color
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
        //Maneja la entrada del teclado en el nivel de formulario en C#
        private void textProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            proveedores.textBoxEvent.textKeyPress(e);
        }
        
   
        
    }
}

