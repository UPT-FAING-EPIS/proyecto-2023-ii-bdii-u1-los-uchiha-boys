using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cancelacion_de_pasajes
{
    public partial class Cancelacion : Form
    {
        private MySqlConnection conexion;
        private string cadenaConexion = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;";
        private DataTable tablaOriginal;

        //id del cliente almacenado
        private int idCliente;

        public Cancelacion(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            conexion = new MySqlConnection(cadenaConexion);
        }

        private void Cancelacion_Load(object sender, EventArgs e)
        {
            CargarDatos();
            AgregarCheckBoxColumn(); 
            tablaOriginal = (DataTable)dgv_datos.DataSource; // Guarda la tabla original
            txt_filtro.Text = Convert.ToString(idCliente);
        }


        private void CargarDatos()
        {
            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos deseados
                string consulta = "SELECT Pasajes.IDPasaje, Pasajes.IDCliente, Clientes.Nombre, Clientes.Apellido, " +
                                   "Viajes.*, Pasajes.FechaCompra, Pasajes.EstadoPasaje " +
                                   "FROM Pasajes " +
                                   "INNER JOIN Clientes ON Pasajes.IDCliente = Clientes.IDCliente " +
                                   "INNER JOIN Viajes ON Pasajes.IDViaje = Viajes.IDViaje";


                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgv_datos.DataSource = tabla;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void dgv_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AgregarCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Cancelar";
            checkBoxColumn.Name = "SeleccionarPasaje";
            dgv_datos.Columns.Add(checkBoxColumn);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_datos.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["SeleccionarPasaje"] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && Convert.ToBoolean(checkBoxCell.Value) == true)
                {
                    int idPasaje = Convert.ToInt32(row.Cells["IDPasaje"].Value);

                    try
                    {
                        conexion.Open();

                        // Consulta SQL para actualizar el estado a "cancelado"
                        string consulta = "UPDATE Pasajes SET EstadoPasaje = 'cancelado' WHERE IDPasaje = @IDPasaje";

                        MySqlCommand comando = new MySqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@IDPasaje", idPasaje);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // La actualización fue exitosa
                            // Puedes realizar alguna acción adicional si lo deseas
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("La actualización no tuvo éxito.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar los datos: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            // Vuelve a cargar los datos en el DataGridView después de la actualización
            CargarDatos();
            txt_filtro_TextChanged(this, EventArgs.Empty);
            this.Close();
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            if (tablaOriginal != null)
            {
                // Verifica si el texto ingresado es un número válido
                if (int.TryParse(txt_filtro.Text, out int filtroNumero))
                {
                    // Filtra las filas en función del número ingresado en txt_filtro
                    DataView vista = tablaOriginal.DefaultView;
                    vista.RowFilter = $"IDCliente = {filtroNumero}";

                    // Actualiza el DataGridView con las filas filtradas
                    dgv_datos.DataSource = vista.ToTable();
                }
                else
                {
                    // Si el texto ingresado no es un número válido, puedes mostrar un mensaje de error o manejarlo de otra manera.
                    MessageBox.Show("Ingrese un número válido para el filtro.");
                }
            }


        }
    }
}
