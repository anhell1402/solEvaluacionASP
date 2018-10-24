
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
    public partial class Asignar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            CentrosTrabajo lst = new CentrosTrabajo();
            CentroTrabajoDAV2 obj = new CentroTrabajoDAV2();
            lst = obj.GetCentrosTrabajo();
            rptAsignar.DataSource = lst;
            rptAsignar.DataBind();
        }

        protected void rptAsignar_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CentroTrabajo centro = (CentroTrabajo)e.Item.DataItem;
                Image pendiente = (Image)e.Item.FindControl("imgPendiente");
                Image listo = (Image)e.Item.FindControl("imgListo");
                Image guardado = (Image)e.Item.FindControl("imgGuardado");
                Image limpiarDisabled = (Image)e.Item.FindControl("imgLimpiarDisabled");
                ImageButton limpiar = (ImageButton)e.Item.FindControl("imgLimpiar");
                pendiente.Visible = false;
                listo.Visible = false;
                guardado.Visible = false;
                limpiar.Visible = false;
                limpiarDisabled.Visible = false;
                switch(centro.Estatus)
                {
                    case 0: //sin revisar
                        pendiente.Visible = true;
                        limpiarDisabled.Visible = true;
                        break;
                    case 1: //liberado
                        limpiar.Visible = true;
                        listo.Visible = true;
                        break;
                }

            }
        }

        protected void rptAsignar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "editar")
            {
                Response.Redirect("~/Asignacion/admAsignarV2.aspx?e=" + id);
            }
            else
            {
                //limpiar
                CentroTrabajoDAV2 obj = new CentroTrabajoDAV2();
                CentroTrabajo centro = new CentroTrabajo();
                centro.IDGlobal = Convert.ToInt32(id);
                if(obj.LimpiarAsignacion(centro))
                {
                    Response.Redirect("~/Asignacion/Asignar");
                }
                else
                {
                    lblAviso.Text = "Ocurrió un error al tratar de almacenar la información.";
                    lblAviso.Visible = true;
                }
            }
        }

        
    }
}