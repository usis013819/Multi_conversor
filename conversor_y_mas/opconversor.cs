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
    class opconversor
    {
        SqlConnection miConexion = new SqlConnection();
        SqlCommand comandosSQL = new SqlCommand();
        SqlDataAdapter miAdaptadorDatos = new SqlDataAdapter();

        DataSet ds = new DataSet();

        public opconversor()
        {
            String Cadena = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Admin\source\repos\Multi_conversor\conversor_y_mas\db_sistema_peliculas.mdf; Integrated Security = True";
            miConexion.ConnectionString = Cadena;
            miConexion.Open();
        }
        public DataSet obtener_datos()
        {

            ds.Clear();
            comandosSQL.Connection = miConexion;

            comandosSQL.CommandText = "select IdAlquiler, IdCliente, IdPelicula, convert(varchar(10),fechaPrestamo, 120) fechaPrestamo, convert(varchar(10),fechaDevolucion, 120) fechaDevolucion, valor from alquiler";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "alquiler");

            comandosSQL.CommandText = "select * from clientes";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "clientes");

            comandosSQL.CommandText = " select clientes.nombre, alquiler.IdAlquiler, alquiler.IdPelicula, convert(varchar(10),alquiler.fechaPrestamo, 120) fechaPrestamo," +
                                        "convert(varchar(10),alquiler.fechaDevolucion, 120) fechaDevolucion, alquiler.valor ,peliculas.descripcion,peliculas.sinopsis " +
                                        "from alquiler " +
                                        "inner join clientes on(clientes.IdCliente = alquiler.IdCliente) " +
                                        "inner join peliculas on(peliculas.IdPelicula = Alquiler.IdPelicula)";

            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "alquiler_clientes");

            comandosSQL.CommandText = "select * from peliculas";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "peliculas");

            comandosSQL.CommandText = "select peliculas.descripcion, alquiler.IdAlquiler, alquiler.IdPelicula, convert(varchar(10),alquiler.fechaPrestamo, 120) fechaPrestamo, convert(varchar(10),alquiler.fechaDevolucion, 120) fechaDevolucion, alquiler.valor from alquiler inner join peliculas on(peliculas.IdPelicula=alquiler.IdPelicula)";
            miAdaptadorDatos.SelectCommand = comandosSQL;
            miAdaptadorDatos.Fill(ds, "alquiler_peliculas");


            return ds;
        }
        public void mantenimiento_datos(String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo")
            {
                sql = "INSERT INTO alquiler(IdCliente,IdPelicula,fechaPrestamo,fechaDevolucion,valor) VALUES (" +

                     "'" + datos[1] + "'," +
                      "'" + datos[2] + "'," +
                       "'" + datos[3] + "'," +
                        "'" + datos[4] + "'," +
                         "'" + datos[5] + "'" +
                ")";
            }
            else if (accion == "modificar")
            {
                sql = "UPDATE alquiler SET" +
                 " IdCliente    = '" + datos[1] + "'," +
                  " IdPelicula    = '" + datos[2] + "'," +
                   " fechaPrestamo  = '" + datos[3] + "'," +
                    " fechaDevolucion = '" + datos[4] + "'," +
                     " valor           = '" + datos[5] + "'" +
                       " WHERE IdAlquiler = '" + datos[0] + "'";
            }
            else if (accion == "eliminar")
            {
                sql = " DELETE alquiler FROM alquiler WHERE IdAlquiler = '" + datos[0] + "'";
            }
            procesarSQL(sql);
        }
        void procesarSQL(String sql)
        {
            comandosSQL.Connection = miConexion;
            comandosSQL.CommandText = sql;
            comandosSQL.ExecuteNonQuery();
        }
    }
}


