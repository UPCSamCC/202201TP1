<%@ Page Title="" Language="C#" MasterPageFile="~/waSS.Master" AutoEventWireup="true" CodeBehind="RegCampana.aspx.cs" Inherits="waSGDA.Frm.RegCampana" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <title>Essalud - Campaña</title> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="../Ds/Dashboard.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Campaña</li>
        </ol>
    </nav>

    <div class="pb-3">
        <h1>Registro de campaña</h1>
    </div>

    <div class="row">
        <div class="col-12"><asp:Image ID="imgCampana" runat="server" /></div>        
    </div>

    <div class="row pt-3">
        <h6 class="col-12">
            <asp:Label ID="lblDatosCampana" runat="server"></asp:Label>
        </h6>
    </div>

    <div class="row pt-3" runat="server" id="dvRegistro">
        <div class="col-2">
            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control cFechaAux"></asp:TextBox>
        </div>
        <div class="col-2">
            <asp:HiddenField ID="hfCodCampana" runat="server" />
            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary form-control" Text="Registrar en Campaña" OnClick="btnRegistrar_Click" />
        </div>        
    </div>

    <div class="row pt-3" runat="server" id="dvExito">
        <div class="col-6">
            <div class="alert alert-success" role="alert">
                Gracias por registrarte en nuestra campaña. Serás redigirido al Inicio en 5 seg.
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">
    <script type="text/javascript">
        flatpickr(".cFechaAux", {
            enableTime: false,
            minDate: new Date().fp_incr(1),
            dateFormat: "d/m/Y",
            "disable": [
                function (date) {
                    return (date.getDay() === 0);
                }
            ],
            "locale": {
                "firstDayOfWeek": 1
            }
        });
    </script>
</asp:Content>
