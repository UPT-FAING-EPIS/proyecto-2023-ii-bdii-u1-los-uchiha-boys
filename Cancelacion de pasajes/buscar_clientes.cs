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
    public partial class buscar_clientes : Form
    {
        private MySqlConnection conexion;
        private string cadenaConexion = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;";


        public buscar_clientes()
        {
            InitializeComponent();
            conexion = new MySqlConnection(cadenaConexion);
        }

        private void buscar_clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos de la tabla Clientes
                string consulta = "SELECT * FROM Clientes";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                System.Data.DataTable tablaClientes = new System.Data.DataTable();
                adaptador.Fill(tablaClientes);

                // Agregar los datos al DataGridView
                dgvClientes.DataSource = tablaClientes;

                // Agregar una columna de botones "Seleccionar"
                DataGridViewButtonColumn columnaSeleccionar = new DataGridViewButtonColumn();
                columnaSeleccionar.Name = "Seleccionar";
                columnaSeleccionar.Text = "Seleccionar";
                columnaSeleccionar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(columnaSeleccionar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de clientes: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvClientes.Columns["Seleccionar"].Index)
            {
                if (dgvClientes.Rows[e.RowIndex].Cells["IDCliente"].Value != null)
                {
                    int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["IDCliente"].Value);

                    datos_clientes datosClientesForm = new datos_clientes(idCliente);
                    datosClientesForm.ShowDialog();
                }
            }
        }

    }
}
