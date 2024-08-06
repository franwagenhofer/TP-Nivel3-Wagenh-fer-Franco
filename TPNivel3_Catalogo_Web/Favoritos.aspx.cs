using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPNivel3_Catalogo_Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        private List<Articulo> FavoritosList
        {
            get
            {
                if (Session["FavoritosList"] == null)
                {
                    Session["FavoritosList"] = new List<Articulo>();
                }
                return (List<Articulo>)Session["FavoritosList"];
            }
            set
            {
                Session["FavoritosList"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!negocio.Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Session.Add("error", "Se requiere estar logueado para acceder a esta pantalla");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }

                    int IdUser = ((Usuario)Session["usuario"]).Id;
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    FavoritosList = usuarioNegocio.ObtenerFavoritos(IdUser);

                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    //Session["listaArticulos"] = articuloNegocio.listarConSP();
                    Session["listaArticulos"] = articuloNegocio.listarArticulos();

                    BindFavoritos();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.ToString();
                Response.Redirect("Error.aspx", false);
            }
        }

        private void BindFavoritos()
        {
            repRepetidor.DataSource = FavoritosList;
            repRepetidor.DataBind();

            dgvFavoritos.DataSource = FavoritosList;
            dgvFavoritos.DataBind();
        }

        protected void dgvFavoritos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvFavoritos.PageIndex = e.NewPageIndex;
            dgvFavoritos.DataSource = Session["listaArticulos"];
            dgvFavoritos.DataBind();
        }


        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idArticulo = Convert.ToInt32(btn.CommandArgument);
                int IdUser = ((Usuario)Session["usuario"]).Id;

                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.EliminarFavorito(IdUser, idArticulo);

                Session["FavoritosList"] = usuarioNegocio.ObtenerFavoritos(IdUser);
                BindFavoritos();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

    }
}