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

        public bool EmpleadoEvaluador(CentroTrabajo centro, BaseEmpleado empleado)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            string comando = string.Empty;
            comando = "dbo.setGuardarEvaluadorAsignado";
            SqlCommand oCmd = new SqlCommand(comando, oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            oCmd.Parameters.AddWithValue("@idEmpleado", empleado.CveEmpleado);
            oCmd.Parameters.AddWithValue("@funcion", empleado.IdFuncion);
            oCmd.Parameters.AddWithValue("@inicio", empleado.Inicio);
            oCmd.Parameters.AddWithValue("@fin", empleado.Fin);
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

        public bool ModificaPeriodoEmpleadoEvaluador(CentroTrabajo centro, BaseEmpleado empleado)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.updateAsignacionEvaluador", oCon);
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            oCmd.Parameters.AddWithValue("@idGral", empleado.IDGral);
            oCmd.Parameters.AddWithValue("@inicio", empleado.Inicio);
            oCmd.Parameters.AddWithValue("@fin", empleado.Fin);
            oCmd.CommandType = CommandType.StoredProcedure;
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

        public BaseEmpleado ObtenerEmpleadoEvaluador(CentroTrabajo centro, BaseEmpleado empleado)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getAsignacionEvaluador", oCon);
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            oCmd.Parameters.AddWithValue("@idGral", empleado.IDGral);
            oCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                oCon.Open();
                SqlDataReader dr = oCmd.ExecuteReader();
                dr.Read();
                empleado.IDGral = Convert.ToInt32(dr["idConsecEvaluador"]);
                empleado.IdConsecCentroTrabajo = Convert.ToInt32(dr["idConsecCentroTrabajo"]);
                empleado.CveEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                empleado.IdFuncion = dr["idFuncion"].ToString();
                empleado.Inicio = Convert.ToDateTime(dr["inicio"]);
                empleado.Fin = Convert.ToDateTime(dr["fin"]);
                empleado.IdUR = Convert.ToInt32(dr["idUR"]);
                empleado.IdArea = Convert.ToInt32(dr["idArea"]);
                empleado.IdEstado = Convert.ToInt32(dr["idEstado"]);
                empleado.IdMunicipio = Convert.ToInt32(dr["idMunicipio"]);
                empleado.IdCentroTrabajo = Convert.ToInt32(dr["idCentroTrabajo"]);
                empleado.IdPlaza = Convert.ToInt32(dr["idPlaza"]);
                empleado.Anio = Convert.ToInt32(dr["anio"]);
                empleado.Paterno = dr["ApellidoPaterno"].ToString();
                empleado.Materno = dr["ApellidoMaterno"].ToString();
                empleado.Nombre = dr["Nombre"].ToString();
                empleado.DenominacionPlaza = dr["DenominacionPlaza"].ToString();
            }
            catch (Exception)
            {
                empleado = null;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
                oCon.Dispose();
            }
            return empleado;
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

        public BaseEmpleados ObtenerListadoEmpleadosLibres(CentroTrabajo centro)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getEmpleadosLibre", oCon);
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            oCmd.CommandType = CommandType.StoredProcedure;
            BaseEmpleados lst = null;
            BaseEmpleado empleado = null;
            try
            {
                oCon.Open();
                lst = new BaseEmpleados();
                SqlDataReader dr = oCmd.ExecuteReader();
                while(dr.Read())
                {
                    empleado = new BaseEmpleado();
                    empleado.CveEmpleado = Convert.ToInt32(dr["Empleado"]);
                    empleado.Nombre = dr["Nombre"].ToString();
                    empleado.DenominacionPlaza = dr["DenominacionPlaza"].ToString();
                    empleado.IdFuncion = dr["Funcion"].ToString();
                    lst.Add(empleado);
                }
            }
            catch (Exception)
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

        public BaseEmpleados ObtenerListadoEmpleadosLibres(CentroTrabajo centro, string prefix)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getEmpleadosLibrePrefix", oCon);
            oCmd.Parameters.AddWithValue("@idCentro", centro.IDGlobal);
            oCmd.Parameters.AddWithValue("@prefix", prefix);
            oCmd.CommandType = CommandType.StoredProcedure;
            BaseEmpleados lst = null;
            BaseEmpleado empleado = null;
            try
            {
                oCon.Open();
                lst = new BaseEmpleados();
                SqlDataReader dr = oCmd.ExecuteReader();
                while (dr.Read())
                {
                    empleado = new BaseEmpleado();
                    empleado.CveEmpleado = Convert.ToInt32(dr["Empleado"]);
                    empleado.Nombre = dr["Nombre"].ToString();
                    empleado.DenominacionPlaza = dr["DenominacionPlaza"].ToString();
                    empleado.IdFuncion = dr["Funcion"].ToString();
                    lst.Add(empleado);
                }
            }
            catch (Exception)
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
        public BaseEmpleados ObtenerListadoEmpleadosLibres(string prefix)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getEmpleadosPrefix", oCon);
            oCmd.Parameters.AddWithValue("@prefix", prefix);
            oCmd.CommandType = CommandType.StoredProcedure;
            BaseEmpleados lst = null;
            BaseEmpleado empleado = null;
            try
            {
                oCon.Open();
                lst = new BaseEmpleados();
                SqlDataReader dr = oCmd.ExecuteReader();
                while (dr.Read())
                {
                    empleado = new BaseEmpleado();
                    empleado.IDGral = Convert.ToInt32(dr["id"]);
                    empleado.CveEmpleado = Convert.ToInt32(dr["Empleado"]);
                    empleado.Nombre = dr["Nombre"].ToString();
                    empleado.DenominacionPlaza = dr["DenominacionPlaza"].ToString();
                    empleado.IdFuncion = dr["Funcion"].ToString();
                    empleado.CentroDeTrabajo = dr["CentroDeTrabajo"].ToString();
                    empleado.Area = dr["Area"].ToString();
                    empleado.UnidadResponsable = dr["UnidadResponsable"].ToString();
                    lst.Add(empleado);
                }
            }
            catch (Exception)
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
        public string[] ObtenerListadoEmpleadosLibres(string centro, string prefix)
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getEmpleadosLibrePrefix", oCon);
            oCmd.Parameters.AddWithValue("@idCentro", Convert.ToInt32(centro));
            oCmd.Parameters.AddWithValue("@prefix", prefix);
            oCmd.CommandType = CommandType.StoredProcedure;
            List<string> lst = null;
            
            try
            {
                oCon.Open();
                lst = new List<string>();
                SqlDataReader dr = oCmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(string.Format("{0}%{1}", dr["Empleado"].ToString(), dr["Nombre"].ToString()));
                }
            }
            catch (Exception)
            {
                lst = null;
            }
            finally
            {
                if (oCon.State == ConnectionState.Open)
                    oCon.Close();
                oCon.Dispose();
            }
            return lst.ToArray();
        }
        /// <summary>
        /// Para el almacenamiento de un hijo de un evaluador, el ID del padre debe ir en la propiedad CveEmpleado del objeto empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <param name="evaluador"></param>
        /// <returns></returns>
        public bool AlmacenaAsignacionManual(BaseEmpleado empleado, bool evaluador, bool supleAutomatico)
        {
            bool correcto = false;
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.setNuevaAsignacion", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.AddWithValue("@idGral", empleado.IDGral);
            oCmd.Parameters.AddWithValue("@ini", empleado.Inicio);
            oCmd.Parameters.AddWithValue("@fi", empleado.Fin);
            if (evaluador)
                oCmd.Parameters.AddWithValue("@padre", "0");
            else
                oCmd.Parameters.AddWithValue("@padre", empleado.CveEmpleado);
            if(supleAutomatico)
                oCmd.Parameters.AddWithValue("@sup", "1");
            else
                oCmd.Parameters.AddWithValue("@sup", "0");
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

        public BaseEmpleados ObtenerAsignacionesManuales()
        {
            SqlConnection oCon = new SqlConnection(cadena);
            SqlCommand oCmd = new SqlCommand("dbo.getAsignacionesManuales", oCon);
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            BaseEmpleados lst = null;
            BaseEmpleado emp = null;
            try
            {
                oCon.Open();
                dr = oCmd.ExecuteReader();
                lst = new BaseEmpleados();
                while (dr.Read())
                {
                    emp = new BaseEmpleado();
                    emp.IDGral = Convert.ToInt32(dr["id"]);
                    emp.CveEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                    emp.Inicio = Convert.ToDateTime(dr["inicio"]);
                    emp.Fin = Convert.ToDateTime(dr["fin"]);
                    emp.IdUR = Convert.ToInt32(dr["ur"]);
                    emp.IdArea = Convert.ToInt32(dr["area"]);
                    emp.IdCentroTrabajo = Convert.ToInt32(dr["ct"]);
                    emp.IdEstado = Convert.ToInt32(dr["edo"]);
                    emp.IdMunicipio = Convert.ToInt32(dr["mun"]);
                    emp.Anio = Convert.ToInt32(dr["anio"]);
                    emp.IdPadre = Convert.ToInt32(dr["idpadre"]);
                    emp.SupleAsignacion = Convert.ToInt32(dr["suple"]);
                    emp.Paterno = dr["ApellidoPaterno"].ToString();
                    emp.Materno = dr["ApellidoMaterno"].ToString();
                    emp.Nombre = dr["Nombre"].ToString();
                    emp.UnidadResponsable = dr["UnidadResponsable"].ToString();
                    emp.Area = dr["Area"].ToString();
                    emp.CentroDeTrabajo = dr["CentroDeTrabajo"].ToString();
                    emp.Municipio = dr["Municipio"].ToString();
                    lst.Add(emp);
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
    }
}