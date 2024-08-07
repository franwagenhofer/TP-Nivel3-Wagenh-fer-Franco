using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPNivel3_Catalogo_Web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        txtId.Text = user.Id.ToString();
                        txtId.ReadOnly = true;
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Imagenes/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (txtNombre.Text.Length < 3 || txtNombre.Text.Length > 15)
                {
                    if (txtNombre.Text.Length < 3)
                    {
                        lblErrorNombre.Text = "El nombre debe tener al menos 3 caracteres.";
                    }
                    else
                    {
                        lblErrorNombre.Text = "El nombre no puede tener más de 15 caracteres.";
                    }
                    lblErrorNombre.Visible = true;
                    return;
                }

                if (txtApellido.Text.Length > 30)
                {
                    lblErrorApellido.Text = "El apellido no puede tener más de 30 caracteres.";
                    lblErrorApellido.Visible = true;
                    return;
                }


                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["usuario"];

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;
                img.ImageUrl = user.ImagenPerfil;


                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}