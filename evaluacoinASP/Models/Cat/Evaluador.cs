using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Models.Cat
{
    public class Evaluador
    {
        public Evaluador()
        {
            InfoEmpleado = new Empleado();
            Asignaciones = new List<Asignacion>();
        }
        public Empleado InfoEmpleado { set; get; }
        public List<Asignacion> Asignaciones { set; get; }
        
        
    }
}