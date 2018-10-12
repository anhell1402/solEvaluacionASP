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
    public partial class admAsignarV2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
            }
        }
    }
}