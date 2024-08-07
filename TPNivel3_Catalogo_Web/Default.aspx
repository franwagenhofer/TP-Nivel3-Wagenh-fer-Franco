<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPNivel3_Catalogo_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: contain;
            margin-top: 10px;
        }

        .mt-2 {
            margin-top: .5rem !important;
            margin-bottom: 1rem;
        }

        .hover-card {
            transition: transform 0.3s ease;
        }

            .hover-card:hover {
                transform: scale(1.05);
                z-index: 1; /* Para asegurarse de que la tarjeta se superponga a las demás */
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Bienvenido al Catálogo Web</h1>

    <%--<hr />--%>
    <br />

    <%--    <div class="row justify-content-center">
    </div>--%>
    <div class="col-4">
        <div class="mb-3">
            <asp:Label Text="Buscar artículo" CssClass="text-center" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
        </div>
    </div>

    <br />

    <h5 id="lblMensaje" runat="server" class="text text-center" style="display: none; margin-top: 3rem;"></h5>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col mb-4">
                    <div class="card h-100 hover-card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title text-center"><%#Eval("Nombre") %></h5>
                            <p class="card-text text-center"><%#Eval("Marca") %></p>
                            <div class="text-center">
                                <hr class="w-25 mx-auto">
                                <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-secondary mt-2">Ver Detalle</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
