<%@ Page Title="" Language="C#" MasterPageFile="~/Seguridad/Seg.Master" AutoEventWireup="true" CodeBehind="SolicitudContrasena.aspx.cs" Inherits="waSGDA.Seguridad.SolicitudContrasena" %>

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
    <form id="frmSolicitud" runat="server" defaultbutton="btnSolicitar">
        <div class="card mb-0">
            <div class="card-header text-center">
                <h5>Solicitud de reinicio de contraseña</h5>
            </div>
            <div class="card-body">
                <div class="form-group mb-4">
                    <label for="txtUsuario" class="form-label">Número de DNI</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="00000000" AutoCompleteType="Disabled" onkeypress="return isNumberKey(event)"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtCorreo" class="form-label">Correo personal</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="xxxxxxxx@yyyyyy.zz" TextMode="Email" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer text-danger">
                <asp:Button ID="btnSolicitar" runat="server" Text="Solicitar" CssClass="btn btn-sm btn-block btn-primary" OnClick="btnSolicitar_Click" />
            </div>
        </div>
    </form>
</asp:Content>
