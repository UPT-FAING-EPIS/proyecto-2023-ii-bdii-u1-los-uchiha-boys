using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cancelacion_de_pasajes
{
    public partial class transferencia_seleccionar : Form
    {
        private MySqlConnection conexion;
        private string cadenaConexion = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;";

        public int idCliente123 { get; set; }
        public int idCliente456 { get; set; }

        public transferencia_seleccionar()
        {
            InitializeComponent();
            conexion = new MySqlConnection(cadenaConexion);
        }

        private void transferencia_seleccionar_Load(object sender, EventArgs e)
        {
            CargarDatosClientes();
        }
        private void CargarDatosClientes()
        {
            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos de la tabla Viajes
                string consulta = "SELECT * FROM Clientes";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tablaViajes = new DataTable();
                adaptador.Fill(tablaViajes);

                // Agregar los datos al DataGridView
                dgvViajes.DataSource = tablaViajes;

                // Agregar una columna de botones "Seleccionar" al final del DataGridView
                DataGridViewButtonColumn columnaSeleccionar = new DataGridViewButtonColumn();
                columnaSeleccionar.Name = "SeleccionarCliente";
                columnaSeleccionar.Text = "Seleccionar";
                columnaSeleccionar.UseColumnTextForButtonValue = true;
                dgvViajes.Columns.Add(columnaSeleccionar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Viajes: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void dgvViajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViajes.Columns["SeleccionarCliente"].Index)
            {
                // Obtén el IDCliente de la fila seleccionada en dgvViajes
                if (dgvViajes.Rows[e.RowIndex].Cells["IDCliente"].Value != null)
                {
                    int idClienteSeleccionado = Convert.ToInt32(dgvViajes.Rows[e.RowIndex].Cells["IDCliente"].Value);

                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                        {
                            conexion.Open();

                            // Valor de IDCliente deseado (el cliente seleccionado)
                            int nuevoIDCliente = idClienteSeleccionado;

                            // IDPasaje que deseas actualizar (puedes obtenerlo de alguna manera)
                            int idPasajeSeleccionado = ObtenerIDPasajeSeleccionado(); // Implementa esta función para obtener el IDPasaje

                            // Consulta SQL de actualización para modificar IDCliente en Pasajes
                            string consulta = "UPDATE Pasajes SET IDCliente = @NuevoIDCliente WHERE IDPasaje = @IDPasajeSeleccionado";

                            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                            {
                                // Establece los parámetros en la consulta
                                comando.Parameters.AddWithValue("@NuevoIDCliente", nuevoIDCliente);
                                comando.Parameters.AddWithValue("@IDPasajeSeleccionado", idPasajeSeleccionado);

                                // Ejecuta la consulta de actualización
                                int filasActualizadas = comando.ExecuteNonQuery();

                                if (filasActualizadas > 0)
                                {
                                    Console.WriteLine("Se ha actualizado el IDCliente en la tabla Pasajes.");
                                }
                                else
                                {
                                    Console.WriteLine("No se ha encontrado el registro para actualizar.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar la tabla Pasajes: " + ex.Message);
                    }

                    // Cierra el formulario actual
                    this.Close();
                }
            }
        }
        private int ObtenerIDPasajeSeleccionado()
        {
            if (dgvViajes.SelectedRows.Count > 0)
            {
                // Por ejemplo, asumamos que el IDPasaje está en la columna "IDPasaje"
                if (dgvViajes.SelectedRows[0].Cells["IDPasaje"].Value != null)
                {
                    return Convert.ToInt32(dgvViajes.SelectedRows[0].Cells["IDPasaje"].Value);
                }
            }

            // Si no se seleccionó ninguna fila o no se encontró el IDPasaje, puedes manejarlo como desees
            // Por ejemplo, puedes mostrar un mensaje de error o devolver un valor predeterminado.
            return -1;
        }
    }
}
