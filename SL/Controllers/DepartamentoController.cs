﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ML;
using BL;
namespace SL.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET: api/Departamento
        [HttpGet]
        [Route("api/Departamento")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Departamento.GetAllDepartamento();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Departamento/5
        [HttpGet]
        [Route("api/Departamento/{IdDepartamento}")]
        public IHttpActionResult GetById(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.GetByDepartamento(IdDepartamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }    
        }

        // POST: api/Departamento
        [HttpPost]
        [Route("api/Departamento")]
        public IHttpActionResult Create([FromBody]ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddDepartamento(departamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Departamento/5
        [HttpPut]
        [Route("api/Departamento/{IdDepartamento}")]
        public IHttpActionResult Update(int IdDepartamento, [FromBody]ML.Departamento departamento)
        {
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.UpdateDepartamento(departamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Departamento/5
        [HttpDelete]
        [Route("api/Departamento/{IdDepartamento}")]
        public IHttpActionResult Delete(int IdDepartamento, [FromBody]ML.Departamento departamento)
        {
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.DeleteDepartamento(departamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}