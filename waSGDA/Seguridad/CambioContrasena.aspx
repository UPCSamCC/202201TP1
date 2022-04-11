<%@ Page Title="" Language="C#" MasterPageFile="~/Seguridad/Seg.Master" AutoEventWireup="true" CodeBehind="CambioContrasena.aspx.cs" Inherits="waSGDA.Seguridad.CambioContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="card mb-0">
        <div class="card-header text-center">
            <h5>Cambio de contraseña</h5>
        </div>
        <div class="card-body">
            <form id="frmCambio" runat="server" defaultbutton="btnCambiar">
                <div class="form-group">
                    <label for="txtContrasena01" class="form-label">Nueva contraseña</label>
                    <asp:TextBox ID="txtContrasena01" runat="server" CssClass="form-control" placeholder="Ingrese nueva contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="form-group mb-4">
                    <label for="txtContrasena02" class="form-label">Confirmar contraseña</label>
                    <asp:TextBox ID="txtContrasena02" runat="server" CssClass="form-control" placeholder="Confirme nueva contraseña" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <asp:HiddenField ID="hdfNewID" runat="server" />
                <asp:HiddenField ID="hdfSistema" runat="server" />
                <asp:HiddenField ID="hdfCodigoUsuario" runat="server" />

                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" CssClass="btn btn-sm btn-block btn-primary" OnClick="btnCambiar_Click" />
            </form>
        </div>
        <div class="card-footer text-secondary">
            <ul>
                <li>La contraseña debe cumplir los <a href="#ModalRequisitos" data-toggle="modal" data-target="#ModalRequisitos">requisitos mínimos</a> de seguridad</li>
            </ul>
        </div>
    </div>

    <%-- Ventana modal --%>
    <div class="modal fade" id="ModalRequisitos" tabindex="-1" role="dialog" aria-labelledby="ModalRequisitosTitulo" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalRequisitosTitulo">Requisitos mínimos de seguridad</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <ul>
                        <li>Longitud mínima, 8 caracteres</li>
                        <li>No utilizar las últimas 4 contraseñas</li>
                        <li>No debe contener tu nombre, apellidos o nombre de usuario Windows</li>
                        <li>Se debe incluir 3 de los siguientes 4 tipos de caracteres</li>                        
                        <ul>
                            <li>Una letra mayúscula</li>
                            <li>Una letra minúscula</li>
                            <li>Un número (0-9)</li>
                            <li>Un caracter especial ($, #, %)</li>
                        </ul>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
