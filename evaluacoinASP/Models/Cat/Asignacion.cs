using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.Cat
{
    public class Asignacion
    {
        public Asignacion()
        {
            InfoCentroTrabajo = new CentroTrabajo();
            InfoFuncionEvaluadora = new FuncionEvaluadora();
        }
        private string inicio;
        private string fin;
        public FuncionEvaluadora InfoFuncionEvaluadora { set; get; }
        public CentroTrabajo InfoCentroTrabajo { set; get; }
        public string Inicio { set { inicio = value; } get { return FechaEstandar(inicio); } }
        public string Fin { set { fin = value; } get { return FechaEstandar(fin); } }
        public int Dias { set; get; }

        private string FechaEstandar(string fecha)
        {
            string[] valores = fecha.Split(' ');
            string[] vals = valores[0].Split('/');
            string anio = vals[2];
            int mes = Convert.ToInt32(vals[1]);
            string mes_ = string.Empty;
            string dia = vals[0];
            switch(mes)
            {
                case 1:
                    mes_ = "Enero";
                    break;
                case 2:
                    mes_ = "Febrero";
                    break;
                case 3:
                    mes_ = "Marzo";
                    break;
                case 4:
                    mes_ = "Abril";
                    break;
                case 5:
                    mes_ = "Mayo";
                    break;
                case 6:
                    mes_ = "Junio";
                    break;
                case 7:
                    mes_ = "Julio";
                    break;
                case 8:
                    mes_ = "Agosto";
                    break;
                case 9:
                    mes_ = "Septiembre";
                    break;
                case 10:
                    mes_ = "Obtubre";
                    break;
                case 11:
                    mes_ = "Noviembre";
                    break;
                case 12:
                    mes_ = "Diciembre";
                    break;
            }
            return dia + " de " + mes_ + " de " + anio;
        }

    }
}