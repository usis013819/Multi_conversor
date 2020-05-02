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
    public partial class Buscador_Peliculas : Form
    {
        Clase_Parcial objConexion = new Clase_Parcial();
        public int _IdPelicula;

        public Buscador_Peliculas()
        {
            InitializeComponent();
        }

        private void Buscador_Peliculas_Load(object sender, EventArgs e)
        {
            GrdBusquedarPeliculas.DataSource = objConexion.obtener_datos().Tables["peliculas"].DefaultView;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (GrdBusquedarPeliculas.RowCount > 0)
            {
                _IdPelicula = int.Parse(GrdBusquedarPeliculas.CurrentRow.Cells[0].Value.ToString());
                Close();
            }
            else
            {
                MessageBox.Show("NO hay datos que seleccionar", "Busqueda de PELICULAS",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void filtrar_datos(String valor)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = GrdBusquedarPeliculas.DataSource;
            bs.Filter = "(descripcion + sinopsis + duracion + genero) like '%" + valor + "%'";
            GrdBusquedarPeliculas.DataSource = bs;
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
