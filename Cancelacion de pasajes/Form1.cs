using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cancelacion_de_pasajes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=cancelacion-de-pasajes-bd;User=root;Password= ;";
        }

        private void btn_Cancelar_Viaje_Click(object sender, EventArgs e)
        {

        }
    }
}
