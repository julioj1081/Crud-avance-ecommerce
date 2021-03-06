﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ML;
namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto agregar el dropdown en cascada area -> departamento y proveedor | 
        [HttpGet]
        public ActionResult GetAllProducto()
        {
            ML.Result result = BL.Producto.GetAllProducto();
            ML.Producto producto = new ML.Producto();
            producto.Productos = result.Objects;

            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)//Add, Update
        {
            ML.Producto producto = new ML.Producto();
            
            //Areas Combobox
            ML.Result resultAreas = BL.Area.GetAllArea();
            producto.Area = new ML.Area();
            producto.Area.Areas = resultAreas.Objects;

            //Departamentos
            ML.Result resultDepartamentos = BL.Departamento.GetAllDepartamento();
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Departamentos = resultDepartamentos.Objects;

            //Proveedor
            ML.Result resultProveedor = BL.Proveedor.GetAllProveedor();
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.Proveedores = resultProveedor.Objects;
            
            if (IdProducto == null) //Add
            {
                return View(producto);
            }
            else
            {
                ML.Result result = BL.Producto.GetByIdProducto(IdProducto.Value);
                if (result.Correct)
                {
                    producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                    producto.Nombre = ((ML.Producto)result.Object).Nombre;
                    producto.Descripcion = ((ML.Producto)result.Object).Descripcion;
                    producto.Precio = ((ML.Producto)result.Object).Precio;

                    //producto.Area = new ML.Area();
                    producto.Area.IdArea = int.Parse("0");

                    //producto.Departamento = new ML.Departamento();
                    producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;

                    //producto.Proveedor = new ML.Proveedor();
                    producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                    //producto.Image = ((ML.Producto)result.Object).Image;
                    return View(producto);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("validacion");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            if(producto.IdProducto == 0) //Add
            {
                producto.Image = "No disponible";
                result = BL.Producto.AddProducto(producto);
                ViewBag.Message = "El producto se agrego correctamente";
            }
            else //Update
            {
                producto.Image = "No disponible";
                result = BL.Producto.UpdateProducto(producto);
                ViewBag.Message = "El producto se modifico correctamente";
            }
            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente: "+ result.ErrorMessage;
            }
            return PartialView("validacion");
        }

        //[HttpGet]
        //public ActionResult Add()
        //{
        //    new ML.Producto();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Registro(ML.Producto producto)
        //{
        //    producto.Image = "No disponible";
        //    var result = BL.Producto.AddEF(producto);
        //    ML.Producto d = new ML.Producto();
        //    if (result.Correct)
        //    {
        //        ViewBag.Message = "El producto se agrego correctamente ";
        //        return PartialView("validacion");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "No se pudo agregar correctamente el producto";
        //        return PartialView("validacion");
        //    }
        //}

        [HttpGet]
        public ActionResult Delete(ML.Producto producto)
        {
            producto.IdProducto = Convert.ToInt32(producto.IdProducto);
            var result = BL.Producto.DeleteProducto(producto);
            return RedirectToAction("GetAllProducto");
        }

       


        ////trae plantilla con datos
        //[HttpGet]
        //public ActionResult Update(int Id)
        //{
        //    int asig = Convert.ToInt32(Id);
        //    var result = BL.Producto.GetByIdEF(asig);

        //    if (result.Object != null)
        //    {

        //        ML.Producto product = new ML.Producto();

        //        product.IdProducto = ((ML.Producto)result.Object).IdProducto;
        //        product.Nombre = ((ML.Producto)result.Object).Nombre;
        //        product.Descripcion = ((ML.Producto)result.Object).Descripcion;
        //        product.Precio = ((ML.Producto)result.Object).Precio;
                
        //        product.Departamento = new Departamento();
        //        product.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                
        //        product.Proveedor = new ML.Proveedor();
        //        product.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
        //        //product.Image = ((ML.Producto)result.Object).Image;

        //        return View(product);
        //    }
        //    else
        //    {
        //        ViewBag.Message = result.ErrorMessage;
        //        return PartialView("validacion");
        //    }
        //}

        //[HttpPost]
        //public ActionResult Actualizar(Producto producto)
        //{
        //    producto.Image = "No disponible";
        //    var result = BL.Producto.UpdateEF(producto);

        //    if (result.Correct)
        //    {
        //        ViewBag.Message = "El producto se actualizo correctamente";
        //        return PartialView("validacion");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "El producto no se ha podido actualizar ";
        //        return PartialView("validacion");
        //    }
        //}
    }
}