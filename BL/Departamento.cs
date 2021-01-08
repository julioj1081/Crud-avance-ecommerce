using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL_SQL_client;
using ML;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EF;

namespace BL
{
    public class Departamento
    {
        //Con ADO Stored y class conexion
        public static ML.Result AddDepartamento(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "AddDepartamento";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                        cmd.Parameters.AddWithValue("@IdArea", departamento.Area.IdArea);
                        int rows = cmd.ExecuteNonQuery();
                        if(rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo agregar el departamento";
                        }
                    }
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido " + e;
            }
            return result;
        }
        //ML.Departamento 
        public static ML.Result DeleteDepartamento(int departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "DeleteDepartamento";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdDepartamento", departamento);
                        int rows = cmd.ExecuteNonQuery();
                        if(rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El departamento no se pudo eliminar";
                        }
                        cmd.Connection.Close();
                    }
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" + e;
            }
            return result;
        }

        public static ML.Result UpdateDepartamento(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "UpdateDepartamento";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                        cmd.Parameters.AddWithValue("@IdArea", departamento.Area.IdArea);
                        cmd.Parameters.AddWithValue("@IdDepartamento", departamento.IdDepartamento);
                        int rows = cmd.ExecuteNonQuery();
                        if(rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El departamento no se pudo modificar";
                        }
                        cmd.Connection.Close();
                    }
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido " + e;
            }
            return result;
        }

        public static ML.Result GetAllDepartamento()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "GetAllDepartamento";
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                //departamento.IdArea = int.Parse(row[2].ToString());
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());
                                departamento.Area.Nombre = row[3].ToString();

                                result.Objects.Add(departamento);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Upps";
                        }

                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" + e;
            }
            return result;


        }

        public static ML.Result GetByDepartamento(int IdDepartamento)
        {
            Result result = new Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    string query = "Select [IdDepartamento], [Nombre], [IdArea] from JFernandezDepartamento WHERE IdDepartamento=" + IdDepartamento;
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection.Open();
                        DataTable departamentos = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(query, context);
                        da.Fill(departamentos);
                        if (departamentos.Rows.Count > 0)
                        {
                            DataRow row = departamentos.Rows[0];

                            ML.Departamento depa = new ML.Departamento();
                            depa.IdDepartamento = int.Parse(row[0].ToString());
                            depa.Nombre = row[1].ToString();
                            depa.Area = new ML.Area();
                            depa.Area.Nombre = row[2].ToString();
                            //
                            result.Object = depa;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                        /////

                    }
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error " + e;
            }
            return result;
        }











        //Con ENTITY
        //public static ML.Result GetAllEF()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using(EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
        //        {
        //            var p = context.JFernandezDepartamento.ToList();
        //            result.Objects = new List<object>();
        //            if(p != null)
        //            {
        //                foreach(var item in p)
        //                {
        //                    ML.Departamento depa = new ML.Departamento();
        //                    depa.IdDepartamento = item.IdDepartamento;
        //                    depa.Nombre = item.NombreD;
        //                    //depa.IdArea = (int)item.IdArea;
        //                    depa.Area = new ML.Area();
        //                    depa.Area.Nombre = item.JFernandezArea.NombreA;
        //                    result.Objects.Add(depa);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }

        //    }catch(Exception e)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = "Error desconocido" +e;
        //    }
        //    return result;
        //}
        
        //public static ML.Result AddEF(ML.Departamento departamento)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using(EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
        //        {
        //            var query = context.AddDepartamento(departamento.Nombre,(int) departamento.Area.IdArea);
        //            if(query >= 1)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }catch(Exception e)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = "Error desconocido" + e;
        //    }
        //    return result;
        //}
    
        //public static ML.Result DeleteEF(ML.Departamento departamento)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities()) {
        //            var query = context.DeleteDepartamento(departamento.IdDepartamento);
        //            if(query >= 1)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }
        //        }
        //    }catch(Exception e)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = "Error desconocido" + e;
        //    }
        //    return result;
        //}
   
        //public static Result GetByIdEF(int IdDepartamento)
        //{
        //    Result resultado = new Result();
        //    try
        //    {
        //        using(EF.JFernandezEcommerceEntities context = new EF.JFernandezEcommerceEntities())
        //        {
        //            var result = (from a in context.GetByIdEF_Departamento(IdDepartamento) select a).FirstOrDefault();

        //            if (result != null)
        //            {
        //                ML.Departamento depa = new ML.Departamento();
        //                depa.IdDepartamento = result.IdDepartamento;
        //                depa.Nombre = result.NombreD;
        //                depa.Area = new ML.Area();
        //                depa.Area.IdArea = Convert.ToInt32(result.IdArea);
        //                resultado.Object = depa;
        //            }
        //            resultado.Correct = true;
        //        }
        //    }catch(Exception e)
        //    {
        //        resultado.Correct = false;
        //        resultado.ErrorMessage = "Error desconocido" + e;
        //    }
        //    return resultado;
        //}

        //public static ML.Result UpdateEF(ML.Departamento departamento)
        //{
        //    //produc.idProducto = idproducto;
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
        //        {
        //            var query = context.UpdateDepartamento(departamento.Nombre, departamento.Area.IdArea, departamento.IdDepartamento);
        //            if (query >= 1)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error desconocido";
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = "Error desconocido" + e.Message;

        //    }
        //    return result;
        //}



    }
}
