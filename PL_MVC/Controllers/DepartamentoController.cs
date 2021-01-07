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
        [HttpGet]
        public ActionResult GetAllDepartamento()
        {
            ML.Result result = BL.Departamento.GetAllEF();
            ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = result.Objects;
            return View(departamento);
        }
        
        [HttpGet] //Muestra el formulario
        public ActionResult Form (int? IdDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();
            if(IdDepartamento == null)//Add
            {
                return View(departamento);
            }
            else//Update
            {
                ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento.Value);
                if (result.Correct)
                {
                    departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
                    departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
                    departamento.Area = new ML.Area();
                    departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;
                    return View(departamento);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("validacion");
                }
            }
        }

        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            if(departamento.IdDepartamento == 0) //agrega
            {
                result = BL.Departamento.AddDepartamento(departamento);
                ViewBag.Message = "El departamento se agrego correctamente";
            }
            else
            {
                result = BL.Departamento.UpdateDepartamento(departamento);
                ViewBag.Message = "El departamento se modifico correctamente";
            }
            //si es incorrecto
            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar el departamento";
            }
            return PartialView("validacion");
        }

        //[HttpPost]
        //public ActionResult Registro(ML.Departamento departamento)
        //{
        //    var result = BL.Departamento.AddEF(departamento);
        //    ML.Departamento d = new ML.Departamento();
        //    if (result.Correct)
        //    {
        //        ViewBag.Message = "El departamento se agrego correctamente ";
        //        return PartialView("validacion");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "No se pudo agregar correctamente el departamento";
        //        return PartialView("validacion");
        //    }
        //}


        [HttpGet]
        public ActionResult Delete (ML.Departamento departamento)
        {
            departamento.IdDepartamento = Convert.ToInt32(departamento.IdDepartamento);
            var result = BL.Departamento.DeleteEF(departamento);
            return RedirectToAction("GetAllDepartamento");
        }

        //[HttpGet]
        //public ActionResult Update(int Id)
        //{
        //    int asig = Convert.ToInt32(Id);
        //    var result = BL.Departamento.GetByIdEF(asig);

        //    if (result.Object != null)
        //    {

        //        ML.Departamento depa = new ML.Departamento();

        //        depa.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
        //        depa.Nombre = ((ML.Departamento)result.Object).Nombre;
        //        depa.Area = new ML.Area();
        //        depa.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;

        //        return View(depa);
        //    }
        //    else
        //    {
        //        ViewBag.Message = result.ErrorMessage;
        //        return PartialView("validacion");
        //    }
        //}
    
        //[HttpPost]
        //public ActionResult Actualizar(Departamento departamento)
        //{
        //    var result = BL.Departamento.UpdateEF(departamento);

        //    if (result.Correct)
        //    {
        //        ViewBag.Message = "El departamento se actualizo correctamente";
        //        return PartialView("validacion");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "El departamento no se ha podido actualizar ";
        //        return PartialView("validacion");
        //    }
        //}
    }
}