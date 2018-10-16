<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admAsignarV2.aspx.cs" Inherits="evaluacoinASP.Asignacion.admAsignarV2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="modal-header">
            <h4 class="modal-title" id="exampleModalLiveLabel">Detalle de asignación de evaluadores a centros de trabajo</h4>
        </div>
        <div class="modal-body">
            <div class="row">
                <div class="col-lg-12"><h4>Centro de trabajo</h4></div>
            </div>
            <div class="row">
                <div class="col-lg-2">Unidad Responsable:</div>
                <div class="col-lg-3"><asp:Label ID="lblUnidadResponsable" runat="server" Font-Bold="true"></asp:Label></div>
                <div class="col-lg-2">Área:</div>
                <div class="col-lg-3"><asp:Label ID="lblArea" runat="server" Font-Bold="true"></asp:Label></div>
                <div class="col-lg-2"><asp:Button ID="btnPersonalNoAutomatico" Text="Buscar personal"
                    runat="server" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">Municipio:</div>
                <div class="col-lg-3"><asp:Label ID="lblMunicipio" runat="server" Font-Bold="true"></asp:Label></div>
                <div class="col-lg-2">Centro de trabajo:</div>
                <div class="col-lg-3"><asp:Label ID="lblCentroTrabajo" runat="server" Font-Bold="true"></asp:Label></div>
            </div>        
        </div>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
            PopupControlID="pnlPopUp" TargetControlID="btnPersonalNoAutomatico"
            CancelControlID="btnCerrar" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlPopUp" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Búsqueda de personal para asignación como Evaluador</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-1">Búsqueda:</div>
                        <div class="col-lg-6"><asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>
                            
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCerrar" runat="server" CssClass="btn btn-secondary" Text="Cerrar" />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar cambios" />
                </div>
            </div>
        </asp:Panel>
        <asp:UpdatePanel ID="upAsignacion" runat="server">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>Evaluadores disponibles para el centro de trabajo</h4>
                    </div>
                    <div class="modal-content">
                        <div style="overflow-y:scroll;height:250px" >
                            <asp:Repeater ID="rptEvaluadoresPosibles" runat="server" OnItemCommand="rptEvaluadoresPosibles_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th style="text-align:center;">Empleado</th>
                                                <th style="text-align:center;">Nombre</th>
                                                <th style="text-align:center;">Puesto</th>
                                                <th style="text-align:center;">Inicio</th>
                                                <th style="text-align:center;">Fin</th>
                                                <th style="text-align:center;">Días</th>
                                                <th style="text-align:center">Agregar</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("CveEmpleado") %></td>
                                        <td><%#Eval("Nombre") %> <%#Eval("Paterno") %> <%#Eval("Materno") %></td>
                                        <td><%#Eval("DenominacionPlaza") %></td>
                                        <td><%#Eval("Inicio") %></td>
                                        <td><%#Eval("Fin") %></td>
                                        <td style="text-align:center;"><%#Eval("Dias") %></td>
                                        <td style="text-align:center;">
                                            <asp:ImageButton ID="imgChecked" runat="server" ImageUrl="~/Content/images/in.png" Height="30" Width="30"
                                                CommandName="seleccionado" CommandArgument='<%#Eval("IDGral") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                        </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="modal-header">
                        <h4>Evaluadores asignados al centro de trabajo</h4>
                    </div>
                    <div class="modal-content">
                        <div style="overflow-y:scroll;height:250px" >
                            <asp:Repeater ID="rptEvaluadoresAsignados" runat="server" OnItemCommand="rptEvaluadoresAsignados_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th style="text-align:center;">Empleado</th>
                                                <th style="text-align:center;">Nombre</th>
                                                <th style="text-align:center;">Puesto</th>
                                                <th style="text-align:center;">Inicio</th>
                                                <th style="text-align:center;">Fin</th>
                                                <th style="text-align:center;">Días</th>
                                                <th style="text-align:center">Selección</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("CveEmpleado") %></td>
                                        <td><%#Eval("Nombre") %> <%#Eval("Paterno") %> <%#Eval("Materno") %></td>
                                        <td><%#Eval("DenominacionPlaza") %></td>
                                        <td><%#Eval("Inicio") %></td>
                                        <td><%#Eval("Fin") %></td>
                                        <td style="text-align:center;"><%#Eval("Dias") %></td>
                                        <td style="text-align:center;">
                                            <asp:ImageButton ID="imgChecked" runat="server" ImageUrl="~/Content/images/out.png" Height="30" Width="30"
                                                CommandName="seleccionado" CommandArgument='<%#Eval("IDGral")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                        </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rptEvaluadoresPosibles" EventName="ItemCommand" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
