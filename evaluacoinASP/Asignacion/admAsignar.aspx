<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admAsignar.aspx.cs" Inherits="evaluacoinASP.Asignacion.admAsignar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="pnlModificacionAsignacion" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="modal-header">
                    <h4 class="modal-title" id="exampleModalLiveLabel">Detalle de asignación de evaluadores a centros de trabajo</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-2">Unidad Responsable:</div>
                        <div class="col-lg-4"><asp:Label ID="lblUnidadResponsable" runat="server" Font-Bold="true"></asp:Label></div>
                        <div class="col-lg-2">Área:</div>
                        <div class="col-lg-4"><asp:Label ID="lblArea" runat="server" Font-Bold="true"></asp:Label></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-2">Municipio:</div>
                        <div class="col-lg-4"><asp:Label ID="lblMunicipio" runat="server" Font-Bold="true"></asp:Label></div>
                        <div class="col-lg-2">Centro de trabajo:</div>
                        <div class="col-lg-4"><asp:Label ID="lblCentroTrabajo" runat="server" Font-Bold="true"></asp:Label></div>
                    </div>                        
                    <div class="row">
                        <div class="controls radio col-lg-12">
                            <asp:RadioButtonList ID="rbList" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CellSpacing="20"
                                OnSelectedIndexChanged="rbList_SelectedIndexChanged" RepeatLayout="Flow">
                                <asp:ListItem Value="0" class="radio-inline" Text="Asignación por jerarquía"></asp:ListItem>
                                <asp:ListItem Value="1" class="radio-inline" Text="Asignación por función"></asp:ListItem>
                                <asp:ListItem Value="2" class="radio-inline" Text="Asignación manual"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <asp:Panel ID="pnlJerarquia" runat="server" Visible="false">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4>Evaluadores disponibles para el centro de trabajo</h4>
                            </div>
                            <div class="modal-content">
                                <div style="overflow-y:scroll;height:300px" >
                                    <asp:Repeater ID="rptEvaluadoresPosibles" runat="server" OnItemCommand="rptEvaluadoresPosibles_ItemCommand"
                                        OnItemDataBound="rptEvaluadoresPosibles_ItemDataBound">
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
                                                <td><%#Eval("InfoEmpleado.Cve") %></td>
                                                <td><%#Eval("InfoEmpleado.NombreEmpleado") %></td>
                                                <td><%#Eval("Asignaciones[0].InfoFuncionEvaluadora.DenominacionCompleto") %></td>
                                                <td><%#Eval("Asignaciones[0].Inicio") %></td>
                                                <td><%#Eval("Asignaciones[0].Fin") %></td>
                                                <td style="text-align:center;"><%#Eval("Asignaciones[0].Dias") %></td>
                                                <td style="text-align:center;">
                                                    <asp:ImageButton ID="imgChecked" runat="server" ImageUrl="~/Content/images/checked.png"
                                                        CommandName="seleccionado" CommandArgument='<%#Eval("InfoEmpleado.Cve") + "-" + Eval("Asignaciones[0].Dias")%>' />
                                                    <asp:ImageButton ID="imgNoCheked" runat="server" ImageUrl="~/Content/images/no_checked.png" 
                                                        CommandName="noSeleccionado" CommandArgument='<%#Eval("InfoEmpleado.Cve") + "-" + Eval("Asignaciones[0].Dias")%>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                                </tbody>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="row">
                                    <div class="col-lg-8">
                                       Total de días: <asp:Label ID="lblTotalDias" runat="server" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlFuncion" runat="server" Visible="false">

                    </asp:Panel>
                    <asp:Panel ID="pnlManual" runat="server" Visible="false">

                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" /><br />
                    <asp:Label ID="lblAvisoPop" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rbList" EventName="selectedindexchanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
