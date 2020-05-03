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
                btnsubmenu1.Location = new Point(8, 56);
                btnsubmenu2.Location = new Point(8, 316);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            btnmenu.Location = new Point(2, 205);
            btnsubmenu1.Location = new Point(8, 56);
            btnsubmenu2.Location = new Point(8, 316);
            panelboton1.Hide();
            panelitem1.Hide();
            panelitem2.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Alquiler frmalquiler = new Alquiler();
            frmalquiler.MdiParent = this;
            frmalquiler.Show();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnalquilermenu_Click(object sender, EventArgs e)
        {
            Alquiler frmalquiler = new Alquiler();
            frmalquiler.MdiParent = this;
            frmalquiler.Show();
        }

        private void btnpelicula_Click(object sender, EventArgs e)
        {
            Peliculas frmpeliculas = new Peliculas();
            frmpeliculas.MdiParent = this;
            frmpeliculas.Show();
        }

        private void btnmenupeliculas_Click(object sender, EventArgs e)
        {
            Peliculas frmpeliculas = new Peliculas();
            frmpeliculas.MdiParent = this;
            frmpeliculas.Show();
        }

        private void btnsubmenu1_Click(object sender, EventArgs e)
        {
            if (panelitem1.Visible == true)
            {
                panelitem1.Visible = false;
            }

            else

            {
                panelitem1.Visible = true;
            }

            btnsubmenu1.Location = new Point(8, 56);
            panelitem1.Location = new Point(8, 91);

            if (panelitem1.Visible == false)
            {
                
                btnsubmenu1.Location = new Point(8, 56);
                btnsubmenu2.Location = new Point(8, 316);
            }
        }

        private void btnsubmenu2_Click(object sender, EventArgs e)
        {
            if (panelitem2.Visible == true)
            {
                panelitem2.Visible = false;
            }

            else

            {
                panelitem2.Visible = true;
            }

            btnsubmenu2.Location = new Point(8, 316);
            panelitem2.Location = new Point(8, 350);

            if (panelitem2.Visible == false)
            {

                btnsubmenu1.Location = new Point(8, 56);
                btnsubmenu2.Location = new Point(8, 316);
            }
        }
    }
}
