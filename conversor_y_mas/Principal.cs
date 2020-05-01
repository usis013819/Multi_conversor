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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {

            if (panelboton1.Visible == true)
            {
                panelboton1.Visible = false;
            }

            else

            {
                panelboton1.Visible = true;
            }

            btnmenu.Location = new Point(2, 205);
            panelboton1.Location = new Point(2, 240);

            if (panelboton1.Visible == false)
            {
                btnmenu.Location = new Point(2, 205);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            btnmenu.Location = new Point(2, 205);
            panelboton1.Hide();

        }

        private void btnclientemenu_Click(object sender, EventArgs e)
        {
            Clientes frmCliente = new Clientes();
            frmCliente.MdiParent = this;
            frmCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes frmCliente = new Clientes();
            frmCliente.MdiParent = this;
            frmCliente.Show();
        }
    }
}
