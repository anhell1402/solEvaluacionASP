<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignEmp.aspx.cs" Inherits="evaluacoinASP.Asignacion.AsignEmp" %>
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
    <div class="modal-content">
        <div class="modal-header">
            <div class="row" style="text-align:center;font-weight:bold;">
                <div class="col-lg-6">Nombre</div>
                <div class="col-lg-2">Inicio</div>
                <div class="col-lg-2">Fin</div>
                <div class="col-lg-2">Eliminar</div>
            </div>
        </div>
        <asp:Panel ID="pnlAsignacionManual" runat="server"></asp:Panel>
    </div>
</asp:Content>
