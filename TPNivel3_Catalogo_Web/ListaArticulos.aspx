<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPNivel3_Catalogo_Web.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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

    <h1>Lista de Artículos</h1>

    <div class="row">

        <div class="col-5">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>

        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                <label for="chkAvanzado" style="margin-left: 3px;">Filtro Avanzado</label>
            </div>
        </div>

        <%if (chkAvanzado.Checked)
            { %>
        <div class="row align-items-end">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione un campo" Value="Seleccione un campo" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Código" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCampo" runat="server" ControlToValidate="ddlCampo" ErrorMessage="Campo requerido." Display="None" ForeColor="Red" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        <asp:ListItem Text="Seleccione un criterio" Value="Seleccione un criterio" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCriterio" runat="server" ControlToValidate="ddlCriterio" ErrorMessage="Criterio requerido." Display="None" ForeColor="Red" />

                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" required=""/>
                    <asp:RequiredFieldValidator ID="rfvFiltro" runat="server" ControlToValidate="txtFiltroAvanzado" ErrorMessage="Filtro requerido." Display="None" ForeColor="Red" />

                </div>
            </div>
            <div class="col-3 d-flex align-items-end">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-secondary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>

        <asp:Label ID="lblErrorGeneral" runat="server" CssClass="text-danger" Style="visibility: hidden;"></asp:Label>

        <h5 id="lblMensaje" runat="server" class="text text-center" style="display: none; margin-top:3rem;"></h5>

        <%} %>
    </div>

    <br />
    <asp:GridView ID="dgvArticulos" CssClass="table table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="8">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar ✍" />
        </Columns>
    </asp:GridView>
    <style>
        .table th {
            background-color: #f8f9fa;
            background-color: cadetblue;
        }
    </style>
    <br />

    <a href="FormularioArticulo.aspx" class="btn btn-secondary">Agregar</a>

</asp:Content>
