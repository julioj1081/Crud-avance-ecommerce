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
    public class VentaProducto
    {
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

    }
}
