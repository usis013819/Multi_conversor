using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libreria DB
using System.Data;
//libreria DB con SQL Server
using System.Data.SqlClient;

namespace conversor_y_mas
{
    class Clase_Parcial
    {

        SqlConnection miconexion = new SqlConnection();
        SqlCommand comandosSQL = new SqlCommand();
        SqlDataAdapter miAdactadorDatos = new SqlDataAdapter();

        DataSet ds = new DataSet();

        public Clase_Parcial()
        {
            String cadena = @"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_sistema_peliculas.mdf;Integrated Security=True ";
            miconexion.ConnectionString = cadena;
            miconexion.Open();
        }
        public DataSet Obtener_datos()
        {
            ds.Clear();
            comandosSQL.Connection = miconexion;

            comandosSQL.CommandText = "select * from peliculas";
            miAdactadorDatos.SelectCommand = comandosSQL;
            miAdactadorDatos.Fill(ds, "peliculas");

            return ds;
        }
        public void mantenimiento_datos_PELICULAS(String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo")
            {

                sql = "INSERT INTO peliculas (descripcion, sinopsis, genero, duracion) VALUES(" +

                    "'" + datos[1] + "'," +
                    "'" + datos[2] + "'," +
                    "'" + datos[3] + "'," +                
                    "'" + datos[4] + "'" +
                    ")";

            }

            else if (accion == "modificar")
            {

                sql = "UPDATE peliculas SET " +
                " descripcion            = '" + datos[1] + "'," +
                " sinopsis               = '" + datos[2] + "'," +
                " genero                 = '" + datos[3] + "'," +
                " duracion               = '" + datos[4]  +"'"+
                "WHERE IdPelicula         = '" + datos[0] + "'";





            }
            else if (accion == "eliminar")
            {
                sql = "DELETE peliculas FROM peliculas WHERE IdPelicula='" + datos[0] + "'";

            }
            procesoSQL(sql);
        }
        void procesoSQL(String sql)
        {
            comandosSQL.Connection = miconexion;
            comandosSQL.CommandText = sql;
            comandosSQL.ExecuteNonQuery();
        }

    }


}
