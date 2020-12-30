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
    public class Venta
    {
        public static ML.Result AddVenta(ML.Venta venta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "AddVenta";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                        cmd.Parameters.AddWithValue("@Total", venta.Total);
                        cmd.Parameters.AddWithValue("@IdMetodoPago", venta.IdMetodoPago);
                        cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
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

        public static ML.Result DeleteVenta(ML.Venta venta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "DeleteVenta";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdVenta", venta.IdVenta);
                        int rows = cmd.ExecuteNonQuery();
                        if(rows > 0)
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
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido";
            }
            return result;
        }

        public static ML.Result GetAllVenta()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "GetAllVenta";
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.Venta venta = new ML.Venta();
                                venta.IdVenta = int.Parse(row[0].ToString());
                                venta.Cliente = row[1].ToString();
                                venta.Total = float.Parse(row[2].ToString());
                                venta.MetodoPago = row[3].ToString();
                                venta.Fecha = Convert.ToDateTime(row[4]);
                                result.Objects.Add(venta);
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
