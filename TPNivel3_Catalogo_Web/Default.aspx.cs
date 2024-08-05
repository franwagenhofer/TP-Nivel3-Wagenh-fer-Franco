using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Data.SqlClient;

namespace TPNivel3_Catalogo_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listarConSP();

            if (!IsPostBack)
            {
                // Guarda la lista de artículos en la sesión
                Session["listaArticulos"] = ListaArticulo;

                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        //protected void txtFiltro_TextChanged(object sender, EventArgs e)
        //{
        //    List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
        //    List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
        //    repRepetidor.DataSource = listaFiltrada;
        //    repRepetidor.DataBind();
        //}


        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> lista = Session["listaArticulos"] as List<Articulo>;

                if (lista == null)
                {
                    // Maneja el caso en que la lista de artículos no esté en la sesión
                    lblError.Text = "No se pudo cargar la lista de artículos.";
                    lblError.Visible = true;
                    return;
                }

                string filtro = txtFiltro.Text.ToUpper();
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro));

                if (listaFiltrada.Count == 0)
                {
                    lblMensaje.InnerText = "No se encontraron artículos.";
                    lblMensaje.Style["display"] = "block";
                }
                else
                {
                    lblMensaje.Style["display"] = "none";
                }



                repRepetidor.DataSource = listaFiltrada;
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que ocurra durante el filtrado
                lblError.Text = "Ocurrió un error al filtrar los artículos: " + ex.Message;
                lblError.Visible = true;
            }
        }




    }
}
