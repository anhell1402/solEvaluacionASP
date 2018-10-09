using evaluacoinASP.Models.Cat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace evaluacoinASP.Class.Catal
{
    public class CentroTrabajoDA
    {
        private string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<CentroTrabajo> GetCentrosTrabajo()
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getCentrosTrabajo", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            List<CentroTrabajo> lst = null;
            CentroTrabajo centro = null;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                lst = new List<CentroTrabajo>();
                while (dr.Read())
                {
                    centro = new CentroTrabajo();
                    centro.IdUR = Convert.ToInt32(dr["idUR"]);
                    centro.IdArea = Convert.ToInt32(dr["IdArea"]);
                    centro.IdEstado = Convert.ToInt32(dr["IdEstado"]);
                    centro.IdMunicipio = Convert.ToInt32(dr["IdMunicipio"]);
                    centro.IdCT = Convert.ToInt32(dr["IdCT"]);
                    centro.UnidadResponsable = dr["unidadResponsable"].ToString();
                    centro.Area = dr["area"].ToString();
                    centro.Municipio = dr["municipio"].ToString();
                    centro.CTrabajo = dr["centroTrabajo"].ToString();
                    centro.IDGlobal = Convert.ToInt32(dr["idConsec"]);
                    lst.Add(centro);
                }
                oCon.Close();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }

        public void LimpiarAsignacion(CentroTrabajo centro)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.eliminaAsignacionEvaluador", oCon);
            oCmd.Parameters.AddWithValue("@idCentroTrabajo", centro.IDGlobal);
            oCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                oCon.Open();
                oCmd.ExecuteNonQuery();
                oCon.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CentroTrabajo getCentroTrabajo(CentroTrabajo centro)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getCentroTrabajo", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@id", centro.IDGlobal);
            SqlDataReader dr;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                dr.Read();
                centro.IdUR = Convert.ToInt32(dr["idUR"]);
                centro.IdArea = Convert.ToInt32(dr["IdArea"]);
                centro.IdEstado = Convert.ToInt32(dr["IdEstado"]);
                centro.IdMunicipio = Convert.ToInt32(dr["IdMunicipio"]);
                centro.IdCT = Convert.ToInt32(dr["IdCT"]);
                centro.UnidadResponsable = dr["unidadResponsable"].ToString();
                centro.Area = dr["area"].ToString();
                centro.Municipio = dr["municipio"].ToString();
                centro.CTrabajo = dr["centroTrabajo"].ToString();
                centro.IDGlobal = Convert.ToInt32(dr["idConsec"]);
            }
            catch (Exception ex)
            {
                centro = null;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
                oCon.Dispose();
            }
            return centro;
        }

        public List<FuncionEvaluadora> getFuncionesEvaluadoras(CentroTrabajo centro)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getPreEvaluadores", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@id", centro.IDGlobal);
            SqlDataReader dr;
            List<FuncionEvaluadora> lst = null;
            FuncionEvaluadora funcion = null;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                lst = new List<FuncionEvaluadora>();
                while (dr.Read())
                {
                    funcion = new FuncionEvaluadora();
                    funcion.IdFuncion = dr["idFuncion"].ToString();
                    funcion.Anio = Convert.ToInt32(dr["anio"]);
                    funcion.Nivel = dr["nivel"].ToString();
                    funcion.Denominacion = dr["DenominacionPlaza"].ToString();
                    lst.Add(funcion);
                }
                oCon.Close();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }
    }
}