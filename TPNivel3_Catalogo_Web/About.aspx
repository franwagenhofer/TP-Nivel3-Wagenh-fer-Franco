<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TPNivel3_Catalogo_Web.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .CajaTexto {
            text-align: center;
        }

        .CajaContactos {
            display: flex;
            /* gap: 40px; */ /* Espacio entre los contenedores principales */
            text-align: center;
        }

        .contacto {
            list-style-type: none;
            padding: 0;
            margin: 0;
            font-size: 18px;
        }

            .contacto li {
                margin-bottom: 10px; /* Espacio entre los elementos de la lista */
            }

            .contacto a {
                color: white;
                text-decoration: none; /* Elimina el subrayado de los enlaces */
            }

                .contacto a:hover {
                    color: cornflowerblue;
                }

        .h-tres {
            margin-bottom: 10px; /* Espacio entre el título y la lista */
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Sobre Nosotros</h1>

    <p class="CajaTexto">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore, enim! Vitae
                        <br>
        debitis quis commodi, adipisci molestias consequatur, placeat maxime ex possimus
                        <br>
        voluptates consectetur nesciunt? Doloribus laborum odio unde optio deleniti?
    </p>

    <br />
    <hr />
    <br />

    <div class="CajaTexto">

        <h3>Origen e Historia</h3>

        <div class="texto">
            <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore, enim! Vitae
                        <br>
                debitis quis commodi, adipisci molestias consequatur, placeat maxime ex possimus
                        <br>
                voluptates consectetur nesciunt? Doloribus laborum odio unde optio deleniti?
            </p>
            <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore, enim! Vitae
                        <br>
                debitis quis commodi, adipisci molestias consequatur, placeat maxime ex possimus
                        <br>
                voluptates consectetur nesciunt? Doloribus laborum odio unde optio deleniti?
            </p>
            <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore, enim! Vitae
                        <br>
                debitis quis commodi, adipisci molestias consequatur, placeat maxime ex possimus
                        <br>
                voluptates consectetur nesciunt? Doloribus laborum odio unde optio deleniti?
            </p>
            <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolore, enim! Vitae
                        <br>
                debitis quis commodi, adipisci molestias consequatur, placeat maxime ex possimus
                        <br>
                voluptates consectetur nesciunt? Doloribus laborum odio unde optio deleniti?
            </p>
        </div>
    </div>

    <br />
    <hr />
    <br />

    <div class="CajaContactos">
        <div class="col-6">
            <h3 class="h-tres">Contactos</h3>
            <ul class="contacto">
                <li>
                    <p>Email: Catalogo@Catalogo.com</p>
                </li>
                <li>
                    <p>Teléfono: +549 1155555555</p>
                </li>
            </ul>
        </div>
        <div class="col-6">
            <h3 class="h-tres">Redes Sociales</h3>
            <ul class="contacto">
                <li>
                    <a href="https://es-la.facebook.com" target="_blank">Facebook</a>
                </li>
                <li>
                    <a href="https://instagram.com" target="_blank">Instagram</a>
                </li>
                <li>
                    <a href="https://twitter.com" target="_blank">Twitter</a>
                </li>
                <li>
                    <a href="https://youtube.com" target="_blank">Youtube</a>
                </li>
            </ul>
        </div>
    </div>

</asp:Content>
