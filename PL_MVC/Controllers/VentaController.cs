using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ML;
namespace PL_MVC.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult GetAllVenta()
        {
            ML.Result result = BL.Venta.GetAllEF();
            ML.Venta v = new ML.Venta();
            v.Ventas = result.Objects;
            return View(v);
        }

        [HttpGet]
        public ActionResult Add()
        {
            new ML.Venta();
            return View();
        }

        [HttpPost]
        public ActionResult Registro(ML.Venta venta)
        {
            var result = BL.Venta.AddEF(venta);
            ML.Venta v = new ML.Venta();
            if (result.Correct)
            {
                ViewBag.Message = "La venta se agrego correctamente ";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "No se pudo agregar correctamente la venta";
                return PartialView("validacion");
            }
        }
        [HttpGet]
        public ActionResult Delete(ML.Venta venta)
        {
            venta.IdVenta = Convert.ToInt32(venta.IdVenta);
            var result = BL.Venta.DeleteEF(venta);
            return RedirectToAction("GetAllVenta");
        }
    }
}