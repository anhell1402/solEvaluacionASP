using evaluacoinASP.Models.V2.Cat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace evaluacoinASP.Class.Catal.V2
{
    public class BaseEvaluador
    {
        private string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public BaseEmpleados ObtenerPosiblesEvaluadores(CentroTrabajo centro, Asig asig)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            string comando = string.Empty;
            if (asig == Asig.Posibles)
                comando = "dbo.getEvaluadoresPosiblesCentroTrabajo";
            else
                comando = "dbo.getEvaluadoresAsignadosCentroTrabajo";
            SqlCommand oCmd = new SqlCommand(comando, oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            SqlDataReader dr;
            BaseEmpleados lst = null;
            BaseEmpleado evaluador = null;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                lst = new BaseEmpleados();
                while (dr.Read())
                {
                    evaluador = new BaseEmpleado();
                    evaluador.IDGral = Convert.ToInt32(dr["IdGral"]);
                    evaluador.CveEmpleado = Convert.ToInt32(dr["Empleado"]);
                    evaluador.Paterno = dr["ApellidoPaterno"].ToString();
                    evaluador.Materno = dr["ApellidoMaterno"].ToString();
                    evaluador.Nombre = dr["Nombre"].ToString();
                    evaluador.RFC = dr["RFC"].ToString();
                    evaluador.DenominacionPlaza = dr["DenominacionPlaza"].ToString();
                    evaluador.Inicio = Convert.ToDateTime(dr["Inicio"]);
                    evaluador.Fin = Convert.ToDateTime(dr["Fin"]);
                    evaluador.Dias = Convert.ToInt32(dr["Dias"]);
                    evaluador.IdFuncion = dr["Funcion"].ToString();
                    evaluador.IdUR = Convert.ToInt32(dr["idUR"]);
                    evaluador.IdArea = Convert.ToInt32(dr["idArea"]);
                    evaluador.IdEstado = Convert.ToInt32(dr["idEstado"]);
                    evaluador.IdMunicipio = Convert.ToInt32(dr["idMunicipio"]);
                    evaluador.IdCentroTrabajo = Convert.ToInt32(dr["idCentroTrabajo"]);
                    evaluador.UnidadResponsable = dr["UnidadResponsable"].ToString();
                    evaluador.Area = dr["Area"].ToString();
                    evaluador.Municipio = dr["Municipio"].ToString();
                    evaluador.CentroDeTrabajo = dr["CentroDeTrabajo"].ToString();
                    evaluador.NivelSalarial = dr["NivelSalarial"].ToString();
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

        public bool EmpleadoEvaluador(CentroTrabajo centro, BaseEmpleado empleado, Accion accion)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            string comando = string.Empty;
            if(accion == Accion.Asignar)
            {
                comando = "dbo.setGuardarEvaluador";
            }
            else
            {
                comando = "dbo.eliminaAsignacionEvaluador";
            }
            SqlCommand oCmd = new SqlCommand(comando, oCon);
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
            catch (Exception ex)
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