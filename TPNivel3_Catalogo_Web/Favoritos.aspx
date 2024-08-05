<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPNivel3_Catalogo_Web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .card-img-top {
            width: 100%;
            height: 200px;
            object-fit: contain;
            margin-top: 10px;
        }

        .mt-2 {
            margin-top: 0.5rem;
            margin-bottom: 0.2rem;
        }

        .card-links {
            display: flex;
            justify-content: center;
            width: 100%;
        }

        .card-link {
            margin: 0.3rem;
            margin-top: 1rem;
        }


        .linea {
            margin: 0.5rem;
            margin-right: auto;
            margin-left: auto;
            width: 25%;
            opacity: .25;
        }

        .table {
            border-collapse: separate;
            border-spacing: 0;
            border-radius: 10px;
            overflow: hidden;
        }

            .table th, .table td {
                text-align: center;
                padding: 10px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mis Favoritos</h1>

    <br />

    <div class="row  row-cols-md-4 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col mb-4">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title text-center"><%#Eval("Nombre") %></h5>
                            <p class="card-text text-center"><%#Eval("Marca") %></p>
                            <hr class="linea">
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-secondary mt-2">Ver Detalle</a>
                            <asp:Button Text="Eliminar" ID="btnEliminarFavorito" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminarFavorito_Click" CssClass="btn btn-secondary mt-2" runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <br />
    <hr />

    <div>
        <br />
        <h3 class="text-center">Lista de Artículos Favoritos</h3>
        <br />
        <asp:GridView ID="dgvFavoritos" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
            AllowPaging="True" PageSize="8" OnPageIndexChanging="dgvFavoritos_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>
    </div>
    <style>
        .table th {
            background-color: cadetblue;
        }
    </style>

    <br />
    <hr />
    <br />

</asp:Content>
