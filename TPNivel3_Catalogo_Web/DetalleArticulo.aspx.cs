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
    public partial class DetalleArticulos : System.Web.UI.Page
    {

        public List<Articulo> FavoritosList
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
                    int articuloId;
                    if (int.TryParse(Request.QueryString["id"], out articuloId))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();

                        List<Articulo> listaArticulos = negocio.listarArticulos();


                        Articulo articulo = listaArticulos.FirstOrDefault(a => a.Id == articuloId);

                        if (articulo != null)
                        {
                            List<Articulo> detalleArticulo = new List<Articulo> { articulo };
                            repArticuloDetalle.DataSource = detalleArticulo;
                            repArticuloDetalle.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);

            ArticuloNegocio negocio = new ArticuloNegocio();
            UsuarioNegocio favorito = new UsuarioNegocio();

            List<Articulo> listaArticulos = negocio.listarArticulos();

            Articulo articulo = listaArticulos.FirstOrDefault(a => a.Id == id);

            try
            {
                List<Articulo> FavoritosList = Session["FavoritosList"] as List<Articulo> ?? new List<Articulo>();

                if (articulo != null)
                {
                    if (!FavoritosList.Exists(a => a.Id == id))
                    {
                        FavoritosList.Add(articulo);
                        Session["FavoritosList"] = FavoritosList;

                        int IdUser = ((Usuario)Session["usuario"]).Id;

                        favorito.GuardarFavorito(IdUser, id);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);

            UsuarioNegocio favorito = new UsuarioNegocio();

            try
            {
                List<Articulo> FavoritosList = Session["FavoritosList"] as List<Articulo> ?? new List<Articulo>();

                if (FavoritosList.Exists(a => a.Id == id))
                {

                    FavoritosList.RemoveAll(a => a.Id == id);
                    Session["FavoritosList"] = FavoritosList;

                    int IdUser = ((Usuario)Session["usuario"]).Id;

                    favorito.EliminarFavorito(IdUser, id);
                }     
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }


        protected bool boolCambiarFavorito(int articuloId)
        {
            List<Articulo> favoritosList = Session["FavoritosList"] as List<Articulo> ?? new List<Articulo>();
            return favoritosList.Any(a => a.Id == articuloId);
        }

        protected void btnCambiarFavorito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int articuloId = Convert.ToInt32(btn.CommandArgument);
            try
            {
                if (boolCambiarFavorito(articuloId))
                {
                    btnEliminarFavorito_Click(btn, e);
                }
                else
                {
                    btnAgregarFavorito_Click(btn, e);
                }

                RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                Button btnFavorito = (Button)item.FindControl("btnCambiarFavorito");
                if (btnFavorito != null)
                {
                    btnFavorito.Text = boolCambiarFavorito(articuloId) ? "Eliminar" : "+Favoritos";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }



    }
}