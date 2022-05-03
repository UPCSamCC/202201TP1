<%@ Page Title="" Language="C#" MasterPageFile="~/waSS.Master" AutoEventWireup="true" CodeBehind="ExClinicos.aspx.cs" Inherits="waSGDA.Frm.ExClinicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <title>Essalud - Exámenes Clínicos</title> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb adminx-page-breadcrumb">
            <li class="breadcrumb-item"><a href="../Ds/Dashboard.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">Exámenes clínicos</li>
        </ol>
    </nav>

    <asp:UpdatePanel ID="upDiagnostico" runat="server">
        <ContentTemplate>
            <div class="row pb-3">
                <div class="col-sm-6 col-md-8">
                    <label class="form-label text-info">Listado de todos los exámenes clínicos realizados con Essalud</label>
                </div>
                <div class="col-sm-6 col-md-4 text-right">
                    <asp:Button ID="btnExportar" ClientIDMode="Static" CausesValidation="false" runat="server" Text="Exportar" CssClass="btn btn-info btn-sm" OnClick="btnExportar_Click" />
                </div>
            </div>

            <div class="form-row pb-2">
                <div class="col-md-12">
                    <div id="divMsj" runat="server" role="alert"></div>
                </div>
            </div>

            <div class="row">
                <div class="col-12">
                    <div class="card mb-grid">
                        <div class="card-body table-responsive">
                            <div class="tab-content">
                                <div runat="server" class="tab-pane fade show active" id="Contenido01_CM" role="tabpanel" aria-labelledby="Tab01_CM">
                                    <div class="form-group row">
                                        <label for="ddlCitas" class="col-sm-1 col-form-label">Cita relacionada</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlCitas" CssClass="form-control form-control-sm" runat="server" OnSelectedIndexChanged="ddlCitas_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <table class="table table-bordered mb-0 mt-3">
                                        <thead>
                                            <tr class="text-center table-active">
                                                <th scope="col">Código</th>
                                                <th scope="col">Descripción</th>
                                                <th scope="col">Tipo</th>
                                                <th scope="col">Fecha</th>
                                                <th scope="col">Médico</th>
                                                <th scope="col">Especialidad</th>
                                                <th scope="col">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpExMedicos" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("iCodDiagnostico") %>'></asp:Label></td>
                                                        <td><%# Eval("vDescrDiagnostico") %></td>
                                                        <td><%# Eval("iTipoDiagnostico") %></td>
                                                        <td><%# Eval("cFechaDiagnostico") %></td>
                                                        <td><%# Eval("vNombreMedico") %></td>
                                                        <td><%# Eval("vNombreEspecialidad") %></td>
                                                        <td class="text-center">
                                                            <a href='<%# "../doc/" + Eval("vResultado") %>' download>
                                                                <img id='imgResultado' class="CurPoi" src="../img/icon/search_24x24.png" alt="Ver resultado" title="Ver resultado">
                                                                <asp:ImageButton ID="btnEnviarMail" runat="server" ImageUrl="~/img/icon/email-24.png" ToolTip="Compartir" CssClass="align-middle" OnClick="btnEnviarMail_Click" />
                                                            </a>
                                                        </td>                                                        
                                                    </tr>
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCitas" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScripts" runat="server">
    <script type="text/javascript">
        function Inicio() {
            $(function () {
                var idPadre = $('.sidebar-nav-link[href="../Frm/ExClinicos.aspx"]').closest('ul').attr('id');
                $('.sidebar-nav-link[href="../Frm/ExClinicos.aspx"]').addClass('active');            
                $('.sidebar-nav-link[href="../Frm/ExClinicos.aspx"]').closest('ul').addClass('show');
                $('.sidebar-nav-link[href="#' + idPadre + '"]').removeClass('collapsed');
            });
        }        

        $(document).ready(Inicio);       
    </script>
</asp:Content>
