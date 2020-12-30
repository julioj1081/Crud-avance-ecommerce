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
    public class Cliente
    {

        //Consola
        public static ML.Result AddCliente(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "AddCliente";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreC", cliente.NombreC);
                        cmd.Parameters.AddWithValue("@Rfc", cliente.Rfc);
                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Hubo un error";
                        }
                    }
                }
            }
            catch (Exception e) { result.Correct = true; result.ErrorMessage = "Error desconocido" + e; }
            return result;
        }

        public static ML.Result DeleteCliente(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "DeleteCliente";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
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
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido" + e;
            }
            return result;
        }

        public static ML.Result UpdateCliente(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "UpdateCliente";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreC", cliente.NombreC);
                        cmd.Parameters.AddWithValue("@Rfc", cliente.Rfc);
                        cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo modificar el cliente";
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

        public static ML.Result GetAllCliente()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "GetAllCliente";
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.Cliente cliente = new ML.Cliente();
                                cliente.IdCliente = int.Parse(row[0].ToString());
                                cliente.NombreC = row[1].ToString();
                                cliente.Rfc = row[2].ToString();
                                result.Objects.Add(cliente);
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



        //Con ENTITY
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var p = context.JFernandezCliente.ToList();
                    result.Objects = new List<object>();
                    if (p != null)
                    {
                        foreach (var item in p)
                        {
                            ML.Cliente client = new ML.Cliente();
                            client.IdCliente= item.IdCliente;
                            client.NombreC = item.NombreC;
                            client.Rfc = item.Rfc;
                            result.Objects.Add(client);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result AddEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.AddCliente(cliente.NombreC, cliente.Rfc);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result DeleteEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.DeleteCliente(cliente.IdCliente);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static Result GetByIdEF(int IdCliente)
        {
            Result resultado = new Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new EF.JFernandezEcommerceEntities())
                {
                    var result = (from a in context.GetByIdEF_Cliente(IdCliente) select a).FirstOrDefault();

                    if (result != null)
                    {
                        ML.Cliente client = new ML.Cliente();
                        client.IdCliente = result.IdCliente;
                        client.NombreC = result.NombreC;
                        client.Rfc = result.Rfc;
                        resultado.Object = client;
                    }
                    resultado.Correct = true;
                }
            }
            catch (Exception e)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = "Error desconocido" + e;
            }
            return resultado;
        }

        public static ML.Result UpdateEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.UpdateCliente(cliente.NombreC, cliente.Rfc, cliente.IdCliente);
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
