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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class Listar_Usuarios : Form
    {
        Controlador_Usuario objp = new Controlador_Usuario(); //Se genera un nuevo objeto a la clae Control Usuario
        DataTable dsTabla; //Representa una tabla de datos en memoria.
        private Usuarios usuarios = new Usuarios();
        int ContadorTotal;


        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Listar_Usuarios()
        {
            InitializeComponent();
            ContadorTotal = objp.UltimoBarraListadoUsuarios();
            CargarDG(); //Se cargan los datos de los Usuarios registrados.

        }

        private void CargarDG()
        {
            objp.Inicio2 = 1;

            

            if (ContadorTotal <= 10)
            {
                botonPrimero.Enabled = false;
                botonAnterior.Enabled = false;
                botonSiguiente.Enabled = false;
                botonUltimo.Enabled = false;
                objp.Final2 = ContadorTotal;
            }
            else
            {
                objp.Final2 = 10;
                botonSiguiente.Enabled = true;
                botonUltimo.Enabled = true;
            }

            dsTabla = objp.Seleccionar_Datos_User(); //La tabla se recarga con el procedimiento almacenado Seleccionar_Datos_User.

            int p = tabControl1.Width;

            dataGridView1.DataSource = dsTabla;
            dataGridView1.ScrollBars = ScrollBars.None; //Desactivar ScrollBar del DataGridView

            dataGridView1.Columns[0].Visible = false; //Desactiva la columna ID
            dataGridView1.Columns[1].Visible = false; //Desactiva la columna IDUsuario
            dataGridView1.Columns[2].Width = (Convert.ToInt32(p * 0.3));     //Se asigna tamaño a la columna Nombre Completo
            dataGridView1.Columns[3].Visible = false; //Desactiva la columna Nombre
            dataGridView1.Columns[4].Visible = false; //Desactiva la columna Primer Apellido
            dataGridView1.Columns[5].Visible = false; //Desactiva la columna Segundo Apellido
            dataGridView1.Columns[6].Visible = false; //Desactiva la columna Cargo
            dataGridView1.Columns[7].Width = (Convert.ToInt32(p * 0.1));     //Se le asigna tamaño a la columna Usuario
            dataGridView1.Columns[8].Width = (Convert.ToInt32(p * 0.3));     //Se le asigna tamaño a la columna correo
            dataGridView1.Columns[9].Width = (Convert.ToInt32(p * 0.1));     //Se le asigna tamaño a la columna Proveedor
            dataGridView1.Columns[10].Visible = false; //Desactiva la columna Teléfono
            dataGridView1.Columns[11].Visible = false; //Desactiva la columna Extensión
            dataGridView1.Columns[12].Visible = false; //Desactiva la columna ComboSistemas
            dataGridView1.Columns[13].Visible = false; //Desactiva columna fecha alta
            dataGridView1.Columns[14].Visible = false; //Desactiva columna fecha actualización

            listarProveedor();

            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

            label12.Text = "Registros: " + objp.Inicio2 + " - " + (objp.Final2) + " de: " + ContadorTotal.ToString();
        }

        private void CargarBotones()
        {
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 90;
            Ver.FlatStyle = FlatStyle.Flat;
            Ver.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 90;
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 90;
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);
        }

        private void Listar_Usuarios_Load(object sender, EventArgs e)
        {
            //Se genera 3 nuevas columas con botones.
            CargarBotones();                                                                                                             
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar") //Si la celda contiene el nombre Eliminar procedera a entrar en la condición.
            {

                if (dataGridView1.SelectedRows.Count > 0) //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                {
                    DialogResult resut = MessageBox.Show("¿Está seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo);
                    if (resut == DialogResult.Yes)
                    {
                        objp.EliminarUsuario(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value)); //Manda a llamar le procedimiento almacenado Eliminar Usuario.
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
                        MessageBox.Show("Registro Eliminado"); //Muestra el siguiente mensaje.
                    }
                    else if (resut == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            if(dataGridView1.Columns[e.ColumnIndex].Name == "Editar") //Si la celda contiene el nombre Editar procedera a entrar en la condición.
            {
                if (dataGridView1.SelectedRows.Count > 0) //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                {
                    //Manda a llamar todos los datos del Usuario a la otra pantalla para proceder a su correspondiente edición
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    txtNombres.Texts = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textPApellido.Texts = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textSApellido.Texts = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textCargo.Texts = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textUser.Texts = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textCorreo.Texts = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    comboProveedor.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textTelefono.Texts = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textExtension.Texts = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    comboEstatus.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                    tabControl1.SelectedTab = EditarUsuarios;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ver") //Si la celda contiene el nombre Editar procedera a entrar en la condición.
            {
                if (dataGridView1.SelectedRows.Count > 0) //Si hay mas de 0 filas entonces procedera a ejecutar el siguiente codigo.
                {
                    //Manda a llamar todos los datos del Usuario a la otra pantalla para proceder a su correspondiente edición

                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    textNombres.Texts = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textPrimerApellido.Texts = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textSegundoApellido.Texts = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textCargo1.Texts = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textUserName.Texts = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textCorreoE.Texts = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    comboProveedor1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textNum.Texts = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textLada.Texts = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    comboEstatus1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                    fecha_Alta.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    fechaActualizacion.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

                    tabControl1.SelectedTab = VerUsuario;

                }
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //En el DataGridView se pintan las imagenes en sus respectivos botones.

            if (e.ColumnIndex == 15)
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
            if (e.ColumnIndex == 16)
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

            
            if (e.ColumnIndex == 17)
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


        //SECCIÓN MODIFICAR USUARIO.

        private void txtNombres_Enter(object sender, EventArgs e)
        {
            if (txtNombres.Texts == "Nombres *")
            {
                txtNombres.Texts = "";
                txtNombres.ForeColor = Color.Black;
            }
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            if (txtNombres.Texts == "")
            {
                txtNombres.Texts = "Nombres *";
                errorProvider1.SetError(txtNombres, "Se necesita ingresar un nombre");
                txtNombres.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(txtNombres, String.Empty);

            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);

        }

        private void textPApellido_Enter(object sender, EventArgs e)
        {
            if (textPApellido.Texts == "Primer Apellido *")
            {
                textPApellido.Texts = "";
                textPApellido.ForeColor = Color.Black;
            }
        }

        private void textPApellido_Leave(object sender, EventArgs e)
        {
            if (textPApellido.Texts == "")
            {
                textPApellido.Texts = "Primer Apellido *";
                errorProvider1.SetError(textPApellido, "Se necesita ingresar el Primer Apellido");
                textPApellido.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textPApellido, String.Empty);

            }
        }

        private void textPApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
        }

        private void textSApellido_Enter(object sender, EventArgs e)
        {
            if (textSApellido.Texts == "Segundo Apellido")
            {
                textSApellido.Texts = "";
                textSApellido.ForeColor = Color.Black;
            }
        }

        private void textSApellido_Leave(object sender, EventArgs e)
        {
            if (textSApellido.Texts == "")
            {
                textSApellido.Texts = "Segundo Apellido";
                textSApellido.ForeColor = Color.Gray;
            }
        }

        private void textSApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
        }

        private void textCargo_Enter(object sender, EventArgs e)
        {
            if (textCargo.Texts == "Cargo *")
            {
                textCargo.Texts = "";
                textCargo.ForeColor = Color.Black;
            }
        }

        private void textCargo_Leave(object sender, EventArgs e)
        {
            if (textCargo.Texts == "")
            {
                textCargo.Texts = "Cargo *";
                errorProvider1.SetError(textCargo, "Se necesita ingresar el Cargo");
                textCargo.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textCargo, String.Empty);
            }
        }

        private void textCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
        }

        private void textCorreo_Enter(object sender, EventArgs e)
        {
            if (textCorreo.Texts == "Correo eléctronico *")
            {
                textCorreo.Texts = "";
                textCorreo.ForeColor = Color.Black;
            }
        }

        private void textCorreo_Leave(object sender, EventArgs e)
        {
            if (textCorreo.Texts == "")
            {
                textCorreo.Texts = "Correo eléctronico *";
                textCorreo.ForeColor = Color.Gray;
            }

            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"; //Regex para la validación del correo electronico.
            bool isEmailValid = Regex.IsMatch(textCorreo.Texts, emailPattern); //Valida si el regex cumpla con los caracteres del correo insertado.

            if (!isEmailValid)
            {
                errorProvider1.SetError(textCorreo, "Correo no valido");
            }
            else
            {
                errorProvider1.SetError(textCorreo, String.Empty);
            }

        }

        private void textCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textTelefono_Enter(object sender, EventArgs e)
        {
            if (textTelefono.Texts == "Número de teléfono *")
            {
                textTelefono.Texts = "";
                textTelefono.ForeColor = Color.Black;
            }
        }

        private void textTelefono_Leave(object sender, EventArgs e)
        {
            if (textTelefono.Texts == "")
            {
                textTelefono.Texts = "Número de teléfono *";
                errorProvider1.SetError(textTelefono, "Se necesita ingresar el Teléfono");
                textTelefono.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textTelefono, String.Empty);
            }

        }

        private void textTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.validarNumeros(e);
        }

        private void textExtension_Enter(object sender, EventArgs e)
        {
            if (textExtension.Texts == "Extensión")
            {
                textExtension.Texts = "";
                textExtension.ForeColor = Color.Black;
            }
        }

        private void textExtension_Leave(object sender, EventArgs e)
        {
            if (textExtension.Texts == "")
            {
                textExtension.Texts = "Extensión";
                textExtension.ForeColor = Color.Gray;
            }
        }

        private void textExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.validarNumeros(e);
        }

        private void textUser_Enter(object sender, EventArgs e)
        {
            if (textUser.Texts == "Nombre de Usuario *")
            {
                textUser.Texts = "";
                textUser.ForeColor = Color.Black;
            }
        }

        private void textUser_Leave(object sender, EventArgs e)
        {
            if (textUser.Texts == "")
            {
                textUser.Texts = "Nombre de Usuario *";
                errorProvider1.SetError(textUser, "Se necesita ingresar el Nombre de Usuario");
                textUser.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textUser, String.Empty);
            }
        }

        private void textUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
        }

        private void limpiar()
        {
            txtNombres.Texts = "Nombres *";
            txtNombres.ForeColor = Color.Gray;
            //Limpiar primer apellido y aplicar color del Texto.
            textPApellido.Texts = "Primer Apellido *";
            textPApellido.ForeColor = Color.Gray;
            // Limpiar segundo apellido y aplicar color del Texto.
            textSApellido.Texts = "Segundo Apellido";
            textSApellido.ForeColor = Color.Gray;
            // Limpiar cargo y aplicar color del Texto.
            textCargo.Texts = "Cargo *";
            textCargo.ForeColor = Color.Gray;
            // Limpiar teléfono y aplicar color del Texto.
            textTelefono.Texts = "Número de teléfono *";
            textTelefono.ForeColor = Color.Gray;
            //Limpiar Correo eléctronico y aplicar color del texto
            textCorreo.Texts = "Correo eléctronico *";
            textCorreo.ForeColor = Color.Gray;
            //Limpiar Extensión y aplicar color del texto
            textExtension.Texts = "Extensión";
            textExtension.ForeColor = Color.Gray;
            //Limpiar Usuario y aplicar color del texto
            textUser.Texts = "Nombre de Usuario *";
            textUser.ForeColor = Color.Gray;

            comboProveedor.Text = "  Proveedor de Datos *";
        }


        private void listarProveedor()
        {
            comboProveedor.DataSource = new Controlador_Usuario().obtenerListaProveedor();
            comboProveedor.ValueMember = "proveedor";
        }

        private void buttonCancelar_Mod_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            tabControl1.SelectedTab = ListaUsuario;
            txtNombres.ForeColor = Color.Black;
            textPApellido.ForeColor = Color.Black;
            textSApellido.ForeColor = Color.Black;
            textCargo.ForeColor = Color.Black;
            textCorreo.ForeColor = Color.Black;
            textTelefono.ForeColor = Color.Black;
            textExtension.ForeColor = Color.Black;
            textUser.ForeColor = Color.Black;
        }

        private void buttonGuardar_Mod_Click(object sender, EventArgs e)
        {

            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"; //Regex para la validación del correo electronico.
            bool isEmailValid = Regex.IsMatch(textCorreo.Texts, emailPattern); //Valida si el regex cumpla con los caracteres del correo insertado.
            //Valida si algun campo no ha sido ingresado.
            if (!isEmailValid || txtNombres.Texts == "Nombres *" || textPApellido.Texts == "Primer Apellido *" ||
                            textCargo.Texts == "Cargo *" || textCorreo.Texts == "Correo eléctronico *" ||
                            textTelefono.Texts == "Número de télefono *" || textUser.Texts == "Nombre de Usuario *" || comboProveedor.Text == "Proveedor")
            {
                MessageBox.Show("Hay datos que aun no se han proporcionado");
            }
            else //Si los datos requeridos han sido insertados procesedara a guardar los datos.
            {
                modeloListaProveedores user = (modeloListaProveedores)comboProveedor.SelectedItem; //Se manda a llmaar la lista de os proveedores.
                int us = Convert.ToInt32(user.id); //Se selecciona el identificador.
                //Se Guarda la modificación de los datos corregidos.
                objp.EditarUsuario(Convert.ToInt32(id), txtNombres.Texts, textPApellido.Texts, textSApellido.Texts, textCargo.Texts, textCorreo.Texts, 
                    textTelefono.Texts, textExtension.Texts, textUser.Texts, us, comboEstatus.SelectedItem.ToString());
                MessageBox.Show("Registro Insertado");
                tabControl1.SelectedTab = ListaUsuario; //Al guardar la modificacón  automaticamente mandara a la pestaña de Listar Usuarios.

                this.Controls.Clear();
                this.InitializeComponent();
                CargarDG(); //Carga el DataGridView

                CargarBotones(); //Se vuelven a generar los botónes.
            }


        }

        //SECCIÓN FUNCIONAMIENTO DEL PAGINADOR.
        private void buttonCancelar_Ver_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = ListaUsuario;
        }

        private void botonPrimero_Click(object sender, EventArgs e)
        {
            objp.Inicio2 = 1;

            if (ContadorTotal < 10)
            {
                botonPrimero.Enabled = false;
                botonAnterior.Enabled = false;
                botonSiguiente.Enabled = false;
                objp.Final2 = ContadorTotal;
            }
            else
            {
                objp.Final2 = 10;
            }

            botonSiguiente.Enabled = true;
            dataGridView1.Columns.Remove("Ver");
            dataGridView1.Columns.Remove("Eliminar");
            dataGridView1.Columns.Remove("Editar");
            dsTabla.Clear();
            dsTabla = objp.Seleccionar_Datos_User();
            dataGridView1.DataSource = dsTabla;
            CargarBotones();

            botonAnterior.Enabled = false;

            label12.Text = "Registros: " + objp.Inicio2 + " - " + (objp.Final2) + " de: " + ContadorTotal.ToString();
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            objp.Inicio2 = objp.Inicio2 - 10;
            objp.Final2 = objp.Inicio2 + 10;
            botonSiguiente.Enabled = true;
            if (objp.Inicio2 <= 1)
            {
                botonAnterior.Enabled = false;
            }
            dataGridView1.Columns.Remove("Ver");
            dataGridView1.Columns.Remove("Eliminar");
            dataGridView1.Columns.Remove("Editar");
            dsTabla.Clear();
            dsTabla = objp.Seleccionar_Datos_User();
            dataGridView1.DataSource = dsTabla;
            CargarBotones();

            label12.Text = "Registros: " + objp.Inicio2 + " - " + (objp.Final2 - 1) + " de: " + ContadorTotal.ToString();
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            objp.Inicio2 = objp.Inicio2 + 10;
            objp.Final2 = objp.Inicio2 + 10;
            if (objp.Final2 >= ContadorTotal)
            {

                botonSiguiente.Enabled = false;
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                dataGridView1.Columns.Remove("Ver");
                dataGridView1.Columns.Remove("Eliminar");
                dataGridView1.Columns.Remove("Editar");
                dsTabla.Clear();
                dsTabla = objp.Seleccionar_Datos_User();
                dataGridView1.DataSource = dsTabla;
                CargarBotones();
                label12.Text = "Registros: " + objp.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
            }
            else
            {

                objp.Final2 = objp.Inicio2 + 10;

                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                dataGridView1.Columns.Remove("Ver");
                dataGridView1.Columns.Remove("Eliminar");
                dataGridView1.Columns.Remove("Editar");
                dsTabla.Clear();
                dsTabla = objp.Seleccionar_Datos_User();
                dataGridView1.DataSource = dsTabla;
                CargarBotones();
                label12.Text = "Registros: " + objp.Inicio2 + " - " + (objp.Final2 - 1) + " de: " + ContadorTotal.ToString();
            }
        }

        private void botonUltimo_Click(object sender, EventArgs e)
        {
            if (ContadorTotal % 10 == 0)
            {
                objp.Inicio2 = ContadorTotal - (ContadorTotal % 10) + 1 - 10;
                objp.Final2 = objp.Inicio2 + 10;

                dataGridView1.Columns.Remove("Ver");
                dataGridView1.Columns.Remove("Eliminar");
                dataGridView1.Columns.Remove("Editar");
                dsTabla.Clear();
                dsTabla = objp.Seleccionar_Datos_User();
                dataGridView1.DataSource = dsTabla;
                CargarBotones();

                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            else
            {
                objp.Inicio2 = ContadorTotal - (ContadorTotal % 10) + 1;
                objp.Final2 = objp.Inicio2 + 10;

                dataGridView1.Columns.Remove("Ver");
                dataGridView1.Columns.Remove("Eliminar");
                dataGridView1.Columns.Remove("Editar");
                dsTabla.Clear();
                dsTabla = objp.Seleccionar_Datos_User();
                dataGridView1.DataSource = dsTabla;
                CargarBotones();

                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            label12.Text = "Registros: " + objp.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
        }
    }
}
