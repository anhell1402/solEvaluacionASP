<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FuncEval.aspx.cs" Inherits="evaluacoinASP.Catal.FuncEval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Funciones evaluadoras</h2>
    <div style="overflow-y:scroll;height:400px;" >
        <asp:Repeater ID="rptFunciones" runat="server" OnItemCommand="rptFunciones_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <tr>
                        <th>Función</th>
                        <th>Denominación</th>
                        <th>Año</th>
                        <th>Nivel</th>
                        <th>Eliminar</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("IdFuncion") %></td>
                    <td><%# Eval("Denominacion") %></td>
                    <td><%# Eval("Anio") %></td>
                    <td><%# Eval("Nivel") %></td>
                    <td style="text-align:center;width:50px">
                        <asp:ImageButton ID="btnEliminar" runat="server" AlternateText="Eliminar" 
                            CommandName="eliminar" CommandArgument='<%#Eval("Id") %>'
                            OnClientClick="return confirm('¿Está seguro que desea eliminar la Función Evaluadora?');"
                            ImageUrl="~/Content/images/del.png" Height="30" Width="30" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="row">
        <div class="col-lg-3">
            <asp:Label ID="lblAviso" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" />
        </div>
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackgrounds"
        TargetControlID="btnNuevo" PopupControlID="pnlModal" CancelControlID="btnCancelar"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel CssClass="" runat="server" ID="pnlModal">
        <div class="">
            <div class="modal-dialog" role="document" style="left:0;width:800px">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" id="exampleModalLiveLabel">Detalle de función evaluadora</h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-3">Año de evaluación:</div>
                            <div class="col-lg-9"><asp:Label ID="lblAnio" runat="server" Font-Bold="true"></asp:Label></div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">Función:</div>
                            <div class="col-lg-9">
                                <asp:DropDownList ID="ddlFuncion" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">&nbsp;</div>
                        </div>
                        <div class="row">
                            <div class="col-lg-9">
                                Si la "Denominación o Función" no se encuentra en el listado, entonces dicha función ya se encuentra habilitada como "Función Evaluadora".
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" /><br />
                        <asp:Label ID="lblAvisoPop" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

