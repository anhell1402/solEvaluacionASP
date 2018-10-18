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
                <div class="col-lg-2"></div>
            </div>
            <div class="row">
                <div class="col-lg-2">Municipio:</div>
                <div class="col-lg-3"><asp:Label ID="lblMunicipio" runat="server" Font-Bold="true"></asp:Label></div>
                <div class="col-lg-2">Centro de trabajo:</div>
                <div class="col-lg-3"><asp:Label ID="lblCentroTrabajo" runat="server" Font-Bold="true"></asp:Label></div>
            </div>        
        </div>
        
        <asp:UpdatePanel ID="upAsignacion" runat="server">
            <ContentTemplate>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlPopup" CancelControlID="btnCerrar" TargetControlID="lnkDummy"></ajaxToolkit:ModalPopupExtender>
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
        <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Periodos de personal para asignación</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-1">Clave:</div>
                        <div class="col-lg-2"><asp:Label ID="lblClaveEmpleado" runat="server" Font-Bold="true"></asp:Label></div>
                        <div class="col-lg-1">Nombre:</div>
                        <div class="col-lg-4"><asp:Label ID="lblNombreEmpleado" runat="server" Font-Bold="true"></asp:Label></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1">Función:</div>
                        <div class="col-lg-5"><asp:Label ID="lblFuncion" runat="server" Font-Bold="true"></asp:Label></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-1">Desde:</div>
                        <div class="col-lg-3">
                            <p class="input-group">
                                <asp:TextBox ID="txtDesde" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Image ID="imgCalDesde" runat="server" ImageUrl="~/Content/images/calendar.png"
                                        Height="30" Width="30" />
                                </span>
                            </p>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
                                PopupButtonID="imgCalDesde" TargetControlID="txtDesde" />
                        </div>
                        <div class="col-lg-1">Hasta:</div>
                        <div class="col-lg-3">
                            <p class="input-group">
                                <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Image ID="imgHasta" runat="server" ImageUrl="~/Content/images/calendar.png"
                                        Height="30" Width="30" />
                                </span>
                            </p>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" 
                                PopupButtonID="imgHasta" TargetControlID="txtHasta" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-10" style="text-align:right;">
                            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="btn btn-secondary" />
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                            <br />
                            <asp:Label ID="lblAvisoErrorAsignado" runat="server" CssClass="p-3 mb-2 bg-danger text-white"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
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
            </div>
                <br />
            <div class="modal-content">  
                    <div class="modal-header">
                        <div class="row">
                            <div class="col-lg-9">
                                <h4>Evaluadores asignados al centro de trabajo</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-1">Búsqueda:</div>
                            <div class="col-lg-3">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button ID="btnBuscarPersonal" Text="Buscar personal" runat="server" 
                                    OnClick="btnBuscarPersonal_Click"
                                    CssClass="btn btn-primary" />
                            </div>
                        </div>
                        <asp:Panel ID="pnlCoincidencias" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div style="overflow-y:scroll;height:200px">
                                        <asp:Repeater ID="rptCoincidencias" runat="server" OnItemCommand="rptCoincidencias_ItemCommand">
                                            <HeaderTemplate>
                                                <table class="table table-striped table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th style="text-align:center;">Cve Empleado</th>
                                                            <th style="text-align:center;">Nombre</th>
                                                            <th style="text-align:center;">Puesto</th>
                                                            <th style="text-align:center;">Agregar</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><asp:Label ID="lblCvEm" runat="server" Text='<%#Eval("CveEmpleado") %>'></asp:Label></td>
                                                    <td><asp:Label ID="lblNoEm" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label></td>
                                                    <td><asp:Label ID="lblFunEm" runat="server" Text='<%#Eval("DenominacionPlaza") %>'></asp:Label></td>
                                                    <td style="text-align:center;">
                                                        <asp:ImageButton ID="imgAgregarEmpleado" runat="server" 
                                                            Height="30" Width="30" ImageUrl="~/Content/images/in.png"
                                                            CommandArgument='<%#Eval("CveEmpleado") %>' 
                                                            CommandName="agregarIndependiente" />
                                                        <asp:HiddenField ID="hfFuncion" runat="server" Value='<%#Eval("IdFuncion")  %>' />
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
                        </asp:Panel>
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
                <asp:AsyncPostBackTrigger ControlID="btnBuscarPersonal" EventName="click" />
                <asp:AsyncPostBackTrigger ControlID="rptCoincidencias" EventName="ItemCommand" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    
</asp:Content>
