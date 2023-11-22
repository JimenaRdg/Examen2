using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen2.Clases
{
    public class Equipos
    {
        public static int id { get; set; }
        public static int usuarioId { get; set; }
        public static string tipoequipo { get; set; }
        public static string modelo { get; set; }

        public Equipos(int UsuarioId,String Tipoequipo,String Modelo)
        {
            
            usuarioId = UsuarioId;
            tipoequipo = Tipoequipo;
            modelo = Modelo;

        }

        public static int Agregar(int UsuarioID, String TipoEquipo,string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID",UsuarioID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo",TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int Borrar(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Codigo", id));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int Modificar(int cod, int UsuarioID, String TipoEquipo, string Modelo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAREQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Codigo", cod));
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

    }
}