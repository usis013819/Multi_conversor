﻿using System;
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
    public partial class Alquiler : Form
    {
        Clase_Parcial objConexion = new Clase_Parcial();
        int posicion = 0;
        string accion = "nuevo";
        DataTable tbl = new DataTable();
        public Alquiler()
        {
            InitializeComponent();
        }

        private void Alquiler_Load(object sender, EventArgs e)
        {
            actualizarDs();
            mostrarDatos();

            CboClientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboClientes.AutoCompleteSource = AutoCompleteSource.ListItems;

            CboPelicula.AutoCompleteMode = AutoCompleteMode.Suggest;
            CboPelicula.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        void actualizarDs()
        {
            tbl = objConexion.obtener_datos().Tables["alquiler"];
            tbl.PrimaryKey = new DataColumn[] { tbl.Columns["IdAlquiler"] };

            CboClientes.DataSource = objConexion.obtener_datos().Tables["clientes"];
            CboClientes.DisplayMember = "nombre";
            CboClientes.ValueMember = "clientes.IdCliente";

            CboPelicula.DataSource = objConexion.obtener_datos().Tables["peliculas"];
            CboPelicula.DisplayMember = "descripcion";
            CboPelicula.ValueMember = "peliculas.IdPelicula";


        }
        void mostrarDatos()
        {
            try
            {
                CboClientes.SelectedValue = tbl.Rows[posicion].ItemArray[1].ToString();

                CboPelicula.SelectedValue = tbl.Rows[posicion].ItemArray[2].ToString();

                LblIdAlqui.Text = tbl.Rows[posicion].ItemArray[0].ToString();
                txtfechaprestamo.Text = tbl.Rows[posicion].ItemArray[3].ToString();
                TxtFechaDevolucion.Text = tbl.Rows[posicion].ItemArray[4].ToString();
                TxtValor.Text = tbl.Rows[posicion].ItemArray[5].ToString();

                lblnregistros.Text = (posicion + 1) + " de " + tbl.Rows.Count;
            }

            catch (Exception ex)
            {
                MessageBox.Show("No hay Datos que mostrar", "Registros de Alquiler",
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
                MessageBox.Show("Primer Registro...", "Registros De Alquiler",
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
                MessageBox.Show("Ultimo Registro...", "Registros de Alquiler",
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
            txtfechaprestamo.Text = "";
            TxtFechaDevolucion.Text = "";
            TxtValor.Text = "";
        }

        void controles(Boolean valor)
        {
            GrbNavegacion.Enabled = valor;
            BtnDelete.Enabled = valor;
            BtnBuscar.Enabled = valor;
            GrbDatosAlquiler.Enabled = !valor;
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

             LblIdAlqui.Text,
             CboClientes.SelectedValue.ToString(),
             CboPelicula.SelectedValue.ToString(),
             txtfechaprestamo.Text,
             TxtFechaDevolucion.Text,
             TxtValor.Text

                };

                objConexion.mantenimiento_datos_alquiler(valores, accion);
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

            if (MessageBox.Show("Esta seguro de eliminar a " + txtfechaprestamo.Text, "Registro de Alquiler",
              MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                String[] valores = { LblIdAlqui.Text };
                objConexion.mantenimiento_datos_alquiler(valores, "eliminar");

                actualizarDs();
                posicion = posicion > 0 ? posicion - 1 : 0;
                mostrarDatos();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda_Alquiler buscarAlquiler = new Busqueda_Alquiler();
            buscarAlquiler.ShowDialog();

            if (buscarAlquiler._IdAlquiler > 0)
            {
                posicion = tbl.Rows.IndexOf(tbl.Rows.Find(buscarAlquiler._IdAlquiler));
                mostrarDatos();
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {

            Busqueda_Clientes buscarcliente = new Busqueda_Clientes();
            buscarcliente.ShowDialog();

            if (buscarcliente._IdCliente > 0)
            {
                CboClientes.SelectedValue = buscarcliente._IdCliente;
            }
        }

        private void BtnBuscarPelicula_Click(object sender, EventArgs e)
        {
            Buscador_Peliculas frmBusqueda = new Buscador_Peliculas();
            frmBusqueda.ShowDialog();

            if (frmBusqueda._IdPelicula > 0)
            {
                posicion = tbl.Rows.IndexOf(tbl.Rows.Find(frmBusqueda._IdPelicula));
                mostrarDatos();
            }
        }

       
    }
}
