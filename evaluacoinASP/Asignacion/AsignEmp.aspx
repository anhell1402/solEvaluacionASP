<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignEmp.aspx.cs" Inherits="evaluacoinASP.Asignacion.AsignEmp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-8">
            <h3>Asignación manual de personal - <%=DateTime.Now.Year %></h3>
        </div>
        <div class="col-lg-4">
            <h3><asp:Button ID="btnNuevoEvaluador" runat="server" CssClass="btn btn-primary"
                    Text="Nuevo evaluador"
                    OnClick="btnNuevoEvaluador_Click" /></h3>
        </div>
    </div>
    <asp:Repeater ID="rptAsignacionesManuales" runat="server" OnItemCommand="rptAsignacionesManuales_ItemCommand"
        OnItemDataBound="rptAsignacionesManuales_ItemDataBound">
        <HeaderTemplate>
            <table class="table table-condensed">
                <thead>
                    <tr>
                        <th style="width:50%">Nombre</th>
                        <th style="width:15%">Inicio</th>
                        <th style="width:15%">Fin</th>
                        <th style="width:10%">Suple cualquier asignación</th>
                        <th>Opciones</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <%--<tr class="warning">--%>
            <asp:Panel ID="pnlClase" runat="server"></asp:Panel>
                <td><%#Eval("CveEmpleado") + " " + Eval("Nombre") + " " + Eval("Paterno") + " " + Eval("Materno") %></td>
                <td><%#Eval("FechaInicio") %></td> 
                <td><%#Eval("FechaFin") %></td> 
                <td><%#Eval("SupleAsignacion").ToString() == "1" ? "Sí" : "No" %></td> 
                <td>
                    <asp:ImageButton ID="imgEliminar" runat="server" Width="30" Height="30" ImageUrl="~/Content/images/del.png"
                        CommandName="eliminar" CommandArgument='<%#Eval("IDGral") %>'
                        OnClientClick="return confirm('Considere que esta acción borrará toda la relación del personal asociado, ¿desea continuar?');" />
                    <asp:ImageButton ID="imgRemover" runat="server" Width="30" Height="30" ImageUrl="~/Content/images/minus.png"
                        CommandName="remover" CommandArgument='<%#Eval("IDGral") %>'
                        OnClientClick="return confirm('¿Está seguro que desea eliminar a esta persona de la asignación?');" />
                    <asp:ImageButton ID="imgAgregarEmp" runat="server" Width="30" Height="30" ImageUrl="~/Content/images/addE.png"
                        CommandName="agregarHijo" CommandArgument='<%#Eval("IDGral") %>' />
                </td> 
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
            
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlAviso" CancelControlID="btnCerrar" TargetControlID="lnkDummy"></ajaxToolkit:ModalPopupExtender>
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    <asp:Panel ID="pnlAviso" runat="server" CssClass="modalPopup">
        <div class="row"><h3><asp:Label ID="lblAviso" runat="server" CssClass="bg-danger"></asp:Label></h3></div>
        <div class="row"><asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="btn btn-secondary" /></div>
    </asp:Panel>
</asp:Content>
