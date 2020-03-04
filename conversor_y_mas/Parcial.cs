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
    public partial class Parcial : Form
    {
        clasconvertir conver = new clasconvertir();

        public Parcial()
        {
            InitializeComponent();
        }

        private void cmbopcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbde.Items.Clear();
            cmba.Items.Clear();
            cmbde.Items.AddRange(conver.categoria[cmbopcion.SelectedIndex]);
            cmba.Items.AddRange(conver.categoria[cmbopcion.SelectedIndex]);
            cmbde.SelectedIndex = 0;
            cmba.SelectedIndex = 1;
            lblresultado.Text = "?";
            txtcantidad.Text = "1";
        }

        private void Parcial_Load(object sender, EventArgs e)
        {
            cmbopcion.Items.AddRange(conver.opciones);
            cmbopcion.SelectedIndex = 0;
        }

        private void btnconvertir_Click(object sender, EventArgs e)
        {
            lblresultado.Text = "Valor: " + conver.opconvertir(cmbde.SelectedIndex, cmba.SelectedIndex, double.Parse(txtcantidad.Text), cmbopcion.SelectedIndex) + " " + conver.categoria[cmbopcion.SelectedIndex][cmba.SelectedIndex];
        }
    }
}
