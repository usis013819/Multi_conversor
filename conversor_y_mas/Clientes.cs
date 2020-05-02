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
    public partial class Clientes : Form
    {
        Clase_Parcial objConexion = new Clase_Parcial();
        int posicion = 0;
        string accion = "nuevo";
        DataTable tbl = new DataTable();


        public Clientes()
        {
            InitializeComponent();
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            actualizarDs();
            mostrarDatos();
        }

        void actualizarDs()
        {
            tbl = objConexion.obtener_datos().Tables["clientes"];
            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["IdCliente"] };
        }

        void mostrarDatos()
        {
            try
            {
                lblidcliente.Text = tbl.Rows[posicion].ItemArray[0].ToString();
                TxtNombre.Text = tbl.Rows[posicion].ItemArray[1].ToString();
                TxtDireccion.Text = tbl.Rows[posicion].ItemArray[2].ToString();
                txttelefono.Text = tbl.Rows[posicion].ItemArray[3].ToString();
                txtdui.Text = tbl.Rows[posicion].ItemArray[4].ToString();
            

                lblnregistros.Text = (posicion + 1) + " de " + tbl.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay Datos que mostrar", "Registros de Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar_cajas();
            }
        }

     

        private void BtnPrimero_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Primer Registro...", "Registros De Cliente",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion < tbl.Rows.Count - 1)
            {
                posicion++;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Ultimo Registro...", "Registros de Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUltimo_Click(object sender, EventArgs e)
        {
            posicion = tbl.Rows.Count - 1;
            mostrarDatos();
        }

        void limpiar_cajas()
        {
            TxtNombre.Text = "";
            txtdui.Text = "";
            txttelefono.Text = "";
            TxtDireccion.Text = "";
        }

        void controles(Boolean valor)
        {
            GrbNavegacion.Enabled = valor;
            BtnDelete.Enabled = valor;
            BtnBuscar.Enabled = valor;
            GrbDatosCliente.Enabled = !valor;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (lblop.Text == "Nuevo")
            {//boton de nuevo
                lblop.Text = "Guardar";
                lblop2.Text = "Cancelar";
                accion = "nuevo";

                limpiar_cajas();
                controles(false);
            }
            else
            { //boton de guardar
                String[] valores = {

              lblidcliente.Text,
              TxtNombre.Text,
              TxtDireccion.Text,
              txttelefono.Text,
              txtdui.Text

                };
                objConexion.mantenimiento_datos_Cliente(valores, accion);
                actualizarDs();
                posicion = tbl.Rows.Count - 1;
                mostrarDatos();

                controles(true);

                lblop.Text = "Nuevo";
                lblop2.Text = "Editar";
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (lblop2.Text == "Editar")
            {//boton de modificar
                lblop.Text = "Guardar";
                lblop2.Text = "Cancelar";
                accion = "modificar";

                controles(false);

                lblop.Text = "Guardar";
                lblop2.Text = "Cancelar";

            }
            else
            { //boton de cancelar
                controles(true);
                mostrarDatos();

                lblop.Text = "Nuevo";
                lblop2.Text = "Editar";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar a " + TxtNombre.Text, "Registro de Clientes",
               MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                String[] valores = { lblidcliente.Text };
                objConexion.mantenimiento_datos_Cliente(valores, "eliminar");

                actualizarDs();
                posicion = posicion > 0 ? posicion - 1 : 0;
                mostrarDatos();
            }
        }

       

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda_Clientes frmBusqueda = new Busqueda_Clientes();
            frmBusqueda.ShowDialog();

            if (frmBusqueda._IdCliente > 0)
            {
                posicion = tbl.Rows.IndexOf(tbl.Rows.Find(frmBusqueda._IdCliente));
                mostrarDatos();
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
