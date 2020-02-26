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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void estadisiticaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void conversoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmconversores = new Form1();
            frmconversores.MdiParent = this;
            frmconversores.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frmconversores = new Form1();
            frmconversores.MdiParent = this;
            frmconversores.Show();

            lblformularioactivo.Text = frmconversores.Text;
        }

        private void principal_Load(object sender, EventArgs e)
        {

            lblstatusfecha.Text = DateTime.Now.ToShortDateString();
        }
    }
}
