using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen2
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }

        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int valor = Clases.Usuarios.Agregar(TNombre.Text, TCorreo.Text,Ttelefono.Text);

            if (valor > 0)
            {
                alertas("El usuario fue ingresado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar usuario");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int valor = Clases.Usuarios.Borrar(int.Parse(TIdUsuario.Text));

            if (valor > 0)
            {
                alertas("El Usuario fue Borrado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Usuario");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int valor = Clases.Usuarios.Modificar(int.Parse(TIdUsuario.Text), TNombre.Text, TCorreo.Text, int.Parse(Ttelefono.Text));

            if (valor > 0)
            {
                alertas("El Usuario fue modificado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar usuario");
            }
        }
        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios where UsuarioID= " + TIdUsuario.Text + ""))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Filtro();
        }
    }
}