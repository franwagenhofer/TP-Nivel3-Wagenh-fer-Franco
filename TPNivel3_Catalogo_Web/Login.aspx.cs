using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Text.RegularExpressions;

namespace TPNivel3_Catalogo_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrorEmail.Visible = false;
            lblErrorPass.Visible = false;
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                bool hayErrores = false;

                if (string.IsNullOrWhiteSpace(txtEmail.Text) || !EmailValido(txtEmail.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    {

                        lblErrorEmail.Text = "Por favor, ingrese un email válido.";
                        lblErrorEmail.Visible = true;
                        hayErrores = true;
                    }
                    else
                    {
                        lblErrorEmail.Text = "Email inválido. Intente nuevamente.";
                        lblErrorEmail.Visible = true;
                        hayErrores = true;
                    }
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 4)
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        lblErrorPass.Text = "Por favor, ingrese una contraseña válida.";
                        lblErrorPass.Visible = true;
                        hayErrores = true;
                    }
                    else
                    {
                        lblErrorPass.Text = "Contraseña invalida. Intente nuevamente.";
                        lblErrorPass.Visible = true;
                        hayErrores = true;
                    }
                }

                if (hayErrores)
                {
                    return;
                }


                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;

                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);

                    UsuarioNegocio favoritoNegocio = new UsuarioNegocio();
                    List<Articulo> favoritos = favoritoNegocio.ObtenerFavoritos(usuario.Id);
                    Session["FavoritosList"] = favoritos;

                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        private bool EmailValido(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}