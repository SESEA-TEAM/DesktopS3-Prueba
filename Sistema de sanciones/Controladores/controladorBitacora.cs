using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_sanciones.ConexionBD;
using Microsoft.VisualBasic;

namespace Sistema_de_sanciones.Controladores
{
    internal class controladorBitacora
    {
        private Conexion ConexionBD = new Conexion();
        public DataSet reporteBitacora(String fInicial,String fFinal, String sistema, String usuario)
        {
            {
                DataSet dt = new DataSet();
                try
                {

                    SqlCommand comando = new SqlCommand("buscarBitacora");
                    comando.Connection = ConexionBD.AbrirConexion();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@fInicial", fInicial);
                    comando.Parameters.AddWithValue("@fFinal", fFinal);
                    comando.Parameters.AddWithValue("@sistema", sistema);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    SqlDataAdapter da = new SqlDataAdapter(comando);

                    da.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                    return dt;
                }

            }
        }

        public void aCSV (DataGridView dg, string ar)
        {
            //prueba que el datagrid no este vacio
            if (dg.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(ar);

                //escribe el encabezado de las columnas
                for (int i = 0; i <= dg.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(dg.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //escribir 
                for (int j = 0; j <= dg.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = dg.Rows[j];

                    for (int i = 0; i <= dg.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();

            }
        }
    }
}
