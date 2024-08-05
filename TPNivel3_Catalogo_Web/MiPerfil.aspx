<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPNivel3_Catalogo_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mi Perfil</h1>

    <div class="container text-center">
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label class="form-label">Nro. de Id </label>
                    <asp:TextBox runat="server" CssClass="form-control non-editable" ReadOnly="true" ID="txtId" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" MaxLength="15" required="" />
                    <asp:Label ID="lblErrorNombre" runat="server" CssClass="text-danger" Visible="false"/>
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="30" required=""/>
                    <asp:Label ID="lblErrorApellido" runat="server" CssClass="text-danger" Visible="false"/>
                </div>
                <br />          
                <div class="mb-3">
                    <asp:Button Text="Guardar" CssClass="btn btn-secondary me-4" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="mb-3">
                    <label class="form-label">Imagen Perfil</label>
                    <asp:FileUpload ID="txtImagen" runat="server" CssClass="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                    runat="server" CssClass="img-fluid mb-3" />
            </div>
        </div>
    </div>

</asp:Content>