using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaProductoController : Controller
    {
        // GET: VentaProducto
        public ActionResult GetAllVentaProducto()
        {
            ML.Result result = BL.VentaProducto.GetAllEF();
            ML.VentaProducto v = new ML.VentaProducto();
            v.VentaProductos = result.Objects;
            return View(v);
        }
        [HttpGet]
        public ActionResult Add()
        {
            new ML.VentaProducto();
            return View();
        }

        [HttpPost]
        public ActionResult Registro(ML.VentaProducto VentaProducto)
        {
            var result = BL.VentaProducto.AddEF(VentaProducto);
            ML.VentaProducto v = new ML.VentaProducto();
            if (result.Correct)
            {
                ViewBag.Message = "Se agrego correctamente la venta producto ";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "No se pudo agregar correctamente la venta producto";
                return PartialView("validacion");
            }
        }
    }
}