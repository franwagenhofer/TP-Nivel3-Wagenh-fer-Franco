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
            //ListaArticulo = negocio.listarConSP();
            ListaArticulo = negocio.listarArticulos();

            if (!IsPostBack)
            {
                Session["listaArticulos"] = ListaArticulo;

                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> lista = Session["listaArticulos"] as List<Articulo>;

                if (lista == null)
                {
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
                lblError.Text = "Ocurrió un error al filtrar los artículos: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
