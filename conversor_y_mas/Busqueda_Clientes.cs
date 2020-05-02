using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conversor_y_mas
{
    public partial class Busqueda_Clientes : Form
    {

        Clase_Parcial objConexion = new Clase_Parcial();
        public int _IdCliente;

  
        public Busqueda_Clientes()
        {
            InitializeComponent();
        }

        private void Busqueda_Clientes_Load(object sender, EventArgs e)
        {
            GrdBusquedaClientes.DataSource = objConexion.obtener_datos().Tables["clientes"].DefaultView;
        }

        void filtrar_datos(String valor)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = GrdBusquedaClientes.DataSource;
            bs.Filter = "(nombre + direccion + telefono + dui) like '%" + valor + "%'";
            GrdBusquedaClientes.DataSource = bs;

        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {

            if (GrdBusquedaClientes.RowCount > 0)
            {
                _IdCliente = int.Parse(GrdBusquedaClientes.CurrentRow.Cells[0].Value.ToString());
                Close();
            }
            else
            {
                MessageBox.Show("NO hay datos que seleccionar", "Busqueda de Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrar_datos(TxtBuscar.Text);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
