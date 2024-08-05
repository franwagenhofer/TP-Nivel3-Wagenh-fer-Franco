using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPNivel3_Catalogo_Web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            lblErrorEmail.Visible = false;
            lblErrorPass.Visible = false;
            try
            {
                Usuario user = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                bool hayErrores = false;

                if (string.IsNullOrWhiteSpace(txtEmail.Text) || !EmailValido(txtEmail.Text))
                {
                    lblErrorEmail.Text = "Por favor, ingrese un email válido.";
                    lblErrorEmail.Visible = true;
                    hayErrores = true;
                }
                else if (usuarioNegocio.EmailYaRegistrado(txtEmail.Text))
                {
                    lblErrorEmail.Text = "Este email ya está registrado.";
                    lblErrorEmail.Visible = true;
                    hayErrores = true;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 4)
                {
                    lblErrorPass.Text = "Por favor, ingrese una contraseña de al menos 4 caracteres.";
                    lblErrorPass.Visible = true;
                    hayErrores = true;
                }

                if (hayErrores)
                {
                    return;
                }

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = usuarioNegocio.insertarNuevo(user);
                Session.Add("usuario", user);

                // Configuracion para Outlook/Hotmail
                //var emailService = new EmailService("IngresarEmail@Outlook/hotmail.com", "IngresarContraseña");                
                emailService.armarCorreo(user.Email, "Bienvenido a nuestra aplicación", "Hola, te damos la bienvenida a la aplicación...");

                try
                {
                    //emailService.enviarEmail();
                    Response.Redirect("MiPerfil.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", "Error al enviar el correo: " + ex.Message);
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        private bool EmailValido(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}