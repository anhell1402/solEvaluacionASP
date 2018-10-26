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
    public partial class AsignEmp : System.Web.UI.Page
    {
        private void CargarDatos()
        {
            BaseEmpleados lst = new BaseEmpleados();
            BaseEvaluador obj = new BaseEvaluador();
            lst = obj.ObtenerAsignacionesManuales();
            rptAsignacionesManuales.DataSource = lst;
            rptAsignacionesManuales.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatos();
            }
        }

        protected void btnNuevoEvaluador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Asignacion/man/fndEmp");
        }

        protected void rptAsignacionesManuales_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            BaseEmpleado empleado = new BaseEmpleado();
            empleado.IDGral = id;
            BaseEvaluador obj = new BaseEvaluador();
            switch (e.CommandName)
            {
                case "remover":
                    //quitar la persona del árbol al que pertenece
                    if (!obj.EliminaAsignacionManual(empleado, false))
                    {
                        lblAviso.Text = "Ocurrió un error al tratar de eliminar el registro.";
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        CargarDatos();
                    }
                    break;
                case "eliminar":
                    //eliminar todo el arbol seleccionado
                    if (!obj.EliminaAsignacionManual(empleado, true))
                    {
                        lblAviso.Text = "Ocurrió un error al tratar de eliminar el registro.";
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        CargarDatos();
                    }
                    break;
                case "agregarHijo":
                    //agregar personal al arbol seleccionado
                    Response.Redirect("~/Asignacion/man/fndEmp?p=" + id.ToString());
                    break;
                default:
                    break;
            }
        }

        protected void rptAsignacionesManuales_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BaseEmpleado emp = (BaseEmpleado)e.Item.DataItem;
                if(emp.IdPadre == 0)
                {
                    ((ImageButton)e.Item.FindControl("imgEliminar")).Visible = true;
                    ((ImageButton)e.Item.FindControl("imgAgregarEmp")).Visible = true;
                    ((ImageButton)e.Item.FindControl("imgRemover")).Visible = false;
                    ((Panel)e.Item.FindControl("pnlClase")).Controls.Add(new LiteralControl("<tr class='warning'>"));
                }
                else
                {
                    ((ImageButton)e.Item.FindControl("imgEliminar")).Visible = false;
                    ((ImageButton)e.Item.FindControl("imgAgregarEmp")).Visible = false;
                    ((ImageButton)e.Item.FindControl("imgRemover")).Visible = true;
                    ((Panel)e.Item.FindControl("pnlClase")).Controls.Add(new LiteralControl("<tr>"));
                }
            }
        }
    }
}