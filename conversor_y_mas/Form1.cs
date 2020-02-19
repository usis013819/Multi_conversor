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
    public partial class Form1 : Form
    {
        opconversor objconversiones = new opconversor();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnconvertir_Click(object sender, EventArgs e)
        {
            
          lblresul.Text = "Valor: " + objconversiones.convertir(cmbde.SelectedIndex, cmba.SelectedIndex, double.Parse(txtcantidad.Text), cmbop.SelectedIndex) + " " + objconversiones.definicion[cmbop.SelectedIndex][cmba.SelectedIndex];
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbop.Items.AddRange(objconversiones.opcion);
            cmbop.SelectedIndex = 0;
        }

        private void cmbop_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbde.Items.Clear();
            cmba.Items.Clear();
            cmbde.Items.AddRange(objconversiones.definicion[cmbop.SelectedIndex]);
            cmba.Items.AddRange(objconversiones.definicion[cmbop.SelectedIndex]);
            cmbde.SelectedIndex = 0;
            cmba.SelectedIndex = 1;
            lblresul.Text = "?";
            txtcantidad.Text = "1";
        }
    }
}
