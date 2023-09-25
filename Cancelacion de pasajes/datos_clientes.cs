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
    public partial class datos_clientes : Form
    {
        private int idCliente;
        public datos_clientes(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
        }

        private void datos_clientes_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            string cadenaConexion = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                // Consulta SQL para obtener los datos del cliente por su ID
                string consulta = "SELECT * FROM Clientes WHERE IDCliente = @IDCliente";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IDCliente", idCliente);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Mostrar los datos en los TextBox
                        txt_id_cliente.Text = reader["IDCliente"].ToString();
                        txt_nombre.Text = reader["Nombre"].ToString();
                        txt_apellido.Text = reader["Apellido"].ToString();
                        txt_correo_electronico.Text = reader["CorreoElectronico"].ToString();
                        txt_telefono.Text = reader["Telefono"].ToString();
                        txt_saldo_credito.Text = reader["SaldoCredito"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btn_cancelar_viaje_Click(object sender, EventArgs e)
        {

            Cancelacion CancelacionForm = new Cancelacion(idCliente);
            CancelacionForm.ShowDialog();
        }

        private void btn_reprogramar_Click(object sender, EventArgs e)
        {
            reprogramacion ReprogramacionForm = new reprogramacion(idCliente);
            ReprogramacionForm.ShowDialog();
        }

        private void btn_transferencia_Click(object sender, EventArgs e)
        {
            reprogramacion TransferenciaForm = new reprogramacion(idCliente);
            TransferenciaForm.ShowDialog();
        }
    }
}
