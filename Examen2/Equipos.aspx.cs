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
    public partial class Equipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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
            int valor = Clases.Equipos.Agregar (int.Parse(TusuarioID.Text),Ttipoequipo.Text,Tmodelo.Text);

            if (valor > 0)
            {
                alertas("El Equipo fue ingresado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar equipo");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int valor = Clases.Equipos.Borrar(int.Parse(tIdequipo.Text));

            if (valor > 0)
            {
                alertas("El equipo fue borrado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar equipo");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int valor = Clases.Equipos.Modificar(int.Parse(TusuarioID.Text), int.Parse(tIdequipo.Text),Ttipoequipo.Text,Tmodelo.Text);

            if (valor > 0)
            {
                alertas("El equipo fue modificado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar equipo");
            }
        }

        protected void Filtro()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos where EquipoID= " + tIdequipo.Text + ""))
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