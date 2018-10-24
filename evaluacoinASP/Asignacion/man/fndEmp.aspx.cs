using evaluacoinASP.Class.Catal.V2;
using evaluacoinASP.Models.V2.Cat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacoinASP.Asignacion.man
{
    public partial class fndEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDesde.Attributes.Add("readonly", "readonly");
            txtHasta.Attributes.Add("readonly", "readonly");
        }

        protected void rptCoincidencias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "agregarIndependiente")
            {
                ((Label)pnlPopup.FindControl("lblClaveEmpleado")).Text = ((Label)e.Item.FindControl("lblCvEm")).Text;
                lblNombreEmpleado.Text = ((Label)e.Item.FindControl("lblNoEm")).Text;
                lblFuncion.Text = ((Label)e.Item.FindControl("lblFunEm")).Text;
                hfIDGralEvaluador.Value = e.CommandArgument.ToString();
                ModalPopupExtender1.Show();
            }
        }

        protected void btnBuscarPersonal_Click(object sender, EventArgs e)
        {
            BaseEvaluador obj = new BaseEvaluador();
            BaseEmpleados lst = obj.ObtenerListadoEmpleadosLibres(txtBusqueda.Text.Trim());
            if (lst.Count > 0)
                pnlCoincidencias.Visible = true;
            else
                pnlCoincidencias.Visible = false;
            rptCoincidencias.DataSource = lst;
            rptCoincidencias.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int padre = 0;
            if(Request.QueryString["p"] != null)
            {
                padre = Convert.ToInt32(Request.QueryString["p"]);
            }
            BaseEmpleado evaluador = new BaseEmpleado();
            BaseEvaluador obj = new BaseEvaluador();
            evaluador.IDGral = Convert.ToInt32(hfIDGralEvaluador.Value);
            evaluador.CveEmpleado = padre;
            evaluador.Inicio = Convert.ToDateTime(txtDesde.Text);
            evaluador.Fin = Convert.ToDateTime(txtHasta.Text);
            if(obj.AlmacenaAsignacionManual(evaluador, true, chkSupleAsignacion.Checked))
            {
                Home();
            }
            else
            {
                lblAvisoErrorAsignado.Text = "Ocurrió un error al tratar de almacenar la información.";
                ModalPopupExtender1.Show();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Home();
        }

        private void Home()
        {
            Response.Redirect("~/Asignacion/AsignEmp");
        }
    }
}