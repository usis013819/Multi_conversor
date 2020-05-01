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
    public partial class Busqueda_Alquiler : Form
    {
        opconversor objConexion = new opconversor();
        public int _IdAlquiler;
        public Busqueda_Alquiler()
        {
            InitializeComponent();
        }

        private void Busqueda_Alquiler_Load(object sender, EventArgs e)
        {
            GrdBusquedaAlquiler.DataSource = objConexion.obtener_datos().Tables["alquiler_clientes"].DefaultView;
           // GrdBusquedaAlquiler.DataSource = objConexion.obtener_datos().Tables["alquiler_peliculas"].DefaultView;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (GrdBusquedaAlquiler.RowCount > 0)
            {
                _IdAlquiler = int.Parse(GrdBusquedaAlquiler.CurrentRow.Cells["IdAlquiler"].Value.ToString());
                Close();
            }
            else
            {
                MessageBox.Show("No hay datos que seleccionar", "Busqueda de Alquiler",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }       
        void filtrar_datos(String valor)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = GrdBusquedaAlquiler.DataSource;
            // bs.Filter = " where alquiler.valor like '%" +valor + "%' or clientes.nombre like '%" + valor + "%'";
            bs.Filter = " nombre like '%" + valor + "%' or descripcion like '%" + valor  + "%'";

            GrdBusquedaAlquiler.DataSource = bs;
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
