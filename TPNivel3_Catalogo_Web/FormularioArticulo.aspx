<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TPNivel3_Catalogo_Web.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .img-fixed-size {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 100%;
            height: auto;
            max-width: 350px;
            max-height: 350px;
            object-fit: contain;
        }



        .d-flex {
            display: flex;
            justify-content: center;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h1>Formulario del Articulo</h1>

    <div class="row">
        <div class="col-6 text-center">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"  />
                <asp:Label ID="lblErrorNombre" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"  />
                <asp:Label ID="lblErrorCodigo" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:Label ID="lblErrorPrecio" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server">  </asp:DropDownList>
                <asp:Label ID="lblErrorMarca" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria:</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"> </asp:DropDownList>
                <asp:Label ID="lblErrorCategoria" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
            <br />
            <div class="mb-3 d-flex">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-secondary me-4" OnClick="btnAceptar_Click" runat="server" />
                <a href="ListaArticulos.aspx" class="btn btn-secondary me-4">Cancelar</a>
                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-secondary me-4" runat="server" />
            </div>
        </div>

        <div class="col-6 text-center">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                <asp:Label ID="lblErrorDescripcion" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                        <asp:Label ID="lblErrorImagenUrl" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    </div>

                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgArticulo" CssClass="img-fixed-size" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3 d-flex">
                        <% if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox ID="chkConfirmaEliminacion" runat="server" />
                            <label for="chkConfirmaEliminacion" class="me-3" style="margin-left: 3px;">Confirma Eliminacion</label>
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <% } %>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
