using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.Cat
{
    public class FuncionEvaluadora
    {
        public int Id { set; get; }
        public string IdFuncion { set; get; }
        public int Anio { set; get; }
        public string Nivel { set; get; }
        public string Denominacion { set; get; }
        public string DenominacionCompleto
        {
            get
            {
                return IdFuncion + " - " + Denominacion;
            }
        }
    }
}