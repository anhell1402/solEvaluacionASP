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
    public class CentroTrabajoDAV2
    {
        private string cadena = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public CentrosTrabajo GetCentrosTrabajo()
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getCentrosTrabajo", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            CentrosTrabajo lst = null;
            CentroTrabajo centro = null;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                lst = new CentrosTrabajo();
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
            }
            catch (Exception ex)
            {
                lst = null;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
                oCon.Dispose();
            }
            return lst;
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
    }
}