using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace BL
{
    public class MetodoPago
    {
        public static ML.Result AddMetodo(ML.MetodoPago metodopago)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "AddMetodoPago";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Metodo", metodopago.Metodo);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Upps";
                        }
                    }
                }
            } catch (Exception e)
            {
                result.ErrorMessage = "Error desconocido " + e;
                result.Correct = false;
            }
            return result;
        }
    
        public static ML.Result DeleteMetodoPago(ML.MetodoPago metodopago)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "DeleteMetodoPago";
                        cmd.CommandType = CommandType.StoredProcedure;
                        int rows = cmd.ExecuteNonQuery();
                        if(rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al eliminar";
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

        public static ML.Result UpdateMetodoPago(ML.MetodoPago metodopago)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "UpdateMetodoPago";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Metodo", metodopago.Metodo);
                        cmd.Parameters.AddWithValue("@IdMetodoProducto", metodopago.IdMetodoPago);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo modificar el metodo";
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

        public static ML.Result GetAllMetodoPago()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "GetAllMetodoPago";
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.MetodoPago metodo = new ML.MetodoPago();
                                metodo.IdMetodoPago = int.Parse(row[0].ToString());
                                metodo.Metodo = row[1].ToString();
                                result.Objects.Add(metodo);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "upps";
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

    }

}
