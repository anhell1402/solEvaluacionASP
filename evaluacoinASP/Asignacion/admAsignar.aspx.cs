using evaluacoinASP.Class.Catal;
using evaluacoinASP.Models.Cat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacoinASP.Asignacion
{
    public partial class admAsignar : System.Web.UI.Page
    {

        private List<Evaluador> lst;
        private List<Evaluador> lstDataSet;

        private const string EVALUADORES = "EVALUADORES";
        private const string EVALUADORES_DATASET = "EVALUADORES_DATASET";

        private void subirSesion(List<Evaluador> lst)
        {
            HttpContext.Current.Session[EVALUADORES] = lst;
        }

        private void obtenerSesion()
        {
            lst = (List<Evaluador>)HttpContext.Current.Session[EVALUADORES];
        }
        private void ObtenerDataSet()
        {
            lstDataSet = (List<Evaluador>)HttpContext.Current.Session[EVALUADORES_DATASET];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["e"]);
                CentroTrabajo centro = new CentroTrabajo();
                CentroTrabajoDA obj = new CentroTrabajoDA();
                centro.IDGlobal = id;
                centro = obj.getCentroTrabajo(centro);
                lblCentroTrabajo.Text = centro.CTrabajo;
                lblArea.Text = centro.Area;
                lblMunicipio.Text = centro.Municipio;
                lblUnidadResponsable.Text = centro.UnidadResponsable;
                lst = new List<Evaluador>();
                subirSesion(lst);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (rbList.SelectedValue)
            {
                case "0":
                    //por jerarquia
                    break;
                case "1":
                    break;
                case "2":
                    break;
            }
        }

        protected void rbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFuncion.Visible = false;
            pnlJerarquia.Visible = false;
            pnlManual.Visible = false;
            CentroTrabajo centro = new CentroTrabajo();
            int id = Convert.ToInt32(Request.QueryString["e"]);
            centro.IDGlobal = id;
            
            switch (((RadioButtonList)sender).SelectedValue)
            {
                case "0":
                    EvaluadorDA obj = new EvaluadorDA();
                    List<Evaluador> lst = new List<Evaluador>();
                    lst = obj.ObtenerPosiblesEvaluadores(centro);
                    rptEvaluadoresPosibles.DataSource = lst;
                    HttpContext.Current.Session[EVALUADORES_DATASET] = lst; //Subir la información de la BD a la sesión (DataSet)
                    rptEvaluadoresPosibles.DataBind();
                    pnlJerarquia.Visible = true;
                    break;
                case "1":
                    pnlFuncion.Visible = true;
                    break;
                case "2":
                    pnlManual.Visible = true;
                    break;
            }
        }
        private void Home()
        {
            Response.Redirect("~/Asignacion/Asignar");
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Home();
        }

        protected void rptEvaluadoresPosibles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            obtenerSesion();
            //Encontrar el elemento en el DataSet  <- Esta es la clave, ¿cómo lo encuentro?
            //agregarlo a la lista de sesión
            Evaluador evaluador = (Evaluador)e.Item.DataItem;
            if (e.CommandName == "seleccionado")
            {
                lst.Add(evaluador);
            }
            else
            {
                Evaluador eval = lst.Find(x => x.InfoEmpleado.Cve == evaluador.InfoEmpleado.Cve &&
                        x.Asignaciones[0].Dias == evaluador.Asignaciones[0].Dias &&
                        x.Asignaciones[0].Inicio == evaluador.Asignaciones[0].Inicio &&
                        x.Asignaciones[0].Fin == evaluador.Asignaciones[0].Fin);
                lst.RemoveAt(lst.IndexOf(eval));
            }
            subirSesion(lst);
            DiasTotales();
        }

        private void DiasTotales()
        {
            obtenerSesion();
            int total = 0;
            foreach(Evaluador eval in lst)
            {
                total += eval.Asignaciones[0].Dias;
            }
            lblTotalDias.Text = total.ToString();
        }

        protected void rptEvaluadoresPosibles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //ImageButton img = (ImageButton)e.Item.FindControl("checked");
                //ImageButton imgNo = (ImageButton)e.Item.FindControl("no_checked");
                //img.Visible = true;
                //imgNo.Visible = false;
            }
        }
    }
}