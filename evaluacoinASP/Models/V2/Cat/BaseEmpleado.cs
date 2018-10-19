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
        private DateTime inicio;
        public DateTime Inicio { set { inicio = value; } get { return inicio; } }
        public string FechaInicio { get { return formatoFecha(inicio); } }
        private DateTime fin;
        public DateTime Fin { set { fin = value; } get { return fin; } }
        public string FechaFin { get { return formatoFecha(fin); } }
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
        public int IdConsecCentroTrabajo { set; get; }
       
        private string formatoFecha(DateTime fecha)
        {
            string texto = string.Empty, month = string.Empty, dias = string.Empty;
            int mes;
            dias = fecha.Day.ToString();
            mes = fecha.Month;
            switch(mes)
            {
                case 1:
                    month = "Enero";
                    break;
                case 2:
                    month = "Febrero";
                    break;
                case 3:
                    month = "Marzo";
                    break;
                case 4:
                    month = "Abril";
                    break;
                case 5:
                    month = "Mayo";
                    break;
                case 6:
                    month = "Junio";
                    break;
                case 7:
                    month = "Julio";
                    break;
                case 8:
                    month = "Agosto";
                    break;
                case 9:
                    month = "Septiembre";
                    break;
                case 10:
                    month = "Octubre";
                    break;
                case 11:
                    month = "Noviembre";
                    break;
                case 12:
                    month = "Diciembre";
                    break;
            }
            if (dias.Length == 1)
                dias = "0" + dias;
            texto = dias + "/" + month + "/" + fecha.Year.ToString();
            return texto;
        }
    }
}