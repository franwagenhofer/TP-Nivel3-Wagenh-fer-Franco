using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace TPNivel3_Catalogo_Web
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio negocio1 = new MarcaNegocio();
                    List<Marca> lista1 = negocio1.listar();
                    CategoriaNegocio negocio2 = new CategoriaNegocio();
                    List<Categoria> lista2 = negocio2.listar();

                    lista1.Insert(0, new Marca { Id = 0, Descripcion = "Seleccione una marca" });
                    lista2.Insert(0, new Categoria { Id = 0, Descripcion = "Seleccione una categoría" });


                    ddlMarca.DataSource = lista1;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = lista2;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (!string.IsNullOrEmpty(id))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo seleccionado = (negocio.listarParaModificar(id))[0];

                        Session.Add("articuloSeleccionado", seleccionado);

                        txtId.Text = id;
                        txtCodigo.Text = seleccionado.Codigo.ToString();
                        txtNombre.Text = seleccionado.Nombre;
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtImagenUrl.Text = seleccionado.ImagenUrl;
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        txtImagenUrl_TextChanged(sender, e);


                        btnEliminar.Visible = true; 
                    }
                    else
                    {
                        btnEliminar.Visible = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            lblErrorNombre.Visible = false;
            lblErrorCodigo.Visible = false;
            lblErrorPrecio.Visible = false;
            lblErrorImagenUrl.Visible = false;
            lblErrorMarca.Visible = false;
            lblErrorCategoria.Visible = false;


            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                bool hayErrores = false;

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
                {
                    lblErrorPrecio.Text = "Por favor, ingrese un precio válido.";
                    lblErrorPrecio.Visible = true;
                    hayErrores = true;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblErrorNombre.Text = "El nombre es obligatorio.";
                    lblErrorNombre.Visible = true;
                    hayErrores = true;
                }

                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    lblErrorCodigo.Text = "El código es obligatorio.";
                    lblErrorCodigo.Visible = true;
                    hayErrores = true;
                }

                if (string.IsNullOrWhiteSpace(txtImagenUrl.Text) || !Uri.IsWellFormedUriString(txtImagenUrl.Text, UriKind.Absolute))
                {
                    lblErrorImagenUrl.Text = "Por favor, ingrese una URL de imagen válida.";
                    lblErrorImagenUrl.Visible = true;
                    hayErrores = true;
                }

                if (ddlMarca.SelectedValue == "0")
                {
                    lblErrorMarca.Text = "Por favor, seleccione una marca.";
                    lblErrorMarca.Visible = true;
                    hayErrores = true;
                }

                if (ddlCategoria.SelectedValue == "0")
                {
                    lblErrorCategoria.Text = "Por favor, seleccione una categoría.";
                    lblErrorCategoria.Visible = true;
                    hayErrores = true;
                }

                if (hayErrores)
                {
                    return;
                }

                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Precio = precio;
                //nuevo.Precio = decimal.Parse(txtPrecio.Text);
              
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);           
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
                    negocio.agregarConSP(nuevo);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx", false);

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