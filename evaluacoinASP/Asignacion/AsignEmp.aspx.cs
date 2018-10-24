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
        protected void Page_Load(object sender, EventArgs e)
        {
            BaseEmpleados lst = new BaseEmpleados();
            BaseEvaluador obj = new BaseEvaluador();
            lst = obj.ObtenerAsignacionesManuales();
            pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='modal-content'>"));
            bool primero = true;
            foreach (BaseEmpleado emp in lst)
            {
                
                if(emp.IdPadre == 0)
                {
                    //es padre
                    pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='row'>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='col-lg-6'><h5>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl(emp.CveEmpleado.ToString() +
                        " - " + emp.Nombre + " " + emp.Paterno + " " + emp.Materno));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("</h5></div>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='col-lg-2'>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl(emp.FechaInicio));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("</div>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='col-lg-2'>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl(emp.FechaFin));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("</div>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='col-lg-2'>Eliminar</div>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("</div>"));
                    pnlAsignacionManual.Controls.Add(new LiteralControl("<div class='modal-body'>"));
                    primero = false;
                }
                else
                {

                }

                pnlAsignacionManual.Controls.Add(new LiteralControl(""));
                
            }
            pnlAsignacionManual.Controls.Add(new LiteralControl("</div>"));
            pnlAsignacionManual.Controls.Add(new LiteralControl("</div>"));
        }

        protected void btnNuevoEvaluador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Asignacion/man/fndEmp");
        }
    }
}