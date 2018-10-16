using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.V2.Cat
{
    public class Asignacion
    {
        public Asignacion()
        {
            InfoCentroTrabajo = new CentroTrabajo();
            ListaEvaluadores = new BaseEmpleados();
        }

        private CentroTrabajo infoCentroTrabajo;
        private BaseEmpleados listaEvaluadores;

        public CentroTrabajo InfoCentroTrabajo
        {
            get{ return infoCentroTrabajo; }
            set{ infoCentroTrabajo = value; }
        }
        public BaseEmpleados ListaEvaluadores
        {
            get { return listaEvaluadores; }
            set { listaEvaluadores = value; }
        }
    }
}