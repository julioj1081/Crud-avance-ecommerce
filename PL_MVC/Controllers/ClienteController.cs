using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ML;
namespace PL_MVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult GetAllCliente()
        {
            ML.Result result = BL.Cliente.GetAllEF();
            ML.Cliente c = new ML.Cliente();
            c.Clientes = result.Objects;
            return View(c);
        }

        //regresa plantilla
        [HttpGet]
        public ActionResult Add()
        {
            new ML.Cliente();
            return View();
        }
        //regresa datos
        [HttpPost]
        public ActionResult Registro(ML.Cliente cliente)
        {
            var result = BL.Cliente.AddEF(cliente);
            ML.Cliente d = new ML.Cliente();
            if (result.Correct)
            {
                ViewBag.Message = "El Cliente se agrego correctamente ";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "No se pudo agregar correctamente el Cliente";
                return PartialView("validacion");
            }
        }
   
        [HttpGet]
        public ActionResult Delete (ML.Cliente cliente)
        {
            cliente.IdCliente = Convert.ToInt32(cliente.IdCliente);
            var result = BL.Cliente.DeleteEF(cliente);
            return RedirectToAction("GetAllCliente");
        }

        //Trae plantilla con datos
        [HttpGet]
        public ActionResult Update(int Id)
        {
            int asig = Convert.ToInt32(Id);
            var result = BL.Cliente.GetByIdEF(asig);
            if (result.Object != null)
            {
                ML.Cliente client = new ML.Cliente();
                client.IdCliente = ((ML.Cliente)result.Object).IdCliente;
                client.NombreC = ((ML.Cliente)result.Object).NombreC;
                client.Rfc = ((ML.Cliente)result.Object).Rfc;
                return View(client);
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
                return PartialView("validacion");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(Cliente cliente)
        {
            var result = BL.Cliente.UpdateEF(cliente);

            if (result.Correct)
            {
                ViewBag.Message = "El Cliente se actualizo correctamente";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "El Cliente no se ha podido actualizar ";
                return PartialView("validacion");
            }
        }


    }
}