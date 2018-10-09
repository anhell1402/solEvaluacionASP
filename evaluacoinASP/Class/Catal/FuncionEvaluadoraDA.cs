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
    public class FuncionEvaluadoraDA
    {
        private string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<FuncionEvaluadora> GetFuncionesEvaluadoras()
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getFuncionesEvaluadoras", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
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
                    funcion.Id = Convert.ToInt32(dr["id"]);
                    funcion.IdFuncion = dr["idFuncion"].ToString();
                    funcion.Anio = Convert.ToInt32(dr["anio"]);
                    funcion.Nivel = dr["nivel"].ToString();
                    funcion.Denominacion = dr["denominacionPlaza"].ToString();
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

        public bool EliminarFuncionEvaluadora(FuncionEvaluadora funcion)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.deleteFuncionEvaluadora", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@id", funcion.Id);
            bool resulado = false;
            try
            {
                oCon.Open();
                oCmd.ExecuteNonQuery();
                oCon.Close();
                resulado = true;
            }
            catch (Exception)
            {
                resulado = false;
            }
            return resulado;
        }

        public List<FuncionEvaluadora> GetFuncionesDisponibles()
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getFuncionesDisponibles", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
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
                    funcion.IdFuncion = dr["Funcion"].ToString();
                    funcion.Anio = Convert.ToInt32(dr["anio"]);
                    funcion.Nivel = dr["NivelSalarial"].ToString();
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

        public bool AlmacenarFuncionEvaluadora(FuncionEvaluadora funcion)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.saveFuncionEvaluadora", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@idFuncion", funcion.IdFuncion);
            bool resulado = false;
            try
            {
                oCon.Open();
                oCmd.ExecuteNonQuery();
                oCon.Close();
                resulado = true;
            }
            catch (Exception)
            {
                resulado = false;
            }
            return resulado;
        }
    }
}