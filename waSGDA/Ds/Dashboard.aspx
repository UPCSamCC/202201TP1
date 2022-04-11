<%@ Page Title="" Language="C#" MasterPageFile="~/waSS.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="waSGDA.Forms.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <title>SGDA - Inicio</title>

    <script type="text/javascript">
 
    </script>   
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
       <div class="adminx-sidebar expand-hover push">
           <ul class="sidebar-nav">
               <li class="sidebar-nav-item">
                   <a href="Dashboard.aspx" class="sidebar-nav-link active">
                       <span class="sidebar-nav-icon">
                           <i data-feather="home"></i>
                       </span>
                       <span class="sidebar-nav-name">Dashboard</span>
                       <span class="sidebar-nav-end"></span>
                   </a>
               </li>

               <li class="sidebar-nav-item">
                   <a class="sidebar-nav-link collapsed" data-toggle="collapse" href="#navUI" aria-expanded="false" aria-controls="navUI">
                       <span class="sidebar-nav-icon">
                           <i data-feather="grid"></i>
                       </span>
                       <span class="sidebar-nav-name">A su servicio</span>
                       <span class="sidebar-nav-end">
                           <i data-feather="chevron-right" class="nav-collapse-icon"></i>
                       </span>
                   </a>

                   <ul class="sidebar-sub-nav collapse" id="navUI">
                       <li class="sidebar-nav-item">
                           <a href="#" class="sidebar-nav-link">
                               <span class="sidebar-nav-abbr">Ca</span>
                               <span class="sidebar-nav-name">Campañas</span>
                           </a>
                       </li>

                       <li class="sidebar-nav-item">
                           <a href="#" class="sidebar-nav-link">
                               <span class="sidebar-nav-abbr">Ci</span>
                               <span class="sidebar-nav-name">Citas médicas</span>
                           </a>
                       </li>

                       <li class="sidebar-nav-item">
                           <a href="#" class="sidebar-nav-link">
                               <span class="sidebar-nav-abbr">La</span>
                               <span class="sidebar-nav-name">Laboratorio</span>
                           </a>
                       </li>

                       <li class="sidebar-nav-item">
                           <a href="#" class="sidebar-nav-link">
                               <span class="sidebar-nav-abbr">Me</span>
                               <span class="sidebar-nav-name">Medicamentos</span>
                           </a>
                       </li>

                       <li class="sidebar-nav-item">
                           <a href="#" class="sidebar-nav-link">
                               <span class="sidebar-nav-abbr">Re</span>
                               <span class="sidebar-nav-name">Resultados</span>
                           </a>
                       </li>
                   </ul>
               </li>
           </ul>
        </div>
    </div>

    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#largeModal"></button>

    <div class="modal fade" id="largeModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Campañas activas</h5>
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
