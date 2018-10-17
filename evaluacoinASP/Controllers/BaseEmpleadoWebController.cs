using evaluacoinASP.Class.Catal.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace evaluacoinASP.Controllers
{
    public class BaseEmpleadoWebController : ApiController
    {
        /*
        // GET: api/BaseEmpleadoWeb
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        *
        */
        
        // GET: api/BaseEmpleadoWeb/5
        public IEnumerable<string> Get(string id)
        {
            string[] elementos = id.Split('$');
            string centro = elementos[0];
            string prefix = elementos[1];
            BaseEvaluador obj = new BaseEvaluador();
            string[] lst = obj.ObtenerListadoEmpleadosLibres(centro, prefix);
            return lst;
        }
        /*
        // POST: api/BaseEmpleadoWeb
        public IEnumerable<string> Post(string value)
        {
            string[] elementos = value.Split('$');
            string centro = elementos[0];
            string prefix = elementos[1];
            BaseEvaluador obj = new BaseEvaluador();
            string[] lst = obj.ObtenerListadoEmpleadosLibres(centro, prefix);
            return lst;
        }*/
        /*
        // PUT: api/BaseEmpleadoWeb/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BaseEmpleadoWeb/5
        public void Delete(int id)
        {
        }
        */
    }
}
