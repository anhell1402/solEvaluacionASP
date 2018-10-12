<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admAsignarV2.aspx.cs" Inherits="evaluacoinASP.Asignacion.admAsignarV2" %>
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
        </div>
    </div>
</asp:Content>
