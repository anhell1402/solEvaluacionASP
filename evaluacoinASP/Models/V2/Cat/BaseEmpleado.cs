using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.V2.Cat
{
    public class BaseEmpleado
    {
        public int IDGral { set; get; }
        public int CveEmpleado { set; get; }
        public string RFC { set; get; }
        public string Paterno { set; get; }
        public string Materno { set; get; }
        public string Nombre { set; get; }
        public string DenominacionPlaza { set; get; }
        public string TipoPeriodo { set; get; }
        public string TipoNombramiento { set; get; }
        public DateTime Inicio { set; get; }
        public DateTime Fin { set; get; }
        public int Dias { set; get; }
        public string Municipio { set; get; }
        public string CentroDeTrabajo { set; get; }
        public string Area { set; get; }
        public string UnidadResponsable { set; get; }
        public string Sexo { set; get; }
        public string NivelSalarial { set; get; }
        public string IdFuncion { set; get; }
        public int IdUR { set; get; }
        public int IdArea { set; get; }
        public int IdEstado { set; get; }
        public int IdMunicipio { set; get; }
        public int IdCentroTrabajo { set; get; }
        public int IdPlaza { set; get; }
        public int Anio { set; get; }
    }
}