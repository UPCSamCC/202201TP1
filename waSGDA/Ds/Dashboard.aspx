<%@ Page Title="" Language="C#" MasterPageFile="~/waSS.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="waSGDA.Forms.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <title>Essalud - Inicio</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="#">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
        </ol>
    </nav>

    <div class="pb-3">
        <h1>General</h1>
    </div>

    <div class="row">
        <div class="col-md-6 col-lg-3 d-flex">
            <div class="card border-0 bg-success text-white text-center mb-grid w-100">
                <div class="d-flex flex-row align-items-center h-100">
                    <div class="card-icon d-flex align-items-center h-100 justify-content-center">
                        <i data-feather="check-square"></i>
                    </div>
                    <div class="card-body">
                        <div class="card-info-title">Campañas asistidas</div>
                        <h3 class="card-title mb-0"><%= iCitasAsistidas %></h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <div class="row mb-grid">
        <asp:Repeater ID="rpCitas" runat="server">
            <ItemTemplate>
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-header">Cita registrada</div>
                        <div class="card-body">
                            <h4 class="card-title"><%# Eval("vNombreCampana") %></h4>
                            <p class="card-text"><%# Eval("sTextoCita") %></p>
                            <a href="#" class="btn btn-primary">Cambiar fecha</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="row">
        <asp:Repeater ID="rpPlanesA" runat="server">
            <ItemTemplate>
                <div class="col-lg-3">
                    <div class="card">
                        <img class="card-img-top" src='<%# "../img/Die/" + Eval("vImagen") %>'  alt='<%# Eval("vTitulo") %>' title='<%# Eval("vTitulo") %>'>
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("vTitulo") %></h5>
                            <p class="card-text"><%# Eval("vResumen") %></p>
                            <a href="#" class="btn btn-primary">Leer completo</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#largeModal"></button>

    <div class="modal fade" id="largeModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Campaña - Para inscribirse, presione la imagen</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <!-- carousel -->
                    <div id='carouselExampleIndicators' class='carousel slide' data-ride='carousel'>
                        <ol class='carousel-indicators' runat="server" id="olOpc"></ol>
                        <div class='carousel-inner' runat="server" id="divImgSlider"></div>
                        <a class='carousel-control-prev' href='#carouselExampleIndicators' role='button' data-slide='prev'>
                            <span class='carousel-control-prev-icon' aria-hidden='true'></span>
                            <span class='sr-only'>Previous</span>
                        </a>
                        <a class='carousel-control-next' href='#carouselExampleIndicators' role='button' data-slide='next'>
                            <span class='carousel-control-next-icon' aria-hidden='true'></span>
                            <span class='sr-only'>Next</span>
                        </a>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">
    <script>
        $(document).ready(function () {
            $('.sidebar-nav-link[href="../Ds/Dashboard.aspx"]').addClass('active')
        });

        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
</asp:Content>
