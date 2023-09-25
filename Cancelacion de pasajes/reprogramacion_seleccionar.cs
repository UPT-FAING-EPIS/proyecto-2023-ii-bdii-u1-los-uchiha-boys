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
    public partial class reprogramacion_seleccionar : Form
    {
        private MySqlConnection conexion;
        private string cadenaConexion = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;";

        public int idCliente123 { get; set; }
        public int idCliente456 { get; set; }

        public reprogramacion_seleccionar()
        {
            InitializeComponent();
            conexion = new MySqlConnection(cadenaConexion);
        }

        private void reprogramacion_seleccionar_Load(object sender, EventArgs e)
        {
            CargarDatosViajes();
        }
        private void CargarDatosViajes()
        {
            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos de la tabla Viajes
                string consulta = "SELECT * FROM Viajes";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tablaViajes = new DataTable();
                adaptador.Fill(tablaViajes);

                // Agregar los datos al DataGridView
                dgvViajes.DataSource = tablaViajes;

                // Agregar una columna de botones "Seleccionar" al final del DataGridView
                DataGridViewButtonColumn columnaSeleccionar = new DataGridViewButtonColumn();
                columnaSeleccionar.Name = "SeleccionarViaje";
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
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViajes.Columns["SeleccionarViaje"].Index)
            {
                // Obtén el IDViaje de la fila seleccionada
                if (dgvViajes.Rows[e.RowIndex].Cells["IDViaje"].Value != null)
                {

                    int idViajeSeleccionado = Convert.ToInt32(dgvViajes.Rows[e.RowIndex].Cells["IDViaje"].Value);

                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                        {
                            conexion.Open();

                            // Valor de IDViaje deseado
                            int nuevoIDViaje = idViajeSeleccionado; // Cambia esto al valor deseado

                            // Criterio para relacionar los registros
                            int idPasajeSeleccionado = idCliente456; // Cambia esto al valor de IDPasaje que deseas actualizar

                            // Consulta SQL de actualización para modificar IDViaje en Pasajes
                            string consulta = "UPDATE Pasajes AS p " +
                                              "INNER JOIN Viajes AS v ON p.IDViaje = v.IDViaje " +
                                              "SET p.IDViaje = @NuevoIDViaje " +
                                              "WHERE p.IDPasaje = @IDPasajeSeleccionado";

                            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                            {
                                // Establece los parámetros en la consulta
                                comando.Parameters.AddWithValue("@NuevoIDViaje", nuevoIDViaje);
                                comando.Parameters.AddWithValue("@IDPasajeSeleccionado", idPasajeSeleccionado);

                                // Ejecuta la consulta de actualización
                                int filasActualizadas = comando.ExecuteNonQuery();

                                if (filasActualizadas > 0)
                                {
                                    Console.WriteLine("Se ha actualizado el IDViaje en la tabla Pasajes.");
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
                    reprogramacion reprogramacion = new reprogramacion(idCliente123);
                    reprogramacion.idViajeSeleccionado = idViajeSeleccionado;
                    reprogramacion.Show();
                    Close();
                }
            }
        }
    }
}
