using evaluacoinASP.Models.Cat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Class.Catal
{
    public class EvaluadorDA
    {
        private string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Evaluador> ObtenerPosiblesEvaluadores(CentroTrabajo centro)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getEvaluadoresPosiblesCentroTrabajo", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            SqlDataReader dr;
            List<Evaluador> lst = null;
            Evaluador evaluador = null;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                lst = new List<Evaluador>();
                while(dr.Read())
                {
                    evaluador = new Evaluador();
                    evaluador.InfoEmpleado.IDGral = Convert.ToInt32(dr["IdGral"]);
                    evaluador.InfoEmpleado.Cve = Convert.ToInt32(dr["Empleado"]);
                    evaluador.InfoEmpleado.Nombre = dr["Nombre"].ToString();
                    evaluador.InfoEmpleado.Paterno = dr["ApellidoPaterno"].ToString();
                    evaluador.InfoEmpleado.Materno = dr["ApellidoMaterno"].ToString();
                    evaluador.InfoEmpleado.RFC = dr["RFC"].ToString();
                    evaluador.InfoEmpleado.IdFuncion = dr["Funcion"].ToString();
                    Models.Cat.Asignacion asignacion = new Models.Cat.Asignacion();
                    asignacion.InfoFuncionEvaluadora.Denominacion = dr["DenominacionPlaza"].ToString();
                    asignacion.InfoFuncionEvaluadora.IdFuncion = dr["Funcion"].ToString();
                    asignacion.InfoFuncionEvaluadora.Nivel = dr["NivelSalarial"].ToString();
                    asignacion.Inicio = dr["Inicio"].ToString();
                    asignacion.Fin = dr["Fin"].ToString();
                    asignacion.Dias = Convert.ToInt32(dr["Dias"]);
                    asignacion.InfoCentroTrabajo.IDGlobal = centro.IDGlobal;
                    asignacion.InfoCentroTrabajo.IdUR = Convert.ToInt32(dr["idUR"]);
                    asignacion.InfoCentroTrabajo.IdArea = Convert.ToInt32(dr["idArea"]);
                    asignacion.InfoCentroTrabajo.IdEstado = Convert.ToInt32(dr["idEstado"]);
                    asignacion.InfoCentroTrabajo.IdMunicipio = Convert.ToInt32(dr["idMunicipio"]);
                    asignacion.InfoCentroTrabajo.IdCT = Convert.ToInt32(dr["idCentroTrabajo"]);
                    asignacion.InfoCentroTrabajo.UnidadResponsable = dr["UnidadResponsable"].ToString();
                    asignacion.InfoCentroTrabajo.Area = dr["Area"].ToString();
                    asignacion.InfoCentroTrabajo.Municipio = dr["Municipio"].ToString();
                    asignacion.InfoCentroTrabajo.CTrabajo = dr["CentroDeTrabajo"].ToString();
                    evaluador.Asignaciones.Add(asignacion);
                    lst.Add(evaluador);
                }
                oCon.Close();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }

        public bool AlmacenarEvaluador(CentroTrabajo centro, Empleado empleado)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.setGuardarEvaluador", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            oCmd.Parameters.AddWithValue("@idGral", empleado.IDGral);
            bool correcto = false;
            try
            {
                oCon.Open();
                oCmd.ExecuteNonQuery();
                correcto = true;
            }
            catch (Exception)
            {
                correcto = false;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
                oCon.Dispose();
            }
            return correcto;
        }
    }
}