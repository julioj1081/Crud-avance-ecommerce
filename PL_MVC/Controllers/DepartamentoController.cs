using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ML;
namespace PL_MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento agregar drop en area
        public ActionResult GetAllDepartamento()
        {
            ML.Result result = BL.Departamento.GetAllEF();
            ML.Departamento d = new ML.Departamento();
            d.Departamentos = result.Objects;
            return View(d);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            new ML.Departamento();
            return View();
        }

        [HttpPost]
        public ActionResult Registro(ML.Departamento departamento)
        {
            var result = BL.Departamento.AddEF(departamento);
            ML.Departamento d = new ML.Departamento();
            if (result.Correct)
            {
                ViewBag.Message = "El departamento se agrego correctamente ";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "No se pudo agregar correctamente el departamento";
                return PartialView("validacion");
            }
        }


        [HttpGet]
        public ActionResult Delete (ML.Departamento departamento)
        {
            departamento.IdDepartamento = Convert.ToInt32(departamento.IdDepartamento);
            var result = BL.Departamento.DeleteEF(departamento);
            return RedirectToAction("GetAllDepartamento");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            int asig = Convert.ToInt32(Id);
            var result = BL.Departamento.GetByIdEF(asig);

            if (result.Object != null)
            {

                ML.Departamento depa = new ML.Departamento();

                depa.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
                depa.Nombre = ((ML.Departamento)result.Object).Nombre;
                depa.Area = new ML.Area();
                depa.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;

                return View(depa);
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
                return PartialView("validacion");
            }
        }
    
        [HttpPost]
        public ActionResult Actualizar(Departamento departamento)
        {
            var result = BL.Departamento.UpdateEF(departamento);

            if (result.Correct)
            {
                ViewBag.Message = "El departamento se actualizo correctamente";
                return PartialView("validacion");
            }
            else
            {
                ViewBag.Message = "El departamento no se ha podido actualizar ";
                return PartialView("validacion");
            }
        }
    }
}