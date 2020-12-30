using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EF;
using ML;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
                        cmd.Parameters.AddWithValue("@NombreD", departamento.NombreD);
                        cmd.Parameters.AddWithValue("@IdArea", departamento.IdArea);
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

        public static ML.Result DeleteDepartamento(ML.Departamento departamento)
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
                        cmd.Parameters.AddWithValue("@NombreD", departamento.NombreD);
                        cmd.Parameters.AddWithValue("@IdArea", departamento.IdArea);
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
                                departamento.NombreD = row[1].ToString();
                                //departamento.IdArea = int.Parse(row[2].ToString());
                                departamento.Are = row[2].ToString();
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












        //Con ENTITY
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var p = context.JFernandezDepartamento.ToList();
                    result.Objects = new List<object>();
                    if(p != null)
                    {
                        foreach(var item in p)
                        {
                            ML.Departamento depa = new ML.Departamento();
                            depa.IdDepartamento = item.IdDepartamento;
                            depa.NombreD = item.NombreD;
                            depa.IdArea = (int)item.IdArea;
                            result.Objects.Add(depa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" +e;
            }
            return result;
        }
        
        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.AddDepartamento(departamento.NombreD,(int) departamento.IdArea);
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" + e;
            }
            return result;
        }
    
        public static ML.Result DeleteEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities()) {
                    var query = context.DeleteDepartamento(departamento.IdDepartamento);
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" + e;
            }
            return result;
        }
   
        public static Result GetByIdEF(int IdDepartamento)
        {
            Result resultado = new Result();
            try
            {
                using(EF.JFernandezEcommerceEntities context = new EF.JFernandezEcommerceEntities())
                {
                    var result = (from a in context.GetByIdEF(IdDepartamento) select a).FirstOrDefault();

                    if (result != null)
                    {
                        ML.Departamento depa = new ML.Departamento();
                        depa.IdDepartamento = result.IdDepartamento;
                        depa.NombreD = result.NombreD;
                        depa.IdArea = Convert.ToInt32(result.IdArea);
                        resultado.Object = depa;
                    }
                    resultado.Correct = true;
                }
            }catch(Exception e)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = "Error desconocido" + e;
            }
            return resultado;
        }

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            //produc.idProducto = idproducto;
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.UpdateDepartamento(departamento.NombreD, departamento.IdArea, departamento.IdDepartamento);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error desconocido";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" + e.Message;

            }
            return result;
        }



    }
}
