using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPNivel3_Catalogo_Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is About ||Page is Registro || Page is DetalleArticulos || Page is Error))
            {
                if (Page is Default)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        lblUser.Text = user.Nombre;

                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        {
                            imgAvatar.ImageUrl = "~/Imagenes/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        }
                    }
                }
                else
                {
                    if (!Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                    else
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        lblUser.Text = user.Nombre;

                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        {
                            imgAvatar.ImageUrl = "~/Imagenes/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        }
                    }
                }
            }
            else
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario user = (Usuario)Session["usuario"];
                    lblUser.Text = user.Nombre;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/Imagenes/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}