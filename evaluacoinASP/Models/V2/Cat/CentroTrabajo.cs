using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.V2.Cat
{
    public class CentroTrabajo
    {
        public int IdUR { set; get; }
        public int IdArea { set; get; }
        public int IdEstado { set; get; }
        public int IdMunicipio { set; get; }
        public int IdCT { set; get; }
        public string UnidadResponsable { set; get; }
        public string Area { set; get; }
        public string Municipio { set; get; }
        public string CTrabajo { set; get; }
        public int Estatus { set; get; }
        public int IDGlobal { set; get; }
        /// <summary>
        /// GET Only
        /// <para>IdUR-IdArea-IdEstado-IdMunicipio-IdCT</para>
        /// </summary>
        public string Identificador
        {
            get
            {
                return IdUR.ToString() + "-" + IdArea.ToString() + "-" + IdEstado.ToString() + "-" + IdMunicipio.ToString() + "-" + IdCT.ToString();
            }
        }
    }
}