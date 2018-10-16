using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.Cat
{
    public class Empleado
    {
        public int IDGral { set; get; }
        public int Cve { set; get; }
        public string Nombre { set; get; }
        public string Paterno { set; get; }
        public string Materno { set; get; }
        public string RFC { set; get; }
        public string IdFuncion { set; get; }
        /// <summary>
        /// GET Only
        /// </summary>
        public string NombreEmpleado
        {
            get { return Nombre + " " + Paterno + "" + Materno; }
        }
    }
}