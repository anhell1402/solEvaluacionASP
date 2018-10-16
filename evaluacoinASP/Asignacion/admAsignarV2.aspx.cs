
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
    }
}