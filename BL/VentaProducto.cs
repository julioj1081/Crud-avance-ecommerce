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
    public class VentaProducto
    {
        //Con SP
        public static ML.Result GetAllVentaProducto()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "GetAllVentaProducto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.VentaProducto VentaProducto = new ML.VentaProducto();
                                VentaProducto.IdVentaProducto = int.Parse(row[0].ToString());
                                //VentaProducto.IdVenta = int.Parse(row[1].ToString());
                                VentaProducto.Venta = row[1].ToString();
                                //VentaProducto.IdProductoSucursal = int.Parse(row[2].ToString());
                                VentaProducto.ProductoSucursal = row[2].ToString();
                                VentaProducto.Cantidad = int.Parse(row[3].ToString());
                                VentaProducto.Producto = row[4].ToString();
                                //VentaProducto.IdProducto = int.Parse(row[4].ToString());
                                result.Objects.Add(VentaProducto);
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

        public static ML.Result AddVentaProducto(ML.VentaProducto ventaProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "AddVentaProducto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdVenta", ventaProducto.IdVenta);
                        cmd.Parameters.AddWithValue("@IdProductoSucursal", ventaProducto.IdProductoSucursal);
                        cmd.Parameters.AddWithValue("@Cantidad", ventaProducto.Cantidad);
                        cmd.Parameters.AddWithValue("@IdProducto", ventaProducto.IdProducto);
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


        //Con ENTITY
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var p = context.JFernandezVentaProducto.ToList();
                    result.Objects = new List<object>();
                    if (p != null)
                    {
                        foreach (var item in p)
                        {
                            ML.VentaProducto ventaProducto = new ML.VentaProducto();
                            ventaProducto.IdVentaProducto = item.IdVentaProducto;
                            ventaProducto.Venta = item.JFernandezVenta.JFernandezCliente.NombreC;
                            ventaProducto.ProductoSucursal = item.JFernandezProductoSucursal.JFernandezSucursal.NombreS;
                            ventaProducto.Cantidad = (int)item.Cantidad;
                            ventaProducto.Producto = item.JFernandezProductos.Nombre;
                            result.Objects.Add(ventaProducto);
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

        public static ML.Result AddEF(ML.VentaProducto ventaProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.AddVentaProducto(ventaProducto.IdVenta, ventaProducto.IdProductoSucursal, ventaProducto.Cantidad, ventaProducto.IdProducto);
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
                result.ErrorMessage = "Error desconocido " + e;
            }
            return result;
        }
    }
}
