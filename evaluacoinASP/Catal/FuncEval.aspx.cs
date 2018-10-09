using evaluacoinASP.Class.Catal;
using evaluacoinASP.Models.Cat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacoinASP.Catal
{
    public partial class FuncEval : System.Web.UI.Page
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
            lblAviso.Text = string.Empty;
            List<FuncionEvaluadora> lst = new List<FuncionEvaluadora>();
            List<FuncionEvaluadora> lstDisponibles = new List<FuncionEvaluadora>();
            FuncionEvaluadoraDA obj = new FuncionEvaluadoraDA();
            lst = obj.GetFuncionesEvaluadoras();
            lstDisponibles = obj.GetFuncionesDisponibles();
            rptFunciones.DataSource = lst;
            rptFunciones.DataBind();
            lblAnio.Text = DateTime.Now.Year.ToString();
            ddlFuncion.DataSource = lstDisponibles;
            ddlFuncion.DataTextField = "DenominacionCompleto";
            ddlFuncion.DataValueField = "IdFuncion";
            ddlFuncion.DataBind();
        }

        protected void rptFunciones_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                FuncionEvaluadora funcion = new FuncionEvaluadora();
                funcion.Id = Convert.ToInt32(e.CommandArgument);
                FuncionEvaluadoraDA obj = new FuncionEvaluadoraDA();
                bool resultado = obj.EliminarFuncionEvaluadora(funcion);
                if (resultado)
                {
                    CargarDatos();
                }
                else
                {
                    lblAviso.Text = "Ocurrió un error al tratar de eliminar la información.";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblAvisoPop.Text = string.Empty;
            FuncionEvaluadora funcion = new FuncionEvaluadora();
            FuncionEvaluadoraDA obj = new FuncionEvaluadoraDA();
            string idFuncion = ddlFuncion.SelectedValue;
            funcion.IdFuncion = idFuncion;
            bool resultado = obj.AlmacenarFuncionEvaluadora(funcion);
            if (resultado)
                CargarDatos();
            else
            {
                lblAvisoPop.Text = "Ocurrió un error al tratar de almacenar la información.";
                ModalPopupExtender1.Show();
            }

        }
    }
}