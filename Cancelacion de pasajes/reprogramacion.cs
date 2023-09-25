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
    public partial class reprogramacion : Form
    {

        public int idViajeSeleccionado { get; set; }

        private MySqlConnection conexion;
        private string cadenaConexion = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;";
        private DataTable tablaOriginal;


        private int idCliente123 = -1; // Inicializado con un valor predeterminado (puedes elegir cualquier valor predeterminado)
        private int idCliente456 = -1;


        private int idCliente;

        public reprogramacion(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            conexion = new MySqlConnection(cadenaConexion);
        }

        private void reprogramacion_Load(object sender, EventArgs e)
        {
            
            actualizar();
            CargarDatos();
            tablaOriginal = (DataTable)dgv_datos.DataSource; // Guarda la tabla original
            txt_filtro.Text = Convert.ToString(idCliente);
        }

        private void actualizar()
        {
            

        }
        private void CargarDatos()
        {
            
            try
            {
                
                conexion.Open();

                // Consulta SQL para obtener los datos deseados con el filtro "EstadoPasaje" activo
                string consulta = "SELECT Pasajes.IDPasaje, Pasajes.IDCliente, Clientes.Nombre, Clientes.Apellido, " +
                                  "Viajes.*, Pasajes.FechaCompra, Pasajes.EstadoPasaje " +
                                  "FROM Pasajes " +
                                  "INNER JOIN Clientes ON Pasajes.IDCliente = Clientes.IDCliente " +
                                  "INNER JOIN Viajes ON Pasajes.IDViaje = Viajes.IDViaje " +
                                  "WHERE Pasajes.EstadoPasaje = 'activo'";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgv_datos.DataSource = tabla;

                // Agrega el botón para seleccionar un nuevo IDViaje en cada fila
                DataGridViewButtonColumn columnaSeleccionar = new DataGridViewButtonColumn();
                columnaSeleccionar.Name = "SeleccionarViaje";
                columnaSeleccionar.Text = "Seleccionar Viaje";
                columnaSeleccionar.UseColumnTextForButtonValue = true;
                dgv_datos.Columns.Add(columnaSeleccionar);
                if (idViajeSeleccionado > 0)
                {
                    txt123.Text = idViajeSeleccionado.ToString();
                }
                
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

        private void dgv_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_datos.Columns["SeleccionarViaje"].Index)
            {
                if (dgv_datos.Rows[e.RowIndex].Cells["IDPasaje"].Value != null)
                {
                    if (dgv_datos.Rows[e.RowIndex].Cells["IDCliente"].Value != null)
                    {
                        idCliente456 = Convert.ToInt32(dgv_datos.Rows[e.RowIndex].Cells["IDPasaje"].Value);
                        idCliente123 = Convert.ToInt32(dgv_datos.Rows[e.RowIndex].Cells["IDCliente"].Value);

                        // Puedes mostrar el valor en un TextBox u otro control si lo deseas
                        // txtClienteSeleccionado.Text = idClienteSeleccionado.ToString();
                        dgv_datos.Columns.Clear();
                        CargarDatos();
                        txt_filtro_TextChanged(this, EventArgs.Empty);



                        reprogramacion_seleccionar reprogramacion_seleccionarForm = new reprogramacion_seleccionar();
                        reprogramacion_seleccionarForm.idCliente123 = idCliente123;
                        reprogramacion_seleccionarForm.idCliente456 = idCliente456;


                        reprogramacion_seleccionarForm.Show();
                        tablaOriginal = null;
                        Close();
                    }
                        
                }

                

            }
        }
    }
}
