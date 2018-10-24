<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignar.aspx.cs" Inherits="evaluacoinASP.Asignacion.Asignar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Asignación manual de funciones evaluadoras a centros de trabajo - <%=DateTime.Now.Year %></h3>
    
    <div style="height:450px; overflow-y:auto;">
        <asp:Repeater ID="rptAsignar" runat="server" OnItemDataBound="rptAsignar_ItemDataBound" OnItemCommand="rptAsignar_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th rowspan="2" scope="col" style="text-align:center">Unidad Responsable</th>
                            <th rowspan="2" scope="col" style="text-align:center">Área</th>
                            <th rowspan="2" scope="col" style="text-align:center">Municipio</th>
                            <th rowspan="2" scope="col" style="text-align:center">Centro de Trabajo</th>
                            <th colspan="3" scope="col" style="text-align:center">Opciones</th>
                        </tr>
                        <tr>
                            <th scope="col" style="text-align:center">Modificar</th>
                            <th scope="col" style="text-align:center">Limpiar</th>
                            <th scope="col" style="text-align:center">Estatus</th>
                        </tr>
                    </thead>
                    <tbody>                
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("UnidadResponsable") %></td>
                    <td><%#Eval("Area") %></td>
                    <td><%#Eval("Municipio") %></td>
                    <td><%#Eval("CTrabajo") %></td>
                    <td style="text-align:center;">
                        <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/Content/images/edit.png" 
                            CommandName="editar" CommandArgument='<%#Eval("IDGlobal") %>'
                            ToolTip="Editar asignación" Height="30" Width="30" />
                    </td>
                    <td style="text-align:center;">
                        <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Content/images/delete.png" 
                            CommandName="limpiar" CommandArgument='<%#Eval("IDGlobal") %>'
                            OnClientClick="return confirm('¿Está seguro que desea limpiar la asignación?');"
                            ToolTip="Limpiar asignación" Height="30" Width="30" />
                        <asp:Image ID="imgLimpiarDisabled" runat="server" ImageUrl="~/Content/images/delete_disabled.png"
                            Height="30" Width="30" />
                    </td>
                    <td style="text-align:center;">
                        <asp:Image ID="imgPendiente" runat="server" ImageUrl="~/Content/images/warning.png" ToolTip="Sin asignación" Height="30" Width="30" />
                        <asp:Image ID="imgListo" runat="server" ImageUrl="~/Content/images/done.png" ToolTip="OK" Height="30" Width="30" />
                        <asp:Image ID="imgGuardado" runat="server" ImageUrl="~/Content/images/pre_done.png" ToolTip="Guardado NO liberado" Height="30" Width="30" />
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
        <div class="col-lg-6">
            <asp:Label ID="lblAviso" runat="server" CssClass="p-3 mb-2 bg-danger text-white" Visible="false"></asp:Label>
        </div>
    </div>
    <br />
    <div class="container"  style="border:solid;">
        <div class="row" style="padding:5px;">
            <div class="col-lg-3">
                <asp:Image ID="imgEditar" runat="server" ImageUrl="~/Content/images/edit.png" Height="50" Width="50" /> Modificar/Realizar asignación
            </div>
            <div class="col-lg-3">
                <asp:Image ID="imgLimpiar" runat="server" ImageUrl="~/Content/images/delete.png" Height="50" Width="50" /> Limpiar asignación
            </div>
            <div class="col-lg-3">
                <asp:Image ID="imgPendiente" runat="server" ImageUrl="~/Content/images/warning.png" Height="50" Width="50" /> Centro de trabajo sin asignación
            </div>
            <div class="col-lg-3">
                <asp:Image ID="imgListo" runat="server" ImageUrl="~/Content/images/done.png" Height="50" Width="50" /> Con Asignación
            </div>
        </div>
    </div>
       
</asp:Content>
