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
    public partial class Peliculas : Form
    {
        Clase_Parcial objConexion = new Clase_Parcial();
            int posicion = 0;
        string accion = "nuevo";
        DataTable tbl = new DataTable();

        public Peliculas()
        {
            InitializeComponent();
        }

        private void LblDireccion_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Peliculas_Load(object sender, EventArgs e)
        {
            actualizarDs();
            mostrarDatos();
        }
        void actualizarDs()
        {
            tbl = objConexion.Obtener_datos().Tables["peliculas"];
            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["IdPelicula"] };
        }
        void mostrarDatos()
        {
            try
            {
                txtcodigo .Text = tbl.Rows[posicion].ItemArray[0].ToString();
                TxtDescripcion.Text = tbl.Rows[posicion].ItemArray[1].ToString();
                txtSinopsis .Text = tbl.Rows[posicion].ItemArray[2].ToString();
                txtGenero.Text = tbl.Rows[posicion].ItemArray[3].ToString();
                txtTiempo.Text = tbl.Rows[posicion].ItemArray[4].ToString();
            
              
              

                lblnregistros.Text = (posicion + 1) + " de " + tbl.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay Datos que mostrar", "Registros de PELICULAS",
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
                MessageBox.Show("Primer Registro...", "Registros De PELICULAS",
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
                MessageBox.Show("Ultimo Registro...", "Registros de PELICULAS",
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

            TxtDescripcion.Text = "";
            txtSinopsis.Text = "";
            txtGenero.Text = "";
            txtTiempo .Text = "";
          
          
          

        }

        void controles(Boolean valor)
        {
            GrbNavegacion.Enabled = valor;
            BtnDelete.Enabled = valor;
            BtnBuscar.Enabled = valor;
            GrbDatosPeliculas .Enabled = !valor;
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
              
              txtcodigo.Text,
             TxtDescripcion . Text ,
              txtSinopsis .Text,
                txtGenero .Text,
              txtTiempo.Text,
             
            
                 

                };
                objConexion.mantenimiento_datos_PELICULAS(valores, accion);
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
            if (MessageBox.Show("Esta seguro de eliminar a " + txtcodigo .Text, "Registro de PELICULAS",
               MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                String[] valores = { txtcodigo .Text };
                objConexion.mantenimiento_datos_PELICULAS(valores, "eliminar");

                actualizarDs();
                posicion = posicion > 0 ? posicion - 1 : 0;
                mostrarDatos();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscador_Peliculas  frmBusqueda = new Buscador_Peliculas();
            frmBusqueda.ShowDialog();

            if (frmBusqueda._IdPelicula > 0)
            {
                posicion = tbl.Rows.IndexOf(tbl.Rows.Find(frmBusqueda._IdPelicula));
                mostrarDatos();
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    
}
