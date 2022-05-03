
<%@ Page Title="" Language="C#" MasterPageFile="~/waSS.Master" AutoEventWireup="true" CodeBehind="MntCita.aspx.cs" Inherits="waSGDA.Frm.MntCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <title>Essalud - Cita</title> 

    <script type="text/javascript">
        function ConfirmarEliminacion() {
            return confirm("¿Desea eliminar el registro?");
        }

        function ConfirmarCancelacion() {
            return confirm("¿Realmente desea cancelar el proceso? Los datos ingresados se limpiarán");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="../Ds/Dashboard.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Citas médicas</li>
        </ol>
    </nav>

    <asp:UpdatePanel ID="upCita" runat="server">
        <ContentTemplate>
            <div class="row pb-3">
                <div class="col-sm-6 col-md-8">
                    <label class="form-label text-info">Cualquier duda o consulta con sus citas registradas, no dude en comunicarse con nosotros</label>
                </div>
                <div class="col-sm-6 col-md-4 text-right">
                    <asp:HiddenField ID="hdfAccionCM" runat="server" />
                    <asp:Button ID="btnNuevaCita" ClientIDMode="Static" CausesValidation="false" runat="server" Text="Nueva Cita" CssClass="btn btn-info btn-sm" OnClick="btnNuevaCita_Click" />
                    <asp:Button ID="btnGrabarCita" ClientIDMode="Static" CausesValidation="false" runat="server" Text="Grabar" CssClass="btn btn-primary btn-sm" OnClick="btnGrabarCita_Click" />
                    <asp:Button ID="btnCancelarCita" ClientIDMode="Static" CausesValidation="false" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-sm" OnClick="btnCancelarCita_Click" OnClientClick="return ConfirmarCancelacion();" />
                </div>
            </div>

            <div class="row">
                <div class="col-12">
                    <div class="card mb-grid">
                        <div class="card-header" runat="server" visible="false">                                
                            <div class="row">
                                <ul class="nav nav-pills card-header-pills" role="tablist">
                                    <li class="nav-item">
                                        <a runat="server" class="nav-link disabled" id="Tab01_FD" data-toggle="tab" href="#Contenido01_CM" role="tab" aria-controls="Contenido01_CM" aria-selected="true">Citas médicas</a>
                                    </li>
                                    <li class="nav-item">
                                        <a runat="server" class="nav-link disabled" id="Tab02_FD" data-toggle="tab" href="#Contenido02_CM" role="tab" aria-controls="Contenido02_CM" aria-selected="false">Administración de cita mádica</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="card-body table-responsive">
                            <div class="tab-content">
                                <%-- Lista de citas --%>
                                <div runat="server" class="tab-pane fade AuxSGDA" id="Contenido01_CM" role="tabpanel" aria-labelledby="Tab01_CM">
                                    <table class="table table-bordered mb-0 mt-3">
                                        <thead>
                                            <tr class="text-center table-active">
                                                <th scope="col">Código</th>
                                                <th scope="col">Descripción</th>
                                                <th scope="col">Tipo</th>
                                                <th scope="col">Fecha</th>
                                                <th scope="col">Médico</th>
                                                <th scope="col">Especialidad</th>
                                                <th scope="col">Estado</th>
                                                <th scope="col">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpCitas" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("iCodCita") %>'></asp:Label></td>
                                                        <td><%# Eval("vDescrCita") %></td>
                                                        <td><%# Eval("vTipoCita") %></td>
                                                        <td><%# Eval("cFechaCita") %></td>
                                                        <td><%# Eval("vNombreMedico") %></td>
                                                        <td><%# Eval("vEspecialidad") %></td>
                                                        <td class='<%# Eval("cEstiladoEstado") %>'><%# Eval("cEstado") %></td>
                                                        <td class="text-center">    
                                                            <img id="imgEditar" class="CurPoi" src="../img/icon/edit_24x24.png" alt="Editar" title="Editar" />
                                                            <img id="imgEliminar" class="CurPoi" src="../img/icon/delete_24x24.png" alt="Eliminar" title="Eliminar" />
                                                            <img id='imgResultado' class="CurPoi" src="../img/icon/search_24x24.png" alt="Ver resultado" title="Ver resultado" data-toggle="modal" data-target='<%# "#MD" + Eval("iCodCita") %>' "#exampleModalCenter" <%# Eval("cEstiloReceta") %> >
                                                            <a href='<%# "../Frm/ExClinicos.aspx?iCC=" + Eval("iCodCita") %>' >
                                                                <img id="imgExClinico" class="CurPoi" src="../img/icon/result-24.png" alt="Ver exámenes clínicos" title="Ver exámenes clínicos" />
                                                            </a>
                                                        </td>                                                        
                                                    </tr>

                                                    <div class="modal fade" id='<%# "MD" + Eval("iCodCita") %>' tabindex="-1" role="dialog" aria-labelledby='<%# "MD" + Eval("iCodCita") %>' aria-hidden="true">
                                                        <div class="modal-dialog modal-dialog-centered" role="document">
                                                            <div class="modal-content">
                                                                <div class="modal-header">
                                                                    <h5 class="modal-title" id="exampleModalLongTitle"><%# "Cita " + Eval("iCodCita") %></h5>
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">&times;</span>
                                                                    </button>
                                                                </div>
                                                                <div class="modal-body p-3">
                                                                    <p class="font-weight-bold">Resultado de la cita</p>
                                                                    <p><%# Eval("vObservaciones") %></p>
                                                                    <hr />
                                                                    <p class="font-weight-bold">Receta válida del <%# Eval("cFechaInicio") %> al <%# Eval("cFechaFin") %></p>
                                                                    <p><%# Eval("vDescrReceta") %></p>
                                                                </div>
                                                                <div class="modal-footer">
                                                                    <button type="button" class="btn btn-secondary btn-sm" data-dismiss="modal">Cerrar</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <div class="card-footer d-flex">
                                                <asp:Label ID="lblRegistros" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="card-footer d-flex justify-content-end">
                                                <ul class="pagination pagination-clean pagination-sm mb-0">
                                                    <asp:Repeater ID="rpPaginado" runat="server" OnItemCommand="rpPaginado_ItemCommand">
                                                        <HeaderTemplate></HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li class='<%# "page-item " + Eval("Estilo") %>'>
                                                                <asp:LinkButton ID="lbPag" runat="server" CssClass="page-link" CommandName="Pag" CommandArgument='<%# Eval("Url") %>'><%#Eval("Valor") %></asp:LinkButton>
                                                            </li>
                                                        </ItemTemplate>
                                                        <FooterTemplate></FooterTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- Administración de cita mádica --%>
                                <div runat="server" class="tab-pane fade AuxSGDA" id="Contenido02_CM" role="tabpanel" aria-labelledby="Tab02_CM">
                                    <asp:HiddenField ID="hdfCodigoCM" runat="server" />
                                    <div class="form-row">
                                        <div class="form-group col-3">
                                            <label for="txtFecha" class="form-label">Fecha</label>
                                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control cFechaAux"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-3">
                                            <label for="ddlSucursal" class="form-label">Sucursal</label>
                                            <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0" Text="SELECCIONE" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="MAGDALENA"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="SAN BORJA"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="SAN ISIDRO"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="SAN MIGUEL"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-3">
                                            <label for="ddlEspecialidad" class="form-label">Especialidad</label>
                                            <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-3">
                                            <label for="ddlMedico" class="form-label">Médico</label>
                                            <asp:DropDownList ID="ddlMedico" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-row" runat="server" id="dvInfo">
                                        <div class="col-12">
                                            <div class="alert alert-info" role="alert">
                                                <asp:Label ID="lblInfoCalificacion" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-12">
                                            <label for="txtMotivo" class="form-label">Motivo</label>
                                            <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>             
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlEspecialidad" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlMedico" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">
    <script type="text/javascript">
        function Inicio() {
            $(function () {
                var idPadre = $('.sidebar-nav-link[href="../Frm/MntCita.aspx"]').closest('ul').attr('id');
                $('.sidebar-nav-link[href="../Frm/MntCita.aspx"]').addClass('active');            
                $('.sidebar-nav-link[href="../Frm/MntCita.aspx"]').closest('ul').addClass('show');
                $('.sidebar-nav-link[href="#' + idPadre + '"]').removeClass('collapsed');
            });
        }        

        $(document).ready(Inicio);

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
