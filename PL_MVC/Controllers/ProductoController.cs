using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ML;
namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAllProducto()
        {
            ML.Result result = BL.Producto.GetAllEF();
            ML.Producto p = new ML.Producto();
            p.Productos = result.Objects;
            return View(p);
        }

        [HttpGet]
        public ActionResult Add()
        {
            new ML.Producto();
            return View();
        }

        [HttpPost]
        public ActionResult Registro(ML.Producto producto)
        {
            producto.Image = "No disponible";
            var result = BL.Producto.AddEF(producto);
            ML.Producto d = new ML.Producto();
            if (result.Correct)
            {
                ViewBag.Message = "El producto se agrego correctamente ";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "No se pudo agregar correctamente el producto";
                return PartialView("validacion");
            }
        }

        [HttpGet]
        public ActionResult Delete(ML.Producto producto)
        {
            producto.IdProducto = Convert.ToInt32(producto.IdProducto);
            var result = BL.Producto.DeleteEF(producto);
            return RedirectToAction("GetAllProducto");
        }

        //trae plantilla con datos
        [HttpGet]
        public ActionResult Update(int Id)
        {
            int asig = Convert.ToInt32(Id);
            var result = BL.Producto.GetByIdEF(asig);

            if (result.Object != null)
            {

                ML.Producto product = new ML.Producto();

                product.IdProducto = ((ML.Producto)result.Object).IdProducto;
                product.Nombre = ((ML.Producto)result.Object).Nombre;
                product.Descripcion = ((ML.Producto)result.Object).Descripcion;
                product.Precio = ((ML.Producto)result.Object).Precio;
                product.IdDepartamento = ((ML.Producto)result.Object).IdDepartamento;
                product.IdProveedor = ((ML.Producto)result.Object).IdProveedor;
                //product.Image = ((ML.Producto)result.Object).Image;

                return View(product);
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
                return PartialView("validacion");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(Producto producto)
        {
            producto.Image = "No disponible";
            var result = BL.Producto.UpdateEF(producto);

            if (result.Correct)
            {
                ViewBag.Message = "El producto se actualizo correctamente";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "El producto no se ha podido actualizar ";
                return PartialView("validacion");
            }
        }
    }
}