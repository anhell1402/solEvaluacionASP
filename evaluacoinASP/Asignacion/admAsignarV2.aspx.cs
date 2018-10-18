
using evaluacoinASP.Class.Catal.V2;
using evaluacoinASP.Models.V2.Cat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacoinASP.Asignacion
{
    public partial class admAsignarV2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Cargar información general del centro de trabajo
                int id = Convert.ToInt32(Request.QueryString["e"]);
                CentroTrabajo centro = new CentroTrabajo();
                CentroTrabajoDAV2 obj = new CentroTrabajoDAV2();
                centro.IDGlobal = id;
                centro = obj.getCentroTrabajo(centro);
                lblCentroTrabajo.Text = centro.CTrabajo;
                lblArea.Text = centro.Area;
                lblMunicipio.Text = centro.Municipio;
                lblUnidadResponsable.Text = centro.UnidadResponsable;
                CargarDatos();
            }

            txtDesde.Attributes.Add("readonly", "readonly");
            txtHasta.Attributes.Add("readonly", "readonly");
        }

        private void CargarDatos()
        {
            int id = Convert.ToInt32(Request.QueryString["e"]);
            CentroTrabajo centro = new CentroTrabajo();
            CentroTrabajoDAV2 obj = new CentroTrabajoDAV2();
            centro.IDGlobal = id;
            BaseEvaluador objE = new BaseEvaluador();
            BaseEmpleados lst = new BaseEmpleados();
            //Obtener información de los posibles evaluadores (automáticos)
            lst = objE.ObtenerPosiblesEvaluadores(centro, Asig.Posibles);
            rptEvaluadoresPosibles.DataSource = lst;
            rptEvaluadoresPosibles.DataBind();

            lst = objE.ObtenerPosiblesEvaluadores(centro, Asig.Asignado);
            rptEvaluadoresAsignados.DataSource = lst;
            rptEvaluadoresAsignados.DataBind();


        }

        protected void rptEvaluadoresPosibles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "seleccionado")
            {
                CentroTrabajo centro = new CentroTrabajo();
                BaseEmpleado empleado = new BaseEmpleado();
                int idCentro = Convert.ToInt32(Request.QueryString["e"]);
                centro.IDGlobal = idCentro;
                empleado.IDGral = Convert.ToInt32(e.CommandArgument);
                BaseEvaluador obj = new BaseEvaluador();
                if(obj.EmpleadoEvaluador(centro, empleado, Accion.Asignar))
                {
                    CargarDatos();
                }
            }
        }

        protected void rptEvaluadoresAsignados_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "seleccionado")
            {
                CentroTrabajo centro = new CentroTrabajo();
                BaseEmpleado empleado = new BaseEmpleado();
                int idCentro = Convert.ToInt32(Request.QueryString["e"]);
                centro.IDGlobal = idCentro;
                empleado.IDGral = Convert.ToInt32(e.CommandArgument);
                BaseEvaluador obj = new BaseEvaluador();
                if (obj.EmpleadoEvaluador(centro, empleado, Accion.Eliminar))
                {
                    CargarDatos();
                }
            }
        }

        protected void btnBuscarPersonal_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["e"]);
            CentroTrabajo centro = new CentroTrabajo();
            centro.IDGlobal = id;
            BaseEvaluador obj = new BaseEvaluador();
            BaseEmpleados lst = obj.ObtenerListadoEmpleadosLibres(centro, txtBusqueda.Text.Trim());
            if (lst.Count > 0)
                pnlCoincidencias.Visible = true;
            else
                pnlCoincidencias.Visible = false;
            rptCoincidencias.DataSource = lst;
            rptCoincidencias.DataBind();
        }

        protected void rptCoincidencias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "agregarIndependiente")
            {
                ((Label)pnlPopup.FindControl("lblClaveEmpleado")).Text = ((Label)e.Item.FindControl("lblCvEm")).Text;
                lblNombreEmpleado.Text = ((Label)e.Item.FindControl("lblNoEm")).Text;
                lblFuncion.Text = ((HiddenField)e.Item.FindControl("hfFuncion")).Value + " - " +
                    ((Label)e.Item.FindControl("lblFunEm")).Text;
                ModalPopupExtender1.Show();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Para guardar la asignación manual de una personal a un centro de trabajo
            //validar las fechas en inicio y fin
            DateTime desde = Convert.ToDateTime(txtDesde.Text);
            DateTime hasta = Convert.ToDateTime(txtHasta.Text);
            int result = DateTime.Compare(desde, hasta);
            if(result <= 0)
            {
                //Fechas OK
                CentroTrabajo centro = new CentroTrabajo();
                BaseEmpleado empleado = new BaseEmpleado();
                empleado.Inicio = desde;
                empleado.Fin = hasta;
                empleado.CveEmpleado = Convert.ToInt32(lblClaveEmpleado.Text);
                empleado.IdFuncion = lblFuncion.Text.Split('-')[0].Trim();
                centro.IDGlobal = Convert.ToInt32(Request.QueryString["e"]);
                BaseEvaluador obj = new BaseEvaluador();
                if(obj.EmpleadoEvaluador(centro, empleado))
                {
                    txtBusqueda.Text = string.Empty;
                    rptCoincidencias.Visible = false;
                }
                else
                {
                    lblAvisoErrorAsignado.Text = "Ocurrió un error al tratar de almacenar la información";
                    ModalPopupExtender1.Show();
                }

                
            }
        }
    }
}