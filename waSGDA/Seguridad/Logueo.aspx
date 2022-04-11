<%@ Page Title="" Language="C#" MasterPageFile="~/Seguridad/Seg.Master" AutoEventWireup="true" CodeBehind="Logueo.aspx.cs" Inherits="waSGDA.Seguridad.Logueo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="card mb-0">
        <div class="card-header text-center">
            <h5>Ingreso al sistema</h5>
        </div>
        <div class="card-body">
            <form id="frmLogin" runat="server" defaultbutton="btnLogueo">
                <div class="form-group">
                    <label for="txtUsuario" class="form-label">Número de DNI</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="00000000" AutoCompleteType="Disabled" onkeypress="return isNumberKey(event)"></asp:TextBox>
                </div>
                <div class="form-group mb-4">
                    <label for="txtContrasena" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" placeholder="Ingrese contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <asp:Button ID="btnLogueo" runat="server" Text="Ingresar" CssClass="btn btn-sm btn-block btn-primary" OnClick="btnLogueo_Click" />
            </form>
        </div>
        <div class="card-footer text-center">
            <asp:Label ID="lblVersion" runat="server"></asp:Label>
            <a href="SolicitudContrasena.aspx"><small>¿Olvidó su contraseña?</small></a>
        </div>
    </div>
</asp:Content>
