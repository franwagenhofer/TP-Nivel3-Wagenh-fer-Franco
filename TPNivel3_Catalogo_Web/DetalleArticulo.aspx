<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPNivel3_Catalogo_Web.DetalleArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .card {
            max-width: 1000px;
            margin: auto; 

            width: 100%;
            height: 450px;
            display: flex;
            flex-direction: column;
        }

        .card-img-top {
            margin-top: 10px;
            height: 420px;
            object-fit: contain;
            max-height: 100%; 
            max-width: 100%;
        }


        .card-body {
            height: 100%;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center; 
            flex: 1; 
            justify-content: space-evenly;
        }


        .row {
            height: 100%;
        }

        .list-group-item {
            width: 100%;
            text-align: center; 
        }

        .card-links {
            display: flex;
            justify-content: center;
            width: 100%;
        }

        .card-link {
            margin: 10px 10px;
        }

            .card-link:hover {
                color: darkorchid;
            }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Detalle del Artículo Seleccionado</h1>

    <br />

    <asp:Repeater ID="repArticuloDetalle" runat="server">
        <ItemTemplate>
            <div class="card">
                <div class="row no-gutters">
                    <div class="col-md-6">
                        <img src="<%# Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><%# Eval("Categoria") %></li>
                                <li class="list-group-item"><%# Eval("Marca") %></li>
                                <li class="list-group-item">$ <%# Eval("Precio") %></li>
                            </ul>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <div class="card-links">
                                <% if (negocio.Seguridad.sesionActiva(Session["usuario"]))
                                    { %>
                                <asp:Button ID="btnCambiarFavorito" runat="server"
                                    Text='<%# boolCambiarFavorito(Convert.ToInt32(Eval("Id"))) ? "Eliminar" : "+Favoritos" %>'
                                    CssClass='<%# boolCambiarFavorito(Convert.ToInt32(Eval("Id"))) ? "card-link btn btn-secondary" : "card-link btn btn-secondary" %>'
                                    CommandArgument='<%# Eval("Id") %>'
                                    OnClick="btnCambiarFavorito_Click" />
                                <a href="Favoritos.aspx?" class="card-link btn btn-secondary">Mis Favoritos</a>
                                <%  } %>
                                <a href="Default.aspx" class="card-link btn btn-secondary">Catalogo</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
