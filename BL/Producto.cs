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
    public class Producto
    {
        public static ML.Result AddProducto(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "AddProducto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                        cmd.Parameters.AddWithValue("@IdDepartamento", producto.Departamento.IdDepartamento);
                        cmd.Parameters.AddWithValue("@IdProveedor", producto.Proveedor.IdProveedor);
                        cmd.Parameters.AddWithValue("@Image", Convert.FromBase64String(producto.Image));
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
            }catch(Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = "Error desconocido " + e;
            }
            return result;
        }

        public static ML.Result DeleteProducto(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "DeleteProducto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
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

        public static ML.Result UpdateProducto(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand("", context))
                    {
                        cmd.Connection.Open();
                        cmd.CommandText = "UpdateProducto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@Precio",  producto.Precio);
                        cmd.Parameters.AddWithValue("@IdDepartamento", producto.Departamento.IdDepartamento);
                        cmd.Parameters.AddWithValue("@IdProveedor", producto.Proveedor.IdProveedor);
                        cmd.Parameters.AddWithValue("@Image", Convert.FromBase64String(producto.Image));
                        cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo modificar el producto";
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

        public static ML.Result GetAllProducto()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL_SQL_client.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "GetAllProducto";
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.Descripcion = row[2].ToString();
                                producto.Precio = decimal.Parse(row[3].ToString());
                                //cambio a strings
                                //producto.IdDepartamento = int.Parse(row[4].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.Nombre = row[4].ToString();
                                //producto.IdProveedor = int.Parse(row[5].ToString());
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.Nombre = row[5].ToString();
                                producto.Image = row[6].ToString();
                                result.Objects.Add(producto);
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
                    var p = context.JFernandezProductos.ToList();
                    result.Objects = new List<object>();
                    if (p != null)
                    {
                        foreach (var item in p)
                        {
                            ML.Producto product = new ML.Producto();
                            product.IdProducto = item.IdProducto;
                            product.Nombre = item.Nombre;
                            product.Descripcion = item.Descripcion;
                            product.Precio = (int)item.Precio;
                            product.Departamento = new ML.Departamento();
                            product.Departamento.Nombre = item.JFernandezDepartamento.NombreD;
                            product.Proveedor = new ML.Proveedor();
                            product.Proveedor.Nombre = item.JFernandezProveedor.NombreProveedor;
                            product.Image = "No disponible";
                            result.Objects.Add(product);
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

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.AddProducto(producto.Nombre, producto.Descripcion, (decimal) producto.Precio, (int)producto.Departamento.IdDepartamento, (int)producto.Proveedor.IdProveedor, Convert.FromBase64String(producto.Image));
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

        public static ML.Result DeleteEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.DeleteProducto(producto.IdProducto);
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

        public static Result GetByIdEF(int IdProducto)
        {
            Result resultado = new Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new EF.JFernandezEcommerceEntities())
                {
                    var result = (from a in context.GetByIdEF_Producto(IdProducto) select a).FirstOrDefault();

                    if (result != null)
                    {
                        ML.Producto product = new ML.Producto();
                        product.IdProducto = result.IdProducto;
                        product.Nombre = result.Nombre;
                        product.Descripcion = result.Descripcion;
                        product.Precio = (decimal)result.Precio;
                        product.Departamento = new ML.Departamento();
                        product.Departamento.IdDepartamento = (int)result.IdDepartamento;
                        product.Proveedor = new ML.Proveedor();
                        product.Proveedor.IdProveedor = (int)result.IdProveedor;
                        //falta la imagen
                        resultado.Object = product;
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (EF.JFernandezEcommerceEntities context = new JFernandezEcommerceEntities())
                {
                    var query = context.UpdateProducto(producto.Nombre, producto.Descripcion, (decimal)producto.Precio, (int)producto.Departamento.IdDepartamento, (int)producto.Proveedor.IdProveedor, Convert.FromBase64String(producto.Image), (int)producto.IdProducto);
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
